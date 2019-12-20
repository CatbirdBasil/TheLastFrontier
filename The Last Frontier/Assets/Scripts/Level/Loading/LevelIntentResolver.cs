using System;
using Intents;

namespace Level.Loading
{
    public class LevelIntentResolver : IntentResolver
    {
        public override void Resolve(Intent intent, object payload)
        {
            switch (intent)
            {
                case Intent.LoadLevel:
                    return;
                default:
                    throw new ArgumentException("Inapplicable intent used (" + intent + ")");
            }
        }
    }
}