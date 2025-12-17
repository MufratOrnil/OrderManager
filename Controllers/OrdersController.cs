using MasterDetailApp.Models;
using MasterDetailApp.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MasterDetailApp.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Items).ToList();
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View(new OrderViewModel());
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel viewModel, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), imageFile.FileName);
                    imageFile.SaveAs(path);
                    viewModel.Order.ImagePath = "/Images/" + imageFile.FileName;
                }

                db.Orders.Add(viewModel.Order);
                db.SaveChanges();

                foreach (var item in viewModel.Items)
                {
                    item.OrderId = viewModel.Order.Id;
                    db.OrderItems.Add(item);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var order = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
            if (order == null)
                return HttpNotFound();

            var viewModel = new OrderViewModel
            {
                Order = order,
                Items = order.Items.ToList()
            };

            return View(viewModel);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel viewModel, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var orderInDb = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == viewModel.Order.Id);
                if (orderInDb == null)
                    return HttpNotFound();

                orderInDb.CustomerName = viewModel.Order.CustomerName;
                orderInDb.OrderDate = viewModel.Order.OrderDate;
                orderInDb.IsPaid = viewModel.Order.IsPaid;

                if (imageFile != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), imageFile.FileName);
                    imageFile.SaveAs(path);
                    orderInDb.ImagePath = "/Images/" + imageFile.FileName;
                }

                
                foreach (var existingItem in orderInDb.Items.ToList())
                {
                    db.OrderItems.Remove(existingItem);
                }
                db.SaveChanges();

                foreach (var item in viewModel.Items)
                {
                    item.OrderId = orderInDb.Id;
                    db.OrderItems.Add(item);
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var order = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
            if (order == null) return HttpNotFound();

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
            if (order == null) return HttpNotFound();

            db.OrderItems.RemoveRange(order.Items);

            db.Orders.Remove(order);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Orders/GetItems/5
        public ActionResult GetItems(int id)
        {
            var items = db.OrderItems.Where(i => i.OrderId == id).ToList();
            return PartialView("_OrderItemsPartial", items);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
