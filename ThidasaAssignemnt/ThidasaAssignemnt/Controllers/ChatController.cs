using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThidasaAssignemnt.DbContext;
using ThidasaAssignemnt.Models;

namespace ThidasaAssignemnt.Controllers
{
    public class ChatController : Controller
    {
        public ChatController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public ChatController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }


        public UserManager<ApplicationUser> UserManager { get; private set; }
        ThidasaDbEntities Db = new ThidasaDbEntities();
        // GET: Chat
        public ActionResult ChatIndex()
        {
            Sendchat model = new Sendchat();
            List<ViewChatSent> chatmodellist = new List<ViewChatSent>();
            List<ViewChatRecieved> chatmodellist2 = new List<ViewChatRecieved>();
            foreach (var item in Db.Chats)
            {
                var userId = User.Identity.GetUserId();
                if (item.SenderId==userId)
                {
                    ViewChatSent chatmodel = new ViewChatSent();
                    chatmodel.Msg = item.Msg;
                    chatmodel.Name = Db.AspNetUsers.Find(item.RecieverId).UserName;
                    chatmodellist.Add(chatmodel);
                }
                if (item.RecieverId == userId)
                {
                    ViewChatRecieved chatmodel = new ViewChatRecieved();
                    chatmodel.Msg = item.Msg;
                    chatmodel.Name = Db.AspNetUsers.Find(item.SenderId).UserName;
                    chatmodellist2.Add(chatmodel);
                }

            }

            List<SelectListItem> itemnamelist = new List<SelectListItem>();
            foreach (var item in Db.AspNetUsers)
            {
                SelectListItem selectmodel = new SelectListItem();
                selectmodel.Text = item.UserName;
                string EmployeeId = item.Id;
                selectmodel.Value = EmployeeId;
                itemnamelist.Add(selectmodel);

            }
            model.EmployeeList = itemnamelist;

            model.ChatRecieved = chatmodellist2;
            model.ChatSent = chatmodellist;

            return View(model);
        }
        [HttpPost]
        [ActionName("ChatIndex")]
        public ActionResult SentChatPost(Sendchat model)
        {
            var userId = User.Identity.GetUserId();
            Chat dbmodel = new Chat();
            dbmodel.SenderId = userId;
            dbmodel.RecieverId = model.EmployeeId;
            dbmodel.Msg = model.Msg;
            Db.Chats.Add(dbmodel);
            Db.SaveChanges();
            return RedirectToAction("ChatIndex", "Chat");
       
        }
        public ActionResult RecievedChat()
        {
            return View();
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
