﻿namespace Test.Host.Models;

public class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public List<Child> Children { get; set; }
}
