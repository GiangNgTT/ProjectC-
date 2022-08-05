using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookstore.Models;

namespace WebBookstore.Controllers
{
    public class NguoidungController : Controller
    {
        dbQLBookstoreDataContext db = new dbQLBookstoreDataContext();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();


        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var email = collection["Email"];
            var diachi = collection["Diachi"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên ĐN không được để trống";
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi1"] = "Mật khẩu không được để trống";
            }
            if (string.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi1"] = "Mật khẩu nhập lại không được để trống";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewData["Loi1"] = "Email không được để trống";
            }
            if (string.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi1"] = "Điện thoại không được để trống";
            }
            else
            {
                //gan gt vào data
                kh.HoTen = hoten;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DienThoai = dienthoai;
                kh.DiaChi = diachi;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");

            }


            return this.Dangky();
        }

        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }

        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];


            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Nhập mật khẩu vào";
            }
            else 
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(n=> n.TaiKhoan==tendn && n.MatKhau ==matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Bạn đã đăng nhập thành công";
                    Session["Taikhoan"]=kh;
                    return RedirectToAction("Index", "Bookstore");



                }
                else
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";

                }

            }
            return View(); 

        }
}
}