using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceDeveloperApp.Library
{
    public class DevTeam
    {
        public List<Developer> TeamMembers { get; set; } = new List<Developer>();
        public string TeamName { get; set; }
        public string TeamIdentification { get; set; }

        public DevTeam() { }

        public DevTeam(List<Developer> teamMembers, 
            string teamName, 
            string teamIdentification)
        {
            this.TeamMembers = teamMembers;
            this.TeamName = teamName;
            this.TeamIdentification = teamIdentification;
        }
    }
}
