using Test.Host.Models;

namespace Test.Host.Contracts;

public interface IChildRepository
{
	Task InsertChild(Child child);

	Task<List<Child>> GetChildren(int userId, int index, int count);

	void DeleteChild(int id);

	Task UpdateChild();

	Task<Child?> ChildIsExist(int id);

	int GetChildCount(int id);
}