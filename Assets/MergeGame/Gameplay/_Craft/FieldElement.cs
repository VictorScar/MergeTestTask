namespace MergeGame.Gameplay._Craft
{
    public class FieldElement
    {
        private FieldElementData _data;

        public FieldElementData Data => _data;
    
        public FieldElement(FieldElementData data)
        {
            _data = data;
        }
    }
}