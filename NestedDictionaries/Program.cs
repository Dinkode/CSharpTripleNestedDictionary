using System;
using System.Collections.Generic;
using System.Linq;

namespace NestedDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Dictionary<string, int>>> test = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] elements = input.Split();
                string country = elements[0];
                string city = elements[1];
                string street = elements[2];
                int number = int.Parse(elements[3]);
                if (!test.ContainsKey(country))
                {
                    test.Add(country, new Dictionary<string, Dictionary<string, int>>());
                    test[country].Add(city, new Dictionary<string, int>());
                    test[country][city].Add(street, 0);
                }
                else
                {
                    if (!test[country].ContainsKey(city))
                    {
                        test[country].Add(city, new Dictionary<string, int>());
                        test[country][city].Add(street, 0);
                    }
                    else
                    {
                        if (!test[country][city].ContainsKey(street))
                        {
                            test[country][city].Add(street, 0);
                        }
                    }
                }
                test[country][city][street] += number;
            }

            //print
            var sort = test.OrderByDescending(country => country.Value.Count);
            foreach (var c in sort)
            {
                Console.WriteLine("- Country: "+ c.Key);
                foreach (var cit in c.Value)
                {
                    Console.WriteLine("-   City: " + cit.Key);
                    foreach (var s in cit.Value)
                    {
                        Console.WriteLine("-     Street: " + s.Key + " " + s.Value);
                    }
                }
            }
        }
    }
}