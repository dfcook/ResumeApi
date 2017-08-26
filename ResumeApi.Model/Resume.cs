namespace ResumeApi.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resume
    {
        [Key]
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

        [Column("summary")]
        [MaxLength(100)]
        public string Summary { get; set; }

        public ICollection<KeySkill> KeySkills { get; set; }

        public ICollection<IndustryKnowledge> IndustryKnowledge { get; set; }

        public ICollection<Education> EducationHistory { get; set; }
    }
}