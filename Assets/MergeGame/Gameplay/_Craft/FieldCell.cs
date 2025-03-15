namespace MergeGame.Gameplay._Craft
{
    public class FieldCell
    {
        public FieldElement FieldElement;
        public bool HasElement => FieldElement != null;

        public void Clear()
        {
            FieldElement = null;
        }
        
        
    }
}