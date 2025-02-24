using FluentValidation;
using GenericRepository;
using KargoTakip.Server.Application.Cargos;
using KargoTakip.Server.Domain.Cargos;
using Mapster;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.Application.Cargos
{
	public sealed record CargoCreateCommand(
		Person Sender,
		Person Receiver,
		Address DeliveryAddress,
		CargoInformationDto CargoInfo) : IRequest<Result<string>>;
	
	public sealed record CargoInformationDto(
		int CargoTypeValue,
		int Weight);
	public sealed class CargoCreateCommandValidator: AbstractValidator<CargoCreateCommand>
	{
		public CargoCreateCommandValidator()
		{
			RuleFor(p => p.Sender.FirstName).NotEmpty().WithMessage("Enter a valid sender first name");
			RuleFor(p => p.Sender.LastName).NotEmpty().WithMessage("Enter a valid sender last name");
			RuleFor(p => p.Receiver.FirstName).NotEmpty().WithMessage("Enter a valid receiver first name");
			RuleFor(p => p.Receiver.LastName).NotEmpty().WithMessage("Enter a valid receiver last name");
			RuleFor(p => p.DeliveryAddress.City).NotEmpty().WithMessage("Enter a valid city");
			RuleFor(p => p.DeliveryAddress.District).NotEmpty().WithMessage("Enter a valid district");
			RuleFor(p => p.DeliveryAddress.Neighborhood).NotEmpty().WithMessage("Enter a valid neighborhood");
			RuleFor(p => p.DeliveryAddress.FullAddress).NotEmpty().WithMessage("Enter a valid full address");
			RuleFor(p => p.CargoInfo.CargoTypeValue)
				.GreaterThanOrEqualTo(0).WithMessage("Select a valid cargo type")
				.LessThan(CargoTypeEnum.List.Count()).WithMessage("Select a valid cargo type");
		}
	}
}

internal sealed class CargoCreateCommandHandler(
	ICargoRepository cargoRepository,
	IUnitOfWork unitOfWork) : IRequestHandler<CargoCreateCommand, Result<string>>
{
	public async Task<Result<string>> Handle(CargoCreateCommand request, CancellationToken cancellationToken)
	{
		Cargo cargo = request.Adapt<Cargo>();
		CargoInformation cargoInformation = new(
			CargoTypeEnum.FromValue(request.CargoInfo.CargoTypeValue), request.CargoInfo.Weight);
		cargo.CargoInfo = cargoInformation;
		cargo.CargoStatus = CargoStatusEnum.Pending;
		cargo.Sender = request.Sender;
		cargo.Receiver = request.Receiver;

		cargoRepository.Add(cargo);
		await unitOfWork.SaveChangesAsync(cancellationToken);


		// to do: burada mail veya sms gönderme işlemleri yapılacak.
		// to do: ileride notification içinde domain event kullanabiliriz.

		return "Cargo added Successfully!";
	}
}
