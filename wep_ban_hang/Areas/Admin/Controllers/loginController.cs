//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using wep_ban_hang.Areas.Admin.Models;
//using wep_ban_hang.Data;

//using Microsoft.AspNetCore.Hosting;
//using wep_ban_hang.Common;
//using Microsoft.AspNetCore.Http;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Cryptography;
//using System.Text;

//namespace wep_ban_hang.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class loginController : Controller
//    {

//        private readonly wep_ban_hangContext _context;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        public loginController(wep_ban_hangContext context, IWebHostEnvironment webHostEnvironment)
//        {
//            _context = context;
//            _webHostEnvironment = webHostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Index(string tendangnhap, string email, string matkhau, taikhoan acc)
//        {
//            //var f_password = GetMD5(Base64Encode(matkhau));
//            var data = _context.taikhoan.Where(s => s.tendangnhap.Equals(tendangnhap) && s.matkhau.Equals(matkhau)).ToList();
//            if (data.Count() > 0)
//            {
//                HttpContext.Session.SetString("tendangnhap", tendangnhap);
//                var claims = new List<Claim>();
//                //claims.Add(new Claim("email", email));
//                //claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
//                claims.Add(new Claim(ClaimTypes.Name, email));
//                //claims.Add(new Claim("password", password));
//                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                var userPrincipal = new ClaimsPrincipal(claimIndentity);
//                await HttpContext.SignInAsync(userPrincipal);
//                return RedirectToAction("Index","sanphamsController");
//            }
//            else
//            {
//                TempData["Error"] = "Tên tài khoản hoặc Password không chính xác";
//                return RedirectToAction("Index");
//            }
//        }

//        //GET: Register
//        public IActionResult Register()
//        {
//            return View();
//        }

//        //POST: Register
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Register(string email, string password, string name, taikhoan Taikhoan)
//        {

//            var check = _context.taikhoan.FirstOrDefault(s => s.tendangnhap == Taikhoan.tendangnhap);
//            if (check == null)
//            {
//                Taikhoan.matkhau = GetMD5(Base64Encode(password));
//                Taikhoan.email = email;
//                Taikhoan.tendangnhap = name;
//                _context.Add(Taikhoan);
//                await _context.SaveChangesAsync();
//                HttpContext.Session.SetString("tendangnhap", name);
//                //SessionHelper.SetObjectAsJson(HttpContext.Session, "email", acc);
//                //add session
//                //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
//                //Session["Email"] = data.FirstOrDefault().Email;
//                //Session["idUser"] = data.FirstOrDefault().idUser;
//                var claims = new List<Claim>();
//                //claims.Add(new Claim("email", email));
//                //claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
//                claims.Add(new Claim(ClaimTypes.Name, email));
//                //claims.Add(new Claim("password", password));
//                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                var userPrincipal = new ClaimsPrincipal(claimIndentity);
//                await HttpContext.SignInAsync(userPrincipal);
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                TempData["Error"] = "Email đã tồn tại";
//                return RedirectToAction("Register");
//            }
//        }

//        [Authorize]
//        public async Task<IActionResult> Logout()
//        {
//            //HttpContext.Session.Clear();//remove session
//            //return RedirectToAction("Login");
//            await HttpContext.SignOutAsync();
//            return RedirectToAction("Login");
//        }

//        //create a string Base64Encode
//        public static string Base64Encode(string password)
//        {
//            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
//            return System.Convert.ToBase64String(plainTextBytes);
//        }

//        //create a string MD5
//        public static string GetMD5(string str)
//        {
//            MD5 md5 = new MD5CryptoServiceProvider();
//            // Compute hash from the bytes of text
//            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));
//            // Get hash result after compute it
//            byte[] result = md5.Hash;
//            StringBuilder strBuilder = new StringBuilder();
//            for (int i = 0; i < result.Length; i++)
//            {
//                strBuilder.Append(result[i].ToString("x2"));
//            }

//            return strBuilder.ToString();
//        }
//    }
//}



using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using wep_ban_hang.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using wep_ban_hang.Data;

namespace wep_ban_hang.Areas.Admin.Controllers
{
    public class loginController : Controller
    {
        private readonly wep_ban_hangContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public loginController(wep_ban_hangContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Register(taikhoan taiKhoan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var check = _context.taikhoan.FirstOrDefault(s => s.tendangnhap == taiKhoan.tendangnhap);
        //        if (check == null)
        //        {
        //            taiKhoan.Password = GetMD5(taiKhoan.Password);
        //            taiKhoan.Configuration.ValidateOnSaveEnabled = false;
        //            taiKhoan.Users.Add(_user);
        //            taiKhoan.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Email already exists";
        //            return View();
        //        }


        //    }
        //    return View();


        //}

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tenDangnhap, string matKhau)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(matKhau);
                var data = _context.taikhoan.Where(s => s.tendangnhap.Equals(tenDangnhap) && s.matkhau.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().hoten ;
                    Session["tenDangnhap"] = data.FirstOrDefault().tendangnhap;
                    Session["id"] = data.FirstOrDefault().id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
