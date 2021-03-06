﻿using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetSkillQuery : IRequest<SkillResponse?>
    {
        public readonly long ProfileId;
        public readonly long SkillId;

        public GetSkillQuery(long skillId) => (this.SkillId) = (skillId);
    }
}
