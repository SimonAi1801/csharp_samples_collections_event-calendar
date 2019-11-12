using System;
using System.Collections.Generic;
using System.Text;

namespace EventCalendar.Entities
{

    /// <summary>
    /// Person kann sowohl zu einer Veranstaltung einladen,
    /// als auch an Veranstaltungen teilnehmen
    /// </summary>
    public class Person : IComparable<Person>
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

        int IComparable<Person>.CompareTo(Person other)
        {
            if (other == null)
            {
                throw new AggregateException("Invalid type!!");
            }
            int value;
            if (CountEventsForParticipant.CompareTo(other.CountEventsForParticipant) == 0)
            {
                if (LastName.CompareTo(other.LastName) == 0)
                {
                    return FirstName.CompareTo(other.FirstName);
                }
                else
                {
                    return LastName.CompareTo(other.LastName);
                }
            }
            else
            {
                value = CountEventsForParticipant.CompareTo(other.CountEventsForParticipant) * -1;
            }
            return value;
        }
    }
}