using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using System.Collections.Generic;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SinhVienController : ControllerBase
{
    private static readonly List<SinhVien> List_SinhVien = new List<SinhVien>()
    {
        new SinhVien(){id = 01, name = "Trung"},
        new SinhVien(){id = 02, name = "Trung2"},
        new SinhVien(){id = 03, name = "Trung3"},
        new SinhVien(){id = 04, name = "Trung4"},
        new SinhVien(){id = 05, name = "Trung5"},
        new SinhVien(){id = 06, name = "Trung6"},
        new SinhVien(){id = 07, name = "Trung7"}
    };
    /*    [HttpGet]
            public IEnumerable<SinhVien> GetAll() 
            { 
                return (IEnumerable<SinhVien>)Ok(List_SinhVien);
            }*/
    [HttpGet]
    public IEnumerable<SinhVien> GetAll()
    {
        return List_SinhVien;
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var thongTin = List_SinhVien.SingleOrDefault(tt => tt.id.Equals(id));
        if (thongTin == null)
              return BadRequest("không có dữ liệu");
        return Ok(thongTin);     
    }
}

