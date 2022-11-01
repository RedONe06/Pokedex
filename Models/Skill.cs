using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexCharp.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public String Generation { get; set; }
        public bool IsInMainSeries { get; set; }
        public String LongEffect { get; set; }
        public String ShortEffect { get; set; }

        public Skill()
        {

        }

    }
}
