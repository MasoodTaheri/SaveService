using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Script.Services.SaveSystem
{
    public class SaveToFile : ISaveSystem
    {
        private static readonly string SaveAddress = Path.Combine(Application.persistentDataPath, "Data") ;

        public void Save<T>(T data, Action onSaveCompleted = null)
        {
            var json = JsonConvert.SerializeObject(data);
            var keyName = typeof(T).Name;
            var dir = Path.Combine(SaveAddress, keyName);
            StreamWriter writer = new StreamWriter(dir);
            writer.WriteLine(json);
            writer.Close();
            onSaveCompleted?.Invoke();
        }

        public T Load<T>(Action onLoadCompleted = null) where T : class
        {
            var keyName = typeof(T).Name;
            if (!Directory.Exists(SaveAddress))
            {
                Directory.CreateDirectory(SaveAddress);
            }
            if (!File.Exists(Path.Combine(SaveAddress, keyName)))
                return null;

            var streamReader = new StreamReader(Path.Combine(SaveAddress, keyName));
            onLoadCompleted?.Invoke();
            return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());

        }
    }
}