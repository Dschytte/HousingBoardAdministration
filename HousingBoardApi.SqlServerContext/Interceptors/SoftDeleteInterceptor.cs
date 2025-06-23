namespace HousingBoardApi.SqlServerContext.Interceptors;

using HousingBoardApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        //checks if current dbcontext is null
        if (eventData.Context is null) return result;


        //gets a entityentry for each entity being tracked by dbcontext
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            //check if entity marked as deleted and then implement ISoftDelete, if so entry state is changed to modified
            //and sets IsDeleted and DeletedAt properties to their values
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            entry.State = EntityState.Modified;
            delete.IsDeleted = true;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        }
        return result;
    }
}
