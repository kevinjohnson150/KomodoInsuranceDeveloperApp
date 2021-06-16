using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperApp.Library
{
   public class DeveloperRepo
    {
        public List<Developer> _listOfDevelopers = new List<Developer>();

        // Create
        public void AddDeveloperToList(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }

        // Read
        public List<Developer> DeveloperList()
        {
            return _listOfDevelopers;
        }

        // Update
        public bool UpdateExistingDeveloperList(string oldDeveloper, Developer newDeveloper)
        {
            //Find the content
            Developer oldIdentification = GetDeveloperByID(oldDeveloper);

            //Update the content
            if (oldIdentification != null)
            {
                oldIdentification.DeveloperIdentification = newDeveloper.DeveloperIdentification;
                oldIdentification.FirstName = newDeveloper.FirstName;
                oldIdentification.LastName = newDeveloper.LastName;
                oldIdentification.HasAccessToPluralsight = newDeveloper.HasAccessToPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveDeveloperFromList(string developerIdentification)
        {
            Developer developer = GetDeveloperByID(developerIdentification);

            if(developer == null)
            {
                return false;
            }
            int developerCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(developerCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       

        // Helper Method
        public Developer GetDeveloperByID(string oldDeveloper)
        {
            foreach(Developer developer in _listOfDevelopers)
            {
                if(developer.DeveloperIdentification.ToLower() == oldDeveloper.ToLower())
                {
                    return developer;
                }
            }

            return null;
        }

    }
}
