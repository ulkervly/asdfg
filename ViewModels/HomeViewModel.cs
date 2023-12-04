using PustokPractice.Models;

namespace PustokPractice.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> BestsellerBooks { get; set; }
    }
}
