using System.Collections.Generic;
using System.Data.Entity;//Added to use Include for eager loading
using System.Linq;
using System.Web.Mvc;
using VIidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //DB context needs to be initialized in controller
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //_context is disposable and we should always Dispose it. We can do so by overriding the base class Dispose method
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //With this we can get all customer from DB
            //Include was used for eager loading to load customers and there MembershipType together
            var customers = _context.Customers.Include(c =>c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //LINQ SingleOrDefault returns null if not found on classes
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

       
    }
}