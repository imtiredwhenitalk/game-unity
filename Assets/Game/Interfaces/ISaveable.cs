namespace Game.Interfaces
{
    /// <summary>
    /// Контракт для будь-якого об'єкта, стан якого потрібно зберігати/відновлювати.
    /// </summary>
    public interface ISaveable
    {
        string SaveId { get; }
        object CaptureState();
        void RestoreState(object state);
    }
}