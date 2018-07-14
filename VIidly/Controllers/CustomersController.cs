using System.Collections.Generic;
using System.Data.Entity;//Added to use Include for eager loading
using System.Linq;
using System.Web.Mvc;
using VIidly.Models;
using VIidly.ViewModels;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }

            //Saves the data send back from the form on the DB and makes it persistent
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ViewResult Index()
        {
            //With this we can get all customer from DB
            //Include was used for eager loading to load customers and there MembershipType together
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


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