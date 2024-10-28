using BTTH2.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BTTH2.ViewComponents
{
    public class LoaiSpMenuViewComponent:ViewComponent
    {
        private readonly ILoaiSanRepository _component;
        public LoaiSpMenuViewComponent(ILoaiSanRepository component)
        {
            _component = component;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp = _component.GetAllLoaiSanPham().OrderBy(x=>x.Loai);
            return View(loaiSp);
        }
    }
}
