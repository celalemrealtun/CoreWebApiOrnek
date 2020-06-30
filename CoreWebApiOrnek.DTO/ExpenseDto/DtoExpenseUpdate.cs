using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApiOrnek.DTO.ExpenseDto
{
   public class DtoExpenseUpdate
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        
    }
}
