using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudSach.Models;

namespace CrudSach.Controllers
{
    public class CrudSachController : Controller
    {
        private QuanLySachContextDataContext context = new QuanLySachContextDataContext();

        // GET: CrudSach
        public ActionResult Index()
        {
            List<Book> books = context.Books.ToList();
            return View(books);
        }

        // GET: CrudSach/Details/5
        public ActionResult Details(int id)
        {
            Book books = context.Books.FirstOrDefault();
            return View(books);
        }

        // GET: CrudSach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudSach/Create
        [HttpPost]
        public ActionResult Create(Book books)
        {
            try
            {   // TODO: Add insert logic here
                var newbook = new Book();
                newbook.Title = books.Title;
                newbook.Author = books.Author;
                newbook.PublicYear = books.PublicYear;
                newbook.Price = books.Price;
                context.Books.InsertOnSubmit(newbook);
                context.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrudSach/Edit/5
        public ActionResult Edit(int id)
        {
            Book books = context.Books.Where(x => x.ID == id).FirstOrDefault();
            return View();
        }

        // POST: CrudSach/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book books)
        {
            try
            {
                // TODO: Add update logic here
                Book editbooks = context.Books.Where(u => u.ID == id).SingleOrDefault();
                editbooks.Title = books.Title;
                editbooks.Author = books.Author;
                editbooks.PublicYear = books.PublicYear;
                editbooks.Price = books.Price;
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrudSach/Delete/5
        public ActionResult Delete(int id)
        {
            Book books = context.Books.Where(x => x.ID == id).FirstOrDefault();
            return View();
        }

        // POST: CrudSach/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Book books = context.Books.Where(x => x.ID == id).FirstOrDefault();
                context.Books.DeleteOnSubmit(books);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}