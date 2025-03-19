namespace MergeGame.Gameplay._Craft
{
    public class PartGenerator : FieldElement
    {
        private FieldElementData _generatePartData;
        private CraftField _field;

        public FieldElementData GeneratePartData => _generatePartData;

        public PartGenerator(FieldElementData craftableItemData, FieldElementData data) : base(data)
        {
            _generatePartData = craftableItemData;
        }
    }
}