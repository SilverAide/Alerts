using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Domain.Models;

namespace DataAccess.Repositories
{
    public class AlertRepository
    {
        private readonly AlertDbContext _context;

        public AlertRepository(AlertDbContext context)
        {
            _context = context;
        }

        public async Task CreateAlert(Alert alert)
        {
            await _context.Alerts.AddAsync(alert);
            await _context.SaveChangesAsync();
        }

        public async Task<Alert> GetAlertById(int id)
        {
            var query = await _context.Alerts.FindAsync(id);
            if(query != null)
            {
                return query;
            }
            throw new ArgumentException("Couldn't find alert with that Id", nameof(id));
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            if(_context.Alerts.Count() > 0)
            {
                return await _context.Alerts.ToListAsync();
            }
            return new List<Alert>();
        }

        public async Task DeleteAlert(int id)
        {
            var query = await _context.Alerts.FindAsync(id);
            if(query != null)
            {
                _context.Alerts.Remove(query);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Couldn't find Alert to delete with that Id.", nameof(id));
            }
        }

        public async Task<bool> DeleteExpiredAlerts()
        {
            var expiredAlerts = await _context.Alerts.Select(e => e).Where(e => DateTime.Now > e.Timestamp.AddDays(1)).ToListAsync();

            if(expiredAlerts.Count > 0)
            {
                foreach (var alert in expiredAlerts)
                {
                    _context.Alerts.Remove(alert);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
