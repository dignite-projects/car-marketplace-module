using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Dignite.CarMarketplace
{
    public static class CommonOperations
    {
        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement { Name = nameof(Update) };
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = nameof(Delete) };
        public static OperationAuthorizationRequirement UsedCarManage = new OperationAuthorizationRequirement { Name = nameof(UsedCarManage) };
    }
}
