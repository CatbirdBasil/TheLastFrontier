namespace Intents
{
    public abstract class IntentResolver
    {
        public T GetPayload<T>()
        {
            return (T) IntentHolder.Instance.CurrentPayload;
        }

        public abstract void Resolve(Intent intent, object payload);

        public void Resolve()
        {
            Resolve(IntentHolder.Instance.CurrentIntent, IntentHolder.Instance.CurrentPayload);
        }
    }
}