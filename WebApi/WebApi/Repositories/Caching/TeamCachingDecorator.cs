using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using WebApi.Model;

namespace WebApi.Repositories.Caching {

    public class TeamCachingDecorator<T> : ITeamRepository where T : ITeamRepository {

        private const string CACHE_KEY = "team";

        private readonly IMemoryCache _memoryCache;
        private readonly T _repository;

        public TeamCachingDecorator(IMemoryCache memoryCache, T repository) {
            _memoryCache = memoryCache;
            _repository = repository;
        }

        public TeamResponse List() {

            var teamsOnCache = _memoryCache.Get<TeamResponse>(CACHE_KEY);

            if(teamsOnCache != null)
                return teamsOnCache;

            var teams = _repository.List();
            teams.InformationFromCache();
            _memoryCache.Set(CACHE_KEY, teams, TimeSpan.FromHours(1));

            return new TeamResponse("DATABASE", teams.Teams.ToArray());
        }

        public TeamResponse GetById(int id) {

            var teamOnCache = _memoryCache.Get<TeamResponse>(CACHE_KEY);

            if(teamOnCache != null) {
                var teamId = teamOnCache.Teams.FirstOrDefault(x => x.Id.Equals(id));
                return new TeamResponse("MEMORY_CACHE", teamId);
            }

            var teams = _repository.List();
            teams.InformationFromCache();
            _memoryCache.Set(CACHE_KEY, teams, TimeSpan.FromHours(1));

            var team = teams.Teams.FirstOrDefault(x => x.Id.Equals(id));
            return new TeamResponse("DATABASE", team);
        }

    }
}
