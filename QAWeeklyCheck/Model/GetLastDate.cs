using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWeeklyCheck.Model
{
    class GetLastDate
    {
        private List<string> _dates;
       
        private string lastDate;

        public GetLastDate (List<string> val)
        {
            _dates = val;
        }

        public  string Date()
        {
            for(var i = 0; i < _dates.Count(); i++)
            {
                var s1 = _dates[i].Split(':');

                if(s1[0].Contains("Date"))
                {
                    var s2 = _dates[i + 1].Split(':');
                    if (s2[1] != "0")
                        lastDate = s1[1];
                }
            }
            return lastDate;
        }

    }
}
