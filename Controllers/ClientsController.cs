using AutoMapper;
using CrudClientAPI.Context.Repositories;
using CrudClientAPI.Entities;
using CrudClientAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IClientRepository repository;

        public ClientsController(IMapper mapper, IClientRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = repository.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = repository.GetById(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public IActionResult Add(AddClientRequest request)
        {
            var client = mapper.Map<Client>(request);

            client.UpdateName(request.FirstName, request.LastName);
            
            repository.Add(client);

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, request);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, UpdateClientRequest request)
        {
            var client = repository.GetById(id);

            if (client == null)
                return NotFound();

            client.UpdateName(request.FirstName, request.LastName);
            client.UpdatePhoneNumber(request.PhoneNumber);
            client.UpdateBirth(request.BirthDate);

            repository.Update(client);

            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var client = repository.GetById(id);

            if (client == null)
                return NotFound();

            client.DeleteClient();

            repository.Update(client);

            return NoContent();
        }
    }
}