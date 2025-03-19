using UnityEngine;

namespace MergeGame.Core
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private Game gamePrefab;
        private Game _game;

        private void Start()
        {
            _game = Instantiate(gamePrefab);
            _game.Init();
        }
    }
}