 using System.Collections.Generic;

namespace CoreWebApiOrnek.Entities.Concrete
{
    public class Group  
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
        public List<Expense> Expenses { get; set; }

    }
}
