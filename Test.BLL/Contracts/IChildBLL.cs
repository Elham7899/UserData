using Test.BLL.DTOModels;
using Test.Host.Models;

namespace Test.BLL.Contracts;

public interface IChildBLL
{
	Task InsertChild(int id,ChildDTO childDTO);

	Task<List<Child>> GetAllChildren(int userId, int index, int count);

	void DeleteChild(int id);

	Task UpdateChild(int id, ChildDTO childDTO);

	int GetChildCount(int id);
}