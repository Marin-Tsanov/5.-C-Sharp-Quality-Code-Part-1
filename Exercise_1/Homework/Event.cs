namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

   public class Event : IComparable<Event>
    {
        public DateTime date;
        public String title;
        public String location;

        public Event(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(Event other)/*(object obj)*/
        {
            //Event other = obj as Event;
            // Default to sort. [Low to high]
            int byDate = this.date.CompareTo(other.date);
            int byTitle = this.title.CompareTo(other.title);
            int byLocation = this.location.CompareTo(other.location);

            //    if (byDate == 0)
            //    {
            //        if (byTitle == 0)
            //        { 
            //            return byLocation;
            //        }

            //        else
            //        {
            //            return byTitle;
            //        }
            //    }
            //    else
            //    { 
            //        return byDate;
            //    }
            //}

            if (byDate != 0)
            {
                return byDate;
            }
            else if (byTitle != 0)
            {
                return byTitle;
            }
            else
            {
                return byLocation;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + title);

            if (location != null && location != "")
            {
                toString.Append(" | " + location);
            }

            return toString.ToString();
        }
    }
}