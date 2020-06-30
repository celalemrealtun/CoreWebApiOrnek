using System;

namespace CoreWebApiOrnek.DTO.ExpenseDto
{
    public class DtoExpenseList
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
