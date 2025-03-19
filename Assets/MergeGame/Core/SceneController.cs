using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MergeGame.Core
{
    public class SceneController : MonoBehaviour
    {
        private int _gameSceneNumber;
       
        public event Action onLoadIsCompleted;

        public void Init(int gameSceneIndex)
        {
            _gameSceneNumber = gameSceneIndex;
        }

        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync(_gameSceneNumber).completed += OnLoadCompleted;
        }

        private void OnLoadCompleted(AsyncOperation loadingOperation)
        {
            loadingOperation.completed -= OnLoadCompleted;
            onLoadIsCompleted?.Invoke();
        }
    }
}