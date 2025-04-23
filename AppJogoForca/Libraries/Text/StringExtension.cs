using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJogoForca.Libraries.Text
{
    public static class StringExtension
    {
        public static List<int> GetPositions(this string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int i = 0; ; i += value.Length)
            {
                i = str.IndexOf(value, i);
                if (i == -1)
                    return indexes;
                indexes.Add(i);
            }
        }
    }
}
