using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Script.Services.SaveSystem
{
    public class SaveToPlayerPrefs : ISaveSystem
    {
        public void Save<T>(T data, Action onSaveCompleted = null)
        {
            var json = JsonConvert.SerializeObject(data);
            var keyName = typeof(T).Name;
            PlayerPrefs.SetString(keyName,json);
            onSaveCompleted?.Invoke();
        }

        public T Load<T>(Action onLoadCompleted = null) where T : class
        {
            T data = null;
            var keyName = typeof(T).Name;
            if (!PlayerPrefs.HasKey(keyName))
                return null;
            
            data = JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(keyName));
            onLoadCompleted?.Invoke();
            return data;
        }
    }
}