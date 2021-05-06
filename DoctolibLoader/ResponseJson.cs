using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctolibLoader
{
    class ResponseJson
    {
        public Dates[] availabilities;
        public int total;
        public String reason;
        public String message;

        public class Dates
        {
            public String date;
            public String[] hours;

            public override string ToString()
            {
                if (hours != null)
                {
                    return $"[{date}, {hours.ToString()}]";
                }

                return $"[{date}]";
            }
        }
    }
}
