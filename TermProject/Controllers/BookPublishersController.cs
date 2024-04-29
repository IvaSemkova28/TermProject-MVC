using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Data;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class BookPublishersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookPublishersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookPublishers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookPublisher.ToListAsync());
        }

        // GET: BookPublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPublisher = await _context.BookPublisher
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookPublisher == null)
            {
                return NotFound();
            }

            return View(bookPublisher);
        }

        // GET: BookPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,PublisherID")] BookPublisher bookPublisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPublisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookPublisher);
        }

        // GET: BookPublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPublisher = await _context.BookPublisher.FindAsync(id);
            if (bookPublisher == null)
            {
                return NotFound();
            }
            return View(bookPublisher);
        }

        // POST: BookPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,PublisherID")] BookPublisher bookPublisher)
        {
            if (id != bookPublisher.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPublisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPublisherExists(bookPublisher.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookPublisher);
        }

        // GET: BookPublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPublisher = await _context.BookPublisher
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (bookPublisher == null)
            {
                return NotFound();
            }

            return View(bookPublisher);
        }

        // POST: BookPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPublisher = await _context.BookPublisher.FindAsync(id);
            if (bookPublisher != null)
            {
                _context.BookPublisher.Remove(bookPublisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPublisherExists(int id)
        {
            return _context.BookPublisher.Any(e => e.BookID == id);
        }
    }
}
