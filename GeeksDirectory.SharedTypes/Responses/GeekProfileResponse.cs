﻿using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Responses
{
    public class GeekProfileResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string FullName
        {
            get
            {
                return string.IsNullOrEmpty(this.MiddleName) ?
                    $"{this.Name} {this.Surname}" :
                    $"{ this.Name} { this.MiddleName} { this.Surname}";
            }
        }

        public string City { get; set; }

        public IEnumerable<SkillResponse> Skills { get; set; }
    }
}