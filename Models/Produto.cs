using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APICatalogo.Models;

/*
    Essa classe é a parte de "Code First" do Entity Framework, que basicamente vai pegar as prpoedades dessa classe, e de acordo com elas criar as linhas e colunas para salvar os dados nas tabelas no banco de dados MySQL utilizando o que é chamado de "Migrations".
*/
    public class Produto    
    {

        [Key]
        public int ProdutoId { get; set; }      //Se o nome tem "Id" no final, é para o EF saber que é a primary key na tabela.

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        
        //Atributos de relacionamento
        public int CategoriaId {get;set;}
        public Categoria? Categoria {get;set;}

    }
