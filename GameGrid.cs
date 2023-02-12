namespace Snake
{
    public class GameGrid
    {
        /// <summary>
        ///     <list type="table">
        ///         <item>0 = empty</item>
        ///         <item>1 = snake</item>
        ///         <item>2 = snake head</item>
        ///         <item>3 = apple</item>
        ///     </list>
        /// </summary>
        public int[,] Map;

        public Vector2 Size;

        public void SetAt(int x, int y, int value)
        {
            Map[x, y] = value;
            Size = new Vector2(x, y);
        }

        public void SetAt(Vector2 pos, int value)
        {
            Map[pos.X, pos.Y] = value;
        }

        public GameGrid(int X, int Y)
        {
            Map = new int[X, Y];
        }
    }
}
