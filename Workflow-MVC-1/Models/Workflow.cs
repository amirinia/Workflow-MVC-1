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

        [DataType(DataType.Date)]
        public DateTime StartDate {get; set;}

        [Required]
        public string TargetUserId { get; set; }
        public virtual ApplicationUser TargetUser { get; set; }

        public List<ApplicationUser> TargetUsers { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public State MyState { get; set; }


    }


    public enum State
    {
        Start,
        Inprosses,
        Accept,
        Rejected,
        Done
    }
}