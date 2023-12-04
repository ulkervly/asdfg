using PustokPractice.Models;

namespace PustokPractice.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(Slider slider);
        Task DeleteAsync(int id);
        Task<List<Slider>> GetAllAsync();
        Task<Slider> GetAsync(int id);
    }
}
