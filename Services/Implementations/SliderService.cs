using PustokPractice.CustomExceptions.Slider;
using PustokPractice.Models;
using PustokPractice.Repositories.Interfaces;
using PustokPractice.Services.Interfaces;

namespace PustokPractice.Services.Implementations
{
    public class SliderService:ISliderService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISliderRepository _sliderRepository;

        public SliderService(IWebHostEnvironment env, ISliderRepository sliderRepository)
        {
            _env = env;
            _sliderRepository = sliderRepository;
        }

        public async Task CreateAsync(Slider slider)
        {
            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
                {
                    throw new TotalSliderException("ImageFile", "Content type must be jpeg or png");
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    throw new TotalSliderException("ImageFile", "Image size must be lower than 2mb!");
                }
                string fileName = slider.ImageFile.FileName;

                fileName = fileName.Length > 64 ? fileName.Substring(fileName.Length - 64, 64) : fileName;

                fileName = Guid.NewGuid().ToString() + fileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/sliders", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(stream);
                }

                slider.Image = fileName;
            }
            else
            {
                throw new TotalSliderException("ImageFile", "Required");
            }

            await _sliderRepository.CreateAsync(slider);
            await _sliderRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(id);

            if (slider == null) throw new NullReferenceException();

            _sliderRepository.Delete(slider);
            await _sliderRepository.CommitAsync();
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await _sliderRepository.GetAllAsync();
        }

        public Task<Slider> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
