using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/pizzerias")]
    [ApiController]
    public class PizzeriasController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PizzeriasController(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPizzerias()
        {
            var pizzerias = _repository.Pizzeria.GetAllPizzerias(trackChanges: false);
            var pizzeriasDto = _mapper.Map<IEnumerable<PizzeriaDto>>(pizzerias);
            return Ok(pizzeriasDto);
        }
    }
}
