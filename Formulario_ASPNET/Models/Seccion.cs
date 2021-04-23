namespace Formulario_ASPNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seccion")]
    public partial class Seccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seccion()
        {
            Alumno = new HashSet<Alumno>();
        }

        [Key]
        public int id_sec { get; set; }

        public int aula_sec { get; set; }

        public int id_cur { get; set; }

        public bool estado_sec { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_registro_sec { get; set; }

        public virtual Curso Curso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }
    }
}
