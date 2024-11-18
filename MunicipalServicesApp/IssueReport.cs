using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ST10067040

namespace MunicipalServicesApp
{
    public class IssueReport : IComparable<IssueReport>
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DateSubmitted { get; set; }
        public List<IssueReport> Dependencies { get; set; } = new List<IssueReport>();

        public List<string> Attachments { get; set; }

        public int CompareTo(IssueReport other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
