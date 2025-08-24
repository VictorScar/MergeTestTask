using MergeGame.Core;
using UnityEngine;

namespace MergeGame.Controllers
{
    public class GameplayControllersProvider : MonoBehaviour
    {
        [SerializeField] private CraftFieldController craftFieldController;

        public CraftFieldController CraftFieldController => craftFieldController;
    }
}