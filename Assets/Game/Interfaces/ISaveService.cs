namespace Game.Interfaces
{
    public interface ISaveService
    {
        void Register(ISaveable saveable);
        void Unregister(ISaveable saveable);

        void SaveGame(string slotName = "default");
        bool LoadGame(string slotName = "default");
        bool HasSave(string slotName = "default");
        void DeleteSave(string slotName = "default");
    }
}