﻿using System;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace Dignite.CarMarketplace.Cars
{
    public interface ITrimConfigItemRepository : IBasicRepository<TrimConfigItem, Guid>
    {
        Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}
