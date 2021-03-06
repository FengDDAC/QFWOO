//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FengDDAC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class Vessel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vessel()
        {
            this.Customers = new HashSet<Customer>();
            this.Items = new HashSet<Item>();

        }

        public int vesselID { get; set; }
        public int vesselScheduleID { get; set; }

        [Required]
        [Display(Name = "Vessel Type:")]
        public string vesselType { get; set; }

        [Required]
        [Display(Name = "Vessel Size:")]
        public Nullable<int> vesselSize { get; set; }

        [Required]
        [Display(Name = "Vessel Name:")]
        public string vesselName { get; set; }
        public string vesselApproval { get; set; }

        [Required]
        [Display(Name = "Vessel of Customer:")]
        public Nullable<int> vesselCustomer { get; set; }
        public string vesselAgent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
        public virtual Schedule Schedule { get; set; }

        public int ScheduleId { get; set; }

        public class vesselContext:DbContext
        {
            public DbSet<Schedule> Schedules { get; set; }
            public DbSet<Vessel> Vessels { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Vessel>()
                    .HasRequired(s => s.Schedule)
                    .WithMany(v => v.Vessels)
                    .WillCascadeOnDelete(false);

                base.OnModelCreating(modelBuilder);
            }
        }

}
        
}

