using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ST10067040
namespace MunicipalServicesApp
{
    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Event(string title, string category, DateTime date)
        {
            Title = title;
            Category = category;
            Date = date;
        }
    }
}
