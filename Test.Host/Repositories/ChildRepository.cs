using Microsoft.EntityFrameworkCore;
using Test.Host.Contracts;
using Test.Host.Models;
using Test.Host.TDbContext;

namespace Test.Host.Repositories;

public class ChildRepository : IChildRepository
{
	private readonly DbContexts _contexts;

	public ChildRepository(DbContexts dbContexts)
	{
		_contexts = dbContexts;
	}

	public async Task<List<Child>> GetChildren(int userid, int index, int count)
	{
		return await _contexts.Children.Where(c => c.UserId == userid).Skip(index * count).Take(count).ToListAsync();
	}

	public async Task InsertChild(Child child)
	{
		await _contexts.Children.AddAsync(child);
		_contexts.SaveChanges();
	}

	public void DeleteChild(int id)
	{
		var child = _contexts.Children.SingleOrDefault(c => c.Id == id);
		_contexts.Children.Remove(child);
		_contexts.SaveChanges();
	}

	public async Task UpdateChild()
	{
		await _contexts.SaveChangesAsync();
	}

	public async Task<Child?> ChildIsExist(int id)
	{
		return await _contexts.Children.SingleOrDefaultAsync(c => c.Id == id);
	}

	public int GetChildCount(int id)
	{
		return _contexts.Children.Where(c => c.UserId == id).Count();
	}
}