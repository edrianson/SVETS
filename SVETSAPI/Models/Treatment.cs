namespace SVETSAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string PetName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerId { get; set; }

        public int ProcedureId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Date { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Notes { get; set; }

        public virtual Pet Pet { get; set; }

        public virtual Procedure Procedure { get; set; }
    }
}
