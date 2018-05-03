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

    public class UserController : Controller
    {
        public UserController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public UserController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }


        public UserManager<ApplicationUser> UserManager { get; private set; }
        ThidasaDbEntities Db = new ThidasaDbEntities();
        // GET: User
        public ActionResult ViewDetails()
        {
            var userId = User.Identity.GetUserId();
            ViewEmployeeDetails model = new ViewEmployeeDetails();
            List<QualificationsOfEmployee> Qlist = new List<QualificationsOfEmployee>();
            List<String> Slist = new List<String>();
            foreach (var item in Db.QualificationsOfEmployees.Where(x=>x.EmpId==userId))
            {
          Qlist.Add(item);

            }

            foreach (var item in Db.UserSkills.Where(x => x.UserId == userId))
            {
               Slist.Add(Db.Skills.Find(item.SkillId).SkillName);

            }
            List<String> Clist = new List<string>();
            foreach (var item in Db.feedbacks.Where(x => x.EmpId == userId))
            {
                Clist.Add(item.Comment);

            }
            model.Qualifications = Qlist;
            model.Skills = Slist;
            model.Comments = Clist;
            model.Name = Db.AspNetUsers.Find(userId).UserName;

            return View(model);
        }

        // GET: User/Details/5
        public ActionResult AddSkills()
        {
            List<AddSkills> model = new List<AddSkills>();

            foreach (var item in Db.Skills)
            {
                AddSkills skill = new AddSkills();
                skill.SkillName = item.SkillName;
                skill.Id = item.Id;
                model.Add(skill);
            }

            return View(model);
          
        }
        [HttpPost]
        [ActionName("AddSkills")]
        public ActionResult AddSkillsPost(List<AddSkills> modelList)
        {
            var userId = User.Identity.GetUserId();
            foreach (var item in modelList)
            {
                if (item.Add==true)
                {
                    UserSkill userskill = new UserSkill();
                    userskill.SkillId = item.Id;
                    userskill.UserId = userId;
                    Db.UserSkills.Add(userskill);
                }
            }
            Db.SaveChanges();


            return View();

        }

        // GET: User/Create
        public ActionResult AddQualifications()
        {


            return View();
        }
        [HttpPost]
        [ActionName("AddQualifications")]
        public ActionResult AddQualificationsPost(QualificationsOfEmployee model)
        {
            var userId = User.Identity.GetUserId();

            model.EmpId = userId;
            Db.QualificationsOfEmployees.Add(model);
            Db.SaveChanges();



            return RedirectToAction("ViewDetails", "User");
        }

        public ActionResult GiveFeedBack()
        {
            FeedBack model = new FeedBack();
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


            return View(model);
        }
        [HttpPost]
        [ActionName("GiveFeedBack")]
        public ActionResult GiveFeedBacPost(FeedBack model)
        {
            feedback contextModel = new feedback();
            contextModel.EmpId = model.EmployeeId;
            contextModel.Comment = model.Comment;
            contextModel.ClientId = User.Identity.GetUserId();
            Db.feedbacks.Add(contextModel);
            Db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



    }
}
