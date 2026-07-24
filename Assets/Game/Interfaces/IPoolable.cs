namespace Game.Interfaces
{
    /// <summary>
    /// Контракт для об'єктів, які можуть перевикористовуватись через Object Pool.
    /// Реалізовується на компонентах, що потребують скидання стану при виході з пулу.
    /// </summary>
    public interface IPoolable
    {
        void OnSpawn();
        void OnDespawn();
    }
}