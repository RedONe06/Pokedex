using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexCharp.Models
{
    public class Pokemon
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public List<String> Forms { get; set ; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Pokemon()
        {
            Skills = new List<Skill>();
            Forms = new List<string>();
        }

        public void ToString()
        {
            Console.WriteLine($"======================= {this.Name} =========================");
            Console.WriteLine($"|| Id = {this.Id}                               ||");
            Console.WriteLine($"|| Height = {this.Height}                               ||");
            Console.WriteLine($"|| Weight = {this.Weight}                               ||");

            foreach (string form in Forms)
            {
                Console.WriteLine($"|| Form = {form}                               ||");
            }
            foreach (var skill in Skills)
            {
                Console.WriteLine($"|| Skill = {skill.Name}                               ||");
            }
            Console.WriteLine("===================================================================");
        }
    }
}
