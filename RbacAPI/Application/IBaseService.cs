using ClassLibraryEF;
using System.Collections.Generic;

namespace Application
{
    public interface IBaseService<TEntity, TDto> where TEntity : class,new() where TDto : class,new()
    {
        int Create(TDto dto);
        int Delete(int id);
        TDto Find(int id);
        List<TEntity> Query();
        int Update(TDto dto);
    }
}