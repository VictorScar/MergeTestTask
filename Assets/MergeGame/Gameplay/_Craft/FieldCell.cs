using System;
using UnityEngine;

namespace MergeGame.Gameplay._Craft
{
    public class FieldCell
    {
        private FieldElement _fieldElement;
        private Vector2Int _address;
        public event Action<FieldElement> onItemAdded;
        public event Action onItemRemoved;

        public FieldCell(int rowNumber, int cellIndex)
        {
            _address = new Vector2Int(rowNumber, cellIndex);
        }

        public Vector2Int Address => _address;
        
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