namespace Snake
{
    public struct Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Compare(Vector2 obj)
        {
            if (X == obj.X && Y == obj.Y)
                return true;
            return false;
        }
    }
}
