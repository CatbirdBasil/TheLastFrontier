using System;
using Intent;

namespace Level.Loading
{
    public class LevelIntentResolver : IntentResolver
    {
        public override void Resolve(Intent.Intent intent, object payload)
        {
            switch (intent)
            {
                case Intent.Intent.LoadLevel:
                    return;
                default:
                    throw new ArgumentException("Inapplicable intent used (" + intent + ")");
            }
        }
    }
}