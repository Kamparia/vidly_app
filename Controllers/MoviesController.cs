using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers {
	public class MoviesController : Controller {
		// GET: /Movies/Random
		public ActionResult Random() {
			var movie = new Movie() { 
				Name = "Shrek", 
				ReleaseDate = "25th October, 2014" 
			};

			var customers = new List<Customer> {
				new Customer { Name = "Somide Olaoye"},
				new Customer { Name = "Bamigbade Toyin"},
				new Customer { Name = "Kalenikanse Temitope"}
			};

			var viewModel = new RandomMovieViewModel {
				Movie = movie,
				Customers = customers
			};
			
			//return View(viewModel);
			//return Content("Hello World!");
			//return HttpNotFound();
			//return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" } ); // redirects to home page with variables
			return Json(new { name = "Somide Olaoye", email = "t.olaoye@yahoo.com" });
		}

		// Creates an action that takes a parameter called ID
		public ActionResult Edit( int id ) {
			return Content("id=" + id);
		}
		
		// Creates an action that takes two optional parameters
		public ActionResult Index( int? pageIndex, string sortBy) {
			if (!pageIndex.HasValue)
				pageIndex = 1;

			if (String.IsNullOrWhiteSpace(sortBy))
				sortBy = "Name";

			return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

		}	

		// creates an action that sorts movies by release date
		public ActionResult ByReleaseDate(int year, int month) {

			return Content(year + "/" + month);
		}
	
	}

}