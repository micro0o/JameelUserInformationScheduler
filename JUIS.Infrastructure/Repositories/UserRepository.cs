using JUIS.Domain.Entities;
using JUIS.Domain.Interfaces;
using JUIS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JUIS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        private readonly INotificationService _notificationService;

        public UserRepository(UserDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await _notificationService.SendNotification($"User {user.FirstName} {user.LastName} was added.");
        }
    }
}
