using AutoMapper;
using CoreWebApiOrnek.BL.Concrete.EfCore.UnitOfWork;
using CoreWebApiOrnek.DTO.GroupDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoreWebApiOrnek.Entities.Concrete;
using System.Collections.Generic;

namespace CoreWebApiOrnek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GroupController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<List<DtoGroupList>>(await _uow.Groups.GetAllAsync()));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<DtoGroupList>(await _uow.Groups.GetByIdAsync(id)));
        }
        [HttpGet("[action]/{id}")]

        public async Task<IActionResult> GetByGroupID(int id)
        {
            return Ok(_mapper.Map<List<DtoGroupListWithExpenses>>(await _uow.Groups.GetGroupWithExpenses(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DtoGroupAdd dtoGroup)
        {
            _uow.Groups.Add(_mapper.Map<Group>(dtoGroup));
            await _uow.SaveChangesAsync();

            return Created("", dtoGroup);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DtoGroupUpdate dtoGroup)
        {
            var gr = await _uow.Groups.GetByIdAsync(dtoGroup.Id);
            if (gr == null)
            {
                return NotFound();
            }
            _mapper.Map(dtoGroup, gr);
            await _uow.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DtoGroupDelete dtoGroup)
        {
            var gr = await _uow.Groups.GetByIdAsync(dtoGroup.Id);
            if (gr == null)
            {
                return NotFound();
            }
            gr.IsActive = false;
            await _uow.SaveChangesAsync();
            return Ok();
        }  
    }
}