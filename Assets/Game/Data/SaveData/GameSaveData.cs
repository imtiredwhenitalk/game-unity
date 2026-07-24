using System;
using System.Collections.Generic;

namespace Game.Data.SaveData
{
    [Serializable]
    public class GameSaveData
    {
        public string saveDate;
        public int waveNumber;
        public float playTimeSeconds;

        // Ключ — SaveId об'єкта, значення — серіалізований стан (JSON конкретного об'єкта)
        public List<SaveEntry> entries = new();
    }

    [Serializable]
    public class SaveEntry
    {
        public string saveId;
        public string jsonState;
    }
}