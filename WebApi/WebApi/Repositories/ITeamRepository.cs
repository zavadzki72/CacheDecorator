using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Repositories {
    public interface ITeamRepository {

        TeamResponse List();
        TeamResponse GetById(int id);

    }
}
