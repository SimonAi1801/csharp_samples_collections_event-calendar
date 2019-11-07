using System;
using System.Collections.Generic;
using System.Text;

namespace EventCalendar.Entities
{

    /// <summary>
    /// Person kann sowohl zu einer Veranstaltung einladen,
    /// als auch an Veranstaltungen teilnehmen
    /// </summary>
    public class Person
    {
        private readonly List<Event> _events;

        public string LastName { get; }
        public string FirstName { get; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public int CountEventsForParticipant => _events.Count;

        public Person(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
            _events = new List<Event>();
        }

        public void AddpersonToEvent(Event ev)
        {
            if (!(_events.Contains(ev)))
            {
                _events.Add(ev);
            }
        }
    }
}