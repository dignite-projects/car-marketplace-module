using Dignite.CarMarketplace.Dealers;
using Dignite.CarMarketplace.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;

namespace Dignite.CarMarketplace.DealerPlatform.Dealers
{
    public class DealerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Dealer>
    {
        protected IPermissionChecker PermissionChecker { get; }

        public DealerAuthorizationHandler(IPermissionChecker permissionChecker)
        {
            PermissionChecker = permissionChecker;
        }

        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Dealer resource)
        {
            if (requirement.Name == CommonOperations.UsedCarManage.Name && await HasUsedCarManagePermission(context, resource))
            {
                context.Succeed(requirement);
                return;
            }

            if (requirement.Name == CommonOperations.Delete.Name && await HasDeletePermission(context, resource))
            {
                context.Succeed(requirement);
                return;
            }

            if (requirement.Name == CommonOperations.Update.Name && await HasUpdatePermission(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
        }

        private async Task<bool> HasUsedCarManagePermission(AuthorizationHandlerContext context, Dealer resource)
        {
            if (resource != null
                && resource.Administrators.Any(uca => uca.UserId == context.User.FindUserId()))
            {
                return true;
            }

            if (await PermissionChecker.IsGrantedAsync(context.User, CarMarketplacePermissions.UsedCars.Management))
            {
                return true;
            }

            return false;
        }

        private async Task<bool> HasDeletePermission(AuthorizationHandlerContext context, Dealer resource)
        {
            if (resource.CreatorId != null && resource.CreatorId == context.User.FindUserId())
            {
                return true;
            }

            if (await PermissionChecker.IsGrantedAsync(context.User, CarMarketplacePermissions.Dealers.Management))
            {
                return true;
            }

            return false;
        }

        private async Task<bool> HasUpdatePermission(AuthorizationHandlerContext context, Dealer resource)
        {
            if (resource.CreatorId != null && resource.CreatorId == context.User.FindUserId())
            {
                return true;
            }

            if (await PermissionChecker.IsGrantedAsync(context.User, CarMarketplacePermissions.Dealers.Management))
            {
                return true;
            }

            return false;
        }
    }
}