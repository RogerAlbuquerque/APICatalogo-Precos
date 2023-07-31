using Microsoft.EntityFrameworkCore;
using APICatalogo.Models;
/*
Essa classe herda da classe "DbContext" que é uma classe do EF, e é justamente nela que é feito o mapeamento de dados e das tabelas, porque nesse classe vão ser criados parâmetros que vão ser tipados com as classes vindas de Models, que represeantam as estruras das tabelas.

Uma instância dessa classe, representa uma sessão de comunicação com o banco de dados, ou seja, apartir de uma instância é possível manipular os dados do banco, criar, deletar, buscar dados do banco.
*/
namespace APICatalogo.Context
{
    // DbContext vem de dentro do pacote "EntityFrameworkCore" por isso ele foi importado la em cima
    public class AppDbContext : DbContext   
    
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Categoria>? Categorias{get;set;}
        public DbSet<Produto>? Produtos{get;set;}
    }
}