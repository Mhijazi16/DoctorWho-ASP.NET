using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Migrations;
using DoctorWho.Web.DTO_s;
using DoctorWhoRepository;
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
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<DoctorDTO>>(doctors));
    }
}