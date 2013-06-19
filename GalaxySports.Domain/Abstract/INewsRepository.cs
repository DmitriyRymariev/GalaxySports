using GalaxySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySports.Domain.Abstract
{
    public interface INewsRepository
    {
        IQueryable<News> News { get; }
        void SaveNews(News news);
        void DeleteNews(News news);
    }
}
