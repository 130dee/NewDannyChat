using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDannyChat
{
    public class StartWord
    {
        private string start;

        public string Start
        {
            get { return start; }
            set { start = value; }
        }
        private Boolean followused;// when constructing  a sentence this will stop a word being used over

        public Boolean Followused
        {
            get { return followused; }
            set { followused = value; }
        }

        private Boolean amEnd;

        public Boolean AmEnd
        {
            get { return amEnd; }
            set { amEnd = value; }
        }

        private Boolean amstart;

        public Boolean Amstart
        {
            get { return amstart; }
            set { amstart = value; }
        }

        private List<WordandCount> nextword;

        public List<WordandCount> Nextword
        {
            get { return nextword; }
            set { nextword = value; }
        }

        public StartWord()
        {
            start = "";
            nextword = new List<WordandCount>();
            amstart = false;
            amEnd = false;
            followused = false;

        }

        public StartWord(string start, List<WordandCount> nextword)

        {
            this.start = "";
            this.nextword = new List<WordandCount>();
            this.amstart = false;
            this.followused = false;

        }
    }
}
