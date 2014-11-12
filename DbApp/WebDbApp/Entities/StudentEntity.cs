using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDbApp.Entities
{
    [Table("Students")]
    public class StudentEntity
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int FacultyId { get; set; }

        public decimal OveralMark { get; set; }
    }
}