﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Entities
{
    [Table("ProductModel", Schema = "SalesLT")]
    [Index(nameof(Name), Name = "AK_ProductModel_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ProductModel_rowguid", IsUnique = true)]
    [Index(nameof(CatalogDescription), Name = "PXML_ProductModel_CatalogDescription")]
    public partial class ProductModel
    {
        public ProductModel()
        {
            ProductModelProductDescriptions = new HashSet<ProductModelProductDescription>();
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "xml")]
        public string? CatalogDescription { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductModelProductDescription.ProductModel))]
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        [InverseProperty(nameof(Product.ProductModel))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
