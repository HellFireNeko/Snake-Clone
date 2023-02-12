namespace Snake
{
    /// <summary>
    /// Only works for a 10 x 10 grid...
    /// </summary>
    public static class HamiltonianCycle
    {
        static readonly int[] Path = new int[100]
        { 
            1, 1, 1, 1, 1, 0, 2, 0, 1, 0 ,2, 0, 1, 0, 0, 2, 3, 2, 0, 0, 2, 0, 1, 1, 3, 1, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1, 1, 1, 1, 0, 2, 0, 1, 1, 3, 3, 1, 3, 2, 3, 1, 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 2, 0, 2, 2, 0, 0, 1, 3, 1, 0, 0, 2, 2, 2, 2, 3, 1, 3, 2, 3, 1, 3, 2, 3, 1, 1, 0, 1, 3, 1
        };

        public static Direction GetDirection(int step)
        {
            int node = Path[step];

            return (Direction)node;
        }
    }
}
