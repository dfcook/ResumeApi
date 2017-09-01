namespace ResumeApi.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Link
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("resume_id")]
        public int ResumeId { get; set; }

        [Column("icon")]
        [MaxLength(50)]
        public string Icon { get; set; }

        [Column("url")]
        [MaxLength(200)]
        public string Url { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }
    }
}
