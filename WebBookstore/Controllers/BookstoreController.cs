using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookstore.Models;
using PagedList;
using PagedList.Mvc;

namespace WebBookstore.Controllers
{
    public class BookstoreController : Controller
    {
        // GET: Bookstore
        dbQLBookstoreDataContext data = new dbQLBookstoreDataContext();
        private List<Sach> Laysachmoi(int count)
        {
            return data.Saches.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        // GET: BookStore
        public ActionResult Index(int ? page)

        {
            int pageSize = 2;
            int pageNum = (page ?? 1);
            var sachmoi = Laysachmoi(5);

            return View(sachmoi.ToPagedList(pageNum, pageSize));

        }
        public ActionResult Chude()
        {
            var chude = from cd in data.ChuDes select cd;
            return PartialView(chude);

        }
        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from cd in data.NhaXuatBans select cd;
            return PartialView(nhaxuatban);

        }

        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.Saches where s.MaCD == id select s;
            return View(sach);

        }

        public ActionResult SPTheoNhaXuatBan(int id)
        {
            var sach = from s in data.Saches where s.MaNXB == id select s;
            return View(sach);

        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.Saches where s.MaSach == id select s;
            return View(sach.Single());

        }
    }
}