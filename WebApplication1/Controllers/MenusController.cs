using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ModelBinders;

namespace WebApplication1.Controllers
{
    [Route("api/companies/{menuId}/employees")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MenusController(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMenu([FromBody] MenuForCreationDto menu)
        {
            if (menu == null)
            {
                _logger.LogError("MenuForCreationDto object sent from client is null.");
                return BadRequest("MenuForCreationDto object is null");
            }
            var menuEntity = _mapper.Map<Menu>(menu);
            _repository.Menu.CreateMenu(menuEntity);
            _repository.Save();
            var menuToReturn = _mapper.Map<Menu>(menu);
            return CreatedAtRoute("MenuById", new { id = menuToReturn.Id },
            menuToReturn);
        }

        [HttpGet("{id}", Name = "MenuById")]
        public IActionResult GetMenuCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var menuEntities = _repository.Menu.GetByIds(ids, trackChanges: false);

            if (ids.Count() != menuEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var menuToReturn =
           _mapper.Map<IEnumerable<MenuDto>>(menuEntities);
            return Ok(menuToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateMenuCollection([FromBody]
        IEnumerable<MenuForCreationDto> menuCollection)
        {
            if (menuCollection == null)
            {
                _logger.LogError("Menu collection sent from client is null.");
                return BadRequest("Menu collection is null");
            }
            var menuEntities = _mapper.Map<IEnumerable<Menu>>(menuCollection);
            foreach (var menu in menuEntities)
            {
                _repository.Menu.CreateMenu(menu);
            }
            _repository.Save();
            var menuCollectionToReturn =
            _mapper.Map<IEnumerable<MenuDto>>(menuEntities);
            var ids = string.Join(",", menuCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("MenuCollection", new { ids },
            menuCollectionToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            var menu = await _repository.Menu.GetAllmenuAsync(trackChanges: false);
            var menuDto = _mapper.Map<IEnumerable<MenuDto>>(menu);
            return Ok(menuDto);
        }

        [HttpGet("{id}", Name = "MenuById")]
        public async Task<IActionResult> GetMenu(Guid id)
        {
            var menu = await _repository.Menu.GetMenuAsync(id, trackChanges: false);

        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(Guid id)
        {
            var menu = _repository.Menu.GetMenu(id, trackChanges: false);

            if (menu == null)
            {
                _logger.LogInfo($"Menu with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            else
            {
                var menuDto = _mapper.Map<MenuDto>(menu);
                return Ok(menuDto);
            }
        }

            _repository.Menu.DeleteMenu(menu);
            _repository.Save();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMenu(Guid id, [FromBody] MenuForUpdateDto menu)
        {
            if (menu == null)
            {
                _logger.LogError("MenuForUpdateDto object sent from client is null.");
                return BadRequest("MenuForUpdateDto object is null");
            }
            var menuEntity = _repository.Menu.GetMenu(id, trackChanges: true);
            if (menuEntity == null)
            {
                _logger.LogInfo($"Menu with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(menu, menuEntity);
            _repository.Save();
            return NoContent();
        }


    }
}