using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application
{

    public interface IQueryableService<TDto>
    {
        IEnumerable<TDto> GetAll();
        TDto GetById(int id);
    }
    public interface IModifiableService<TDto>
    {
        CommandResult Create(TDto dto);
        CommandResult Update(TDto dto);
        CommandResult Delete(TDto dto);
    }
    public interface IService<TDto> : IQueryableService<TDto>,IModifiableService<TDto>
    {
    }
    public interface IService<TDto, TSummary> : IService<TDto>
    {
        TSummary GetSummaryById(int id);
        IEnumerable<TSummary> GetSummaries();
    }

}
