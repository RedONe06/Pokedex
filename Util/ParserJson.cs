using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokedexCharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PokedexCharp.Util
{
    public class ParserJson
    {
        public ParserJson()
        {

        }
        public List<Pokemon> ParseAllPokemons(string json)
        {
            List<Pokemon> speciesList = new List<Pokemon>();

            try
            {
                JObject o = JObject.Parse(json);

                for (int i = 0; i < o["results"].Count(); i++)
                {
                    Pokemon specie = new Pokemon();
                    specie.Id = i + 1;
                    specie.Name = (string)o.SelectToken($"results[{i}].name");
                    specie.Url = (string)o.SelectToken($"results[{i}].url");
                    speciesList.Add(specie);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }

            return speciesList;
        }

        public Pokemon ParsePokemon(String json)
        {
            Pokemon pokemon = new Pokemon();

            try
            {
                JObject o = JObject.Parse(json);
                
                pokemon.Id = (int)o.SelectToken($"id");
                pokemon.Name = (String)o.SelectToken($"name");
                pokemon.Weight = (double)o.SelectToken($"weight");
                pokemon.Height = (double)o.SelectToken($"height");

                for (int i = 0; i < o.SelectToken($"abilities").Count(); i++)
                {
                    Skill skill = new Skill();
                    skill.Name = (String)o.SelectToken($"$.abilities[{i}].ability.name");
                    pokemon.Skills.Add(skill);
                }

                for (int i = 0; i < o.SelectToken($"forms").Count(); i++)
                {
                    String form = (String)o.SelectToken($"$.forms[{i}].name");
                    pokemon.Forms.Add(form);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return pokemon;
        }

    }
}
