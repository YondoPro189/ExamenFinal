using System.ComponentModel.DataAnnotations;

namespace ExamenFinal.Models
{
    public class Producto
    {
        [Required]
        public string Nombre { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double Precio { get; set; }

        public Producto() { }

        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
