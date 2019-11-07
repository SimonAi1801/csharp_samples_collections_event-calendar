using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using EventCalendar.Entities;
using static System.String;

namespace EventCalendar.Logic
{
    public class Controller
    {
        private readonly ICollection<Event> _events;
        public int EventsCount => _events.Count;

        public Controller()
        {
            _events = new List<Event>();
        }

        /// <summary>
        /// Ein Event mit dem angegebenen Titel und dem Termin wird für den Einlader angelegt.
        /// Der Titel muss innerhalb der Veranstaltungen eindeutig sein und das Datum darf nicht
        /// in der Vergangenheit liegen.
        /// Mit dem optionalen Parameter maxParticipators kann eine Obergrenze für die Teilnehmer festgelegt
        /// werden.
        /// </summary>
        /// <param name="invitor"></param>
        /// <param name="title"></param>
        /// <param name="dateTime"></param>
        /// <param name="maxParticipators"></param>
        /// <returns>Wurde die Veranstaltung angelegt</returns>
        public bool CreateEvent(Person invitor, string title, DateTime dateTime, int maxParticipators = 0)
        {
            bool isCreated = false;
            if (invitor == null || title == null || title.Length < 1)
            {
                return false;
            }

            if (DateTime.Now < dateTime && GetEvent(title) == null)
            {
                isCreated = true;
                if (maxParticipators == 0)
                {
                    Event newEvent = new Event(invitor, title, dateTime);
                    _events.Add(newEvent);
                }
                else
                {
                    Event newEvent = new EventWithDetails(invitor, title, dateTime, maxParticipators);
                    _events.Add(newEvent);
                }
            }
            return isCreated;
        }

        /// <summary>
        /// Liefert die Veranstaltung mit dem Titel
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Event oder null, falls es keine Veranstaltung mit dem Titel gibt</returns>
        public Event GetEvent(string title)
        {
            Event myEvent = null;
            foreach (Event item in _events)
            {
                if (title == item.Title)
                {
                    myEvent = item;
                    break;
                }
            }
            return myEvent;
        }

        /// <summary>
        /// Person registriert sich für Veranstaltung.
        /// Eine Person kann sich zu einer Veranstaltung nur einmal registrieren.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="ev">Veranstaltung</param>
        /// <returns>War die Registrierung erfolgreich?</returns>
        public bool RegisterPersonForEvent(Person person, Event ev)
        {
            bool isRegisterd = false;
            if (ev != null && person != null)
            {
                if (GetEvent(ev.Title) == ev)
                {
                    isRegisterd = ev.AddParticipant(person);
                }
            }
            return isRegisterd;
        }

        /// <summary>
        /// Person meldet sich von Veranstaltung ab
        /// </summary>
        /// <param name="person"></param>
        /// <param name="ev">Veranstaltung</param>
        /// <returns>War die Abmeldung erfolgreich?</returns>
        public bool UnregisterPersonForEvent(Person person, Event ev)
        {
            bool isUnregistered = false;
            if (ev != null && person != null)
            {
                if (GetEvent(ev.Title) == ev)
                {
                   isUnregistered = ev.RemoveParticipant(person);
                }
            }
            return isUnregistered;
        }

        /// <summary>
        /// Liefert alle Teilnehmer an der Veranstaltung.
        /// Sortierung absteigend nach der Anzahl der Events der Personen.
        /// Bei gleicher Anzahl nach dem Namen der Person (aufsteigend).
        /// </summary>
        /// <param name="ev"></param>
        /// <returns>Liste der Teilnehmer oder null im Fehlerfall</returns>
        public IList<Person> GetParticipatorsForEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liefert alle Veranstaltungen der Person nach Datum (aufsteigend) sortiert.
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Liste der Veranstaltungen oder null im Fehlerfall</returns>
        public List<Event> GetEventsForPerson(Person person)
        {
            List<Event> events = new List<Event>();

            return events;
        }

        /// <summary>
        /// Liefert die Anzahl der Veranstaltungen, für die die Person registriert ist.
        /// </summary>
        /// <param name="participator"></param>
        /// <returns>Anzahl oder 0 im Fehlerfall</returns>
        public int CountEventsForPerson(Person participator)
        {
            throw new NotImplementedException();
        }
    }
}
