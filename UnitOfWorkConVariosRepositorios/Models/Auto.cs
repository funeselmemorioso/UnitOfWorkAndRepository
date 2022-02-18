using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkConVariosRepositorios.Models
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
