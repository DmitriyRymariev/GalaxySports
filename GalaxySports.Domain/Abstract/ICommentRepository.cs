using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySports.Domain.Entities;

namespace GalaxySports.Domain.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        void SaveComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
