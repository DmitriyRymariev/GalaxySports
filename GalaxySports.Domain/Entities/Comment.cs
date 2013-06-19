using GalaxySports.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySports.Domain.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int ProductID { get; set; }

        public int UserID { get; set; }

        public string CommentText { get; set; }

        public DateTime Time { get; set; }
    }
}
