using Test.Host.Models;

namespace Test.Host.Contracts;

public interface IUserReository
{
	Task<List<User>> Get(string name, int index, int count);

	//Task<List<User>> Get();

	int GetCount();

	int GetSearchCount(string name);

	Task<string> Insert(User user);

	void Delete(int id);

	Task Update();

	User? IsUserExist(int id);
}
