
using Azure.Core;
using KargoTakip.Server.Application.Cargos;
using MediatR;
using TS.Result;

namespace KargoTakip.Server.WebAPI.Modules;

public static class CargoModule
{
    public static void RegisterCargoRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/cargos").WithTags("Cargos").RequireAuthorization();

        group.MapPost(string.Empty,
            async (ISender sender, CargoCreateCommand request, CancellationToken cancellatioNToken) =>
            {
                var response = await sender.Send(request, cancellatioNToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            })
            .Produces<Result<string>>()
            .WithName("CargoCreate");

        group.MapDelete("{id}",
            async (Guid id, ISender sender, CancellationToken cancellatioNToken) =>
            {
				var response = await sender.Send(new CargoDeleteCommand(id), cancellatioNToken);
				return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
			})
			.Produces<Result<string>>()
			.WithName("CargoDelete");
	}
}
