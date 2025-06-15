using System;

namespace MergeGame._ProfileData
{
    public class GameResource
    {
        private readonly ResourceID _id;
        private int _amount;

        public event Action<ResourceID, int> onCountChanged;

        public GameResource(ResourceID id, int startAmount)
        {
            _id = id;
            _amount = startAmount;
        }

        public ResourceID ID => _id;
        public int Amount => _amount;

        public bool Add(int count)
        {
            _amount += count;
            onCountChanged?.Invoke(_id, _amount);
            return true;
        }

        public bool Remove(int count)
        {
            _amount -= count;

            if (_amount < 0)
            {
                _amount = 0;
                onCountChanged?.Invoke(_id, _amount);
                return false;
            }
            
            onCountChanged?.Invoke(_id, _amount);
            return true;
        }
    }
}