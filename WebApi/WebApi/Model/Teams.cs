using System.Collections.Generic;

namespace WebApi.Model {

    public static class Teams {

        public readonly static List<TeamEntity> TeamList = new() {
            { 
                new TeamEntity() {
                    Id = 1,
                    Name = "São Paulo Futebol Clube",
                    Initials = "SPFC",
                    Locale = "São Paulo/SP"
                }
            },
            {
                new TeamEntity() {
                    Id = 2,
                    Name = "Santos Futebol Clube",
                    Initials = "SAN",
                    Locale = "Santos/SP"
                }
            },
            {
                new TeamEntity() {
                    Id = 3,
                    Name = "Clube de Regatas Flamengo",
                    Initials = "FLA",
                    Locale = "Rio de Janeiro/RJ"
                }
            },
            {
                new TeamEntity() {
                    Id = 4,
                    Name = "Clube de Regatas Vasco da Gama",
                    Initials = "VAS",
                    Locale = "Rio de Janeiro/RJ"
                }
            },
            {
                new TeamEntity() {
                    Id = 5,
                    Name = "Sport Clube Internacional",
                    Initials = "INT",
                    Locale = "Porto Alegre/RS"
                }
            },
            {
                new TeamEntity() {
                    Id = 6,
                    Name = "Grêmio Foot-Ball Porto Alegrense",
                    Initials = "GRE",
                    Locale = "Porto Alegre/RS"
                }
            }
        };

    }
}
