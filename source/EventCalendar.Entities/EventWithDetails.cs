using System;
using System.Collections.Generic;
using System.Text;

namespace EventCalendar.Entities
{
    public class EventWithDetails : Event
    {
        private int _maxParticipation;
        public EventWithDetails(Person invitor, string title, DateTime dateTime, int maxParticipation)
            : base(invitor, title, dateTime)
        {
            _maxParticipation = maxParticipation;
        }

        protected override bool IsAddToValid()
        {
            bool isAble = false;
            if (_participants.Count + 1 <= _maxParticipation)
            {
                isAble = true;
            }
            return isAble;
        }
    }
}
