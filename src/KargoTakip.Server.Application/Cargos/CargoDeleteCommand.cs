using GenericRepository;
using KargoTakip.Server.Domain.Cargos;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.Application.Cargos;

public sealed record CargoDeleteCommand(Guid Id) : IRequest<Result<string>>;

internal sealed class CargoDeleteCommandHandler(
	ICargoRepository cargoRepository,
	IUnitOfWork unitOfWork) : IRequestHandler<CargoDeleteCommand, Result<string>>
{
	public async Task<Result<string>> Handle(CargoDeleteCommand request, CancellationToken cancellationToken)
	{
		Cargo cargo = await cargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

		if (cargo is null)
			return Result<string>.Failure("Cargo not found.");

		if (cargo.CargoStatus != CargoStatusEnum.Pending)
			return Result<string>.Failure("Only pending cargos can be deleted!");

		cargo.IsDeleted = true;
		cargoRepository.Update(cargo);

		await unitOfWork.SaveChangesAsync(cancellationToken);

		return "Cargo deleted successfully.";
	}
}