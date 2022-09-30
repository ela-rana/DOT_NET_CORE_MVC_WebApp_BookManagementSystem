using BookManagementSystem.Models;
using BookManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.Controllers
{
    public class BookController : Controller
    {
        ICRUD crud;
        public BookController(ICRUD crud)
        {
            this.crud = crud;   
        }
        public IActionResult AllBooks()
        {
            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Books = crud.GetRecords();
            return View(bookViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(long? ISBN)
        {
            Book? b = crud.GetRecord(ISBN);
            if (b == null)
                return NotFound();
            return View(b);
        }
        public IActionResult Edit(long? ISBN)
        {
            Book? b = crud.GetRecord(ISBN);
            if (b == null)
                return NotFound();
            return View(b);
        }
        public IActionResult Delete(long? ISBN)
        {
            Book? b = crud.GetRecord(ISBN);
            if (b == null)
                return NotFound();
            return View(b);
        }
    }
}
