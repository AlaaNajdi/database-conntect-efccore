using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CategoryService
  {

    private static List<CategoryDto> _category = new List<CategoryDto>();
      

    public List<CategoryDto> GetAllCategoryService()
    {
      return _category;
    }
    public CategoryDto? GetUserByIdService(Guid id)
    {
      var foundCategory = _category.Find(user => user.CategoryId == id);
      return foundCategory;
    }
    public CategoryDto? CreateCategoryService(CreateCategoryDto newCategory)
    {
      var category = new CategoryDto {
        CategoryId = Guid.NewGuid(),
        Name = newCategory.Name,};
      if(category == null){
        return null;
      }
      _category.Add(category);
      return category;
    }
    public bool DeleteCategoryByIdService(Guid id)
    {
      var categoryToRemove = _category.FirstOrDefault(u => u.CategoryId == id);
      if (categoryToRemove != null)
      {
        _category.Remove(categoryToRemove);
        return true;
      }
      return false;
    
    }}
  