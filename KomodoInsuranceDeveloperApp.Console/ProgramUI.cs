using KomodoInsuranceDeveloperApp.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperApp
{
   
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedDeveloperAndTeamList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options
                Console.WriteLine("Select an option below: \n" +
                    "1. Create A New Developer \n" +
                    "2. Create A New Team \n" +
                    "3. View Developer By ID \n" +
                    "4. View List Of Teams \n" +
                    "5. View Developers On A Team \n" +
                    "6. Remove DevTeam \n" +
                    "7. Remove Developer From Team \n" +
                    "8. Add Developer To Team \n" +
                    "9. Exit");

                // User input
                string input = Console.ReadLine();

                // Evaluate input
                switch (input)
                {
                    case "1":
                        // Create New Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // Create A New Team
                        CreateNewTeam();
                        break;
                    case "3":
                        // View devs
                        ViewListOfDevelopers();
                        break;
                    case "4":
                        // View teams
                        ViewListOfTeams();
                        break;
                    case "5":
                        // View developer on a team
                        ViewDevelopersOnATeam();
                        break;
                    case "6":
                        // Remove dev team
                        RemoveDevTeam();
                        break;
                    case "7":
                        RemoveDeveloperFromTeam();
                        break;
                    case "8":
                        // Add developer to team
                        AddDeveloperToTeam();
                        break;
                    case "9":
                        // Exit
                        Console.WriteLine("Have a great day!");
                        keepRunning = false;
                        break;
                    default:
                       Console.WriteLine("Invalid response please try again.");
                        break;
                }
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create New Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            // First Name
            Console.WriteLine("Enter the developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();

            // Last Name
            Console.WriteLine("Enter the developer's last name:");
            newDeveloper.LastName = Console.ReadLine();

            // Developer ID
            Console.WriteLine("Enter the developer's identification number:");
            newDeveloper.DeveloperIdentification = Console.ReadLine();

            // Access to Pluralsight
            Console.WriteLine("Does the deveeloper have access to Pluralsight? (y/n)");
            string pluralAccess = Console.ReadLine().ToLower();

            if(pluralAccess == "y")
            {
                newDeveloper.HasAccessToPluralsight = true;
            }
            else
            {
                newDeveloper.HasAccessToPluralsight = false;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);
        }

        // Create New Team

        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            // Team Name
            Console.WriteLine("Enter the team name:");
            newTeam.TeamName = Console.ReadLine();

            // Team ID
            Console.WriteLine("Enter the team identification number:");
            newTeam.TeamIdentification = Console.ReadLine();
        }

        // View Developers
        private void ViewListOfDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.DeveloperList();

            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Developer ID: {developer.DeveloperIdentification}");
            }
        }

        // View Team By ID
        private void ViewListOfTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.DevTeamList();

            foreach(DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Dev Team Name: {devTeam.TeamName}\n" +
                    $"Dev Team ID: {devTeam.TeamIdentification}\n");
            }

        }

        private void ViewDevelopersOnATeam()
        {
            Console.Clear();
            ViewListOfTeams();

            Console.WriteLine("\nEnter the DevTeam ID to see the developer's on that team:");
            string input = Console.ReadLine();

            DevTeam listOfDevsOnTeam = _devTeamRepo.GetNewDeveloperFromDevTeam(input);

            foreach(Developer devTeam in listOfDevsOnTeam.TeamMembers)
            {
                Console.WriteLine($"Developer full name: {devTeam.FirstName} {devTeam.LastName}\n" +
                    $"Does developer has Pluralsight access: {devTeam.HasAccessToPluralsight}\n" +
                    $"Devloper Identification Number: {devTeam.DeveloperIdentification}");
            }

        }

        // Remove dev team
          private void RemoveDevTeam()
         {
            Console.Clear();
            ViewListOfTeams();

            Console.WriteLine("\nEnter the team ID for the team you like to remove:");
            string input = Console.ReadLine();
            bool teamRemoved = _devTeamRepo.RemoveDevTeam(input);

            if (teamRemoved)
            {
                 Console.WriteLine("The team was removed.");
            }
            else
            {
              Console.WriteLine("The team was unable to be deleted. Check the ID number and try again.");
            }
          }   

        // Remove developer from team
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();

            Console.WriteLine("\nEnter the developer ID for the developer you would like to remove:");
            string devID = Console.ReadLine();
            Console.WriteLine("\nEnter the team ID the developer should be removed from:");
            string teamID = Console.ReadLine();

            bool devRemoved = _devTeamRepo.RemoveDevFromTeam(devID, teamID);

            if (devRemoved)
            {
                Console.WriteLine("The dev was removed.");
            }
            else
            {
                Console.WriteLine("The developer was unable to be deleted. Check the ID number and try again.");
            }
        }

        // Add developer to team
        private void AddDeveloperToTeam()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();
            
            ViewListOfTeams();
            ViewListOfDevelopers();

            Console.WriteLine("Enter the developer's ID number you would like:");
            string developerToLookup = Console.ReadLine();
            newDeveloper = _developerRepo.GetDeveloperByID(developerToLookup);

            Console.WriteLine("What team ID would you like to add the developer to?");
            string teamID = Console.ReadLine();
            _devTeamRepo.AddDeveloperToTeam(teamID, newDeveloper);
        }

     

        //Seed Method
        private void SeedDeveloperAndTeamList()
        {
            Developer dev1 = new Developer("Kevin", "Johnson", "150", true);
            Developer dev2 = new Developer("Phil", "Smith", "100", true);
            Developer dev3 = new Developer("Austin", "McCracken", "120", false);
            Developer dev4 = new Developer("Jamie", "Wozniak", "99", false);
            Developer dev5 = new Developer("Nick", "Stoner", "75", true);

            _developerRepo.AddDeveloperToList(dev1);
            _developerRepo.AddDeveloperToList(dev2);
            _developerRepo.AddDeveloperToList(dev3);
            _developerRepo.AddDeveloperToList(dev4);
            _developerRepo.AddDeveloperToList(dev5);

            DevTeam team1 = new DevTeam(new List<Developer> { dev1 }, "iOS", "19");
            DevTeam team2 = new DevTeam(new List<Developer> { dev3 }, "Android", "10");
            DevTeam team3 = new DevTeam(new List<Developer> { dev4 }, "C#", "16");
            DevTeam team4 = new DevTeam(new List<Developer> { dev5 }, "Java", "29");
            DevTeam team5 = new DevTeam(new List<Developer> { dev2 }, "HTML", "4");

            _devTeamRepo.CreateDevTeam(team1);
            _devTeamRepo.CreateDevTeam(team2);
            _devTeamRepo.CreateDevTeam(team3);
            _devTeamRepo.CreateDevTeam(team4);
            _devTeamRepo.CreateDevTeam(team5);
           

        }


    }
   
}
