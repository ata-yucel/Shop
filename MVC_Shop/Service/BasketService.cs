﻿using MVC_Shop.Models.DTO;
using MVC_Shop.Repository;

namespace MVC_Shop.Service
{
	public interface IBasketService
	{
		public List<BasketDTO> GetProductById(List<int> ids);
	}
	public class BasketService : IBasketService
	{
		private IBasketRepository _basketRepository;
        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;	
        }
        public List<BasketDTO> GetProductById(List<int> ids)
		{
			var result= _basketRepository.GetByProdyctId(ids);
			return result;
		}
	}
}
