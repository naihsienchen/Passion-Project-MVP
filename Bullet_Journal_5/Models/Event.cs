using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bullet_Journal_5.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        
        public string Subject { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public bool AllDay { get; set; }
        //how does event interact with calendar? Do I construct a table of calendar for events?
    }


    public class EventDto
    {
        public int EventID { get; set; }
        [DisplayName("Subject")] 
        public string Subject { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        [DisplayName("All Day Event?")]
        public bool AllDay { get; set; }
    }
}