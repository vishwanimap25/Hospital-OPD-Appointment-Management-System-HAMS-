using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Configuration
{

    //the Fluent Api are used where there is no Annotation.
    //The fluent api like given below are used in older version.
    //but in the new version we can use Data Annotations.
    //the difference between both of them -> https://chatgpt.com/share/686e33b7-0380-8003-90c9-b2b6f85dd359



    public class DoctorConfiguration //: IEntityTypeConfiguration<Doctor>
    {
        //public void Configure(EntityTypeBuilder<Doctor> builder)
        //{
        //    builder.HasKey(d => d.Id);
        //    builder.Property(d => d.FullName).IsRequired();
        //    builder.Property(d => d.Specialization).IsRequired();
        //    builder.Property(d => d.Email).IsRequired();
        //    builder.Property(d => d.PhoneNumber).IsRequired().HasMaxLength(10);
        //    builder.Property(d => d.Gender).IsRequired().HasMaxLength(10);

        //    builder.HasMany(d => d.Appointments)
        //        .WithOne(a => a.Doctor)
        //        .HasForeignKey(a => a.DoctorId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //}

        
    }
}
