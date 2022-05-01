using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Web.Data;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Controllers
{
    public class DuenosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DuenosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Duenos
        public async Task<IActionResult> Index()
        {
            return View(await _context.duenos.ToListAsync());
        }

        // GET: Duenos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.duenos
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // GET: Duenos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duenos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Documento,Nombre,Direccion,Telefono,Correo,Barrio")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                try
                {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException) { 
                    if (dbUpdateException.InnerException.Message.Contains("duplicate")) { 
                        ModelState.AddModelError(string.Empty, "Ya hay un registro con el mismo documento."); 
                    } else { 
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); 
                    } 
                }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(dueno);
        }

        // GET: Duenos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.duenos.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            return View(dueno);
        }

        // POST: Duenos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Documento,Nombre,Direccion,Telefono,Correo,Barrio")] Dueno dueno)
        {
            if (id != dueno.Documento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            { try 
                { _context.Update(dueno); 
                    await _context.SaveChangesAsync(); 
                    return RedirectToAction(nameof(Index)); 
                } catch (DbUpdateException dbUpdateException) 
                { 
                    if (dbUpdateException.InnerException.Message.Contains("duplicate")) 
                    { 
                        ModelState.AddModelError(string.Empty, "Ya hay un registro con el mismo documento."); 
                    } 
                    else 
                    { 
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); 
                    } 
                } catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); 
                } 
            }
            return View(dueno);
        }

        // GET: Duenos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) { 
                return NotFound(); 
            }
            Dueno dueno = await _context.duenos.FirstOrDefaultAsync(m => m.Documento == id); 
            if (dueno == null) { 
                return NotFound(); 
            }
            _context.duenos.Remove(dueno); 
            await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(string id)
        {
            return _context.duenos.Any(e => e.Documento == id);
        }
    }
}
