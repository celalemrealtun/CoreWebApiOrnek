 
using System;

namespace CoreWebApiOrnek.Entities.Concrete
{
    public class Expense  
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }

    }
}
