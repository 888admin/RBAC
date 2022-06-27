﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using AutoMapper;

namespace Application
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : class,new () where TDto : class,new()
    {
        private readonly IBaseRepository<TEntity, int> repository;
        private readonly IMapper mapper;

        public BaseService(IBaseRepository<TEntity, int> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public int Create(TDto dto)
        {
            return repository.AddInfo(mapper.Map<TEntity>(dto));
        }
        public List<TEntity> Query()
        {
            return repository.QueryAll();
        }
        public TDto Find(int id)
        {
            return mapper.Map<TDto>(repository.GetBity(id));
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public int Update(TDto dto)
        {
            return repository.UpdInfo(mapper.Map<TEntity>(dto));
        }
    }
}
