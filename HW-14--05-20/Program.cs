using System;
using HW_14__05_20.Persons;
using HW_14__05_20.Repositories.PersonRepositories;
namespace HW_14__05_20
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository person = new PersonRepository();
            while (true)
            {
                Console.Clear();
                Console.Write("1.Create\n2.Read\n3.Update\n4.Delete\nВаш выбор: ");
                switch (Console.ReadLine())
                {
                    case "1": { person.Create(); Console.ReadKey(); } break;
                    case "2": { person.Read(); Console.ReadKey(); } break;
                    case "3": { person.Update(); Console.ReadKey(); } break;
                    case "4": { person.Delete(); Console.ReadKey(); } break;
                    default:
                        break;
                }
            }
        }
    }
}
