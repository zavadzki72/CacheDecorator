using System.Linq;
using WebApi.Model;

namespace WebApi.Repositories {

    public class TeamRepository : ITeamRepository {

        public TeamResponse List() {
            var listTeam = Teams.TeamList;
            return new TeamResponse("DATABASE", listTeam.ToArray());
        }

        public TeamResponse GetById(int id) {
            var team = Teams.TeamList.FirstOrDefault(x => x.Id.Equals(id));
            return new TeamResponse("DATABASE", team);
        }

    }
}
