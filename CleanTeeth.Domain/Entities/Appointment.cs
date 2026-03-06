using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using CleanTeeth.Domain.Enums;
namespace CleanTeeth.Domain.Entities;

internal class Appointment
{
    public Guid Id { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DentistId { get; private set; }
    public Guid DentalOfficeId { get; private set; }
    public AppointmentStatus Status { get; private set; }
    //public DateTime StartDate { get; private set; }
    //public DateTime EndDate { get; private set; }
    public TimeInterval TimeInterval { get; private set; }
    //Propiedades que facilitan la navegación
    public Patient? Patient { get; private set; }
    public Dentist? Dentist { get; private set; }
    public DentalOffice? DentalOffice { get; private set; }

    public Appointment(Guid patientId, Guid dentistId, Guid dentalOffice,string status,TimeInterval timeInterval)
    {
        if (timeInterval.Start < DateTime.UtcNow)
        {
            throw new BusinessRuleException($"La fecha de inicio no puede ser anterior a la de actual");
        }

        PatientId = patientId;
        DentistId = dentistId;
        DentalOfficeId = dentalOffice;
        Status = AppointmentStatus.Scheduled;
        //StartDate = startDate;
        //EndDate = endDate;
        TimeInterval = timeInterval;
        Id = Guid.CreateVersion7();
    }
    public void Cancel()
    {
        if (Status != AppointmentStatus.Scheduled)
        {
            throw new BusinessRuleException($"Solo puede ser cancelada una cita programada");
        }
        Status = AppointmentStatus.Cancelled;
    }
    public void Complete()
    {
        if(Status != AppointmentStatus.Scheduled)
        {
            throw new BusinessRuleException($"Solo puede ser completada una cita programada");
        }
        Status = AppointmentStatus.Completed;
    }
}
