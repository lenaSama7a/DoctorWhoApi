# DoctorWhoApi
## Requirements

1. Create a solution named `DoctorWho` with a web application project named `DoctorWho.Web`.
2. Add `DoctorWho.Db` project from the EF core exercise to the solution and reference it from `DoctorWho.Web` project.

For each of the next APIs:
    - Separate DB entity models from outer facing models.
    - Setup `AutoMapper` profiles to map between these models.
    - Use `FluentValidation` to setup the necessary validation rules.
    - Handle all type of faults that can be thrown.
3. Create a controller for the doctors with a `Get` all doctors API.
4. Add `Upsert` API for the doctors, and make it return the upserted entity.
    - **DoctorNumber** and **DoctorName** are required.
    - **LastEpisodeDate** should has no value when **FirstEpisodeDate** has no value.
    - **LastEpisodeDate** should be greater than or equal to **FirstEpisodeDate**.
5. Add `Delete` API for the doctors.
6. Create a controller for the episodes with a `Get` all episodes API.
7. Add `Create` API for the episodes, and make it return the new entity id.
    - **AuthorId** and **DoctorId** are required.
    - **SeriesNumber** should be 10 characters long.
    - **EpisodeNumber** should be greater than 0.
8. Add `AddEnemyToEpisode` API.
9. Add `AddCompanionToEpisode` API.
10. Create a controller for the authors with an `Update` API for the authors.
11. Move DB connection string out of the DbContext to `AppSettings.json`.
