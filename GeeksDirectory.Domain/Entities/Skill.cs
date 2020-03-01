﻿#nullable disable

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AverageScore { get; set; }

        public List<Assessment> Assessments { get; set; }

        public int ProfileId { get; set; }

        public GeekProfile Profile { get; set; }
    }
}
