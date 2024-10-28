
namespace BTTH2.Repository
{
    public class LoaiSanPhamRepository : ILoaiSanRepository
    {

        private readonly QlbanVaLiContext _context;
        public LoaiSanPhamRepository(QlbanVaLiContext context) { 
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp entity)
        {
            _context.TLoaiSps.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TLoaiSp Delete(TLoaiSp entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSanPham()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(TLoaiSp entity)
        {
            return _context.TLoaiSps.Find(entity);    
        }

        public TLoaiSp Update(TLoaiSp entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
