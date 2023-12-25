using Test.BLL.DTOModels;
using Test.Host.Models;

namespace Test.BLL.Contracts;

public interface IUserBLL
{
	int GetCount();

	int GetSearchCount(string name);

	Task<List<User>> GetUsers(string name, int index, int count);

	void Delete(int id);

	Task Update(int id, UserDTO userDTO);

	Task<string> Create(UserDTO userDTO);
}