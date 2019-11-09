using System;
using System.Collections.Generic;

namespace EventCalendar.Entities
{
    public class Event
    {
        private Person _invitor;
        private string _title;
        private DateTime _dateTime;
        protected readonly List<Person> _participants;

        public int Count => _participants.Count;
        public string Title => _title;
        public List<Person> Participants => _participants;

        public Event(Person invitor, string title, DateTime dateTime)
        {
            _invitor = invitor;
            _title = title;
            _dateTime = dateTime;
            _participants = new List<Person>();
        }

        public bool AddParticipant(Person participant)
        {
            bool isAble = false;
            if (!(_participants.Contains(participant)) && IsAddToEventValid())
            {
                _participants.Add(participant);
                isAble = true;
            }
            return isAble;
        }

        public bool RemoveParticipant(Person participant)
        {
            bool isAble = false;
            if (_participants.Contains(participant))
            {
                _participants.Remove(participant);
                isAble = true;
            }
            return isAble;
        }

        public bool IsPersonContainedInList(Person person)
        {
            return _participants.Contains(person);
        }

        protected virtual bool IsAddToEventValid()
        {
            return true;
        }
    }
}
