using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookstore.Models;

namespace WebBookstore.Controllers
{
    public class AdminController : Controller
    {
        dbQLBookstoreDataContext db = new dbQLBookstoreDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sach(int? page)
        {
            int pageSize = 30;
            int pageNum = (page ?? 1);


            return View(db.Saches.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNum, pageSize));
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];


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
                Admin admin = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (admin != null)
                {
                    ViewBag.Thongbao = "Bạn đã đăng nhập thành công";
                    Session["Taikhoan"] = admin;
                    return RedirectToAction("Sach", "Admin");
                }
                else
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Themmoisach()
        {
            ViewBag.MaCD = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themmoisach(Sach sach, HttpPostedFileBase fileupload)
        {
            ViewBag.MaCD = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Chọn hình ảnh vào";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //luu ten file
                    var fileName = Path.GetFileName(fileupload.FileName);
                    //luu duong dẫn
                    var path = Path.Combine(Server.MapPath("~/product_imgs"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    sach.AnhBia = fileName;
                    //luu file
                    db.Saches.InsertOnSubmit(sach);
                    db.SubmitChanges();

                }
                return RedirectToAction("Sach");
            }
        }
        [HttpGet]
        public ActionResult Xoasach(int id)
        {
            //lay doi tuong can xoa
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == id);
            ViewBag.Masach = sach.MaSach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost, ActionName("Xoasach")]
        public ActionResult Xacnhanxoa(int id)
        {
            //lay doi tuong can xoa
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == id);
            ViewBag.Masach = sach.MaSach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return RedirectToAction("Sach");
        }

        [HttpGet]
        public ActionResult Suasach(int id)
        {
            //lay doi tuong can xoa
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == id);
            ViewBag.Masach = sach.MaSach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCD = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", sach.MaCD);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suasach(Sach sach, HttpPostedFileBase fileupload)
        {
            ViewBag.MaCD = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Chọn hình ảnh vào";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //luu ten file
                    var fileName = Path.GetFileName(fileupload.FileName);
                    //luu duong dẫn
                    var path = Path.Combine(Server.MapPath("~/product_imgs"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    sach.AnhBia = fileName;
                    //luu file
                    UpdateModel(sach);
                    db.SubmitChanges();

                }
                return RedirectToAction("Sach");
            }
        }
    }
}
    