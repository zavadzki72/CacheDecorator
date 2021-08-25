using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Repositories;

namespace WebApi.Controllers {

    [ApiController]
    [Route("team")]
    public class TeamController : ControllerBase {

        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository) {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult Get() {

            var teams = _teamRepository.List();

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            var team = _teamRepository.GetById(id);

            if(team.Teams.FirstOrDefault() == null)
                return NotFound($"Não encontramos nenhum time com o ID: {id}");

            return Ok(team);
        }
        
    }
}
