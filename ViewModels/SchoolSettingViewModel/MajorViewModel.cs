using BeApi.Models;

namespace BeApi.ViewModels.SchoolSettingViewModel;

public class MajorViewModel
{
    public int Id { get; set; }
    public string? MajorName { get; set; }
    
    public static implicit operator Major(MajorViewModel majorViewModel)
    {
        return new Major
        {
            Id = majorViewModel.Id,
            MajorName = majorViewModel.MajorName
        };
    }
    
    public static implicit operator MajorViewModel(Major major)
    {
        return new MajorViewModel
        {
            Id = major.Id,
            MajorName = major.MajorName
        };
    }
}