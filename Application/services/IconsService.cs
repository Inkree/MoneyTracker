using Application.Interfaces;
using Core.interfaces;
using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    public class IconsService : IIconsService
    {
        private readonly IIconsRepository _iconsRepository;
        public IconsService(IIconsRepository iconsRepository)
        {
            _iconsRepository = iconsRepository;
        }

        public async Task Create(Icon icon)
        {
           await _iconsRepository.AddAsync(icon);
        }

        public async Task Delete(string id)
        {
           await _iconsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Icon>> GetAll()
        {
           return await _iconsRepository.GetAllAsync();
        }
    }
}
