﻿#pragma warning disable CS1998

using Dapper;

using GeeksDirectory.Domain.Responses;
using GeeksDirectory.Services.Helpers;
using GeeksDirectory.Services.Queries;

using MediatR;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetProfileByIdHandler : IRequestHandler<GetProfileByIdQuery, GeekProfileResponse?>
    {
        private readonly string connection;

        public GetProfileByIdHandler(IConfiguration configuration)
        {
            this.connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<GeekProfileResponse?> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqliteConnection(this.connection);

            var sql = @"SELECT  P.[Id],
                                P.[Email],
                                P.[Name],
                                P.[Surname],
                                P.[Middlename],
                                P.[City],
                                S.[Id],
                                S.[Name],
                                S.[Description],
                                S.[AverageScore]
                        FROM    [Profiles] AS P
                                LEFT JOIN [Skills] AS S
                                         ON S.[ProfileId] = P.[Id]
                        WHERE   P.[Id] = @ProfileId;";

            var skills = new List<SkillResponse>();
            var response = await db.QueryAsync<GeekProfileResponse, SkillResponse, GeekProfileResponse>(sql,
                map: (profile, skill) =>
                {
                    skills.AddIfNotEmpty(skill);
                    return profile;
                },
                param: new { request.ProfileId },
                splitOn: "Id");

            var profile = response.First();
            profile.Skills = skills;

            return profile;
        }
    }
}
