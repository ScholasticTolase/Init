using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Added
using System.Data.Entity;
using Init.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Init.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            // The Using Statement used

            using (var context = new StaffDbContext())
            {
                //selecting all data input in the database
                var allstaff = (from data in context.Staffs select data).ToList();

                return View(allstaff);
            }
        }
        //GET FOR CREATING STAFF
        public ActionResult CreateStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStaff(Staff new_staff)
        {
            using (var context = new StaffDbContext())
            {
                context.Staffs.Add(new_staff);
                //saving changes
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        //---------------------------
        //          DELETE
        //---------------------------



        public ActionResult DeleteStaff(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new StaffDbContext())
            {
                var staff = context.Staffs.Where(data => data.Id == id).FirstOrDefault();
                return View(staff);
            }

        }

        [HttpPost]
        [ActionName("DeleteStaff")]
        public ActionResult ConfirmDeleteStaff(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new StaffDbContext())
            {
                var value = context.Staffs.Where(data => data.Id == id).FirstOrDefault();
                context.Staffs.Remove(value);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        //-------------------------
        //      Editing
        //-------------------------


        public ActionResult EditStaff(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new StaffDbContext())
            {
                var staff = context.Staffs.Where(data => data.Id == id).FirstOrDefault();
                return View(staff);
            }

        }

        [HttpPost]
        public ActionResult EditStaff(Staff staff)
        {
            using (var context = new StaffDbContext())
            {
                if (staff.Id > 0)
                {
                    // Edit
                    var val = context.Staffs.Where(data => data.Id == staff.Id).FirstOrDefault();
                    if (val != null)
                    {
                        val.Name = staff.Name;
                        val.Age = staff.Age;
                        val.City = staff.City;
                    }
                }
                else
                {
                    //Save
                    context.Staffs.Add(staff);
                }
                context.SaveChanges();

                return RedirectToAction("Index");

            }
        }

        //Details


        public ActionResult StaffDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new StaffDbContext())
            {
                var staff = context.Staffs.Where(data => data.Id == id).FirstOrDefault();
                return View(staff);
            }
        }

    }


}
