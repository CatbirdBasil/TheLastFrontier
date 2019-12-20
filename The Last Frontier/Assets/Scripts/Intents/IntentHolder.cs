namespace Intents
{
    public class IntentHolder
    {
        private static IntentHolder _instance;

        private IntentHolder()
        {
            CurrentIntent = Intent.LoadLevelsMenu;
            CurrentPayload = null;
        }

        public Intent CurrentIntent { get; private set; }
        public object CurrentPayload { get; private set; }

        public static IntentHolder Instance
        {
            get
            {
                if (_instance == null) _instance = new IntentHolder();

                return _instance;
            }
        }

        public void SetIntent(Intent intent)
        {
            CurrentIntent = intent;
            CurrentPayload = null;
        }

        public void SetIntent(Intent intent, object payload)
        {
            CurrentIntent = intent;
            CurrentPayload = payload;
        }
    }
}