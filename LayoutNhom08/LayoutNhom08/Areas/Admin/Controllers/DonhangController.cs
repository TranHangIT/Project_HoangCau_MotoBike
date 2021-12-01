using LayoutNhom08.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LayoutNhom8.Areas.Admin.Controllers
{
    public class DonhangController : Controller
    {
        private ShopMotoBikes db = new ShopMotoBikes();

        // GET: Admin/DonHangs
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.TaiKhoan).Include(d => d.TaiKhoan1).Include(d => d.TaiKhoan2);
            return View(donHangs.ToList());
        }

        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DonHang donHang = db.DonHangs.Find(id);

            if (donHang == null)
            {
                return HttpNotFound();
            }

            List<ChiTietDonHang> chiTietDonHangByID = db.ChiTietDonHangs.Where(p => p.MaDH == id).ToList();
            List<Hang> dsHang = new List<Hang>();

            foreach (var item in chiTietDonHangByID)
            {
                Hang sp= db.Hangs.Where(p => p.MaHang == item.MaHang).SingleOrDefault();
                dsHang.Add(sp);
            }

            ViewBag.SanPhams = dsHang;
            ViewBag.ChiTietDH = chiTietDonHangByID;

            return View(donHang);
        }

       

       
        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }


            List<string> tinhtrangDH = new List<string>
            {
                  "Đang giao", "Đã giao",  "Đã huỷ"
            };
            ViewBag.TinhTrangDH = tinhtrangDH;

            //Mình thấy cái này không dùng nên xóa đi
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "HoTen", donHang.MaTK);
            return View(donHang);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,NgayDat,DiaChiGiaoHang,TinhTrangDH,MaTK")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                //Lấy tình trạng đơn hàng
                string tinhTrang = Request["TinhTrang"];
                donHang.TinhTrangDH = int.Parse(tinhTrang);

                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            ViewBag.MaTK = new SelectList(db.TaiKhoans, "MaTK", "HoTen", donHang.MaTK);
            return View(donHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}