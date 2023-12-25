using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Host.Models;

namespace Test.Host.Mappings;

public class ChildMapping : IEntityTypeConfiguration<Child>
{
	public void Configure(EntityTypeBuilder<Child> builder)
	{
		builder.ToTable("Child");
	}
}
