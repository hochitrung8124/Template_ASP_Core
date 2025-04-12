
using Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using Template_ASP_Core.Models;

namespace Template_ASP_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync($"https://localhost:7155/api/SinhVien");
            var res = await data.Content.ReadAsStringAsync();
            var dataJson = JsonConvert.DeserializeObject<IEnumerable<SinhVien>>(res);
            return View(dataJson);
        }
        public async Task<IActionResult> Privacy()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync($"https://localhost:7155/api/SinhVien");
            var res = await data.Content.ReadAsStringAsync();
            var dataJson = JsonConvert.DeserializeObject<IEnumerable<SinhVien>>(res);
            return View(dataJson);
        }
        public async Task<IActionResult> UpdateData([FromForm] SinhVienModel sinhVien)
        {
            using (HttpClient client = new HttpClient())
            {
                // Địa chỉ API
                string url = $"https://localhost:7155/api/SinhVien/{sinhVien.Id}";
                // Chuẩn bị nội dung JSON để gửi
                var content = new StringContent(
                    JsonConvert.SerializeObject(new {id = sinhVien.Id, name = sinhVien.Name }),
                    Encoding.UTF8,
                    "application/json"
                );

                // Gửi yêu cầu PUT
                var response = await client.PutAsync(url, content);

                // Kiểm tra phản hồi từ server
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Ok($"Cập nhật thành công: {result}");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return BadRequest($"Cập nhật thất bại: {error}");
                }
            }
        }

        public async Task<IActionResult> AddData([FromForm] SinhVienModel sinhVien)
        {
            using (HttpClient client = new HttpClient())
            {
                // Địa chỉ API
                string url = $"https://localhost:7155/api/SinhVien";
                // Chuẩn bị nội dung JSON để gửi
                var content = new StringContent(
                    JsonConvert.SerializeObject(new { Id = sinhVien.Id, Name = sinhVien.Name }),
                    Encoding.UTF8,
                    "application/json"
                );

                // Gửi yêu cầu PUT
                var response = await client.PostAsync(url, content);
                // Kiểm tra phản hồi từ server
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Ok($"Cập nhật thành công: {result}");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return BadRequest($"Cập nhật thất bại: {error}");
                }
            }
        }

        public async Task<IActionResult> DropById(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync($"https://localhost:7155/api/SinhVien/{id}");
            // Kiểm tra phản hồi từ server
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Ok($"Cập nhật thành công: {result}");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return BadRequest($"Cập nhật thất bại: {error}");
            }
        }

        public async Task<IActionResult> GetById(int id)
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync($"https://localhost:7155/api/SinhVien/{id}");
            var res = await data.Content.ReadAsStringAsync();
            var dataJson = JsonConvert.DeserializeObject<SinhVien>(res);

            return View(dataJson);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
}
