using LayoutNhom08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutNhom8.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ShopMotoBikes db = new ShopMotoBikes();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.SoTaiKhoan = db.TaiKhoans.Count();
            int soluongconlai= db.Hangs.Count();
            ViewBag.SoSanPhamDaBan = db.ChiTietDonHangs.Sum(s => s.SoLuongDat);

            //Cái này sẽ tìm hiểu sau
            //ViewBag.DoanhThu = db.ChiTietDonHangs.Sum(s=> (s.SoLuongDat*))

            ViewBag.TongSanPham = ViewBag.SoSanPhamDaBan + soluongconlai;
            return View();
        }
        
    }
}