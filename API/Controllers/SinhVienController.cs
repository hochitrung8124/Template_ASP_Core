using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SinhVienController : ControllerBase
{
    private MyDbcontext _dbcontext;

    public SinhVienController( MyDbcontext myDbcontext) 
    {
        _dbcontext = myDbcontext;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var sinhViens = _dbcontext.sinhViens.ToList();
        return Ok(sinhViens);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var thongTin = _dbcontext.sinhViens.SingleOrDefault(tt => tt.id.Equals(id));
        if (thongTin == null)
            return BadRequest("không có dữ liệu");
        return Ok(thongTin);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateData(int id, [FromBody] SinhVien sinhVien)
    {
        var thongTin = _dbcontext.sinhViens.SingleOrDefault(tt => tt.id.Equals(id));
        if (thongTin == null)
            return BadRequest("Không tìm thấy sinh viên.");
        thongTin.name = sinhVien.name;
        _dbcontext.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult AddData([FromBody] SinhVien sinhVien)
    {
        var thongTin = _dbcontext.sinhViens.SingleOrDefault(tt => tt.id.Equals(sinhVien.id));
        if (thongTin != null)
        {
            return BadRequest("Id has existed");
        }
        var _sinhVien = new SinhVien()
        {
            name = sinhVien.name,
        };
        _dbcontext.Add(_sinhVien);
        _dbcontext.SaveChanges();
        return Ok(_sinhVien);
    }

    [HttpDelete("{id}")]
    public IActionResult DropData(int id)
    {
        try
        {
            var thongTin = _dbcontext.sinhViens.SingleOrDefault(tt => tt.id.Equals(id));
            if (thongTin != null)
            {
                return NoContent();
            }
            _dbcontext.Remove(thongTin);
            _dbcontext.SaveChanges();
            return Ok("Delete is success!");
        } catch 
        {
            return BadRequest();
        }
    }
}

