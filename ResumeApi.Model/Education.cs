namespace ResumeApi.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Education
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("resume_id")]
        public int ResumeId { get; set; }

        [Column("from_year")]
        public int FromYear { get; set; }

        [Column("to_year")]
        public int ToYear { get; set; }

        [Column("establishment")]
        [MaxLength(200)]
        public string Establishment { get; set; }

        [Column("qualifications")]
        [MaxLength(500)]
        public string Qualifications { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }
    }
}