using Microsoft.EntityFrameworkCore;
using MVC_Shop.DMO;
using MVC_Shop.Models.DTO;

namespace MVC_Shop.Repository
{
	public interface IProductRepository
	{
		public List<ProductDTO> GetProductBySubCategoryId(int subCategoryId);
	}
	public class ProductRepository : IProductRepository
	{
		private AdventureWorks2019Context _context;
		public ProductRepository(AdventureWorks2019Context context)
		{
			_context = context;
		}
		public List<ProductDTO> GetProductBySubCategoryId(int subCategoryId)
		{
			var result = _context.Products.Include(m => m.ProductProductPhotos).ThenInclude(k => k.ProductPhoto).Where(s => s.ProductSubcategoryId == subCategoryId).Select(k => new ProductDTO()
			{
				Id = k.ProductId,
				Name = k.Name,
				Price = k.ListPrice,
				Photo = k.ProductProductPhotos.Where(s => s.ProductId == s.ProductId).Select(k => k.ProductPhoto.LargePhoto).SingleOrDefault()
			}).ToList();


			//List<int> ids = result.Select(s => s.Id).ToList();
			//// photo çekelim 

			//List<byte[]> photos = _context.ProductProductPhotos.Include(s => s.ProductPhoto).Where(s => ids.Contains(s.ProductId)).Select(k => k.ProductPhoto.LargePhoto).ToList();


			return result;
		}

	}
}
