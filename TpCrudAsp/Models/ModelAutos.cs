using System.ComponentModel.DataAnnotations;

namespace TpCrudAsp.Models
{
    public class ModelAutos
    {
        //columnas de nuestra tabla
        public int idAuto { get; set; }

        [Required(ErrorMessage = "El campo Modelo es Obligatorio ")]
        public string? modelo { get; set; }
        [Required(ErrorMessage = "El campo Marca es Obligatorio ")]
        public string? marca { get; set; }
        [Required(ErrorMessage = "El campo Patente es Obligatorio ")]
        public string? patente { get; set; }
        [Required(ErrorMessage = "El campo Precio es Obligatorio ")]
        public string? precio { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es Obligatorio ")]
        public string? descripcion { get; set; }
        [Required(ErrorMessage = "El campo URL es Obligatorio ")]
        public string? img{ get; set; }
    }
}
