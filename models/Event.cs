using System;
namespace api.models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string EventDeets { get; set; }
        public int OrgId { get; set; }
        public Boolean EventDraft { get; set; }
        public Boolean EventPending { get; set; }
        public Boolean EventApproved { get; set; }
        public int UserId { get; set; }
    }
}