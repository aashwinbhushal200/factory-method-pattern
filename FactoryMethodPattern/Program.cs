using FactoryMethodPattern;

namespace FactoryMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationServiceProvider nsp = new NotificationServiceProvider();
            ShipppingService shipppingService = new ShipppingService(nsp);

            shipppingService.ShipItem();
        }
    }
    interface IUserNotfigy
    {
        void NotifyUser(int id);
    }


    class EmailUserNotifier : IUserNotfigy
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine("Notified by email");
        }
    }
    class TestUserNotifier : IUserNotfigy
    {
        public void NotifyUser(int id)
        {
            Console.WriteLine("Notified by Test");
        }
    }

    //creator object
    class NotificationServiceProvider
    {
        public IUserNotfigy GetUserNotifier()
        {
#if DEBUG
            return new TestUserNotifier();
#else
            
            return new EmailUserNotifier();
#endif
        }
    }

    //service using notificationProvider
    class ShipppingService
    {
        NotificationServiceProvider _notificationServiceProvider;

        public ShipppingService(NotificationServiceProvider notificationServiceProvider)
        {
            _notificationServiceProvider = notificationServiceProvider;
        }
        public void ShipItem()
        {
            _notificationServiceProvider.GetUserNotifier().NotifyUser(1);
        }

    }
}
