using eIMIC223925.ApiIntegration;
using eIMIC223925.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eIMIC223925.AdminApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            if (TempData["thongbao"] != null)
            {
                ViewBag.ThongBao = TempData["thongbao"];
            }

            var data = await _userApiClient.GetUsersPagings(request);

            return View(data.ResultObj);

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userApiClient.RegisterUser(request);

            if (result.IsSuccessed)
            {
                TempData["thongbao"] = "Thêm người dùng thành công!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var result = await _userApiClient.GetById(Id);

            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserUpdateRequest()
                {
                    Dob = user.Dob,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Id = user.Id
                };

                return View(updateRequest);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userApiClient.UpdateUser(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["thongbao"] = "Sửa người dùng thành công!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            return View(new UserDeleteRequest()
            {
                Id = Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userApiClient.Delete(request.Id);

            if (result.IsSuccessed)
            {
                TempData["thongbao"] = "Xóa người dùng thành công!";
                return RedirectToAction("Index");
            }


            ModelState.AddModelError("", result.Message);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            return View(result.ResultObj);
        }
    }
}
