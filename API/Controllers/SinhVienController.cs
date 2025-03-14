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

    [HttpPut("{id}")]
    public IActionResult UpdateData(int id, [FromBody] SinhVien sinhVien)
    {
        var thongTin = List_SinhVien.SingleOrDefault(tt => tt.id == id);
        if (thongTin == null)
            return BadRequest("Không tìm thấy sinh viên.");
        thongTin.name = sinhVien.name;
        return Ok(thongTin);
    }

    [HttpPost]
    public IActionResult AddData([FromBody] SinhVien sinhVien)
    {
        var check = List_SinhVien.FirstOrDefault(tt => tt.id == sinhVien.id);
        if (check != null)
        {
            return BadRequest("Id has existed");
        }
        var _sinhVien = new SinhVien()
        {
            id = sinhVien.id,
            name = sinhVien.name,
        };
        List_SinhVien.Add(_sinhVien);
        return Ok(_sinhVien);
    }

    [HttpDelete("{id}")]
    public IActionResult DropData(int id)
    {
        var check = List_SinhVien.FirstOrDefault(tt => tt.id == id);
        if (check == null)
        {
            return BadRequest("Id does not existed");
        }
        List_SinhVien.Remove(check);
        return Ok("Remove is success!");
    }
}

