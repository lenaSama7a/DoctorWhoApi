using System.ComponentModel.DataAnnotations;

namespace DoctorWho.Web.Models
{
    public class DoctorForUpdateDto
    {
        [Required(ErrorMessage = " you should provide doctor Number")]
        public int DoctorNumber { get; set; }

        [Required(ErrorMessage = " you should provide a name value")]
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}
