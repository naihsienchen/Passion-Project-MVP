### MVP Achievement
1. set up database
2. set up data-processing controller and communicating-channel controller
3. CRUD functionality in MVP (with template provided by VS)

### Pseudo code for next steps
For calendar view
1. auto-generated monthly view
2. when there's an event month matching the month, put the event on the corresponding spot on the calendar.

For event table
1. look up info for: how to present info from the database

### Feb 26 commit

MonthCalendar example from microsoft documentation (not recommended)
https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.monthcalendar?view=net-5.0

HOW DO I:
1. link this to event database and view
2. Collect information from my event database and bind them with the monthcalendar class
3. Display them with a view

### March 4 commit

#### next step suggestions from instructor

1. display events within a particular date range of a month (starttime, endtime)

- SQL
  - select * from events where eventtime > starttime and eventtime < endtime

- LINQ
  - db.events.where(e=>e.eventtime>startime && e.eventtime<endtime)

2. Generate a list of all of the days that appear between starttime and endtime. 
Use much simpler functions like this one https://docs.microsoft.com/en-us/dotnet/api/system.datetime.dayofweek?view=netframework-4.7.2#code-try-1.
Use a loop to count the days between the start of the month (starttime) and the end of the month (endtime). 
On all the dates between this range, and pass them from your controller to your view.

3. Use HTML view to display the calendar
View can describe some HTML for each day. The day can be an HTML div element, with another span element inside to represent which day of the week it is. If there is an event scheduled for that day, you can include that as well.

#### WHERE TO START?
see event controller line 20 for more details. 




