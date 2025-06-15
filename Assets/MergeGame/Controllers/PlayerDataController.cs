using MergeGame._ProfileData;
using MergeGame.Core;
using ScarFramework.UI;

namespace MergeGame.Controllers
{
    public class PlayerDataController : GameplayControllerBase
    {
        private PlayerData _playerData;
        private UIScreen _profilePanel;

        public override void Init(GameConfig config)
        {
            _playerData = new PlayerData(config.ResourcesConfig);
        }
    }
}