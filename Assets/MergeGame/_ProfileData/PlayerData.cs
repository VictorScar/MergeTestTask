namespace MergeGame._ProfileData
{
    public class PlayerData
    {
        private GameResource[] _resources;
        private int _stageNumber;
        private ResourcesConfig _config;

        public PlayerData(ResourcesConfig config)
        {
            _config = config;
            CreateResourcesData();
        }
        
        public bool AddResource(ResourceID resourceID, int count)
        {
            if (_resources != null)
            {
                foreach (var resource in _resources)
                {
                    if (resource.ID == resourceID)
                    {
                        return resource.Add(count);
                    }
                }
            }

            return false;
        }

        public bool RemoveResource(ResourceID resourceID, int count)
        {
            if (_resources != null)
            {
                foreach (var resource in _resources)
                {
                    if (resource.ID == resourceID)
                    {
                        return resource.Remove(count);
                    }
                }
            }

            return false;
        }

        private void CreateResourcesData()
        {
            if (_config != null)
            {
                var resourceDatas = _config.ResourceDatas;

                if (resourceDatas != null)
                {
                    _resources = new GameResource[resourceDatas.Length];

                    for (int i = 0; i < _resources.Length; i++)
                    {
                        var resource = new GameResource(resourceDatas[i].ID, 0);
                    }
                }
            }
        }
    }
}