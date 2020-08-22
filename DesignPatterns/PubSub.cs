using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class PubSub
    {
        public static void Driver()
        {
            Publisher youtube = new Publisher("YOUTUBE", 1000);
            Publisher faceBook = new Publisher("FACEBOOK", 2000);

            Subscriber subscriberOne = new Subscriber("FLORIN");
            Subscriber subscriberTwo = new Subscriber("THORIN");
            Subscriber subscriberThree = new Subscriber("CHLORIN");

            subscriberOne.Subscribe(youtube);
            subscriberTwo.Subscribe(youtube);
            subscriberThree.Subscribe(youtube);

            subscriberOne.Subscribe(faceBook);
            subscriberTwo.Subscribe(faceBook);
            subscriberThree.Subscribe(faceBook);


            Task task1 = Task.Factory.StartNew(() => youtube.Publish());
            Task task2 = Task.Factory.StartNew(() => faceBook.Publish());
            Task.WaitAll(task1, task2);

        }
    }

    public class Publisher
    {
        public string Name { get; }

        public int NotificationInterval { get; }

        public delegate void Notify(Publisher publisher, NotificationEvent notificationEvent);

        public event Notify OnPublish;

        public Publisher(string name, int interval)
        {
            Name = name;
            NotificationInterval = interval;
        }

        public void Publish()
        {
            if(OnPublish!= null)
            {
                NotificationEvent notificationEvent = new NotificationEvent($"Published form {Name}", DateTime.Now);
                OnPublish(this, notificationEvent);
            }
        }
        
    }

    public class Subscriber
    {
        public string SubsriberName { get; }
        public Subscriber(string subName)
        {
            SubsriberName = subName;
        }

        public void Subscribe(Publisher publisher)
        {
            publisher.OnPublish += OnNotificationRecieved;
        }

        public void UnSubscribe(Publisher publisher)
        {
            publisher.OnPublish -= OnNotificationRecieved;
        }

        protected virtual void OnNotificationRecieved(Publisher publisher, NotificationEvent notificationEvent)
        {
            Console.WriteLine($"Hey, {SubsriberName}, {notificationEvent.NotificationMessage} - {publisher.Name} at {notificationEvent.NotificationDate}");
        }
    }

    public class NotificationEvent : EventArgs
    {
        public string NotificationMessage { get; }
        public DateTime NotificationDate { get; }
        public NotificationEvent(string notificationMessage, DateTime notificationDate)
        {
            NotificationMessage = notificationMessage;
            NotificationDate = notificationDate;
        }
    }
}
