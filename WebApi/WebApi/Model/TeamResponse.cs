using System.Collections.Generic;
using System.Linq;

namespace WebApi.Model {

    public class TeamResponse {

        public List<TeamEntity> Teams { get; set; }
        public string InformationFrom { get; set; }

        public TeamResponse(string from, params TeamEntity[] teams) {
            Teams = teams.ToList();
            InformationFrom = from;
        }

        public void InformationFromCache() {
            InformationFrom = "MEMORY_CACHE";
        }

        public void InformationFromDatabase() {
            InformationFrom = "DATABASE";
        }

    }
}
