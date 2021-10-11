using AutoMapper;
using Core.Entities.Product;
using Core.Interfaces;
using Core.Specifications;
using LetsShop_API.Dtos;
using LetsShop_API.Errors;
using LetsShop_API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LetsShop_API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await _unitOfWork.Repository<Product>().CountAsync(countSpec); 

            var products = await _unitOfWork.Repository<Product>().ListAsync(spec);

            var resultDatas = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, resultDatas));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            var resultData = _mapper.Map<ProductToReturnDto>(product);

            return Ok(resultData);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _unitOfWork.Repository<ProductBrand>().ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            return Ok(await _unitOfWork.Repository<ProductType>().ListAllAsync());
        }
    }
}
