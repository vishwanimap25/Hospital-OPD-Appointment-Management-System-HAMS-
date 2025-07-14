using Hospital_OPD___Appointment_Management_System__HAMS_.Data;
using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBcontext context;

        public UserRepository(ApplicationDBcontext context)
        {
            this.context = context;
        }

        public async Task AddAsync(User user)
        {
            await context.User.AddAsync(user);
        }

        public void Delete(User user)
        {
            context.User.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.User.ToListAsync();
        }

        public Task<User> GetIdByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
