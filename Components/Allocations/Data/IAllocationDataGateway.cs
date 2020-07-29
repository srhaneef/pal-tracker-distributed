using System;
using System.Collections.Generic;

namespace Allocations.Data
{
    public interface IAllocationDataGateway
    {
        AllocationRecord Create(long projectId, long userId, DateTime firstDay, DateTime lastDay);

        List<AllocationRecord> FindBy(long projectId);
    }
}