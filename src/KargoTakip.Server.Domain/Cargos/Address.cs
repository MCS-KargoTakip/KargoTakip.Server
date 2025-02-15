namespace KargoTakip.Server.Domain.Cargos
{
	public sealed record Address(
		string City,
		string District,
		string Neighborhood,
		string Street,
		string FullAddress
		);
}
