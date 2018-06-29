namespace SVETSAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Owner")]
    public partial class Owner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owner()
        {
            Pets = new HashSet<Pet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string SurName { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string GivenName { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
