using Support_system.Context;
using Support_system.Models.Entities;
using Support_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Support_system.Services
{
    internal class CommentsService
    {
        private static readonly DataContext _context = new DataContext();

        public static async Task SaveCommentAsync(Comments comments, Customer Selectedcase)
        {
            var _commentEntity = new CommentsEntity
            {
             CaseId = comments.Id,
             TitleComment = comments.TitleComment,
             DescriptionComment = comments.DescriptionComment,
            };

            _context.Add(_commentEntity);
            await _context.SaveChangesAsync();
        }

    }
}

