using HousingBoardAdministration.HousingAdministrationWeb.UserManagement.Requirement;
using Microsoft.AspNetCore.Authorization;

namespace HousingBoardAdministration.HousingAdministrationWeb.UserManagement.Handler
{
    public class IsAdminOrBoardMemberHandler : AuthorizationHandler<IsAdminOrBoardMemberRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminOrBoardMemberRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Value == ClaimsTypes.Admin))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (context.User.HasClaim(c => c.Value == ClaimsTypes.BoardMember))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }

}
