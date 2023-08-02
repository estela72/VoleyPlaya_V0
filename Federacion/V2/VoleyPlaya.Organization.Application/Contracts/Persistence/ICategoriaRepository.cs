using GenericLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Contracts.Persistence
{
    public interface ICategoriaRepository: IAsyncRepository<Categoria>
    {
        //Task<Categoria?> GetCategoriaByIdWithDepartmentAsync(int id);
        //Task<IList<Employee>> GetEmployeesWithDepartmentAsync();
    }
}
