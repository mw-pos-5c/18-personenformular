using Microsoft.AspNetCore.Mvc;

using Persons.DTOs;
using Persons.Services;

namespace Persons.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private PersonService service;

    public PersonController(PersonService service)
    {
        this.service = service;
    }

    [HttpGet()]
    public IActionResult GetAllPersons()
    {
        return Ok(service.GetAllPersons());
    }

    [HttpGet("{id}")]
    public IActionResult GetPerson(long id)
    {
        return Ok(service.GetPerson(id));
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] PersonDto dto)
    {
        return Ok(service.AddPerson(dto));
    }
}
