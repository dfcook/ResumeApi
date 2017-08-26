namespace ResumeApi.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class IndustryKnowledge
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("resume_id")]
        public int ResumeId { get; set; }

        [Column("description")]
        [MaxLength(200)]
        public string Description { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }
    }
}