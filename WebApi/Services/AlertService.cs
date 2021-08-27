using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Models;
using DataAccess;
using DataAccess.Repositories;

namespace WebApi.Services
{
    public class AlertService
    {

        private readonly AlertRepository _repo;

        public AlertService(AlertRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAlert(Alert alert)
        {
            if(alert == null || alert.Description == null)
            {
                throw new ArgumentException("Invalid alert format", nameof(alert));
            }
            await _repo.CreateAlert(alert);
        }

        public async Task<Alert> GetAlertById(int id)
        {
            if(id < 1)
            {
                throw new ArgumentException("Invalid Id value", nameof(id));
            }
            return await _repo.GetAlertById(id);
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            return await _repo.GetAllAlerts();
        }

        public async Task DeleteAlert(int id)
        {
            if(id < 1)
            {
                throw new ArgumentException("Invalid Id value", nameof(id));
            }
            await _repo.DeleteAlert(id);
        }
    }
}
