using System;
using System.Collections.Generic;
using System.Drawing;
using ShapeLibrary;
using Point = ShapeLibrary.Point;

namespace ControllerLibrary
{
    public enum DrawMode
    {
        MODE_NO_ACTION,
        MODE_DRAW_FROM_FILE,
        MODE_DRAW_RANDOM_SHAPE,
        MODE_DRAW_BY_MOUSE
    }
    public class Controller
    {
        /*
        public static int WINDOW_WIDTH = Screen.PrimaryScreen.Bounds.Width;// 800;
        public static int WINDOW_HEIGHT = Screen.PrimaryScreen.Bounds.Height;// Sys480;
        */
        
        public static int WINDOW_WIDTH = 1000;
        public static int WINDOW_HEIGHT = 600;

        public static int TOOLBOX_WIDTH = 130;
        public static int TOOLBOX_HEIGHT = 600;

        public static int PICTURE_BOX_WIDTH = WINDOW_WIDTH - TOOLBOX_WIDTH;
        public static int PICTURE_BOX_HEIGHT = 600;

        public DrawMode mode;

        public Bitmap mBitmap, mDraftBitmap;

        public Boolean isDrawing;

        public Color mColor;

        public Algorithm mAlgorithm;

        public Shape mShape;

        public void InitController()
        {
            mode = DrawMode.MODE_DRAW_BY_MOUSE;
            if (mBitmap == null)
                mBitmap = getNewBitmap();
            if (mDraftBitmap == null)
                mDraftBitmap = getNewBitmap();

            mColor = getRandomizeColor();
            mAlgorithm = Algorithm.DDA_Line;
            mShape = new Line();
            isDrawing = false;
        }

       

        public Color getRandomizeColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }


      
        /* Init New bitmap with size of current window
         * params: null
         * return: mBitmap
         */

        public Bitmap getNewBitmap()
        {
            return new Bitmap(PICTURE_BOX_WIDTH, PICTURE_BOX_WIDTH);
        }


        public void resetBitmap()
        {
            if (mBitmap != null)
            {
                mBitmap.Dispose();
            }
            mBitmap = getNewBitmap();
        }

        public void drawShape(ref System.Windows.Forms.PictureBox pictureBox)
        {
            if (mBitmap == null)
                mBitmap = getNewBitmap();

            mShape.drawShape(ref mBitmap, mColor, mAlgorithm);

            pictureBox.Image = this.mBitmap;
            pictureBox.Update();
        }

        public void drawTemporary(ref System.Windows.Forms.PictureBox pictureBox)
        {
            if (mDraftBitmap == null)
                mDraftBitmap = getNewBitmap();
            mDraftBitmap = (Bitmap)mBitmap.Clone();

            mShape.drawShape(ref mDraftBitmap, mColor, mAlgorithm);

            pictureBox.Image = mDraftBitmap;
            pictureBox.Update();
        }
        
    }
}
