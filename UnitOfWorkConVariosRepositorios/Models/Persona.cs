using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkConVariosRepositorios.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
