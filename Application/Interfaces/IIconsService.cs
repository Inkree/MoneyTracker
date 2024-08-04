using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIconsService
    {
        Task Create(Icon icon);
        Task Delete(string id);
        Task<IEnumerable<Icon>> GetAll();
    }
}
