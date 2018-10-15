using System;
using System.Collections.Generic;

namespace ShapeLibrary
{
    public class Parabola : Shape, InterfaceDrawingAlgorithm
    {
        public Point I;
        public Point Bound;
        public Parabola(Point root, Point pBound)
        {
            I = root;
            if (pBound.x < I.x)
                pBound.x = I.x + (I.x - pBound.x);
            this.Bound = pBound;
        }

        public Parabola()
        {
            I = new Point(50, 50);
            Bound = new Point(60, 70);
        }

        public override List<Point> getListPoints()
        {
            if (mListPoints == null)
                mListPoints = new List<Point>();
            else
                mListPoints.Clear();
            return getListPointsUsingMidPoint();
        }


        public List<Point> getListPointsUsingMidPoint()
        {
            Point realBound = new Point(Bound.x - I.x, Bound.y - I.y);
            float a = (float)realBound.y / (realBound.x * realBound.x);
            int sign = a > 0 ? 1 : -1;
            a = a * sign;
            int x = 0;
            int y = 0;

            //Drawing from while f'x > f'y
            double p = a - 0.5f;

            while (x <= 1.0f / (2.0f * a))
            {
                shiftAndAddSymmetryPointsToListPoints(new Point(x, y));

                x++; 	//x = x +1
                if (p < 0)
                {
                    p = p + 2 * x * a + a;
                }
                else
                {
                    y = y + sign;
                    p = p + 2 * x * a + a - 1;
                }
            }

            p = a / 4 - 0.5f;

            while (Math.Abs(y) < Math.Abs(realBound.y))
            {
                shiftAndAddSymmetryPointsToListPoints(new Point(x, y));
                y = y + sign;
                if (p < 0)
                {
                    x++;
                    p = p + 2 * a * x - 1;
                }
                else
                {
                    p = p - 1;
                }
            }

            return mListPoints;
        }

        private void shiftAndAddSymmetryPointsToListPoints(Point p)
        {
            Point left = getPointAfterShift(new Point(-p.x, p.y), this.I);
            Point right = getPointAfterShift(p, this.I);

            mListPoints.Add(left);
            mListPoints.Add(right);

            setPointToBitmap(left);
            setPointToBitmap(right);
        }

        public List<Point> getListPointsUsingBresenham()
        {
            throw new NotImplementedException();
        }

        public List<Point> getListPointsUsingDDA()
        {
            throw new NotImplementedException();
        }

    }
}
