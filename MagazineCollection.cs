using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    class MagazineCollection
    {
        private List<Magazine> _magazines;
        public void AddDefaults()
        {
            if (_magazines == null) _magazines = new List<Magazine>();            
            var articles = new List<Article>
            {
                new Article()
            };
            var editors = new List<Person>
            {
                new Person()
            };
            _magazines.Add(new Magazine("First",new DateTime(2012,12,1),1000,Frequency.Monthly,articles,editors));           
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            if (_magazines==null) _magazines = new List<Magazine>();
            for (int i = 0; i < magazines.Length; i++)
            {
                _magazines.Add(magazines[i]);
            }
        }

        public override string ToString()
        {
            foreach (Magazine s in _magazines)
            {
                Console.WriteLine(s);
            }
            return "";
        }
        public string ToShortString()
        {
            foreach(Magazine s in _magazines)
            {
                Console.WriteLine(s.ToShortString());
            }
            return "";
        }
        public void SortByName() => _magazines.Sort((x, y) => x.CompareTo(y));

        public void SortByDate() => _magazines.Sort((x, y) => new Edition().Compare(x, y));

        public void SortByCount() => _magazines.Sort((x, y) => new HelpMagazine().Compare(x, y));

        public double GetMaxAvgRating
        {
            get
            {
                if (_magazines != null) return _magazines.Max(x => x.AvgValueRating);
                else return 0;
            }
        }
        public IEnumerable<Magazine> MonthlyMagazines
        {
            get
            {
                return from magazine in _magazines
                       where magazine[Frequency.Monthly]
                       select magazine; ;
            }
        }
        
        public List<Magazine> RatingGroup(double value)
        {
            //List<Magazine> list = new List<Magazine>();            
            //foreach (IGrouping<bool, Magazine> magazines in _magazines.GroupBy(rat => rat.AvgValueRating >= value).Where(p => p.Key))
            //{
            //    list = magazines.ToList();
            //}
            //return list;
            return _magazines.GroupBy(rat => rat.AvgValueRating >= value).Where(p => p.Key).First().ToList();
        }
    }
}
