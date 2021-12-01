using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LayoutNhom08.Models;


namespace LayoutNhom8.Areas.Admin.Controllers
{
    public class SanphamController : Controller
    {
        private ShopMotoBikes db = new ShopMotoBikes();

        // GET: Admin/Hangs
        public ActionResult Index()
        {
            var hangs = db.Hangs.Include(h => h.DanhMuc);
            return View(hangs.ToList());
        }

        // GET: Admin/Hangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: Admin/Hangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,MaDM,TenHang,ThuongHieu,LoaiXe,GiaTien,MoTaHang,MauSac,SoLuong,Anh")] Hang hang)
        {
            //Làm theo kiểu này mình cũng không hiểu lắm nó lại mất hình ảnh khi mà thiếu dữ liệu
            if (ModelState.IsValid)
            {
                hang.Anh = null;
                var f = Request.Files["ImageFilesss"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/img/sanpham/" + FileName);

                    f.SaveAs(UploadPath);

                    hang.Anh = FileName;
                }
                db.Hangs.Add(hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
            return View(hang);



            //Cái này làm theo bài tập của cô nhưng không hiểu sao nó chạy ra luôn index và không có thông báo gì
            //theo mình nghĩ là do phần file script không có thư mục script nhúng vào
            /* try
             {
                 if (ModelState.IsValid)
                 { 
                     hang.Anh = null;
                     var f = Request.Files["ImageFilesss"];
                     if (f != null && f.ContentLength > 0)
                     {
                         string FileName = System.IO.Path.GetFileName(f.FileName);
                         string UploadPath = Server.MapPath("~/wwwroot/img/sanpham/" + FileName);

                         f.SaveAs(UploadPath);

                         hang.Anh = FileName;
                     }
                     db.Hangs.Add(hang);
                     db.SaveChanges();
                 }
                 return RedirectToAction("Index");
             }
             catch (Exception ex)
             {
                 ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
                 ViewBag.Error = "Có lỗi xảy ra ! " + ex.Message;
                 return View(hang);
             }*/
        }



        // GET: Admin/Hangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", hang.MaDM);
            return View(hang);
        }

        // POST: Admin/Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,MaDM,TenHang,ThuongHieu,LoaiXe,GiaTien,MoTaHang,MauSac,SoLuong,Anh")] Hang hang)
        {

            if (ModelState.IsValid)
            {
                var f = Request.Files["ImageFilesss"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/img/sanpham/" + FileName);

                    f.SaveAs(UploadPath);

                    hang.Anh = FileName;
                }
                db.Entry(hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
            return View(hang);
            

            //Cái này mình nghĩ tương tự với creat như mình đã ghi chú
        }

        // GET: Admin/Hangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Admin/Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hang hang = db.Hangs.Find(id);
            db.Hangs.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("Index");
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