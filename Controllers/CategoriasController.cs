using Microsoft.AspNetCore.Mvc;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

         [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();           
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProduto()
        {
             return _context.Categorias?.Include(p=>p.Produtos).ToList();           
        }


        [HttpGet("{id:int}", Name="ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(p=>p.CategoriaId == id);

            if(categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(categoria);
        }

        [HttpPost]
         public ActionResult<Categoria> Post(Categoria categoria)
         {
            if(categoria is null) return BadRequest();

            _context.Categorias?.Add(categoria);
            _context.SaveChanges();
            
            return new CreatedAtRouteResult("ObterCategoria", new {id = categoria.CategoriaId}, categoria);
         }

         [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)        
        {
            if(id != categoria.CategoriaId) return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)       // Esse <Categoria> não precisaria ai, mas é só pra confirmar que também funciona
        {
            var categoria = _context.Categorias?.FirstOrDefault(p=>p.CategoriaId == id);

            if(categoria == null) return NotFound();

            _context.Categorias?.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }

    }
}