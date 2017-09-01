namespace ResumeApi.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Experience
    {        
        [Column("id")]
        public int Id { get; set; }

        [Column("resume_id")]        
        public int ResumeId { get; set; }

        [Column("from_date")]
        public DateTime? FromDate { get; set; }

        [Column("to_date")]
        public DateTime ToDate { get; set; }

        [Column("role")]
        [MaxLength(100)]
        public string Role { get; set; }

        [Column("company_name")]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Column("location")]
        [MaxLength(100)]
        public string Location { get; set; }

        [JsonIgnore]
        public Resume Resume { get; set; }
    }
}