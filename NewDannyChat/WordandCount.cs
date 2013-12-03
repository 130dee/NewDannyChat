using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDannyChat
{
    public class WordandCount
    {
        private string usedword;

        public string Usedword
        {
            get { return usedword; }
            set { usedword = value; }
        }
        

        private int countused;

        public int Countused
        {
            get { return countused; }
            set { countused = value; }
        }

        public WordandCount()
        {
            usedword = "";
            countused = 0;
        }
        public WordandCount(string usedword, int countused)
        {
            this.usedword = usedword;
            this.countused = countused;
        }
    }
}
