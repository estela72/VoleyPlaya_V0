using GenericLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Contracts.Persistence
{
    public interface IEdicionRepository : IAsyncRepository<Edicion>
    {
        //Task<Employee?> GetEmployeeByIdWithDepartmentAsync(int id);
        //Task<IList<Employee>> GetEmployeesWithDepartmentAsync();
    }
}
