using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreWebApiOrnek.BL.Concrete.EfCore.UnitOfWork;
using CoreWebApiOrnek.DTO.ExpenseDto;
using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiOrnek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ExpenseController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ExpenseController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<List<DtoExpenseList>>(await _uow.Expenses.GetAllAsync()));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<DtoExpenseList>(await _uow.Expenses.GetByIdAsync(id)));
        }
        [HttpGet("[action]/{id}")]

        public async Task<IActionResult> GetByGroupID(int id)
        {
            return Ok(_mapper.Map<DtoExpenseList>(await _uow.Expenses.GetAllAsync(ce=> ce.GroupId==id)));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DtoExpenseAdd dtoExpense)
        {
            _uow.Expenses.Add(_mapper.Map<Expense>(dtoExpense));
            await _uow.SaveChangesAsync();

            return Created("", dtoExpense);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DtoExpenseUpdate dtoExpense)
        {
            var gr = await _uow.Expenses.GetByIdAsync(dtoExpense.Id);
            if (gr == null)
            {
                return NotFound();
            }
            _mapper.Map(dtoExpense, gr);
            await _uow.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DtoExpenseDelete dtoExpense)
        {
            var gr = await _uow.Expenses.GetByIdAsync(dtoExpense.Id);
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
