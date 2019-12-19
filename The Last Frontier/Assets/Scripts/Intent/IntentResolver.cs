using System;
using UnityEditor.VersionControl;

namespace Intent
{
    public abstract class IntentResolver
    {
        public T GetPayload<T>()
        {
            return (T) IntentHolder.Instance.CurrentPayload;
        }

        public abstract void Resolve(Intent intent, Object payload);

        public void Resolve()
        {
            Resolve(IntentHolder.Instance.CurrentIntent, IntentHolder.Instance.CurrentPayload);
        }
    }
}