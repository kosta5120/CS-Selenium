using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWeeklyCheck.Model
{
    public static class ReplaceCharecters
    {
        public static string Clean(this string v)
        {
            StringBuilder sb = new StringBuilder(v);

            sb.Replace("[", "");
            sb.Replace("]", "");
            sb.Replace("}", "");
            sb.Replace("{", "");
            sb.Replace("\"", "");
            sb.Replace("'", "");


            return sb.ToString();
        }
    }
}
