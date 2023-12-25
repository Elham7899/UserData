using Microsoft.AspNetCore.Mvc;
using Test.BLL.Contracts;
using Test.BLL.DTOModels;
using Test.BLL.Services;

namespace TestProject.Controllers
{
	[ApiController]
	[Route("users")]
	public class UsersController : Controller
	{
		private readonly IUserBLL _userBLL;

		public UsersController(IUserBLL userBLL)
		{
			_userBLL = userBLL;
		}

		[Route("Get")]
		[HttpGet]
		public async Task<IActionResult> Get(string name, int index, int count)
		{
			try
			{
				if (string.IsNullOrEmpty(name) || name == "1")
				{
					var users = await _userBLL.GetUsers("1", index, count);
					return Ok(users);
				}
				var user = await _userBLL.GetUsers(name, index, count);
				return Ok(user);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("create")]
		[HttpPost]
		public IActionResult Post(UserDTO userDTO)
		{
			try
			{
				_userBLL.Create(userDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[Route("delete")]
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			try
			{
				_userBLL.Delete(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[Route("GetCount")]
		[HttpGet]
		public  IActionResult GetCount()
		{
			try
			{
				var count = _userBLL.GetCount();
				return Ok(count);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("GetSearchCount")]
		[HttpGet]
		public IActionResult GetSearchCount(string name)
		{
			try
			{
				var count = _userBLL.GetSearchCount(name);
				return Ok(count);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//[HttpGet]
		//public async Task<IActionResult> GetAll()
		//{
		//	try
		//	{
		//		var users = await _userBLL.Register("e");
		//		return Ok(users);
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

		[Route("update")]
		[HttpPut]
		public async Task<IActionResult> Put(int id, UserDTO userDTO)
		{
			try
			{
				await _userBLL.Update(id, userDTO);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}
	}
}
