using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.StaticManagers
{
    public static class DateExtension
    {
        public static string ToRelativeDate(this DateTime dateTime)
        {
            var timeSpan = DateTime.UtcNow - dateTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
                return string.Format("{0} seconds ago", timeSpan.Seconds);

            if (timeSpan <= TimeSpan.FromMinutes(60))
                return timeSpan.Minutes > 1 ? String.Format("{0} minutes ago", timeSpan.Minutes) : "about a minute ago";

            if (timeSpan <= TimeSpan.FromHours(24))
                return timeSpan.Hours > 1 ? String.Format("{0} hours ago", timeSpan.Hours) : "about an hour ago";

            if (timeSpan <= TimeSpan.FromDays(30))
                return timeSpan.Days > 1 ? String.Format("{0} days ago", timeSpan.Days) : "yesterday";

            if (timeSpan <= TimeSpan.FromDays(365))
                return timeSpan.Days > 30 ? String.Format("{0} months ago", timeSpan.Days / 30) : "about a month ago";

            return timeSpan.Days > 365 ? String.Format("{0} years ago", timeSpan.Days / 365) : "about a year ago";
        }


        public static string ConvertDateToFull(DateTime dateTime)
        {
            if(dateTime != null)
            {
                string day;
                string month;

                switch (dateTime.Month)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                    default:
                        month = "";
                        break;
                }



                switch (dateTime.Day)
                {
                    case 1:
                    case 21:
                    case 31:
                        day = dateTime.Day.ToString() + "st";
                        break;
                    case 2:
                    case 22:
                        day = dateTime.Day.ToString() + "nd";
                        break;
                    case 3:
                    case 23:
                        day = dateTime.Day.ToString() + "rd";
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                        day = dateTime.Day.ToString() + "th";
                        break;
                    default:
                        day = "";
                        break;
                }

                return day + " of " + month + ", " + dateTime.Year.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ConvertDateToShort(DateTime dateTime)
        {
            if (dateTime != null)
            {
                string month;

                switch (dateTime.Month)
                {
                    case 1:
                        month = "Jan.";
                        break;
                    case 2:
                        month = "Feb.";
                        break;
                    case 3:
                        month = "Mar.";
                        break;
                    case 4:
                        month = "Apr.";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "Jun.";
                        break;
                    case 7:
                        month = "Jul.";
                        break;
                    case 8:
                        month = "Aug.";
                        break;
                    case 9:
                        month = "Sept.";
                        break;
                    case 10:
                        month = "Oct.";
                        break;
                    case 11:
                        month = "Nov.";
                        break;
                    case 12:
                        month = "Dec.";
                        break;
                    default:
                        month = "";
                        break;
                }
                return dateTime.Day.ToString() + " " + month + " " + dateTime.Year.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ConvertDateToIdentity(DateTime dateTime)
        {
            if (dateTime != null)
            {
                string month;

                switch (dateTime.Month)
                {
                    case 1:
                        month = "jan";
                        break;
                    case 2:
                        month = "feb";
                        break;
                    case 3:
                        month = "mar";
                        break;
                    case 4:
                        month = "apr";
                        break;
                    case 5:
                        month = "may";
                        break;
                    case 6:
                        month = "jun";
                        break;
                    case 7:
                        month = "jul";
                        break;
                    case 8:
                        month = "aug";
                        break;
                    case 9:
                        month = "sept";
                        break;
                    case 10:
                        month = "oct";
                        break;
                    case 11:
                        month = "nov";
                        break;
                    case 12:
                        month = "dec";
                        break;
                    default:
                        month = "";
                        break;
                }
                return month + dateTime.Year.ToString();
            }
            else
            {
                return string.Empty;
            }
        }


        public static int PercentageProgressBetweenDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > DateTime.UtcNow)
                return 0;
            if (DateTime.UtcNow > endDate)
                return 100;

            int a = (DateTime.UtcNow - startDate).Days;
            int b = (endDate - startDate).Days;
            double c = (double)a / (double)b;
            double percentage = c * 100.0;
            return (int)Math.Round(percentage);
        }
    }
}
