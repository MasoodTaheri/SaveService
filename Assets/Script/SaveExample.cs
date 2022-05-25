using Script.Services.SaveSystem;
using UnityEngine;

namespace Script
{
    public class SaveExample : MonoBehaviour
    {
        [SerializeField] private ISaveSystem _saveSystem;

        private void Start()
        {
            var settings = new GameSettings();
            settings.musicVolume = 10;
            settings.sfxVolume = 20;
            
            _saveSystem = new SaveToPlayerPrefs();
            _saveSystem.Save(settings);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                var settings = _saveSystem.Load<GameSettings>();
                Debug.Log(settings.musicVolume);
            }
        }
    }

    [System.Serializable]
    public class GameSettings
    {
        public int musicVolume;
        public int sfxVolume;
    }
}