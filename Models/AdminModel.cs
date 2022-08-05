using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AdminModel
    {
        private dbcontext context = null;
        public AdminModel()
        {
            context = new dbcontext();
        }
        public List<Sach> ListAll()
        {
            List<Sach> list = context.Database.SqlQuery<Sach>("SP_Books_listall").ToList();
            return list;
        }


        public int create(string Tensach, decimal? Giaban, string Mota, string Anhbia, DateTime? Ngaycapnhat, int? Soluongton)
        {
            object[] parameters =
            {
                 new SqlParameter("@TenSach", Tensach),
                 new SqlParameter("@GiaBan", Giaban),
                 new SqlParameter("@MoTa", Mota),
                 new SqlParameter("@AnhBia", Anhbia),
                 new SqlParameter("@NgayCapNhat", Ngaycapnhat),
                 new SqlParameter("@SoLuongTon", Soluongton)

                };
                int res = context.Database.ExecuteSqlCommand("Sp_Books_Insert @TenSach, @GiaBan, @MoTa,@AnhBia,@NgayCapNhat,@SoLuongTon", parameters);
                return res;
        }
        public int update( string Tensach, decimal? Giaban, string Mota, string Anhbia, DateTime? Ngaycapnhat, int? Soluongton, int? Macd, int? Manxb)
        {
            object[] parameters =
            {
            new SqlParameter("@TenSach", Tensach),
            new SqlParameter("@GiaBan", Giaban),
            new SqlParameter("@MoTa", Mota),
            new SqlParameter("@AnhBia", Anhbia),
            new SqlParameter("@NgayCapNhat", Ngaycapnhat),
            new SqlParameter("@SoLuongTon", Soluongton),
            new SqlParameter("@MaCD", Macd),
            new SqlParameter("@MaNXB", Manxb),

        };

        int res = context.Database.ExecuteSqlCommand("Sp_Books_Update  @TenSach, @GiaBan, @MoTa, @AnhBia, @NgayCapNhat, @SoLuongTon, @MaCD, @MaNXB ", parameters);
        return res;
        }
    }
}
