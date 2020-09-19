using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Presistence.Repositories;

namespace GigHub.Presistence
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendances { get; private set; } 
        public IFollowingRepository Followings { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public INotificationRepository Notifications { get; private set; }
        public IUserNotificationRepository UserNotifications { get; private set; }
        public IApplicationUserRepository Users { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Genres = new GenreRepository(context);
            Notifications = new NotificationRepository(context);
            Followings = new FollowingRepository(context);
            UserNotifications = new UserNotificationRepository(context);
            Users = new ApplicationUserRepository(context);

        }


        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}