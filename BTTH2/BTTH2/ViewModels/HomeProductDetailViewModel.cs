namespace BTTH2.ViewModels
{
    public class HomeProductDetailViewModel
    {
        private TDanhMucSp? sanPham;
        private List<TAnhSp> anhSanPham;

  

        public TDanhMucSp danhMucSanPham { get; set; }
        public List<TAnhSp> anhMucSanPham {  set; get; }
    }
}
