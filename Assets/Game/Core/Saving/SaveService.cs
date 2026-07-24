using System.Collections.Generic;
using System.IO;
using Game.Data.SaveData;
using Game.Interfaces;
using UnityEngine;

namespace Game.Core.Saving
{
    /// <summary>
    /// Центральний сервіс збереження. Не знає про Player/Enemy/Base —
    /// лише збирає ISaveable-об'єкти та серіалізує їхній стан.
    /// </summary>
    public class SaveService : MonoBehaviour, ISaveService
    {
        private readonly List<ISaveable> registered = new();
        private string SaveFolder => Path.Combine(Application.persistentDataPath, "Saves");

        private void Awake()
        {
            if (!Directory.Exists(SaveFolder))
                Directory.CreateDirectory(SaveFolder);
        }

        public void Register(ISaveable saveable)
        {
            if (!registered.Contains(saveable))
                registered.Add(saveable);
        }

        public void Unregister(ISaveable saveable)
        {
            registered.Remove(saveable);
        }

        public void SaveGame(string slotName = "default")
        {
            var saveData = new GameSaveData
            {
                saveDate = System.DateTime.UtcNow.ToString("o"),
                waveNumber = 0, // сюди підʼєднати WaveService, коли буде готовий
                playTimeSeconds = Time.realtimeSinceStartup
            };

            foreach (var saveable in registered)
            {
                var state = saveable.CaptureState();
                saveData.entries.Add(new SaveEntry
                {
                    saveId = saveable.SaveId,
                    jsonState = JsonUtility.ToJson(state)
                });
            }

            var json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(GetPath(slotName), json);

            Debug.Log($"[SaveService] Гру збережено: {slotName}");
        }

        public bool LoadGame(string slotName = "default")
        {
            var path = GetPath(slotName);
            if (!File.Exists(path)) return false;

            var json = File.ReadAllText(path);
            var saveData = JsonUtility.FromJson<GameSaveData>(json);

            var lookup = new Dictionary<string, string>();
            foreach (var entry in saveData.entries)
                lookup[entry.saveId] = entry.jsonState;

            foreach (var saveable in registered)
            {
                if (lookup.TryGetValue(saveable.SaveId, out var stateJson))
                    saveable.RestoreState(stateJson);
            }

            Debug.Log($"[SaveService] Гру завантажено: {slotName}");
            return true;
        }

        public bool HasSave(string slotName = "default") => File.Exists(GetPath(slotName));

        public void DeleteSave(string slotName = "default")
        {
            var path = GetPath(slotName);
            if (File.Exists(path)) File.Delete(path);
        }

        private string GetPath(string slotName) => Path.Combine(SaveFolder, $"{slotName}.json");
    }
}