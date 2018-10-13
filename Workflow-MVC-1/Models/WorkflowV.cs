using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Workflow_MVC_1.Models;

namespace Workflow_MVC_1.ViewModels
{
    public class WorkflowV
    {
        public int Id { get; set; }
        public string OwnerUser { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        [Required]
        public string TargetUser { get; set; }
        public IEnumerable<ApplicationUser> TargetUsers { get; set; }
        public string ImageUrl { get; set; }
        public Statevm MyState { get; set; }
    }


    public enum Statevm
    {
        Start,
        Inprosses,
        Accept,
        Rejected,
        Done
    }
}