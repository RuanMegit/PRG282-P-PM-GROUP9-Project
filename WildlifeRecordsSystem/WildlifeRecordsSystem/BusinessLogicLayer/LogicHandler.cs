using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeRecordsSystem.BusinessLogicLayer
{
    internal class LogicHandler
    {
        public LogicHandler()
        {
        }

        //Method 1: to calculate the housing unit and status from recovery score without the user nedding to enter it (Add, Update)
        public void StatusCalculation(int score, out string status, out string housingunit)
        {
            if (score <= 19)
            {
                status = "Critical";
                housingunit = "Intensive Care Unit";
            }
            else if (score <= 39)
            {
                status = "Serious";
                housingunit = "High-Dependency Ward";
            }
            else if (score <= 59)
            {
                status = "Stable";
                housingunit = "Recovery Ward";
            }
            else if (score <= 79)
            {
                status = "Recovering";
                housingunit = "Outdoor Enclosure";
            }
            else
            {
                status = "Release-Ready";
                housingunit = "Pre-Release Camp";
            }
        }
    }
}
