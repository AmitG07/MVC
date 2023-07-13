using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagement.Context;
using EventManagement.Models;
using EventManagement.Controllers;

using System.Web.Security;
namespace EventManagement.Controllers
{
    public class EventController : Controller
    {
        LoginContext entity=new LoginContext();
        public EventController()
        {
        }
        public EventController(LoginContext _entity)
        {
            entity = _entity;
        }
        
        // GET: Event
        public ActionResult Index()
        {
            var userId=HttpContext.Session["UserID"].ToString();
            if (userId!=null)
            {
                var events = entity.Events.Where(u => u.UserId.Equals(userId)).ToList();
                return View(events);
            }
            else
            {
                Session.Clear();
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
        }
        
        public ActionResult EventInvitedTo()
        {

            var userId = HttpContext.Session["UserID"];
            int uid = Convert.ToInt32(userId);
            var user = entity.Users.Where(u => u.Id.Equals(uid)).FirstOrDefault();
            List<EventModel> EventsInvited=new List<EventModel>();
            foreach(var item in entity.Events)
            {
                List<string> l=item.InviteByEmail.Split(';').ToList();
                if(l.Contains(user.Email))
                {
                    EventsInvited.Add(item);
                }
            }
            return View(EventsInvited);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventModel anEvent)
        {
            if (ModelState.IsValid)
            {

                anEvent.UserId=HttpContext.Session["UserID"].ToString();
                entity.Events.Add(anEvent);
                entity.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(anEvent);
        }
        public ActionResult Edit(int id)
        {
            var events = entity.Events.Where(e => e.EventID == id).FirstOrDefault();

            return View(events);
        }

        [HttpPost]
        public ActionResult Edit(EventModel e)
        {
            var ev = entity.Events.Where(u => u.EventID.Equals(e.EventID)).FirstOrDefault();
            if (ev == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                entity.Events.Remove(ev);
                entity.Events.Add(e);
                entity.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        public ActionResult Details(int id)
        {
            var obj = entity.Events.Where(e => e.EventID.Equals(id)).FirstOrDefault();
            if(obj==null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }
        public ActionResult CreateComment(int EventID,string Comment )
        {
            
            
            var eventCommented = entity.Events.Where(u => u.EventID == EventID).FirstOrDefault();
            if(ModelState.IsValid){
                string newComment = "";
                if (eventCommented.CommentAdded==null)
                { newComment =Comment; }
                else
                {
                    newComment =";"+ Comment;
                }

                eventCommented.CommentAdded += newComment;
                entity.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}