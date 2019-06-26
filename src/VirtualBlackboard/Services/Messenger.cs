using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBlackboard.Services
{
    public static class Messenger
    {

        private static List<MessengerObject> registrations = new List<MessengerObject>();
        public static void Register(string Key, Action<object> Method)
        {
            registrations.Add(new MessengerObject(Key, Method));
        }

        public static void Trigger(string Key, object obj)
        {
            foreach (var item in registrations)
            {
                if (item.Key == Key)
                    item.Method.Invoke(obj);
            }
        }


       class MessengerObject
        {
            public MessengerObject(string key, Action<object> method)
            {
                Key = key;
                Method = method;
            }
            public string Key { get; set; }
            public Action<object> Method { get; set; }
        }

    }

}
