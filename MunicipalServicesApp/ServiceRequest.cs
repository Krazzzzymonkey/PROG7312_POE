using System;
using System.Collections.Generic;

public class ServiceRequest : IComparable<ServiceRequest>
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Priority { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public DateTime DateSubmitted { get; set; }

    // List of dependent service requests
    public List<ServiceRequest> Dependencies { get; set; } = new List<ServiceRequest>();

    // Parameterless Constructor
    public ServiceRequest()
    {
    }

    public ServiceRequest(string id, string description, string status, int priority, string category, string location, DateTime dateSubmitted)
    {
        Id = id;
        Description = description;
        Status = status;
        Priority = priority;
        Category = category;
        Location = location;
        DateSubmitted = dateSubmitted;
    }

    public int CompareTo(ServiceRequest other)
    {
        return Id.CompareTo(other.Id);
    }

    public override string ToString()
    {
        return $"{Id}: {Description} - {Status}";
    }
}
