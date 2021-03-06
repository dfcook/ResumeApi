﻿namespace ResumeApi.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resume
    {        
        [Column("id")]
        public int Id { get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Column("first_name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column("company_name")]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Column("role")]
        [MaxLength(100)]
        public string Role { get; set; }

        [Column("summary")]
        [MaxLength(1000)]
        public string Summary { get; set; }

        public ICollection<KeySkill> KeySkills { get; set; }

        public ICollection<IndustryKnowledge> IndustryKnowledge { get; set; }

        public ICollection<Education> EducationHistory { get; set; }

        public ICollection<Experience> CareerExperience { get; set; }

        public ICollection<Link> Links { get; set; }
    }
}