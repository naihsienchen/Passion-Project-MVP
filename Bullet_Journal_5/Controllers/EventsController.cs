using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Windows.Forms;
using Bullet_Journal_5.Models;

namespace Bullet_Journal_5.Controllers
{
    public class EventsController : Controller
    {
        private BulletJournalDBcontext db = new BulletJournalDBcontext();
        // THIS IS NOT THE CUSTOMIZED WAY OF CONNECTING TO THE DATABASE. SEE VARSITY EXAMPLES OF HOW TO CONNECT TO API CONTROLLORS
        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
            //THIS IS WHERE TO CHANGE TO LOOP THROUGH EVENTS AND CREATE MONTHLY VIEW
            //MODULE 7: TAKLKING ABOUT VIEW MODEL
            //SEE ALSO: VARSITY EXAMPLE, DISPLAYING TEAM INFO (WITH MULTIPLE TABLES),
            //SEE ALSO: WIREFRAMINE.PDF FIG 3
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Subject,Description,StartDate,EndDate,AllDay")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,Subject,Description,StartDate,EndDate,AllDay")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

//MonthCalendar example from microsoft documentation
//https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.monthcalendar?view=net-5.0
//HOW DO I:
//1. link this to event database and view
//2. Collect information from my event database and bind them with the monthcalendar class
//3. Display them with a view
/*
public class Calendar : Form
{
    private MonthCalendar monthCalendar1;
    private TextBox textBox1;

    [STAThread]
    static void Main()
    {
        Application.Run(new Calendar());
        
    }
    /*
    public Calendar()
    {
        this.textBox1 = new TextBox();
        this.textBox1.BorderStyle = BorderStyle.FixedSingle;
        this.textBox1.Location = new Point(48, 488);
        this.textBox1.Multiline = true;
        this.textBox1.ReadOnly = true;
        this.textBox1.Size = new Size(824, 32);

        // Create the calendar.
        this.monthCalendar1 = new MonthCalendar();

        // Set the calendar location.
        this.monthCalendar1.Location = new Point(47, 16);

        // Change the color.
        this.monthCalendar1.BackColor = SystemColors.Info;
        this.monthCalendar1.ForeColor = Color.FromArgb(
                                 ((Byte)(192)), ((Byte)(0)), ((Byte)(192)));
        this.monthCalendar1.TitleBackColor = Color.Purple;
        this.monthCalendar1.TitleForeColor = Color.Yellow;
        this.monthCalendar1.TrailingForeColor = Color.FromArgb(
                                 ((Byte)(192)), ((Byte)(192)), ((Byte)(0)));

        // Add dates to the AnnuallyBoldedDates array.
        this.monthCalendar1.AnnuallyBoldedDates =
            new DateTime[] { new DateTime(2002, 4, 20, 0, 0, 0, 0),
                                    new DateTime(2002, 4, 28, 0, 0, 0, 0),
                                    new DateTime(2002, 5, 5, 0, 0, 0, 0),
                                    new DateTime(2002, 7, 4, 0, 0, 0, 0),
                                    new DateTime(2002, 12, 15, 0, 0, 0, 0),
                                    new DateTime(2002, 12, 18, 0, 0, 0, 0)};

        // Add dates to BoldedDates array.
        this.monthCalendar1.BoldedDates = new DateTime[] { new DateTime(2002, 9, 26, 0, 0, 0, 0) };

        // Add dates to MonthlyBoldedDates array.
        this.monthCalendar1.MonthlyBoldedDates =
           new DateTime[] {new DateTime(2002, 1, 15, 0, 0, 0, 0),
                                  new DateTime(2002, 1, 30, 0, 0, 0, 0)};

        // Configure the calendar to display 3 rows by 4 columns of months.
        this.monthCalendar1.CalendarDimensions = new Size(4, 3);

        // Set week to begin on Monday.
        this.monthCalendar1.FirstDayOfWeek = Day.Monday;

        // Set the maximum visible date on the calendar to 12/31/2010.
        this.monthCalendar1.MaxDate = new DateTime(2010, 12, 31, 0, 0, 0, 0);

        // Set the minimum visible date on calendar to 12/31/2010.
        this.monthCalendar1.MinDate = new DateTime(1999, 1, 1, 0, 0, 0, 0);

        // Only allow 21 days to be selected at the same time.
        this.monthCalendar1.MaxSelectionCount = 21;

        // Set the calendar to move one month at a time when navigating using the arrows.
        this.monthCalendar1.ScrollChange = 1;

        // Do not show the "Today" banner.
        this.monthCalendar1.ShowToday = false;

        // Do not circle today's date.
        this.monthCalendar1.ShowTodayCircle = false;

        // Show the week numbers to the left of each week.
        this.monthCalendar1.ShowWeekNumbers = true;

        // Add event handlers for the DateSelected and DateChanged events
        this.monthCalendar1.DateSelected += new DateRangeEventHandler(this.monthCalendar1_DateSelected);
        this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);

        // Set up how the form should be displayed and add the controls to the form.
        this.ClientSize = new Size(920, 566);
        this.Controls.AddRange(new Control[] { this.textBox1, this.monthCalendar1 });
        this.Text = "Month Calendar Example";
    }

    private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
    {
        // Show the start and end dates in the text box.
        this.textBox1.Text = "Date Selected: Start = " +
            e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString();
    }

    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        // Show the start and end dates in the text box.
        this.textBox1.Text = "Date Changed: Start =  " +
            e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString();
    }
    
}*/