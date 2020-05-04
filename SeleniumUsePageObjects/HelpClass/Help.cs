using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelpClass
{
    public class Help
    {

        public static string ReplaceMonth(string str)//expexted input in format "04.03.2020"
        {
            string[] month = new string[] { " січня ", " лютого ", " березня ", " квітня ",
                " травня ", " червня ", " липня ", " серпня ", " вересня ", " жовтня ", " листопада ", " грудня " };
            Regex regex = new Regex(@"^[0]{1}");
            string out_month = regex.Replace(str.Substring(3, 2), "");
            int num = Int16.Parse(out_month);
            return String.Concat(str.Substring(0, 2), month[num - 1], str.Substring(6, 4));
        }

    }
}
