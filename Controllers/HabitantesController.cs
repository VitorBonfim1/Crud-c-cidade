using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudCidade.Models;

namespace crudCidade.Controllers
{
    public class HabitantesController : Controller
    {
        private readonly HabitanteContexto _context;

        public HabitantesController(HabitanteContexto context)
        {
            _context = context;
        }

        // GET: Habitantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habitantes.ToListAsync());
        }

         public async Task<IActionResult> Lista()
        {
            return View(await _context.Habitantes.Where(m=>m.Idade>60).ToListAsync());
        }

         public async Task<IActionResult> Lista2()
        {
            return View(await _context.Habitantes.Where(m=>m.Idade<18).ToListAsync());
        }

    


       

        

        // GET: Habitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitantes = await _context.Habitantes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (habitantes == null)
            {
                return NotFound();
            }

            return View(habitantes);
        }

        // GET: Habitantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Sobrenome,Sexo,Idade")] Habitantes habitantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitantes);
        }

        // GET: Habitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitantes = await _context.Habitantes.FindAsync(id);
            if (habitantes == null)
            {
                return NotFound();
            }
            return View(habitantes);
        }

        // POST: Habitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Sobrenome,Sexo,Idade")] Habitantes habitantes)
        {
            if (id != habitantes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitantesExists(habitantes.ID))
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
            return View(habitantes);
        }

        // GET: Habitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitantes = await _context.Habitantes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (habitantes == null)
            {
                return NotFound();
            }

            return View(habitantes);
        }

        // POST: Habitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitantes = await _context.Habitantes.FindAsync(id);
            _context.Habitantes.Remove(habitantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitantesExists(int id)
        {
            return _context.Habitantes.Any(e => e.ID == id);
        }
    }
}
