using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApiOrnek.Helper
{
    public static class General
    {
        public static bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
