using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.Utility
{
    public static class DateManipulator
    {
        private const string culture = "en-GB";

        public static bool checkIfLaterDate(DateTime currentDate, DateTime checkingDate)
        {
            return currentDate >= checkingDate;
        }

    }
}
