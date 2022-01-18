using System;
using System.Collections.Generic;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]s")]
[ApiController]
public class PersonController : ControllerBase {
    public static List<Person> persons = new List<Person>();
    PersonService _service;

    public PersonController(PersonService service) {
        _service = service;
    }

    // GET: /Persons
    [HttpGet]
    public IEnumerable<Person> Get() {
        return _service.GetAll();
    }

    // GET: /Persons/5
    [HttpGet("{id}")]
    public ActionResult<Person> Get(int id) {
        var person = _service.Get(id);

        if (person is not null) {
            return person;
        }
        else {
            return NotFound();
        }
    }

    // GET /Persons/color/{Color.color} or 
    // GET /Persons/color/3
    [HttpGet("Color/{color}")]
    public IEnumerable<Person> Get(Person.Color color) {
        return _service.GetByColor(color);
    }

    // POST /Persons content-type: application/json {JsonData}
    [HttpPost]
    public IActionResult Create([FromBody] Person newPerson) {
        var person = _service.Create(newPerson);
        return CreatedAtAction(nameof(Get), new {
            id = person!.Id
        }, person);
    }

    // PUT /Persons/3/updateColor?color=1 or
    // PUT /Persons/3/updateColor?color=rot
    [HttpPut("{id}/updateColor")]
    public IActionResult UpdateColor(int id, string color) {
        var PersonToUpdate = _service.Get(id);
        if (PersonToUpdate is not null) {
            int colorID;
            if (!int.TryParse(color, out colorID)) //try using param color as integer, else...
                colorID = (int)Enum.Parse(typeof(Person.Color), color); //use param color as string
            Person.Color newColor = (Person.Color)colorID;
            _service.UpdateColor(id, newColor);
            return NoContent();
        }
        else {
            return NotFound();
        }
    }

    // DELETE /Persons/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var person = _service.Get(id);

        if (person is not null) {
            _service.DeleteById(id);
            return Ok();
        }
        else {
            return NotFound();
        }
    }
}