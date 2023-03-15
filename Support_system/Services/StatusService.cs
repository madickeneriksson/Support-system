using Microsoft.EntityFrameworkCore;
using Support_system.Models.Entities;
using Support_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support_system.Context;

namespace Support_system.Services
{
    internal class StatusService
    {
        private static readonly DataContext _context = new DataContext();

        public static async Task SaveStatusAsync(Status status)
        {
            var _statusEntity = new StatusEntity
            {
                CaseId = status.Id,
                NotStarted = status.NotStarted,
                Started = status.Started,
                Finished = status.Finished
            };
            _context.Add(_statusEntity);
            await _context.SaveChangesAsync();
        }

    }
}
