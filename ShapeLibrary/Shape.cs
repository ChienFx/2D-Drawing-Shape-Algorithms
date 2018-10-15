using System.Collections.Generic;
using System.Drawing;

namespace ShapeLibrary
{
    public abstract class Shape
    {
        protected List<Point> mListPoints;
        protected Bitmap mBitmap;
        protected Color mColor;
        protected Algorithm mAlgorithm;

        public void drawShape(ref Bitmap bitmap, Color color, Algorithm algorithm)
        {
            this.mBitmap = bitmap;
            this.mColor = color;
            this.mAlgorithm = algorithm;
            this.getListPoints();
        }

        public abstract List<Point> getListPoints();

        public const int MAX_WIDTH = 880;
        public const int MAX_HEIGHT = 600;

        public int myRound(float f)
        {
            int tmp;
            if (f % 1.0f >= .5f)
                tmp = (int)(f) + 1;
            else
                tmp = (int)(f);
            return tmp;
        }
        public bool pointIsInBitmap(Point point)
        {
            if (point.x > 0 && point.x < mBitmap.Width && point.y > 0 && point.y < mBitmap.Height)
                return true;
            return false;
        }

        public void setPointToBitmap(Point point)
        {
            if (pointIsInBitmap(point))
                mBitmap.SetPixel(point.x, point.y, mColor);
        }

        public Point getPointAfterShift(Point curPoint, Point pNail)
        {
            return new Point(curPoint.x + pNail.x, curPoint.y + pNail.y);
        }
    }

    public enum Algorithm
    {
        DDA_Line,
        Bresenham_Line,
        MidPoint_Line,
        Xiaolin_Line,

        DDA_Circle,
        MidPoint_Circle,

        MidPoint_Ellipse,
        MidPoint_Hyperbole,
        MidPoint_Parabola
    }
}