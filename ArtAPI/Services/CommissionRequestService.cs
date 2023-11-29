using ArtCommissions.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtAPI.Services
{
	public class CommissionRequestService : ICommissionService
	{
		private readonly ILogger<CommissionRequest> _logger;
		private IDbContextFactory<PostgresContext> _contextfactory;

        public CommissionRequestService(ILogger<CommissionRequest> logger, IDbContextFactory<PostgresContext> context)
        {
			this._logger = logger;
			this._contextfactory = context;
        }

		public async Task<IEnumerable<CommissionRequest>> GetAll()
		{
			var context = _contextfactory.CreateDbContext();

			return await context.CommissionRequests
				.ToListAsync();
		}

		public async Task<int> GetCount(int id)
		{
			var context = _contextfactory.CreateDbContext();

			return await context.CommissionRequests
				.Where(i => i.ArtistId == id)
				.CountAsync();

		}
			
	}
}
