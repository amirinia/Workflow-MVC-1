using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workflow_MVC_1.Models
{
    public class DownloadFile
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }
}