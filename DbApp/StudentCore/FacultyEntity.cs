using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCore
{
    [Table("Faculty")]
    public class FacultyEntity
    {
        [Key]
        public int FacultyId { get; set; }

        public string FacultyName { get; set; }
    }
}