﻿using Application.Interfaces;
using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _repository;
        public CategoriesService(ICategoriesRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(Category category)
        {
          await _repository.AddAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
           await _repository.DeleteAsync(id);
        }

        public Category Edit(string id, Category transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category?>> GetAllByUserIdAsync(string userId)
        {
            return await _repository.GetAllByUserIdAsync(userId);
        }
        public IEnumerable<Category> Find(string name)
        {
            return _repository.Find(name);
        }
    }
}
