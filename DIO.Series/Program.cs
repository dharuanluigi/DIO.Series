using DIO.Series.Classes;
using DIO.Series.Enum;
using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository respository = new SerieRepository();
        static List<Gender> genderList = new List<Gender>();
        static void Main(string[] args)
        {
            AddGenderToList();

            string opt = GetUserOption();

            while (opt.ToUpper() != "X")
            {
                switch (opt)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                opt = GetUserOption();
            }

            Console.WriteLine("Thanks for using us service!");
            Console.ReadLine();
        }

        private static void ViewSerie()
        {
            Console.WriteLine("Viewing a serie...");

            Console.Write("Type serie's id to view more informations: ");
            int serieId = int.Parse(Console.ReadLine());

            var serie = respository.ReturnById(serieId);

            Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Deleting a serie...");

            Console.Write("Type serie's id to deleted: ");
            int serieId = int.Parse(Console.ReadLine());

            respository.Delete(serieId);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Updating a serie...");

            Console.Write("Type serie's id to update: ");
            int serieId = int.Parse(Console.ReadLine());

            for (var i = 0; i < genderList.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, genderList[i]);
            }

            Console.Write("How gender is? Choose number above: ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            Console.Write("Serie's title: ");
            string title = Console.ReadLine();

            Console.Write("Release year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Serie's description: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(serieId, gender, title, description, year);

            respository.Update(serieId, serie);
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserting new serie");

            for(var i = 0; i < genderList.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i+1, genderList[i]);
            }

            Console.Write("How gender is? Choose number above: ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            Console.Write("Serie's title: ");
            string title = Console.ReadLine();

            Console.Write("Release year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Serie's description: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(respository.NextId(), gender, title, description, year);

            respository.Insert(serie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listing series...");

            var list = respository.Liist();

            if (list.Count == 0)
            {
                Console.WriteLine("No one series available rigth now.");
                return;
            }
            else
            {
                foreach (var serie in list)
                {
                    var excludedTag = serie.IsDeleted() ? "(Deleted)" : string.Empty;
                    Console.WriteLine("#ID {0}: - {1} - {2}", serie.Id, serie.ReturnTitle(), excludedTag);
                }
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to DIO Series!");
            Console.WriteLine("Choose wished option: ");

            Console.WriteLine("1 - List series");
            Console.WriteLine("2 - Add a new serie");
            Console.WriteLine("3 - Update a serie");
            Console.WriteLine("4 - Delete a serie");
            Console.WriteLine("5 - View a serie");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            Console.Write("Choose: ");
            string opt = Console.ReadLine().ToUpper();
            Console.WriteLine();
            
            return opt;
        }

        private static void AddGenderToList()
        {
            genderList.Add(Gender.Action);
            genderList.Add(Gender.Adventure);
            genderList.Add(Gender.Comedy);
            genderList.Add(Gender.Documentary);
            genderList.Add(Gender.Drama);
            genderList.Add(Gender.Espionage);
            genderList.Add(Gender.Fantasy);
            genderList.Add(Gender.Horror);
            genderList.Add(Gender.Musical);
            genderList.Add(Gender.Romance);
            genderList.Add(Gender.Science_Fiction);
            genderList.Add(Gender.Suspense);
            genderList.Add(Gender.Western);
        }
    }
}
