namespace Shared.Infrastructure.Services
{
    using Shared.Core;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataService
    {
        Task<IEnumerable<ToDoItem>> GetToDosAsync();
    }
}