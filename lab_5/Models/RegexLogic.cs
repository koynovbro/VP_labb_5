using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_5.Models
{
    public partial class RegexLogic
    {
        public static string FindRegexInText(string Text, string Curr)
        {
            if (Curr == String.Empty || Curr == null)
            {
                return "Exception";
            }

            string Result = "";

            Regex regex = new Regex(Curr);

            MatchCollection match = regex.Matches(Text);

            foreach (Match x in match)
            {
                Result += (x.Value + "\n");
            }

            return Result;
        }
    }
}
