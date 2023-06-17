using AutoMapper;
using DoctorWho.Db;
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

}