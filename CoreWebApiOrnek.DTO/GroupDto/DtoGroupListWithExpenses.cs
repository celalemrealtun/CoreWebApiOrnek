
using CoreWebApiOrnek.DTO.ExpenseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApiOrnek.DTO.GroupDto
{
    public class DtoGroupListWithExpenses
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<DtoExpenseList> Expenses { get; set; }
    }
}
