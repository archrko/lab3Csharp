using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Lab1
    {
        static void Main(string[] args)
        {
            //Завдання 1
            MagazineCollection m = new MagazineCollection();
            Magazine magazine = new Magazine("name", new DateTime(), 100, Frequency.Yearly);
            Magazine magazine2 = new Magazine("Archy", new DateTime(2013,01,01), 10000, Frequency.Weekly);
            magazine.AddArticles(new Article(new Person(), "smth", 10));
            magazine2.AddArticles(new Article(new Person(), "Shoo", 5));
            m.AddDefaults();
            m.AddMagazines(magazine);            
            m.AddMagazines(magazine2);
            Console.WriteLine(m);
            //Завдання 2
            Console.WriteLine("SortByName");
            m.SortByName();
            Console.WriteLine("SortByDate\n{0}",m);
            m.SortByDate();
            Console.WriteLine("SortByCount\n{0}", m);
            m.SortByCount();
            Console.WriteLine(m);
            //Завдання 3
            Console.WriteLine("Max Avarage Rating is " + m.GetMaxAvgRating);
            Console.WriteLine("Monthly magazines\n");
            foreach (Magazine a in m.MonthlyMagazines)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Enter min rating");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Rating >= {0} :\n",k);
            try
            {
                foreach (Magazine rat in m.RatingGroup(k))
                {
                    Console.WriteLine(rat);
                }
            }
            catch { Console.WriteLine("No such magazines"); }
            //Завдання 4
            int n = 0;            
            while (n < 1)
            {
                Console.WriteLine("Enter positive integer ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect value");
                }
            }
            TestCollections t = new TestCollections(n);           
            Dictionary<string, int> time;
            Console.WriteLine("0-first,1-average,2-last,default-random");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 0:                    
                    time = t.GetTime(t.editionAndMagazine[t.edition[0]]); 
                    break;
                case 1:
                    time = t.GetTime(t.editionAndMagazine[t.edition[n/2]]);
                    break;
                case 2:
                    time = t.GetTime(t.editionAndMagazine[t.edition[n-1]]);
                    break;
                default:
                    time = t.GetTime(new Magazine("didnt EXIST", new DateTime(), 100, Frequency.Yearly));
                    break;
            }
            foreach (KeyValuePair<string, int> kvp in time)
            {
                Console.WriteLine("{0},\tTime is {1}",
                    kvp.Key, kvp.Value);
            }
            Console.ReadKey();
        }
    }

}
