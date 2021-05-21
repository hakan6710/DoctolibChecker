using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace DoctolibLoader
{
    class Program
    {
        public const string wohnhaftHS = "wohnhaftHS";
        public const string prio4 = "Prio4";
        public static Dictionary<string, string> urlsPerReason = new Dictionary<string, string> {
            { wohnhaftHS, "https://www.doctolib.de/availabilities.json?start_date=<#PLACEHOLDERDATE>&visit_motive_ids=2838662&agenda_ids=435743-379939-432243&insurance_sector=public&practice_ids=150739&limit=6" },
            { prio4,"https://www.doctolib.de/availabilities.json?start_date=<#PLACEHOLDERDATE><&visit_motive_ids=2736075&agenda_ids=435743-379939-460713-432243&insurance_sector=public&practice_ids=150739&limit=6" 
                 }
        };

        static void Main(string[] args)
        {


           
            
            while (true)
            {
                DateTime current = DateTime.Now;
                string currentDate = current.ToString("yyyy-MM-dd");
                Console.WriteLine("Current Time=" + current.ToString());
                foreach (KeyValuePair<string, string> entry in urlsPerReason)
                {
                    string url = entry.Value.Replace("<#PLACEHOLDERDATE>", currentDate);
                    CallServer(entry.Key, url);
                }
                Console.WriteLine("");
                Thread.Sleep(10000);
            }

        }


        public static void AnnoyTheFuckOut()
        {
            for(int i=0; i<20; i++)
            {

                Console.Beep(2000, 100);
                Thread.Sleep(500);
            }
            
        }

        public static void CallServer(string reason, string url)
        {
            try {     
                var client = new WebClient();
                string content = client.DownloadString(url);
                ResponseJson response = JsonConvert.DeserializeObject<ResponseJson>(content);
                if (response.total > 1)
                {
                    Console.WriteLine($"Grund=[{reason}], Verfuegbar={response.total}", System.Drawing.Color.Green);
                    AnnoyTheFuckOut();
                }
                else
                {
                    Console.WriteLine($"Grund=[{reason}], Verfuegbar={response.total}", System.Drawing.Color.Red);
                }
            }
            catch (Exception ex){
                Console.WriteLine("eRROR");
            }

        }

       
    }
}
