namespace BTTH2.Repository
{
    public interface ILoaiSanRepository
    {
        TLoaiSp Add(TLoaiSp entity);
        TLoaiSp Update(TLoaiSp entity);
        TLoaiSp Delete(TLoaiSp entity);
        TLoaiSp GetLoaiSp(TLoaiSp entity);
        IEnumerable <TLoaiSp> GetAllLoaiSanPham();
    }
}
