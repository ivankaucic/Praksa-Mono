using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Common
{
    public class Filtering
    {
        public int? Age { get; set; }
        public int? AgeIsLower { get; set; }
        public int? AgeIsHigher { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }

        public Filtering(int? age, int? ageIsLower, int? ageIsHIgher, string Nationality)
        {
            this.Age = age;
            this.AgeIsLower = ageIsLower;
            this.AgeIsHigher = ageIsHIgher;
            this.Nationality = Nationality;
        }

        public Filtering(string genre)
        {
            this.Genre = genre;
        }


    }
}
