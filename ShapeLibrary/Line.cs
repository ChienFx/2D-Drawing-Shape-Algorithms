using System;
using System.Collections.Generic;

namespace ShapeLibrary
{
    public class Line : Shape, InterfaceDrawingAlgorithm
    {
        /*Attibutes*/
        public Point p1, p2;
        
        /*Contructor*/
        public Line()
        {
            p1 = new Point(0, 0);

            p2 = new Point(0, 50);
        }
        public Line(Point m_P1, Point m_P2)
        {
            if(m_P1.getX() < m_P2.getX())
            {
                p1 = m_P1;
                p2 = m_P2;
            }
            else
            {
                p1 = m_P2;
                p2 = m_P1;
            }
        }
        public Point getP1() { return p1; }
        public Point getP2() { return p2; }
        /* Func: getDx
         * return (x2-x1)
         */
        private int getDx() { return (p2.getX() - p1.getX()); }

        /* Func: getDx
         * return (x2-x1)
        */
         private int getDy() { return (p2.getY() - p1.getY()); }


        /*Override methods*/
        public override List<Point> getListPoints()
        {
            if (mListPoints == null)
                mListPoints = new List<Point>();
            else
                mListPoints.Clear();


            if (this.mAlgorithm == Algorithm.DDA_Line)
                return getListPointsUsingDDA();
            else if (this.mAlgorithm == Algorithm.Bresenham_Line)
                return getListPointsUsingBresenham();
            else if (this.mAlgorithm == Algorithm.MidPoint_Line)
                return getListPointsUsingMidPoint();
            else
                return getListPointsUsingXiaolinWu();
        }

        

        /* Draw a line contains P1 and P2 using DDA Algorithm
         * Return: a list of points
         */
        public List<Point> getListPointsUsingDDA()
        {
            storePointAndDraw(p1.x, p1.y);
            //generat points here
            int dx = getDx();
            int dy = getDy();
            float steps;
            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            
            float xInc = dx / steps;
            float yInc = dy / steps;

            float x = p1.getX(), y = p1.getY();
            for (int i = 0; i < Math.Abs(steps); i++)
            {
                x += xInc;
                y += yInc;
                storePointAndDraw(myRound(x), myRound(y));
                
            }          
            return mListPoints;
        }

        private void storePointAndDraw(int x, int y)
        {
            mListPoints.Add(new Point(x, y));
            if (x >= 0 && x < mBitmap.Width && y >= 0 && y < mBitmap.Height)
                mBitmap.SetPixel(x, y, mColor); ;
        }

        /* Draw a line contains P1 and P2 using Bresenham Algorithm
         * Return: a list of points
         */
        public List<Point> getListPointsUsingBresenham()
        {
            storePointAndDraw(p1.x, p1.y);
            //generat points here

            int xInc = 0, yInc = 0, xe = 0, ye = 0, steps = 0, dx = this.getDx(), dy = this.getDy();
            int Dx = Math.Abs(dx), Dy = Math.Abs(dy);
            int p, const1, const2;
            int x = p1.x, y = p1.y;

            if (Dx > Dy)
            {
                p = 2 * Dy - Dx;
                const1 = 2 * Dy;
                const2 = 2 * (Dy - Dx);
                steps = Dx;
                if(Dx!=0)
                    xInc = dx/Dx;
                if(Dy != 0)
                    ye = dy / Dy;
            }
            else
            {
                p = 2 * Dx - Dy;
                const1 = 2 * Dx;
                const2 = 2 * (Dx - Dy); 
                steps = Dy;
                if(Dy != 0)
                    yInc = dy/Dy;
                if(Dx!=0)
                    xe = dx / Dx;
            }

            for(int i = 0; i < steps; i++)
            {
                if(p < 0)
                {
                    p = p + const1;
                }
                else
                {
                    p = p + const2;
                    x = x + xe;
                    y = y + ye;
                }
                x = x + xInc;
                y = y + yInc;
                storePointAndDraw(x, y);
            }

            return mListPoints;
        }

        /* Draw a line contains P1 and P2 using MidPoint Algorithm
         * Return: a list of points
         */
        public List<Point> getListPointsUsingMidPoint()
        {
            return getListPointsUsingBresenham();
        }





        /*Xiaolin Wu algorithm
         * 
         */
                 

        private List<Point> getListPointsUsingXiaolinWu()
        {
            storePointAndDraw(p1.x, p1.y);
            //generat points here
            int dx = getDx();
            int dy = getDy();
            float steps;
            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);

            float xInc = dx / steps;
            float yInc = dy / steps;

            float x = p1.getX(), y = p1.getY();
            for (int i = 0; i < Math.Abs(steps); i++)
            {
                x += xInc;
                y += yInc;
                storePointAndDraw(myRound(x), myRound(y));

            }
            return mListPoints;

        }
    }
}
