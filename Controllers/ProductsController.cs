﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acacia_Back_End.Core.Interfaces;
using Acacia_Back_End.Core.Models;
using Acacia_Back_End.Core.Specifications;
using Acacia_Back_End.Core.ViewModels;
using Acacia_Back_End.Errors;
using Acacia_Back_End.Helpers;
using Acacia_Back_End.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System.Text.Json;


namespace Acacia_Back_End.Controllers
{
    public class ProductsController : BaseApiController
    {
        private IGenericRepository<Product> _productsRepo;
        private IGenericRepository<ProductCategory> _productCategoryRepo;
        private IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        private Context _context;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductCategory> productCategoryRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper, Context context)
        {
            _context = context;
            _productsRepo = productsRepo;
            _productCategoryRepo = productCategoryRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductVM>>> GetProducts([FromQuery]ProductSpecParams productParams) 
        {
            var products = await _productsRepo.GetProductsAsync(productParams);

            // Try implement this in the repsoitory 
            var data = _mapper.Map<IReadOnlyList<ProductVM>>(products.Skip((productParams.PageIndex - 1) * productParams.PageSize).Take(productParams.PageSize).ToList());

            return Ok(new Pagination<ProductVM>(productParams.PageIndex, productParams.PageSize, products.Count, data));
        }

        [HttpGet("{id}")]
        // Swagger configuration
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductVM>> GetProduct(int id)
        {

            var product = await _productsRepo.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Product, ProductVM>(product);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetProductCategories()
        {
            return Ok(await _productCategoryRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("AddProductList")]
        public async Task<IActionResult> AddProductList([FromForm] JsonFilesVM JsonProducts)
        {
            if (JsonProducts.ProductList != null)
            {
                List<Product> products;
                using (var streamReader = new StreamReader(JsonProducts.ProductList.OpenReadStream()))
                {
                    var productsData = await streamReader.ReadToEndAsync();
                    products = JsonSerializer.Deserialize<List<Product>>(productsData);
                }

                foreach (var prod in products)
                {
                    prod.PriceHistory = new List<ProductPrice>();
                    prod.Quantity = 10;
                    prod.TresholdValue = 5;
                    var productPrice = new ProductPrice
                    {
                        ProductId = prod.Id,
                        Price = 100,
                        StartDate = DateTime.Now
                    };
                    prod.PriceHistory.Add(productPrice);
                }

                var result = await _productsRepo.AddEntityList(products);
                if (result) return Ok();

                return BadRequest(new ApiResponse(400, "Please check the format of your JSON file."));
            }

            return BadRequest(new ApiResponse(400, "No file or empty file uploaded."));
        }

        // Base64 Version
        [HttpPost, DisableRequestSizeLimit]
        [Route("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] AddProductVM product)
        {
            var formCollection = await Request.ReadFormAsync();
            var imageurl = "";
            if (formCollection.Files.Count() > 0)
            {
                var file = formCollection.Files.First();
                imageurl = SaveProductImage(file).Result;
            }

            var myproduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                PriceHistory = new List<ProductPrice>()
                {
                    new ProductPrice
                    {
                        Price = product.Price,
                        StartDate = DateTime.Now
                    }
                },
                TresholdValue = product.TresholdValue,
                QRCode = "To be implemented",
                ProductCategoryId = product.ProductCategoryId,
                ProductTypeId = product.ProductTypeId,
                SupplierId = product.SupplierId
            };
            if(imageurl == "")
            {
                myproduct.PictureUrl = "images/products/default.jpg";
            }
            else
            {
                myproduct.PictureUrl = imageurl;
            }

            var result = await _productsRepo.AddEntity(myproduct);
            if (result == true) return Ok();
            return BadRequest(new ApiResponse(400, "There was a problem adding a new product"));
        }

        [HttpPut, DisableRequestSizeLimit]
        public async Task<ActionResult> UpdateProduct([FromForm] UpdateProductVM product, int id)
        {
            var myproduct = await _productsRepo.GetProductByIdAsync(id);
            if (myproduct == null) return NotFound(new ApiResponse(404));

            var formCollection = await Request.ReadFormAsync();
            if (formCollection.Files.Count() > 0)
            {
                var file = formCollection.Files.First();
                myproduct.PictureUrl = UpdateProductImage(file, myproduct.PictureUrl).Result;
            }

            myproduct.Description = product.Description;
            myproduct.Name = product.Name;
            myproduct.TresholdValue = product.TresholdValue;
            myproduct.ProductCategoryId = product.ProductCategoryId;
            myproduct.ProductTypeId = product.ProductTypeId;
            myproduct.SupplierId = product.SupplierId;
            // Checks if price has changed
            if (product.Price != myproduct.GetPrice())
            {
                myproduct.PriceHistory.OrderByDescending(pp => pp.StartDate).First().EndDate = DateTime.Now;
                myproduct.PriceHistory.Add(new ProductPrice()
                {
                    ProductId = myproduct.Id,
                    Price = product.Price,
                    StartDate = DateTime.Now
                });
            }
            var result = await _productsRepo.UpdateEntity(myproduct);
            if (result == false) return BadRequest(new ApiResponse(400));
            return Ok();
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVM>> DeleteProduct(int id)
        {
            var result = await _productsRepo.RemoveEntity(id);

            if (result == true) return Ok();

            return BadRequest("There was a problem adding a deleting the product");
        }


        [HttpGet("category/{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {

            var category = await _productCategoryRepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(category);
        }
        [HttpPost("category/add")]
        [Authorize]
        public async Task<ActionResult> CreateProductCategory(string name)
        {
            var category = new ProductCategory { Name = name };
            var result = await _productCategoryRepo.AddProductCategory(category);

            if (result == true) return Ok();
            return BadRequest(new ApiResponse(400, "There was a problem adding the product category"));
        }

        [HttpDelete("category/delete/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteProductCategory(int id)
        {
            var result = await _productCategoryRepo.RemoveEntity(id);

            if (result == true) return Ok();

            return BadRequest(new ApiResponse(400, "There was a problem deleting the product category"));
        }

        [HttpPut("category/update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateProductCategory(string name, int id)
        {
            var category = await _productCategoryRepo.GetByIdAsync(id);
            if (category == null) return NotFound(new ApiResponse(404));

            category.Name = name;

            var result = await _productCategoryRepo.UpdateProductCategory(category);

            if (result == true) return Ok();

            return BadRequest(new ApiResponse(400, "There was a problem updating the product category"));
        }

        [HttpGet("type/{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {

            var type = await _productTypeRepo.GetByIdAsync(id);

            if (type == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(type);
        }

        [HttpPost("type/add")]
        [Authorize]
        public async Task<ActionResult> CreateProductType(string name)
        {
            var type = new ProductType { Name = name };
            var result = await _productTypeRepo.AddProductType(type);
            if (result == true) return Ok();
            return BadRequest(new ApiResponse(400, "There was a problem adding the product type"));
        }

        [HttpDelete("type/delete/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteProductType(int id)
        {
            var result = await _productTypeRepo.RemoveEntity(id);

            if (result == true) return Ok();

            return BadRequest(new ApiResponse(400, "There was a problem deleting the product type"));
        }

        [HttpPut("type/update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateProductType(string name, int id)
        {
            var type = await _productTypeRepo.GetByIdAsync(id);
            if (type == null) return NotFound(new ApiResponse(404));

            type.Name = name;

            var result = await _productTypeRepo.UpdateProductType(type);

            if (result == true) return Ok();

            return BadRequest(new ApiResponse(400, "There was a problem updating the product type"));
        }

        private async Task<string> SaveProductImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);

                string filePath = Path.Combine("wwwroot/images/products/", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return "images/products/" + uniqueFileName;
            }
            return null;
        }

        private async Task<string> UpdateProductImage(IFormFile file, string imageurl)
        {
            if (file != null && file.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);

                string filePath = Path.Combine("wwwroot/images/products/", uniqueFileName);

                // Remove the existing image if it exists
                string existingFilePath = imageurl;
                if (System.IO.File.Exists("wwwroot/" + existingFilePath))
                {
                    System.IO.File.Delete("wwwroot/" + existingFilePath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return "images/products/" + uniqueFileName;
            }
            return null;
        }

    }
}
