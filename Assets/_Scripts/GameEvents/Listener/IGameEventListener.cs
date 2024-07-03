namespace MyProject.Events.Listener
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}