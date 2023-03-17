using Microsoft.EntityFrameworkCore;
using Support_system.Context;

using Support_system.Models;
using Support_system.Models.Entities;
using System.Security.Cryptography.X509Certificates;

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
            var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.CaseTitle == customer.CaseTitle && x.Description == customer.Description );
            if (_caseEntity != null)
                _customerEntity.CaseId = _caseEntity.Id;
            else
                _customerEntity.Cases = new CaseEntity
                {

                    CaseTitle = customer.CaseTitle,
                    Description = customer.Description,
                    CreatedAt = DateTime.UtcNow,
                };
            var _adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.SteetName == customer.StreetName && x.PostalCode == customer.Postalcode && x.City == customer.City);
            if (_adressEntity != null)
                _customerEntity.AddressId = _adressEntity.Id;
            else
                _customerEntity.Addresses = new AddressEntity
                {
                    SteetName = customer.StreetName,
                    PostalCode = customer.Postalcode,
                    City = customer.City,
                };

            var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.UpdateComment == customer.UpdateComment && x.UpdatedAt == customer.UpdatedAt);
            if (_commentEntity != null)
                _customerEntity.CommentsId = _commentEntity.Id;
            else
                _customerEntity.Comments = new CommentEntity
                {
                    UpdateComment = customer.UpdateComment,
                    UpdatedAt= DateTime.UtcNow,

                };
            var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.NotStarted == customer.NotStarted && x.Started == customer.Started && x.Closed == customer.Closed);
            if (_commentEntity != null)
                _customerEntity.StatusId = _commentEntity.Id;
            else
                _customerEntity.Statuses = new StatusEntity
                {
                    NotStarted = customer.NotStarted,
                    Started = customer.Started,
                    Closed = customer.Closed,
                };


            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }



        public static async Task SaveAsync(Employee employee)
        {
            var _employeeEntity = new EmployeeEntity
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };

            _context.Add(_employeeEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var _customers = new List<Customer>();

            foreach (var _customer in await _context.Customers.Include(x => x.Cases).ThenInclude(x => x.Addresses).Include(x => x.Comments).ToListAsync())

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
                    UpdateComment = _customer.Comments.UpdateComment,
                    UpdatedAt = DateTime.Now,
                    StreetName = _customer.Addresses.SteetName,
                    Postalcode = _customer.Addresses.PostalCode,
                    City= _customer.Addresses.City,


                }); 
            return _customers;
        }
  

        public static async Task<Customer> GetAsync(string email)
        {
            var _customer = await _context.Customers.Include(x => x.Cases).ThenInclude(x => x.Addresses).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);
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
                    UpdateComment = _customer.Comments.UpdateComment,
                    UpdatedAt = DateTime.Now,
                    StreetName = _customer.Addresses.SteetName,
                    Postalcode = _customer.Addresses.PostalCode,
                    City = _customer.Addresses.City,
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
                if (!string.IsNullOrEmpty(customer.StreetName) || !string.IsNullOrEmpty(customer.Postalcode) || !string.IsNullOrEmpty(customer.City))
                if (!string.IsNullOrEmpty(customer.UpdateComment))
                    {
                var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.UpdateComment == customer.UpdateComment && x.UpdatedAt == customer.UpdatedAt);
                if (_commentEntity != null)
                _customerEntity.CommentsId = _commentEntity.Id;
                else
                _customerEntity.Comments = new CommentEntity
                {
                    UpdateComment = customer.UpdateComment,
                    UpdatedAt= DateTime.UtcNow,

                };
                    var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.CaseTitle == customer.CaseTitle && x.Description == customer.Description && x.UpdateComment == customer.UpdateComment);
                    if (_caseEntity != null)
                        _customerEntity.CaseId = _caseEntity.Id;
                    else
                        _customerEntity.Cases = new CaseEntity
                        {
                            CaseTitle = customer.CaseTitle,
                            Description = customer.Description,
                            CreatedAt = DateTime.Now,
                        };
                        var _adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.SteetName == customer.StreetName && x.PostalCode == customer.Postalcode && x.City == customer.City);
                        if (_adressEntity != null)
                            _customerEntity.AddressId = _adressEntity.Id;
                        else
                            _customerEntity.Addresses = new AddressEntity
                            {
                                SteetName = customer.StreetName,
                                PostalCode = customer.Postalcode,
                                City = customer.City,
                        };
                    }
                _context.Update(_customerEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(string email)
        {
            var customer = await _context.Customers.Include(x => x.Cases).ThenInclude(x => x.Addresses).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

    }
}


