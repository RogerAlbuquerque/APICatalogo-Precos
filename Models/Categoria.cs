using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
    Essa classe é a parte de "Code First" do Entity Framework, que basicamente vai pegar as prpoedades dessa classe, e de acordo com elas criar as linhas e colunas para salvar os dados nas tabelas no banco de dados MySQL utilizando o que é chamado de "Migrations".
*/

namespace APICatalogo.Models;
    [Table("Categorias")]           // Esse aqui não precisaria ja que o EF entende sozinho que isso faz parte da tabela categorias
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        [Key]
        public int CategoriaId { get; set; }    // Se a propriedade for do tipo "int" e no seu nome tiver "Id" no final, o EF vai entender que ela é a primary key

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        
        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos {get;set;}
    }

    //Quando classes só tem propriedades, não tem comportamento, métodos, elas são chamadas de "classes anêmicas".
