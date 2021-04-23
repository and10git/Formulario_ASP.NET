namespace Formulario_ASPNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Seccion = new HashSet<Seccion>();
        }

        [Key]
        public int id_alu { get; set; }

        [Required]
        [StringLength(8)]
        public string dni_alu { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_alu { get; set; }

        [Required]
        [StringLength(100)]
        public string apellidos_alu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seccion> Seccion { get; set; }

        /* METODOS */
        public List<Alumno> Listar()
        {
            List<Alumno> alumnos = new List<Alumno>();
            string cadena = "SELECT * FROM ALUMNO";
            //var model = new Model1();
            //model.Alumno.ToList();
            try
            {
                using (var contenedor = new Model1())
                {
                    alumnos = contenedor.Database.SqlQuery<Alumno>(cadena).ToList();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return alumnos;
        }

        public bool Insertar(string dni, string nombre, string apellido)
        {
            bool estado = false;
            string cadena = "'" + dni + "',";
            cadena += "'" + nombre + "',";
            cadena += "'" + apellido + "'";

            try
            {
                using (var cnx = new Model1())
                {
                    int r = cnx.Database.ExecuteSqlCommand("INSERT INTO [dbo].[Alumno]([dni_alu],[nombre_alu],[apellidos_alu])VALUES("
                                                            + cadena + ")");
                    if (r == 1)
                        estado = true;
                }
            }
            catch (Exception)
            {
                estado = false;
        
            }

            return estado;
        }


    }
}
