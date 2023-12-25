using Test.BLL.Contracts;
using Test.BLL.DTOModels;
using Test.Host.Contracts;
using Test.Host.Models;

namespace Test.BLL.Services;

public class ChildBLL : IChildBLL
{
	private readonly IChildRepository _childRepository;

	public ChildBLL(IChildRepository childRepository)
	{
		_childRepository = childRepository;
	}

	public async Task InsertChild(int id, ChildDTO childDTO)
	{
		var child = new Child() { FirstName = childDTO.FirstName, LastName = childDTO.LastName, UserId = id };
		await _childRepository.InsertChild(child);
	}

	public async Task<List<Child>> GetAllChildren(int userId, int index, int count)
	{
		return await _childRepository.GetChildren(userId,index,count);
	}

	public void DeleteChild(int id)
	{
		_childRepository.DeleteChild(id);
	}

	public async Task UpdateChild(int id, ChildDTO childDTO)
	{
		var child =await _childRepository.ChildIsExist(id);
		if(child != null) {
			child.FirstName = childDTO.FirstName;
			child.LastName = childDTO.LastName;
			await _childRepository.UpdateChild();
		}
	}

	public int GetChildCount(int id)
	{
		return _childRepository.GetChildCount(id);
	}
}