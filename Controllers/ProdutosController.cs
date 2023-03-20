using Microsoft.AspNetCore.Mvc;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var Produtos = _context.Produtos?.ToList();
                if(Produtos is null)
                {
                    return NotFound("Produtos não encontrados");
                }
            
            return Produtos;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var Produto = _context.Produtos?.FirstOrDefault(p=>p.ProdutoId == id);
            if (Produto is null)
            {
                return NotFound("Produtos não encontrados");
            }

            return Produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if(produto is null)
            {return BadRequest("Produto não encontrado");}
            _context.Produtos?.Add(produto);							// "Produto" é o model "produto" é o objeto
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new {id = produto.ProdutoId}, produto);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Id do produto não corresponde");
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos?.FirstOrDefault(p=> p.ProdutoId == id);
            
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Produtos?.Remove(produto);  // Isso aqui no caso de deleted é tipo como se estivesse marcando o produto a ser deletado com uma flag "Deleted" 
            _context.SaveChanges();
            return Ok(produto);
        }
    }
}