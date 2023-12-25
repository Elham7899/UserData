using Test.BLL.Contracts;
using Test.BLL.DTOModels;
using Test.Host.Contracts;
using Test.Host.Models;

namespace Test.BLL.Services;

public class UserBLL : IUserBLL
{
	public IUserReository testRepository;

	public UserBLL(IUserReository userReository)
	{
		testRepository = userReository;
	}

	public async Task<List<User>> GetUsers(string name, int index, int count)
	{
		if (string.IsNullOrEmpty(name) || name == "1")
		{
			return await testRepository.Get("1", index, count);
		}
		return await testRepository.Get(name, index, count);
	}

	public int GetCount()
	{
		var result = testRepository.GetCount();
		return result;
	}

	public int GetSearchCount(string name)
	{
		var result = testRepository.GetSearchCount(name);
		return result;
	}

	public void Delete(int id)
	{
		testRepository.Delete(id);
	}

	public async Task Update(int id, UserDTO userDTO)
	{
		var user = testRepository.IsUserExist(id);

		if (user != null)
		{
			user.FirstName = userDTO.FirstName;
			user.LastName = userDTO.LastName;
			await testRepository.Update();
		}
	}

	public async Task<string> Create(UserDTO userDTO)
	{
		var user = new User() { FirstName = userDTO.FirstName, LastName = userDTO.LastName };
		await testRepository.Insert(user);
		return "true";
	}
}
