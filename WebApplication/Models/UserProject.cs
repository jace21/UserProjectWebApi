namespace WebApplication.Models
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("UserProject")]
    public partial class UserProject
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IsActive { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime AssignedDate { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
