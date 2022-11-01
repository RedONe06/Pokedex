using PokedexCharp.Models;
using PokedexCharp.Util;

PokedexClient client = new();
ParserJson parser = new();
Person person = new Person();
Saudacoes();
Menu();

#region
void Saudacoes()
{
    char number = ' ';
    Console.WriteLine("                                  ,'\\\r\n    _.----.        ____         ,'  _\\   ___    ___     ____\r\n_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\r\n\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\r\n \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\r\n   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\r\n    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\r\n     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\r\n      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\r\n       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\r\n        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\r\n                                `'                            '-._|");
    Console.WriteLine("===================================================================");
    Console.WriteLine("||                                                                ||");
    Console.WriteLine("||                  Seja bem vindo ao POKEDEX!                    ||");
    Console.WriteLine("||                                                                ||");
    Console.WriteLine("===================================================================");
    bool notSure = true;
    while (notSure)
    {
        Console.WriteLine("===================================================================");
        Console.WriteLine("|| Qual o seu nome?                                               ||");
        Console.WriteLine("===================================================================");
        string nome = Console.ReadLine();
        Console.WriteLine("===================================================================");
        Console.WriteLine($"|| Certeza que o seu nome é {nome}?                               ||");
        Console.WriteLine("===================================================================");
        Console.WriteLine("|| (1) Sim!                                                       ||");
        Console.WriteLine("|| (2) Não!                                                       ||");
        Console.WriteLine("===================================================================");
        try
        {
            number = Console.ReadLine()[0];
        }
        catch
        {
            Console.WriteLine("Opção Inválida");
        }

        if (number.Equals('1'))
        {
            notSure = false;
            person.Name = nome;
        }
    }
}
void Menu()
{
    char option = ' ';
    while (!option.Equals('3'))
    {
        Console.WriteLine("===================================================================");
        Console.WriteLine($"|| Então {person.Name}, o que deseja fazer?                        ||");
        Console.WriteLine("===================================================================");
        Console.WriteLine("||                                                                ||");
        Console.WriteLine("|| (1) Adotar um mascote                                          ||");
        Console.WriteLine("|| (2) Ver mascotes adotados                                      ||");
        Console.WriteLine("|| (3) Sair do jogo                                               ||");
        Console.WriteLine("||                                                                ||");
        Console.WriteLine("===================================================================");
        try
        {
            option = Console.ReadLine()[0];
        }
        catch
        {
            Console.WriteLine("Opção Inválida");
        }
        finally
        {
            ExecuteOption(option);
        }
        
    }
}

void ExecuteOption(char option)
{
    switch (option)
    {
        case '1':
            Console.WriteLine("==================== Adotando um Pokemon ==========================");
            Console.WriteLine("|| Escolha a sua espécie                                          ||");
            Console.WriteLine("===================================================================");
            ListPokemons();
            String chose = Console.ReadLine();
            ShowAdoptionActions();
            ListPokemonByNameOrId(chose);
            break;
        case '6':
            Console.WriteLine("Saindo do programa! Tchau!");
            break;
        default:
            Console.WriteLine("===================================================================");
            Console.WriteLine("|| Ok! Adeus!                                                    ||");
            Console.WriteLine("===================================================================");
            break;
    }
}

void ShowAdoptionActions()
{
    Console.WriteLine("==================== Sobre este Pokemon ==========================");
    Console.WriteLine("|| (1) Saber mais sobre o                                       ||");
    Console.WriteLine("===================================================================");
}

void ListPokemons()
{
    string jsonGetAllPokemons = client.GetRequest();
    List<Pokemon> pokemonList = parser.ParseAllPokemons(jsonGetAllPokemons);

    foreach (Pokemon pokemon in pokemonList)
    {
        Console.WriteLine($"({pokemon.Id}) {pokemon.Name}");
    }
}

void ListPokemonByNameOrId(String nameOrID)
{
    string jsonGetPokemon = client.GetRequestByNameOrId(nameOrID);
    if(jsonGetPokemon != null)
    {
        Pokemon pokemon = parser.ParsePokemon(jsonGetPokemon);
        pokemon.ToString();
    } else
    {
        Console.WriteLine("===================================================================");
        Console.WriteLine("|| Este Pokemon não foi encontrado.                               ||");
        Console.WriteLine("===================================================================");
    }
    
}

#endregion

// var jsonGetAllPokemons = client.GetRequestByName("charmeleon");
// cw(jsonGetAllPokemons);