namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; private set; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }

        public bool PickFruit(int numberOfPiecesToRemote)
        {
            bool canPickFruit = PiecesOfFruitLeft >= numberOfPiecesToRemote;
            if (canPickFruit)
                PiecesOfFruitLeft -= numberOfPiecesToRemote;
            return canPickFruit;
        }
        
    }
}
