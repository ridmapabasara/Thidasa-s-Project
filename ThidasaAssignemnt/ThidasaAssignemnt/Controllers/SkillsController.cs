using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThidasaAssignemnt.DbContext;

namespace ThidasaAssignemnt.Controllers
{
    public class SkillsController : Controller
    {
        ThidasaDbEntities Db = new ThidasaDbEntities();


        // GET: Skills
        public ActionResult Index()
        {
            List<Skill> model = new List<Skill>();

            foreach (var item in Db.Skills)
            {
                Skill skill = new Skill();
                skill.SkillName = item.SkillName;
                skill.Id = item.Id;
                model.Add(skill);
            }
           
            return View(model);
        }

      
        

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        public ActionResult Create(Skill Model)
        {
            Db.Skills.Add(Model);
            Db.SaveChanges();
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

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            Skill toBeEdited = Db.Skills.Find(id);
            return View(toBeEdited);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public ActionResult Edit(Skill model)
        {
            Skill toBeEdited = Db.Skills.Find(model.Id);

            toBeEdited.SkillName = model.SkillName;
            Db.Entry(toBeEdited).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();




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

        // GET: Skills/Delete/5
        public ActionResult Delete(int id)
        {

            Skill toBeDeleted = Db.Skills.Find(id);
            return View(toBeDeleted);
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public ActionResult Delete(Skill model)
        {
            Skill toBeEdited = Db.Skills.Find(model.Id);

            toBeEdited.SkillName = model.SkillName;
            Db.Skills.Remove(toBeEdited);
            Db.SaveChanges();

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
