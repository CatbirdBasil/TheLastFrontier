using System;

namespace Intent
{
    public class IntentHolder
    {
        public Intent CurrentIntent { get; private set; }
        public Object CurrentPayload { get; private set; }

        private IntentHolder()
        {
            CurrentIntent = Intent.LoadLevelsMenu;
            CurrentPayload = null;
        }

        private static IntentHolder _instance;
        public static IntentHolder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IntentHolder();
                }
            
                return _instance;  
            }
        }

        public void SetIntent(Intent intent)
        {
            CurrentIntent = intent;
            CurrentPayload = null;
        }
        
        public void SetIntent(Intent intent, Object payload)
        {
            CurrentIntent = intent;
            CurrentPayload = payload;
        }
    }
}