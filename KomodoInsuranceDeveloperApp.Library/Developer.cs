using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperApp.Library
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeveloperIdentification { get; set; }
        public bool HasAccessToPluralsight { get; set; }
        public Developer() { }

        public Developer(string firstName, 
            string lastName, 
            string developerIdentification,
            bool hasAccessToPluralsight)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DeveloperIdentification = developerIdentification;
            this.HasAccessToPluralsight = hasAccessToPluralsight;
        }

    }
}
