using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeriaController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PizzeriaController(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreatePizzeriaForMenu(Guid menuId, [FromBody] PizzeriaForCreationDto pizzeria)
        {
            if (pizzeria == null)
            {
                _logger.LogError("PizzeriaForCreationDto object sent from client is null.");
                return BadRequest("PizzeriaForCreationDto object is null");
            }
            var menu = _repository.Menu.GetMenu(menuId, trackChanges: false);
            if (menu == null)
            {
                _logger.LogInfo($"Menu with id: {menuId} doesn't exist in the database.");
                return NotFound();
            }
            var pizzeriaEntity = _mapper.Map<Pizzeria>(pizzeria);
            _repository.Pizzeria.CreatePizzeriaForMenu(menuId, pizzeriaEntity);
            _repository.Save();
            var pizzeriaToReturn = _mapper.Map<PizzeriaDto>(pizzeriaEntity);
            return CreatedAtRoute("GetPizzeriaForMenu", new
            {
                menuId,
                id = pizzeriaToReturn.Id
            }, pizzeriaToReturn);
        }
        [HttpGet("{id}")]
        public IActionResult GetPizzeriaForMenu(Guid menuId, Guid id)
        {
            var menu = _repository.Menu.GetMenu(menuId, trackChanges: false);
            if (menu == null)
            {
                _logger.LogInfo($"Menu with id: {menuId} doesn't exist in the database.");
                return NotFound();
            }
            var pizzeriaDb = _repository.Pizzeria.GetPizzeria(menuId, id,
           trackChanges:
            false);
            if (pizzeriaDb == null)
            {
                _logger.LogInfo($"Pizzeria with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var pizzeria = _mapper.Map<PizzeriaDto>(pizzeriaDb);
            return Ok(pizzeria);
        }
    }
}
