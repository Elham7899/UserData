using Microsoft.AspNetCore.Mvc;
using Test.BLL.Contracts;
using Test.BLL.DTOModels;

namespace TestProject.Controllers
{
	[ApiController]
	[Route("users/children/")]
	public class ChildrenController : Controller
	{
		private readonly IChildBLL _childBLL;

		public ChildrenController(IChildBLL childBLL)
		{
			_childBLL = childBLL;

		}

		[Route("post")]
		[HttpPost]
		public async Task<IActionResult> Post(int id, ChildDTO childDTO)
		{
			try
			{
				await _childBLL.InsertChild(id, childDTO);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("Get")]
		[HttpGet]
		public async Task<IActionResult> Get(int userId, int index, int count)
		{
			try
			{
				var children = await _childBLL.GetAllChildren(userId, index, count);
				return Ok(children);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("Delete")]
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			try
			{
				_childBLL.DeleteChild(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("Update")]
		[HttpPut]
		public async Task<IActionResult> Update(int id, ChildDTO childDTO)
		{
			try
			{
				await _childBLL.UpdateChild(id, childDTO);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("GetChildCount")]
		[HttpGet]
		public IActionResult GetChildCount(int userId)
		{
			try
			{
				var result = _childBLL.GetChildCount(userId);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}