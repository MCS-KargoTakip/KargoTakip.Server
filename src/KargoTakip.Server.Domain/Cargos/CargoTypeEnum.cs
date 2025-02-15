using Ardalis.SmartEnum;

namespace KargoTakip.Server.Domain.Cargos
{
	public sealed class CargoTypeEnum : SmartEnum<CargoTypeEnum>
	{
		public static CargoTypeEnum Package = new("Package", 0);
		public static CargoTypeEnum Envelope = new("Envelope", 1);
		public static CargoTypeEnum Box = new("Box", 2);
		public CargoTypeEnum(string name, int value) : base(name, value)
		{
		}
	}
}
