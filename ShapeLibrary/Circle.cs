using System;
using System.Collections.Generic;

namespace ShapeLibrary
{
    public class Circle : Shape, InterfaceDrawingAlgorithm
    {
        public Point I;
        public int R;
        
        public Circle()
        {
            I = new Point(10, 10);
            R = 5;
        }
        public Circle(Point center, int radius)
        {
            if(radius > 0 && center.x >0 && center.y >0)
            {
                this.I = center;
                this.R = radius;
            }
            else
            {
                I = new Point(10, 10);
                R = 5;
            }
        }

       

        public override List<Point> getListPoints()
        {

            if (mListPoints == null)
                mListPoints = new List<Point>();
            else
                mListPoints.Clear();

            if (this.mAlgorithm == Algorithm.DDA_Circle)
                return getListPointsUsingDDA();
            else
                return getListPointsUsingMidPoint();
        }

        public List<Point> getListPointsUsingBresenham()
        {
            throw new NotImplementedException();
        }

        public List<Point> getListPointsUsingDDA()
        {
            int r2 = R * R;
            Point p = new Point(0, R);
            shiftAndAddSymmetryPointsToListPoints(p);
            int x = 1;
            int y = myRound((float)Math.Sqrt(r2 - x * x));
            p.x = x; p.y = y;
            while(x <= y)
            {
                shiftAndAddSymmetryPointsToListPoints(p);
                x++;
                y = myRound((float)Math.Sqrt(r2 - x * x));
                p.x = x; p.y = y;
            }
            return mListPoints;
        }

        

        public List<Point> getListPointsUsingMidPoint()
        {
            Point pTmp = new Point(0, R);
            shiftAndAddSymmetryPointsToListPoints(pTmp);
            int x = 0, y = this.R;

            int p = 1 - R;

            while(x<=y)
            {
                if (p < 0)
                {
                    p = p + 2 *(x+1) + 1;
                }
                else
                {
                    y--;        //now y(k+1) = yk - 1
                    p = p + 2*(x+1) + 1 - 2*y;                   
                }
                if (x <= y)
                {
                    pTmp.x = x; pTmp.y = y;
                    shiftAndAddSymmetryPointsToListPoints(pTmp);
                    x++;

                }
            }
            return mListPoints;
        }

        private void shiftAndAddSymmetryPointsToListPoints(Point p)
        {
            Point p0 = getPointAfterShift(new Point(p.x, p.y), this.I);
            Point p1 = getPointAfterShift(new Point(p.x, -p.y), this.I);
            Point p2 = getPointAfterShift(new Point(-p.x, p.y), this.I);
            Point p3 = getPointAfterShift(new Point(-p.x, -p.y), this.I);

            Point p4 = getPointAfterShift(new Point(p.y, p.x), this.I);
            Point p5 = getPointAfterShift(new Point(p.y, -p.x), this.I);
            Point p6 = getPointAfterShift(new Point(-p.y, p.x), this.I);
            Point p7 = getPointAfterShift(new Point(-p.y, -p.x), this.I);

            mListPoints.Add(p0);
            mListPoints.Add(p1);
            mListPoints.Add(p2);
            mListPoints.Add(p3);
            mListPoints.Add(p4);
            mListPoints.Add(p5);
            mListPoints.Add(p6);
            mListPoints.Add(p7);

            setPointToBitmap(p0);
            setPointToBitmap(p1);
            setPointToBitmap(p2);
            setPointToBitmap(p3);
            setPointToBitmap(p4);
            setPointToBitmap(p5);
            setPointToBitmap(p6);
            setPointToBitmap(p7);

        }
    }
}
