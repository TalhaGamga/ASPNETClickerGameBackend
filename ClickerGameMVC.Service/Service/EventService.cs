using ClickerGameMVC.Data;
using ClickerGameMVC.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace ClickerGameMVC.Service.Service
{
    public class EventService
    {
        private readonly ApplicationDbContext _dbContext;
        public EventService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Event[] GetAllForUser(string email)
        {
            var user = _dbContext.Users.
                FirstOrDefault(user => user.Email == email);

            return _dbContext.Events
                .Include(ev => ev.UserEvents)
                .Where(e => e.UserEvents.FirstOrDefault(ue => ue.UserId == user.Id) != null).ToArray();
        }

        public Event GetByLetterId(string letterId)
        {
            return _dbContext.Events
                .Include(e => e.UserEvents)
                .FirstOrDefault(e => e.LetterId == letterId);
        }

        public Event Create(Event model)
        {
            var generatedLetterId = IdGenerator.CreateLetterId(6);
            var existWithId = GetByLetterId(generatedLetterId);

            while (existWithId != null)
            {
                generatedLetterId = IdGenerator.CreateLetterId(6);
                existWithId = GetByLetterId(generatedLetterId);
            }

            model.LetterId = generatedLetterId;
            var eventEntity = _dbContext.Events.Add(model);
            _dbContext.SaveChanges();

            return eventEntity.Entity;
        }

        public Event Update(Event model)
        {
            var eventEntity = _dbContext.Events
                .Include(ev => ev.UserEvents)
                .FirstOrDefault(c => c.LetterId == model.LetterId);

            if (eventEntity != null)
            {
                eventEntity.Title = model.Title != null ? model.Title : eventEntity.Title;
                eventEntity.Date = model.Date != null ? model.Date : eventEntity.Date;
                eventEntity.Category = model.Category != null ? model.Category :
                    eventEntity.Category;

                eventEntity.UserEvents = model.UserEvents.Count! > 0 ? model.UserEvents :// Take a control
                    eventEntity.UserEvents;
                _dbContext.SaveChanges();
            }

            return eventEntity;
        }

        public Event Delete(string letterId)
        {
            var eventEntity = GetByLetterId(letterId);

            if (eventEntity != null)
            {
                _dbContext.Events.Remove(eventEntity);
                _dbContext.SaveChanges();
            }

            return eventEntity;
        }
    }
}