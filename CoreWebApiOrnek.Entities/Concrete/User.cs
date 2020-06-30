 
using System.Collections.Generic;

namespace CoreWebApiOrnek.Entities.Concrete
{
    public class User  
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
