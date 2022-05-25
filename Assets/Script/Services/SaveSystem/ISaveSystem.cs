using System;

namespace Script.Services.SaveSystem
{
    public interface ISaveSystem
    {
        void Save<T>(T data, Action onSaveCompleted = null);
        T Load<T>(Action onLoadCompleted = null) where T : class;
    }
}