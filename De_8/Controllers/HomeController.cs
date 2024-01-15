using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De_8.Models;

namespace De_8.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QLBanChauCanhEntities db = new QLBanChauCanhEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderNav()
        {
            List<PhanLoaiPhu> listLoai = db.PhanLoaiPhus.ToList();
            return PartialView("Header",listLoai);
        }
        public ActionResult RenderProduct()
        {
            List<SanPham> listPro = db.SanPhams.ToList();
            return PartialView("Main_Content", listPro);
        }
        public ActionResult RenderProductByCatId(string CatId)
        {
            List<SanPham> listPro = db.SanPhams.Where(p => p.MaPhanLoaiPhu == CatId).ToList();

            return PartialView("Main_Content", listPro);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}