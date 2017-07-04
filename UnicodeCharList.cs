using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jFont2
{
    public class UnicodeCharList
    {
        private List<CharEntry> _charCodes = new List<CharEntry>();

        public UnicodeCharList()
        {
            LoadList();
        }

        public List<CharEntry> CharCodes { get { return _charCodes; } }

        private void LoadList()
        {
            //sample file contents:
            //32D0;CIRCLED KATAKANA A;So;0;L;<circle> 30A2;;;;N;;;;;
            string rawTextOfList = ResourceExtensions.GetResourceTextFile("UnicodeCharSet.txt");

            //split by <CR>
            string[] lines = rawTextOfList.Split('\r');
            foreach(string oneLine in lines)
            {
                string[] elements = oneLine.Replace("\n", "").Split(';');

                CharEntry oneEntry = new CharEntry();
                oneEntry.CodeHex = elements[0];
                oneEntry.CodeDec = Int64.Parse(elements[0], System.Globalization.NumberStyles.HexNumber).ToString();
                oneEntry.Desc = elements[1];
                oneEntry.AltDesc = elements[10];

                _charCodes.Add(oneEntry);
            }
        }

        public class CharEntry
        {
            public string CodeDec { get; set; }
            public string CodeHex { get; set; }
            public string Desc { get; set; }

            public string AltDesc { get; set; }
        }
    }
}
