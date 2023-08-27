using loja_games.Util;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loja_games.Model
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Usuario { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Senha { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(5000)]
        public string? Foto { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime DataNascimento { get; set; }
    }
}