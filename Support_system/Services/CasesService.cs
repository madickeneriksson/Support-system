using Microsoft.EntityFrameworkCore;
using Support_system.Context;
using Support_system.Models;
using Support_system.Models.Entities;


namespace Support_system.Services
{
    internal class CasesService
    {
        private static readonly DataContext _context = new DataContext();
        public static async Task SaveAsync(Customer customer)
        {
            var _customerEntity = new CustomerEntity
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
            var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.CaseTitle == customer.CaseTitle && x.Description == customer.Description && x.UpdateComment == customer.UpdateComment);
            if (_caseEntity != null)
                _customerEntity.CaseId = _caseEntity.Id;
            else
                _customerEntity.Cases = new CaseEntity
                {

                    CaseTitle = customer.CaseTitle,
                    Description = customer.Description,
                    CreatedAt = DateTime.UtcNow,
                    UpdateComment = customer.UpdateComment,
                    UpdatedAt = DateTime.UtcNow,
                };        

            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }
      
        public static async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var _customers = new List<Customer>();

            foreach (var _customer in await _context.Customers.Include(x => x.Cases).ToListAsync())
                _customers.Add(new Customer

                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    CaseTitle = _customer.Cases.CaseTitle,
                    Description = _customer.Cases.Description,
                    CreatedAt = DateTime.Now,
                    UpdateComment = _customer.Cases.UpdateComment,
                    UpdatedAt = DateTime.Now,

                });
            return _customers;
        }

        public static async Task<Customer> GetAsync(string email)
        {
            var _customer = await _context.Customers.Include(x => x.Cases).FirstOrDefaultAsync(x => x.Email == email);
            if (_customer != null)
                return new Customer
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    CaseTitle = _customer.Cases.CaseTitle,
                    Description = _customer.Cases.Description,
                    CreatedAt = DateTime.Now,
                    UpdateComment = _customer.Cases.UpdateComment,
                    UpdatedAt = DateTime.Now

                };
            else
                return null!;
        }

        public static async Task UpdateAsync(Customer customer)
        {
            var _customerEntity = await _context.Customers.Include(x => x.Cases).FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (_customerEntity != null)
            {
                if (!string.IsNullOrEmpty(customer.FirstName))
                    _customerEntity.FirstName = customer.FirstName;

                if (!string.IsNullOrEmpty(customer.LastName))
                    _customerEntity.LastName = customer.LastName;

                if (!string.IsNullOrEmpty(customer.Email))
                    _customerEntity.Email = customer.Email;

                if (!string.IsNullOrEmpty(customer.PhoneNumber))
                    _customerEntity.PhoneNumber = customer.PhoneNumber;

                if (!string.IsNullOrEmpty(customer.CaseTitle) || !string.IsNullOrEmpty(customer.Description) || !string.IsNullOrEmpty(customer.UpdateComment))
                {
                    var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.CaseTitle == customer.CaseTitle && x.Description == customer.Description && x.UpdateComment == customer.UpdateComment);
                    if (_caseEntity != null)
                        _customerEntity.CaseId = _caseEntity.Id;
                    else
                        _customerEntity.Cases = new CaseEntity
                        {
                            CaseTitle = customer.CaseTitle,
                            Description = customer.Description,
                            CreatedAt = DateTime.Now,
                            UpdateComment = customer.UpdateComment,
                            UpdatedAt = DateTime.Now
                        };
                }
                _context.Update(_customerEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(string email)
        {
            var customer = await _context.Customers.Include(x => x.Cases).FirstOrDefaultAsync(x => x.Email == email);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

    }
}


