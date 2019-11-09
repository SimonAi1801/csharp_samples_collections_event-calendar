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

        public int CountEventsForParticipant => _events.Count;

        public string FullName => $"{FirstName} {LastName}";

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

        //public List<Person> GetParticipantsOfEvent(Event ev)
        //{
        //    List<Person> participants = null;
        //    if (_events.Contains(ev))
        //    {
        //        participants = new List<Person>();

        //        foreach (Event myEvent in _events)
        //        {
        //            if (myEvent == ev)
        //            {
        //                participants = myEvent.Participants;
        //                break;
        //            }
        //        }
        //    }
        //    return participants;
        //}

        public int CompareTo(object obj)
        {
            var person = obj as Person;
            int value;

            if (person == null)
            {
                throw new AggregateException("Invalid type!");
            }
            value = CountEventsForParticipant.CompareTo(person.CountEventsForParticipant) * -1;
            if (value == 0)
            {
                value = FullName.CompareTo(person.FullName);
            }
            return value;
        }
    }
}