using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MSOTestSolution.Models
{
    public class Cockpit
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Responsible")]
        public string  Responsible { get; set; }
        [DisplayName("Due Date")]
        public DateTime Date { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Progress")]
        public string Progress { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}
