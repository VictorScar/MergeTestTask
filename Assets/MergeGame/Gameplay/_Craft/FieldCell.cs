using System;

namespace MergeGame.Gameplay._Craft
{
    public class FieldCell
    {
        private FieldElement _fieldElement;
        public event Action<FieldElement> onItemAdded;
        public event Action onItemRemoved;

        public FieldElement FieldElement
        {
            get => _fieldElement;
            set
            {
                _fieldElement = value;

                if (value != null)
                {
                    onItemAdded?.Invoke(_fieldElement);
                }
                else
                {
                    onItemRemoved?.Invoke();
                }
            }
        }

        public bool HasElement => FieldElement != null;


        public void Clear()
        {
            FieldElement = null;
        }
    }
}