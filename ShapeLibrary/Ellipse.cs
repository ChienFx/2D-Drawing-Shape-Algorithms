using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Ellipse : Shape, InterfaceDrawingAlgorithm
    {
        public Point I;
        public int a;
        public int b;
        public Ellipse()
        {
            I = new Point(342, 203);
            a = 363; b = 198;
        }
        public Ellipse(Point center, int ra, int rb)
        {
            if(center.x >=0 && center.y >=0 && ra >0 && rb > 0)
            {
                I = center; a = ra; b = rb;
            }
            else
            {
                I = new Point(20, 20);
                a = 10;
                b = 5;
            }
        }

        public override List<Point> getListPoints()
        {
            if (mListPoints == null)
                mListPoints = new List<Point>();
            else
                mListPoints.Clear();
            return this.getListPointsUsingMidPoint();
            return this.getListPointsUsingBresenham();
        }


        public List<Point> getListPointsUsingMidPoint()
        {
            int x = 0;
            int y = b;

            double aa = a * a;
            double bb = b * b;

            //Drawing from while f'x > f'y
            double p = b * b - a * a * b + (a * a) / 4.0f;

            while (x * bb < y * aa)
            {
                shiftAndAddSymmetryPointsToListPoints(new Point(x, y));
				
				x++; 	//x = x +1
                if (p < 0)
                {
                    p = p + (2 * bb * x) + bb;
                }
                else
                {
                    y = y - 1;
                    p = p + 2*bb*x - 2*aa* y + bb;
                }
            }

            //Drawing from while f'x < f'y

            p = bb * (x + 0.5) * (x + 0.5) + aa * (y - 1) * (y - 1) - aa * bb;

            while (y >= 0)
            {
                shiftAndAddSymmetryPointsToListPoints(new Point(x, y));

                y--;    //y(i+1) = yk -1
                if(p < 0)
                {
                    x = x + 1;
                    p = p + 2*bb*x - 2*aa*y + aa;
                }
                else
                {
                    p = p - 2*aa*y + aa;
                }
            }
            
            return mListPoints;
        }


        

        public List<Point> getListPointsUsingBresenham()
        {
            return null;
        }

        public List<Point> getListPointsUsingDDA()
        {
            return null;
        }

        private void shiftAndAddSymmetryPointsToListPoints(Point p)
        {
            Point topLeft = getPointAfterShift(new Point(-p.x, p.y), this.I);
            Point topRight = getPointAfterShift(p, this.I);
            Point bottomLeft = getPointAfterShift(new Point(-p.x, -p.y), this.I);
            Point bottomRight = getPointAfterShift(new Point(p.x, -p.y), this.I);

            mListPoints.Add(topLeft);
            mListPoints.Add(topRight);
            mListPoints.Add(topRight);
            mListPoints.Add(bottomLeft);
            mListPoints.Add(bottomRight);

            setPointToBitmap(topLeft);
            setPointToBitmap(topRight);
            setPointToBitmap(bottomLeft);
            setPointToBitmap(bottomRight);
        }

    }
}
