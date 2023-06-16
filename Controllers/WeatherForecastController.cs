using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QuanLyBanHang.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : ControllerBase {
        private static List<Branch> branches = new List<Branch>();

        public BranchesController(){}

        [HttpGet]
        public ActionResult<IEnumerable<Branch>> Get() {
            return Ok(branches); // API lấy toàn bộ dữ liệu của branch
        }

        [HttpPost]
        public ActionResult<Branch> Add(Branch branch) {
            // API Thêm branch
            branches.Add(branch);
            return CreatedAtAction(nameof(Get), new { id = branch.BranchId }, branch);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id) {
            // API Xóa branch
            var branch = branches.Find(b => b.BranchId == id);
            if (branch == null) return NotFound();

            branches.Remove(branch);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, Branch branch) {
            // API sửa branch
            var existingBranch = branches.Find(b => b.BranchId == id);
            if (existingBranch == null) return NotFound();

            existingBranch.Name = branch.Name;
            existingBranch.Address = branch.Address;
            existingBranch.City = branch.City;
            existingBranch.State = branch.State;
            existingBranch.ZipCode = branch.ZipCode;

            return NoContent();
        }
    }

    public class Branch {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
