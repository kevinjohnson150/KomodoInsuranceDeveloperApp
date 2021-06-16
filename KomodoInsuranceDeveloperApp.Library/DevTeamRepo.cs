using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperApp.Library
{
    public class DevTeamRepo
    {
        public List<DevTeam> _listOfTeams = new List<DevTeam>();

        // Create
        public void CreateDevTeam(DevTeam devTeamFromListOfDevelopers)
        {
            List<Developer> developers = new List<Developer> { };
            _listOfTeams.Add(devTeamFromListOfDevelopers);
        }

        // Read
        public List<DevTeam> DevTeamList()
        {
            return _listOfTeams;
        }

        // Update
        public bool UpdateExistingDevTeam(string originalTeam, DevTeam newDeveloperFromListOfDevelopers)
        {
            // Find the content
            DevTeam oldDeveloperFromDevTeam = GetNewDeveloperFromDevTeam(originalTeam);

            // Update the content
            if (oldDeveloperFromDevTeam != null)
            {
                oldDeveloperFromDevTeam.TeamMembers = newDeveloperFromListOfDevelopers.TeamMembers;
                oldDeveloperFromDevTeam.TeamIdentification = newDeveloperFromListOfDevelopers.TeamIdentification;
                oldDeveloperFromDevTeam.TeamName = newDeveloperFromListOfDevelopers.TeamName;

                return true;
            }
            else
            {
                return false;
            }
        }
            public bool AddDeveloperToTeam(string originalTeam, Developer newDeveloperFromListOfDevelopers)
            {
                // Find the content
                DevTeam oldDeveloperFromDevTeam = GetNewDeveloperFromDevTeam(originalTeam);

                // Update the content
                if (oldDeveloperFromDevTeam != null)
                {
                    oldDeveloperFromDevTeam.TeamMembers.Add(newDeveloperFromListOfDevelopers);

                    return true;
                }
                else
                {
                    return false;
                }
            }

        // Delete
        public bool RemoveDevTeam(string team)
        {
           DevTeam devTeamFromListOfDevTeams = GetNewDeveloperFromDevTeam(team);

            if(devTeamFromListOfDevTeams == null)
            {
                return false;
            }

            int teamCount = _listOfTeams.Count;
            _listOfTeams.Remove(devTeamFromListOfDevTeams);

            if(teamCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDevFromTeam(string developerID, string teamID)
        {
            DevTeam devTeam = GetNewDeveloperFromDevTeam(teamID);

            foreach (Developer developerInDevTeam in devTeam.TeamMembers)
            {
                if(developerInDevTeam.DeveloperIdentification.ToLower() == developerID.ToLower())
                {
                    devTeam.TeamMembers.Remove(developerInDevTeam);
                    return true;
                }
            }
            return false;
        }


        // Helper Method
        public DevTeam GetNewDeveloperFromDevTeam(string team)
        {
            foreach(DevTeam devTeamFromListOfDevelopers in _listOfTeams)
            {
                if(devTeamFromListOfDevelopers.TeamIdentification.ToLower() == team.ToLower())
                {
                    return devTeamFromListOfDevelopers;
                }    
            }
            return null;
        }

    }
}
