using System;
using System.Collections.Generic;
using System.Text;

namespace EventCalendar.Entities
{

    /// <summary>
    /// Person kann sowohl zu einer Veranstaltung einladen,
    /// als auch an Veranstaltungen teilnehmen
    /// </summary>
    public class Person : IComparable
    {
        private readonly List<Event> _events;

        public string LastName { get; }
        public string FirstName { get; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int CountEventsForParticipant => _events.Count;

        public Person(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
            _events = new List<Event>();
        }

        public void AddPersonToEvent(Event ev)
        {
            if (!(_events.Contains(ev)))
            {
                _events.Add(ev);
            }
        }

        public void RemovePersonFromEvent(Event ev)
        {
            if (_events.Contains(ev))
            {
                _events.Remove(ev);
            }
        }

        public int CompareTo(object obj)
        {
            var person = obj as Person;
            if (person == null)
            {
                throw new AggregateException("Invalid type!!");
            }
            int value = CountEventsForParticipant.CompareTo(person.CountEventsForParticipant) * -1;
            if (value == 0)
            {
                value = FullName.CompareTo(person.FullName);
            }
            return value;
        }
    }
}