using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Migrations;
using DoctorWho.Web.DTO_s;
using DoctorWhoRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers;

[Route("api/doctors")] 
[ApiController]
public class DoctorController : Controller
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public DoctorController(IDoctorRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctors()
    {
        var doctors = await _repository.GetAllDoctorsAsync();
        if (doctors == null)
        {
            return NotFound("There are no Doctors");
        }

        return Ok(_mapper.Map<IEnumerable<DoctorDTO>>(doctors));
    }

    [HttpGet("{id}",Name = "GetDoctor")]
    public async Task<ActionResult<DoctorDTO>> GetDoctor(int id)
    {
       var doctor = await _repository.GetDoctorAsync(id);
       if (doctor == null)
       {
           return NotFound("Docotr Does not Exist.");
       }

       return Ok(_mapper.Map<DoctorDTO>(doctor));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DoctorDTO>> DeleteDoctor(int id)
    {
        var doctor = await _repository.GetDoctorWithEpisodes(id);
        
        if (doctor == null)
            return NotFound();
        
        if (await _repository.DeleteDoctorAsync(doctor) <= 0)
            return StatusCode(500, "Internal Server Error");
        
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> PostDoctor(int docID, DoctorDTO doctorDto)
    {
        if (await _repository.GetDoctorAsync(docID) != null)
        {
            return Conflict("The Doctor already exists.");
        }

        var doctor = _mapper.Map<Doctor>(doctorDto);
        doctor.DoctorId = docID;
        var saved = await _repository.CreateDoctorAsync(doctor);

        if (!saved)
        {
            return BadRequest();
        }
        
        return CreatedAtRoute("GetDoctor",
            new {id = docID},doctorDto);
    }
}