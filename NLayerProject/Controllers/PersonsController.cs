using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Entities;
using NLayerProject.Core.Services;
using NLayerProject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;
        private readonly IMapper _mapper;
        public PersonsController(IService<Person> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _service.GetByIdAsync(id);

            return Ok(_mapper.Map<PersonDto>(person));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto person)
        {
            var savedPerson = await _service.AddAsync(_mapper.Map<Person>(person));

            return Created(String.Empty, _mapper.Map<PersonDto>(savedPerson));
        }

        [HttpPut]
        public IActionResult Update(PersonDto person)
        {
            var updatedPerson = _service.Update(_mapper.Map<Person>(person));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedPerson = _service.GetByIdAsync(id).Result;

            _service.Remove(_mapper.Map<Person>(deletedPerson));

            return NoContent();
        }

    }
}
