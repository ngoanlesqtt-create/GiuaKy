using BTTH2.Models;
using BTTH2.Models.Authentication;
using BTTH2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace BTTH2.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db=new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       // [Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listSanPham = db.TDanhMucSps.AsTracking().OrderBy(x=>x.TenSp);
            PagedList<TDanhMucSp> list=new PagedList<TDanhMucSp>(listSanPham,pageNumber,pageSize);
            return View(list);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SanPhamTheoLoai(string maLoai, int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listSanPham = db.TDanhMucSps.AsTracking().Where(x=>x.MaLoai==maLoai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listSanPham, pageNumber, pageSize);
            ViewBag.maloai = maLoai;
            List<TDanhMucSp> danhSachSanPham = db.TDanhMucSps.Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp).ToList();
            return View(list);
        }
        public IActionResult ChiTietSanPham(string maSanPham)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSanPham);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham).ToList();
            ViewBag.anhSanPham = anhSanPham;

            return View(sanPham);
        }
        public IActionResult ProductDetail(string maSanPham)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSanPham);
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSanPham = sanPham,
                anhMucSanPham = anhSanPham
            };
            return View(homeProductDetailViewModel);
        }
    }
}
