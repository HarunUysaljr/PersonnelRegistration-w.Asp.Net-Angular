using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetAngular.Models
{
    public class PersonDetails
    {
        [Key]

        public int PerId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string PerName { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string PerSname { get; set; } = "";
        [Column(TypeName = "nvarchar(10)")]
        public string PerAge { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string PerMail { get; set; } = "";
    }
}
