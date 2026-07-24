using Game.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Settings
{
    public class SaveLoadPanel : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;

        private ISaveService saveService;

        // saveService приходить через DI
        public void Construct(ISaveService saveService)
        {
            this.saveService = saveService;
            loadButton.interactable = saveService.HasSave();
        }

        private void Start()
        {
            saveButton.onClick.AddListener(() => saveService.SaveGame());
            loadButton.onClick.AddListener(() => saveService.LoadGame());
        }
    }
}