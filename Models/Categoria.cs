using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
    [Table("Categorias")]           // Esse aqui não precisaria ja que o EF entende sozinho que isso faz parte da tablea categorias
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        [Key]
        public int CategoriaId { get; set; }    // Se a propriedade for do tipo "int" e no seu nome tiver "Id" no final, o EF vai entender que ela é a primari key

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        
        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos {get;set;}
    }

    //Quando classes só tem propriedades, não tem comportamento, métodos, elas são chamadas de "classes anêmicas".
