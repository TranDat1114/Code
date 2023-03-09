using Lab_7_2_Net_4.Models;

namespace Lab_7_2_Net_4.Services
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories();
    }
}
