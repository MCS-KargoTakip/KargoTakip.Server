namespace KargoTakip.Server.Domain.Cargos
{
	public sealed record Person(
		string FirstName,
		string LastName,
		string IdentityNumber,
		string Email,
		string PhoneNumber
		);
}
