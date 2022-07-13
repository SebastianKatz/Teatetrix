using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTeatro.Context;
using ProyectoTeatro.Models;

namespace ProyectoTeatro.Controllers
{
    public class ObraController : Controller
    {
        private readonly TeatroDbContext _context;

        public ObraController(TeatroDbContext context)
        {
            _context = context;
        }

        // GET: Obra
        public async Task<IActionResult> Index()
        {
            return View(await _context.Obras.ToListAsync());
        }

        // GET: Obra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .FirstOrDefaultAsync(m => m.IdObra == id);
            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.Id == obra.IdSala);
            if (obra == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.capacidadSala = sala.CapacidadMax - obra.Participantes;
            }
            return View(obra);
        }

        // GET: Obra/Create
        public IActionResult Create()
        {
            var _missalas = new SelectList(_context.Salas.ToList(), "Id", "Nombre", null);
            ViewBag.MisSalas = _missalas;
            return View();
        }

        // POST: Obra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObra,Nombre,Fecha,IdSala")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                obra.Participantes = 0;
                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obra);
        }

        // GET: Obra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            return View(obra);
        }

        // POST: Obra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObra,Nombre,Fecha,IdSala")] Obra obra)
        {
            if (id != obra.IdObra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.IdObra))
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
            return View(obra);
        }

        // GET: Obra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .FirstOrDefaultAsync(m => m.IdObra == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // POST: Obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id)
        {
            return _context.Obras.Any(e => e.IdObra == id);
        }

        // POST: Obra/Reservar
        public async Task<IActionResult> EfectuarReserva(int? id, int cantidadEntradas)
        {
            var obra = await _context.Obras
                .FirstOrDefaultAsync(m => m.IdObra == id);
            if (obra == null)
            {
                return NotFound();
            }
            int participantes = obra.Participantes;
            String[] meses = new string[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

            var sala = await _context.Salas.FindAsync(obra.IdSala);
            if (sala == null)
            {
                return NotFound();
            }
            int capacidadSala = sala.CapacidadMax;
            if (participantes + cantidadEntradas <= capacidadSala)
            {
                participantes += cantidadEntradas;
                obra.Participantes = participantes;
                await _context.SaveChangesAsync();
                ViewBag.capacidadSala = capacidadSala - participantes;
                ViewBag.cantidadEntradas = cantidadEntradas;
                ViewBag.dia = Convert.ToDateTime(obra.Fecha).Day;
                ViewBag.mes = meses[Convert.ToDateTime(obra.Fecha).Month - 1];
                ViewBag.hora = Convert.ToDateTime(obra.Fecha).ToShortTimeString();
                ViewBag.nombreObra = obra.Nombre;
                ViewBag.nombreSala = sala.Nombre;
                return View("CompraRealizada", obra);
            }
            else
            {
                ViewBag.mensajeError = "No se puede reservar esa cantidad de entradas";
                return View("CompraDefectuosa", obra);
            }

        }
    }
}