using AutoMapper;
using DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Web.Models;
using DoctorWho.Db.Entities;

namespace DoctorWho.Web.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository ??
                throw new ArgumentNullException(nameof(doctorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync(); // this is entity not dto
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctors)); //here to convert from entity to dto
        }

        [HttpDelete("{DoctorId}")]
        public async Task<ActionResult> DeleteDoctor(int DoctorId)
        {

            if (!await _doctorRepository.DoctorExists(DoctorId))
            {
                return NotFound();
            }

            await _doctorRepository.DeleteDoctorAsync(DoctorId);

            return NoContent();
        }
        [HttpGet("{DoctorId}", Name = "GetDoctor")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetPointOfInterest(int DoctorId)
        {
            if (!await _doctorRepository.DoctorExists(DoctorId))
            {
                return NotFound();
            }

            var doctor = await _doctorRepository.GetDoctorByIdAsync(DoctorId);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DoctorDto>(doctor));

        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctor( DoctorForCreationDto doctor)
        {
            var doctorToCreate = _mapper.Map<DoctorWho.Db.Entities.Doctor>(doctor); //from doctorForCreation to doctor

            await _doctorRepository.CreateDoctorAsync(doctorToCreate);
            var createdDoctorToReturn = _mapper.Map<Models.DoctorDto>(doctorToCreate);// doctor to doctorDto

            return CreatedAtRoute("GetDoctor",
                 new
                 {
                     doctorId = createdDoctorToReturn.DoctorId
                 },
                 createdDoctorToReturn);
        }

        [HttpPut("{doctorId}")]
        public async Task<ActionResult> UpdateDoctor(int doctorId, DoctorForUpdateDto doctor)
        {
            if (!await _doctorRepository.DoctorExists(doctorId))
            {
                return NotFound();
            }

            var doctorToUpdate = _mapper.Map<DoctorDto>(doctor);
            doctorToUpdate.DoctorId = doctorId;
            var doctorAfterUpdate = await _doctorRepository.UpdateDoctorAsync(_mapper.Map<Doctor>(doctorToUpdate));
            //return NoContent();

            return Ok(_mapper.Map<DoctorDto>(doctorAfterUpdate));
        }







    }
}
