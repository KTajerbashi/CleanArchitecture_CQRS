using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Core.Domain.Library.Aggregates.Products.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public int ProductCost { get; set; }
    public int ProductStock { get; set; }
}