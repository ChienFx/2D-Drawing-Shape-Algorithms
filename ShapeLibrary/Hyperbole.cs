using System;
using System.Collections.Generic;

namespace ShapeLibrary
{
    public class Hyperbole : Shape, InterfaceDrawingAlgorithm
    {
        public Point I;
        public Point Bound;
        public int a;

        public Hyperbole(Point root, Point pBound, int mA)
        {
            if (mA > 0 && mA < MAX_WIDTH / 2)
                a = mA;
            else
                a = 10;
            I = root;
            if (pBound.x < I.x)
                pBound.x = I.x + (I.x - pBound.x);
            if (pBound.y < I.y)
                pBound.y = I.y + (I.y - pBound.y);

            this.Bound = pBound;
        }

        public Hyperbole()
        {
            I = new Point(250, 250);
            Bound = new Point(350, 450);
            a = 10;
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
            if (this.Bound.x < I.x)
                this.Bound.x = I.x + (I.x - this.Bound.x);
            if (this.Bound.y < I.y)
                this.Bound.y = I.y + (I.y - this.Bound.y);
            Point realBound = new Point(Bound.x - I.x, Bound.y - I.y);



            float b = realBound.y*a / (float)Math.Sqrt(Math.Abs(realBound.x*realBound.x - a*a));

            int x = a;
            int y = 0;

            double aa = a * a;
            double bb = b*b;

            //Drawing from while f'x > f'y
            double p = bb * (a + 0.5f) * (a + 0.5f) - aa - aa * bb;

            while (2*bb*x > 2*aa*y && x <= realBound.x && y <= realBound.y)
            {
                shiftAndAddSymmetryPointsToListPoints(new Point(x, y));
                y++;    // y = yi + 1
                if (p < 0)
                {
                    x++;
                    p = p + (2 * bb * x) - (aa) * (2 * y + 1);
                }
                else
                {
                    p = p - (aa) * (2 * y + 1);
                }
            }

            p = bb * (x + 1) * (x + 1) - aa * (y + 0.5f) * (y + 0.5f) - aa * bb;//

            while (x <= realBound.x && y <= realBound.y)
            {
                shiftAndAddSymmetryPointsToListPoints(new Point(x, y));
                x++;
                if (p < 0)
                {
                    p = p + bb * (2 * x + 1);
                }
                else
                {
                    y++;
                    p = p + bb * (2 * x + 1) - 2*aa*y;
                }
            }

            return mListPoints;
        }

        private void shiftAndAddSymmetryPointsToListPoints(Point p)
        {
            Point topLeft = getPointAfterShift(new Point(-p.x, p.y), this.I);
            Point topRight = getPointAfterShift(p, this.I);
            Point bottomLeft = getPointAfterShift(new Point(-p.x, -p.y), this.I);
            Point bottomRight = getPointAfterShift(new Point(p.x, -p.y), this.I);

            mListPoints.Add(topLeft);
            mListPoints.Add(topRight);
            mListPoints.Add(bottomLeft);
            mListPoints.Add(bottomRight);

            setPointToBitmap(topLeft);
            setPointToBitmap(topRight);
            setPointToBitmap(bottomLeft);
            setPointToBitmap(bottomRight);
               
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
