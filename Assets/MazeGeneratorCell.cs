namespace DefaultNamespace
{
    public class MazeGeneratorCell
    {
        public int x;
        public int y;

        public bool WallLeft;
        public bool WallBottom;
        public bool Floor = true;
        public bool IsATrap = false;

        public bool Visited;
        
    }
}