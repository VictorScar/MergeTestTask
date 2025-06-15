using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace MergeGame._ProfileData
{
    [CreateAssetMenu(menuName = "Configs/ResourcesConfig", fileName = "RecourcesConfig")]
    public class ResourcesConfig : ScriptableObject
    {
        [SerializeField] private ResourceData[] resource;

        public ResourceData[] ResourceDatas => resource;

        public bool TryGetResourceData(ResourceID id, out ResourceData resourceData)
        {
            foreach (var data in resource)
            {
                if (data.ID == id)
                {
                    resourceData = data;
                    return true;
                }
            }

            resourceData = new ResourceData();
            return false;
        }
    }
}
