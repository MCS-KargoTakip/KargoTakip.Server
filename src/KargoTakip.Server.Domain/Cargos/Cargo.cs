using KargoTakip.Server.Domain.Abstractions;

namespace KargoTakip.Server.Domain.Cargos
{
	public sealed class Cargo : Entity
	{
		public Person Sender { get; set; } = default!;
		public Person Receiver { get; set; } = default!;
		public Address DeliveryAddress { get; set; } = default!;
		public CargoInformation CargoInfo { get; set; } = default!;
		public CargoStatusEnum CargoStatus { get; set; } = default!;
	}
}
