﻿using BTTH2.Models.ProductModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTTH2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanVaLiContext db=new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat=p.GiaNhoNhat,
                           }).ToList();

            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductByCategory(string maLoai)
        {
            var sanPham = (from p in db.TDanhMucSps
                           where p.MaLoai == maLoai
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat,
                           }).ToList();

            return sanPham;
        }
    }

}
