using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Workflow_MVC_1.Models
{
    public class Workflow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string OwnerUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Name { get; set; }
        public string Context { get; set; }

        public DateTime StartDate {get; set;}

        [Required]
        public string TargetUser { get; set; }
        public virtual ApplicationUser TargetUser1 { get; set; }

        public List<ApplicationUser> MyUsers { get; set; }


        public enum State
        {
            Start,
            Inprosses,
            Done
        }
    }
}