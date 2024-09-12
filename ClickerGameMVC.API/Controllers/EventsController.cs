using AutoMapper;
using ClickerGameMVC.Common.Models;
using ClickerGameMVC.Entity.Entities;
using ClickerGameMVC.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.API.Controllers
{
    public class EventsController : Controller
    {
        AuthService _authService;
        EventService _eventService;
        IMapper _mapper;

        public EventsController(EventService eventService, AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<EventBindingModel[]> GetAll()
        {
            try
            {
                var userEmail = _authService.DecodeEmailFromToken(this.Request.Headers["Authorization"]);
                var events = _eventService.GetAllForUser(userEmail);
                return Ok(_mapper.Map<Event[], EventBindingModel[]>(events));
            }

            catch (Exception error)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Event> GetById(string id)
        {
            try
            {
                var eventEntity = _eventService.GetByLetterId(id);

                if (eventEntity != null)
                {
                    return Ok(eventEntity);
                }

                return NotFound();
            }
            catch (Exception error)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult<Event> Create(EventInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedModel = _mapper.Map<EventInputModel,
                        Event>(model);
                    var eventEntity = _eventService.Create(mappedModel);

                    return Ok(eventEntity);
                }

                return BadRequest(ModelState);
            }

            catch (Exception error)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult<Event> Update(EventInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedModel = _mapper.Map<EventInputModel, Event>(model);
                    var eventEntity = _eventService.Update(mappedModel);

                    if (eventEntity != null)
                    {
                        return Ok(eventEntity);
                    }

                    return NotFound();
                }

                return BadRequest(ModelState);
            }
            catch (Exception error)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Event> Delete(string id)
        {
            try
            {
                var eventEntity = _eventService.Delete(id);

                if (eventEntity != null)
                {
                    return Ok(eventEntity);
                }

                return NotFound();
            }

            catch (Exception error)
            {
                return StatusCode(500);
            }
        }
    }
}