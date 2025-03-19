using MergeGame.Core;
using UnityEngine;

namespace MergeGame.Controllers
{
    public abstract class GameplayControllerBase : MonoBehaviour
    {
        public abstract void Init(GameConfig config);
    }
}