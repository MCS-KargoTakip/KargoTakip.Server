using KargoTakip.Server.Application.Cargos;
using KargoTakip.Server.Domain.Abstractions;
using KargoTakip.Server.Domain.Cargos;
using KargoTakip.Server.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KargoTakip.Server.Application.Cargos
{
	public sealed record CargoGetAllQuery(
		) : IRequest<IQueryable<CargoGetAllQueryResponse>>;
	

	// Bu kısım frontend tarafında görünmesini istenen yer.
	public sealed class CargoGetAllQueryResponse : EntityDto
	{
		public string SenderFullName { get; set; } = default!;
		public string ReceiverFullName { get; set; } = default!;
		public string DeliveryAddressCity { get; set; } = default!;
		public string DeliveryAddressDistrict { get; set; } = default!;
		public string CargoTypeName { get; set; } = default!;
		public int Weight { get; set; }
		public string CargoStatusName { get; set; } = default!;
	}
}


internal sealed class CargoGetAllQueryHandler(
	ICargoRepository cargoRepository,
	UserManager<AppUser> userManager) : IRequestHandler<CargoGetAllQuery, IQueryable<CargoGetAllQueryResponse>>
{
	public Task<IQueryable<CargoGetAllQueryResponse>> Handle(CargoGetAllQuery request, CancellationToken cancellationToken)
	{
		var response = (from entity in cargoRepository.GetAll()
						join create_user in userManager.Users.AsQueryable() on entity.CreateUserId equals create_user.Id
						join update_user in userManager.Users.AsQueryable() on entity.CreateUserId equals update_user.Id into update_user
						from update_users in update_user.DefaultIfEmpty()
						select new CargoGetAllQueryResponse
						{
							SenderFullName = entity.Sender.FirstName + " " + entity.Sender.LastName,
							ReceiverFullName = entity.Receiver.FirstName + " " + entity.Receiver.LastName,
							Weight = entity.CargoInfo.Weight,
							CargoTypeName = entity.CargoInfo.CargoType.Name,
							DeliveryAddressCity = entity.DeliveryAddress.City,
							DeliveryAddressDistrict = entity.DeliveryAddress.District,
							CargoStatusName = entity.CargoStatus.Name,
							CreateAt = entity.CreateAt,
							DeleteAt = entity.DeleteAt,
							Id = entity.Id,
							IsDeleted = entity.IsDeleted,
							UpdateAt = entity.UpdateAt,
							CreateUserId = entity.CreateUserId,
							CreateUserName = create_user.FirstName + " " + create_user.LastName + " (" + create_user.Email + ")",
							UpdateUserId = entity.UpdateUserId,
							UpdateUserName = entity.UpdateUserId == null ? null : update_users.FirstName + " " + update_users.LastName + " (" + update_users.Email + ")",
						});

		return Task.FromResult(response);
	}
}
