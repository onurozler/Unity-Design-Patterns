using System;

namespace Publisher.Subscriber
{
    public static class AccomplishmentEventBroker
    {
        public static event Action OnPlayerSuccessful;
        public static event Action OnPlayerFail;
    
        public static void CallOnPlayerSuccessful()
        {
            if (OnPlayerSuccessful != null) 
                OnPlayerSuccessful();
        }

        public static void CallOnPlayerFail()
        {
            if (OnPlayerFail != null) 
                OnPlayerFail();
        }
    }
}

