using Microsoft.AspNetCore.Mvc;
using moon_light_rest_api.Dtos;
using moon_light_rest_api.entities;
using moon_light_rest_api.Repositories;

namespace moon_light_rest_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentsController : ControllerBase
    {
        private readonly IParentRepository _repository;

        public ParentsController(IParentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parents = await _repository.GetAllAsync();
            return Ok(parents);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ParentCreateDto dto)
        {
            var parent = new Parent
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            await _repository.AddAsync(parent);
            return CreatedAtAction(nameof(GetAll), new { id = parent.Id }, parent);
        }
    }
}
