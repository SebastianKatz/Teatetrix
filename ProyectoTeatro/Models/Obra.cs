using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTeatro.Models
{
    public class Obra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdObra { get; set; }
        public String Nombre { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de obra")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime Fecha { get; set; }
        public int IdSala { get; set; }
        public int Participantes { get; set; }
    }
}