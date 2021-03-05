using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bullet_Journal_5.Controllers
{
    public class CalendarController : Controller
    {
        private BulletJournalDBcontext db = new BulletJournalDBcontext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
    }
}
/* steps instruction from Instructor

// display events within a particular date range of a month (starttime, endtime)

SQL
select * from events where eventtime > starttime and eventtime < endtime

LINQ
db.events.where(e=>e.eventtime>startime && e.eventtime<endtime)

// generate a list of all of the days that appear between starttime and endtime. You can use much simpler functions like this one https://docs.microsoft.com/en-us/dotnet/api/system.datetime.dayofweek?view=netframework-4.7.2#code-try-1. You can use a loop to count the days between the start of the month (starttime) and the end of the month (endtime). On all the dates between this range, and pass them from your controller to your view.

// use HTML view to display the calendar
Then, you view can describe some HTML for each day. The day can be an HTML div element, with another span element inside to represent which day of the week it is. If there is an event scheduled for that day, you can include that as well.

I'm looking for you to build out something that is your own with this calendar feature, even if it is a less complete functionality than something you would be able to generate with a pre-built plugin or library.

*/