namespace BeApi.ViewModels.AdmissionProfileViewModel
{
    public class AdmissionProfileViewModel
    {
        public int Id { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? AdmissionProfileCode { get; set; } 
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? DateOfBirth { set; get; }
        public string? Gender { set; get; }
        public string? PlaceOfBirth { set; get; }
        public string? CitizenIdentificationCard { set; get; }
        public string? HealthInsuranceNumber { set; get; }
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }
        public bool IsSendMail { set; get; }
        public bool IsPayment { set; get; }
        public string? Class { set; get; } 
        public string? StudentCode { set; get; }
        public bool IsMatriculated { set; get; }
    }
}
