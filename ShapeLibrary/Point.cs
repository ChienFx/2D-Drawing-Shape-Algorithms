
namespace ShapeLibrary
{
    public class Point
    {
        public int x, y;
        public Point(int m_X, int m_Y)
        {
            this.x = m_X;
            this.y = m_Y;
        }
        public int getX() { return this.x; }
        public int getY() { return this.y; }
        public void setX(int m_X) { this.x = m_X; }
        public void setY(int m_Y) { this.y = m_Y; }
        public double getDistance(Point M)
        {
            return System.Math.Sqrt((M.x - this.x) * (M.x - this.x) + (M.y - this.y) * (M.y - this.y));
        }
        
    }
}
