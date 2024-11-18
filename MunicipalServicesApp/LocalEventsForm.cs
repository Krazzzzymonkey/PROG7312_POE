using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        private SortedDictionary<DateTime, List<Event>> events;
        private Dictionary<string, int> categoryPreferences;

        public LocalEventsForm()
        {
            InitializeComponent();
            events = new SortedDictionary<DateTime, List<Event>>();
            categoryPreferences = new Dictionary<string, int>();
            PopulateEventList();
        }

        private void PopulateEventList()
        {
            DateTime today = DateTime.Today;

            AddEvent(new Event("Community Cleanup", "Sanitation", today));
            AddEvent(new Event("Park Trash Removal", "Sanitation", today.AddDays(2)));
            AddEvent(new Event("Beach Cleanup", "Sanitation", today.AddDays(4)));
            AddEvent(new Event("River Cleanup Day", "Sanitation", today.AddDays(6)));
            AddEvent(new Event("Neighborhood Sweeping", "Sanitation", today.AddDays(8)));
            AddEvent(new Event("Recycling Collection Drive", "Sanitation", today.AddDays(10)));

            AddEvent(new Event("Water Conservation Workshop", "Utilities", today.AddDays(1)));
            AddEvent(new Event("Power Saving Tips Seminar", "Utilities", today.AddDays(3)));
            AddEvent(new Event("Water Supply Maintenance", "Utilities", today.AddDays(5)));
            AddEvent(new Event("Electricity Outage Info Session", "Utilities", today.AddDays(7)));
            AddEvent(new Event("Sustainable Energy Fair", "Utilities", today.AddDays(9)));
            AddEvent(new Event("Solar Panel Installation Demo", "Utilities", today.AddDays(11)));

            AddEvent(new Event("Health Awareness Seminar", "Health", today.AddDays(3)));
            AddEvent(new Event("Free Health Screening", "Health", today.AddDays(6)));
            AddEvent(new Event("Vaccination Drive", "Health", today.AddDays(8)));
            AddEvent(new Event("Mental Health Workshop", "Health", today.AddDays(12)));
            AddEvent(new Event("Blood Donation Camp", "Health", today.AddDays(14)));
            AddEvent(new Event("Yoga and Wellness Retreat", "Health", today.AddDays(16)));

            AddEvent(new Event("Recycling Workshop", "Education", today.AddDays(5)));
            AddEvent(new Event("STEM Workshop", "Education", today.AddDays(7)));
            AddEvent(new Event("Literacy Program Launch", "Education", today.AddDays(9)));
            AddEvent(new Event("Coding Bootcamp", "Education", today.AddDays(11)));
            AddEvent(new Event("Library Book Drive", "Education", today.AddDays(13)));
            AddEvent(new Event("Teacher Training Workshop", "Education", today.AddDays(15)));

            AddEvent(new Event("Local Farmers Market", "Community", today.AddDays(2)));
            AddEvent(new Event("Food Festival", "Community", today.AddDays(4)));
            AddEvent(new Event("Craft Fair", "Community", today.AddDays(6)));
            AddEvent(new Event("Charity Run", "Community", today.AddDays(10)));
            AddEvent(new Event("Art Exhibition", "Community", today.AddDays(12)));
            AddEvent(new Event("Night Market", "Community", today.AddDays(14)));
            AddEvent(new Event("Cultural Dance Show", "Community", today.AddDays(18)));

            AddEvent(new Event("Fire Safety Workshop", "Safety", today.AddDays(3)));
            AddEvent(new Event("Emergency Preparedness Fair", "Safety", today.AddDays(5)));
            AddEvent(new Event("CPR Training Session", "Safety", today.AddDays(7)));
            AddEvent(new Event("Traffic Safety Workshop", "Safety", today.AddDays(9)));
            AddEvent(new Event("Neighborhood Watch Info Session", "Safety", today.AddDays(13)));
            AddEvent(new Event("Self-Defense Class", "Safety", today.AddDays(17)));

            AddEvent(new Event("Tech Startup Meetup", "Technology", today.AddDays(2)));
            AddEvent(new Event("AI Workshop", "Technology", today.AddDays(4)));
            AddEvent(new Event("Cybersecurity Awareness", "Technology", today.AddDays(6)));
            AddEvent(new Event("Innovation & Technology Expo", "Technology", today.AddDays(8)));
            AddEvent(new Event("Coding Challenge", "Technology", today.AddDays(12)));
            AddEvent(new Event("Robotics Club Meetup", "Technology", today.AddDays(14)));
        }

        private void AddEvent(Event ev)
        {
            DateTime eventDateOnly = ev.Date.Date;
            if (!events.ContainsKey(eventDateOnly))
            {
                events[eventDateOnly] = new List<Event>();
            }
            events[eventDateOnly].Add(ev);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateEventList();
            UpdateRecommendations();
        }

        private void UpdateEventList()
        {
            string category = cboCategory.SelectedItem?.ToString();
            string searchTerm = txtSearch.Text.ToLower();
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            lstEvents.Items.Clear();

            foreach (var date in events.Keys)
            {
                if (date >= startDate && date <= endDate)
                {
                    foreach (var ev in events[date])
                    {
                        bool matchesCategory = category == "All" || ev.Category == category;
                        bool matchesTitle = ev.Title.ToLower().Contains(searchTerm);

                        if (matchesCategory && matchesTitle)
                        {
                            lstEvents.Items.Add($"{ev.Date.ToShortDateString()} - {ev.Title} ({ev.Category})");

                            if (categoryPreferences.ContainsKey(ev.Category))
                                categoryPreferences[ev.Category]++;
                            else
                                categoryPreferences[ev.Category] = 1;
                        }
                    }
                }
            }

            if (lstEvents.Items.Count == 0)
            {
                lstEvents.Items.Add("No events found for the specified criteria.");
            }
        }

        private void UpdateRecommendations()
        {
            int totalSearchCount = 0;
            foreach (var count in categoryPreferences.Values)
            {
                totalSearchCount += count;
            }

            if (totalSearchCount < 5)
            {
                lblRecommendation.Text = "To get recommendations, please search.";
                return;
            }

            string recommendedCategory = "None";
            int maxCount = 0;

            foreach (var kvp in categoryPreferences)
            {
                if (kvp.Value > maxCount)
                {
                    recommendedCategory = kvp.Key;
                    maxCount = kvp.Value;
                }
            }

            lblRecommendation.Text = $"Recommended Category: {recommendedCategory}";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            UpdateEventList();
            UpdateRecommendations();
        }
    }
}
