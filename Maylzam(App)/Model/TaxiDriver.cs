namespace Maylzam_App_.Model
{

    // هو عباره عن كلاس يحتوي على الجداول التي سوف يتم بناءها في قواعد البيانات والذي سوف يتم عمل دوال إيه بي اي عليها


    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string? worked { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class Notification
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CustomerId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class TaxiDriver
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Driver_License { get; set; }
        public byte[]? Personal_Card { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
    public class Vechicle
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string? Type { get; set; }
        public string? Model { get; set; }
        public string? VNumber { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class Payment
    {
        public int Id { get; set; }
        public string? Method { get; set; }
        public float Amount { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
    public class Trip
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        public string? CurrentLocation { get; set; }
        public string? EndLocation  { get; set; }
        public string? Payment { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class AcceptedTrip
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int TripId { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Completed_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class Report
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int DriverId { get; set; } 
        public int CustomerId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }



    //AutomMechanic
    public class Skill
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsDelete { get; set; }

    }

    public class Employee
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Skill { get; set; }
        public string? Phone { get; set; }
        public byte[]? Personal_Photo { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
    public class AutomMechanic
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Center_Location { get; set; }
        public byte[]? Rental_License { get; set; }
        public byte[]? Personal_Card { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
    public class MNotification
    {
        public int Id { get; set; }
        public int AutomMechanicId { get; set; }
        public int CustomerId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class MaintenanceR
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public int SkillId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        public string? CurrentLocation { get; set; }
        public string? EndLocation { get; set; }
        public string? Payment { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
    public class AcceptedMR
    {
        public int Id { get; set; }
        public int AutomMechanicId { get; set; }
        public int MaintenanceRequestId { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Completed_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class MReport
    {
        public int Id { get; set; }
        public int AutomMechanicId { get; set; }
        public int MaintenanceRequestId { get; set; }
        public int CustomerId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }





    ///traffic police
    ///

    public class TrafficPolice
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class TPNotification
    {
        public int Id { get; set; }
        public int TrafficPoliceId { get; set; }
        public int CustomerId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class TPRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        public string? CurrentLocation { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }


    public class TPAcceptedRequest
    {
        public int Id { get; set; }
        public int TrafficPoliceId { get; set; }
        public int TrafficPoliceRequestId { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Completed_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
