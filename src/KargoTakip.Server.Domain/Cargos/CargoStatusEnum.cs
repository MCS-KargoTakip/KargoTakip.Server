using Ardalis.SmartEnum;

public sealed class CargoStatusEnum : SmartEnum<CargoStatusEnum>
{
	public static CargoStatusEnum Pending = new("Pending", 0);
	public static CargoStatusEnum DeliveredToVehicle = new("Delivered to Vehicle", 1);
	public static CargoStatusEnum InTransit = new("In Transit", 2);
	public static CargoStatusEnum ArrivedAtDeliveryBranch = new("Arrived at Delivery Branch", 3);
	public static CargoStatusEnum OutForDelivery = new("Out for Delivery", 4);
	public static CargoStatusEnum Delivered = new("Delivered", 5);
	public static CargoStatusEnum RecipientNotFoundAtAddress = new("Recipient Not Found at Address", 6);
	public static CargoStatusEnum Canceled = new("Canceled", 7);

	public CargoStatusEnum(string name, int value) : base(name, value)
	{
	}
}
