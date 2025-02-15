using GenericRepository;
using KargoTakip.Server.Domain.Cargos;
using KargoTakip.Server.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.Server.Infrastructure.Repositories
{
	internal sealed class CargoRepository : Repository<Cargo, ApplicationDbContext>, ICargoRepository
	{
		public CargoRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
