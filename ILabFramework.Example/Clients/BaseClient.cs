using IntenseLab.Framework;
using System;

namespace ILabFramework.Example
{
    public abstract class BaseClient
    {
        protected User User { get; }
        protected ILabSession Session { get; private set; }

        protected BaseClient(User user)
        {
            User = user;
        }

        public virtual void StartDemo()
        {
            Logger.Instance.WriteLog("If you want to go back to the previous menu press CTRL+C!!!",ConsoleColor.DarkRed);
            Session = new ILabSession();
            SubscribeSessionEvents();
            try
            {
                Session.Connect(User.Login, User.Password, User.Host, User.Port);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message,ConsoleColor.Red);
            }
            
        }

        public void StopDemo()
        {
            UnsubscribeSessionEvents();
            Session.Disconnect();
        }

        protected abstract void UnsubscribeSessionEvents();
        protected abstract void SubscribeSessionEvents();

    }
}