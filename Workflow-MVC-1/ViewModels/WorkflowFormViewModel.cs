using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workflow_MVC_1.ViewModels
{
    public class WorkflowFormViewModel
    {
        public string OwnerUser { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public int TargetUser { get; set; }
        public IEnumerable<Models.ApplicationUser> TargetUsers { get; set; }
        public string ImageUrl { get; set; }
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