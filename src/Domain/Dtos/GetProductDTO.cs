﻿namespace Domain.ModelView;
public class GetProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public int Quantity { get; set; }
}