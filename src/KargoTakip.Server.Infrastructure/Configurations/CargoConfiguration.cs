using KargoTakip.Server.Domain.Cargos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KargoTakip.Server.Infrastructure.Configurations
{
	internal sealed class CargoConfiguration : IEntityTypeConfiguration<Cargo>
	{
		public void Configure(EntityTypeBuilder<Cargo> builder)
		{
			builder.OwnsOne(p => p.Sender, builder =>
			{
				builder.Property(p => p.FirstName).HasColumnType("varchar(50)"); // default nvarchar(MAX)
				builder.Property(p => p.LastName).HasColumnType("varchar(50)");
			});
			builder.OwnsOne(p => p.Receiver);
			builder.OwnsOne(p => p.DeliveryAddress);
			builder.OwnsOne(p => p.CargoInfo, builder =>
			{
				builder
				.Property(p => p.CargoType)
				.HasConversion(tip => tip.Value, value => CargoTypeEnum.FromValue(value));
			});
			builder.Property(p => p.CargoStatus).HasConversion(status => status.Value, value => CargoStatusEnum.FromValue(value));

		}
	}
}
