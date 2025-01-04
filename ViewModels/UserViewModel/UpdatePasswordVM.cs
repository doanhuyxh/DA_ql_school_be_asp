namespace BeApi.ViewModels
{
    public class UpdatePasswordVM
    {
        public int Id { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}