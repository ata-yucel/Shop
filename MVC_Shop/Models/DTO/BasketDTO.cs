﻿namespace MVC_Shop.Models.DTO
{
	public class BasketDTO
	{
        public int StockQuantity { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public byte[] Photo { get; set; }


    }
}
