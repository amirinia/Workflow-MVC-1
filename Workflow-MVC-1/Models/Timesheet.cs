using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Workflow_MVC_1.Models
{
    public class Timesheet
    {

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public string Name { get; set; }

            public string IP { get; set; }

            [DataType(DataType.Date)]
            public DateTime StartDay { get; set; }

            public DateTime EndDay { get; set; }

            public TimeSpan GetDifferenceTimes()
            {
                return EndDay - StartDay;
            }

            public string UserId { get; set; }
            public virtual ApplicationUser ApplicationUser { get; set; }

        
    }
}