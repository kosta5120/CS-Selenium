using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAWeeklyCheck.Model;

namespace QAWeeklyCheck.Model
{
    class FixedElement 
    {

        private string _id;

        public string ID { get { return _id; } set { _id = value; } }

        public string MaximizeFirstDashboard { get { return "//*[@id=\"chartDB\"]/div[1]/div[1]/div[1]/div[1]/div/span[7]"; } }
        
        public string Resolution { get { return "//*[@id=\"" + ID + "\"]/div[1]/div[4]/div/button/span[2]/span"; }  }
        public string  RepairResolution { get { return "//*[@title=\"Month\"]"; } }               
        public string  Day { get { return "//*[@id=\"" + ID + "\"]/div[1]/div[4]/div/div/ul/li[1]/a/span[1]"; } }
        public string  RepairResolutionDay { get { return "//*[@id=\"" + ID + "\"]/div[2]/div[2]/div/div/ul/li[1]"; } }
        public string Update { get { return "//*[@type =\"submit\"]"; } }                                 
        public string Values { get { return "//*[@id=\"chartjs_Chart_1\"]"; } }
        public string Plant { get { return "//*[@id=\"" + ID + "\"]/div[2]/div[1]/div/button/span[2]/span"; } }
        public string DeselectAllPlants { get { return "//*[@id=\"" + ID + "\"]/div[2]/div[1]/div/div/div[2]/div/button[2]"; } }
        public string DeselectAllProcessesTS { get { return "//*[@id=\"" + ID  + "\"]/div[2]/div[2]/div/div/div[2]/div/button[2]"; } }
        public string SearchTBProcess { get { return "//*[@id=\"" + ID + "\"]/div[2]/div[2]/div/div/div[1]/input"; } }

        public string RmaDay { get { return "//*[@id=\"" + ID + "\"]/div[1]/div[4]/div/div/ul/li[1]/a"; } }
                                                        
    }
}
