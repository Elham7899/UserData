using System.Data;
using Microsoft.EntityFrameworkCore;
using Test.Host.Contracts;
using Test.Host.Models;
using Test.Host.TDbContext;

namespace Test.Host.Repositories;

public class UserRepository : IUserReository
{
	public string connectionString = "Data Source=.;Initial Catalog=ICANTest;Persist Security Info=True;User ID=sa;Password=12345";

	private readonly DbContexts _contexts;

	public UserRepository(DbContexts contexts)
	{
		_contexts = contexts;

	}

	//public List<User> Get(string name)
	//{
	//	var users = _contexts.Users.Where(u => u.FirstName == name || u.LastName == name).ToList();
	//	return users;
	//}

	//public async Task<List<User>> Get()
	//{
	//	var result =await _contexts.Users.ToListAsync();
	//	return result;
	//}

	public async Task<List<User>> Get(string name, int index, int count)
	{
		if (string.IsNullOrEmpty(name) || name == "1")
		{
			var result = await _contexts.Users.Skip(count * index).Take(count).ToListAsync();
			return result;
		}
		var users = await _contexts.Users.Where(u => u.FirstName == name || u.LastName == name).Skip(count * index).Take(count).ToListAsync();
		return users;
	}

	public int GetCount()
	{
		return _contexts.Users.Count();
	}

	public int GetSearchCount(string name)
	{
		return _contexts.Users.Count(u => u.FirstName == name || u.LastName == name);
	}

	public async Task<string> Insert(User user)
	{
		await _contexts.Users.AddAsync(user);
		_contexts.SaveChanges();
		return "true";
	}

	public void Delete(int id)
	{
		var user = _contexts.Users.Where(u => u.Id == id).Include(u=>u.Children).SingleOrDefault();
		_contexts.Users.Remove(user);
		_contexts.SaveChanges();
	}

	public async Task Update()
	{
		await _contexts.SaveChangesAsync();
	}

	public User? IsUserExist(int id)
	{
		return _contexts.Users.SingleOrDefault(u => u.Id == id);
	}
}
