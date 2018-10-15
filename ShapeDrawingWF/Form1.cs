using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CsvHelper;
using ControllerLibrary;
using ShapeLibrary;
using Point = ShapeLibrary.Point;
using DrawMode = ControllerLibrary.DrawMode;

namespace ShapeDrawingWF
{
    public partial class Form1 : Form
    {
        Controller controller;

        public Form1()
        {
            controller = new Controller();
            controller.InitController();

            InitializeComponent();
            ModifyLayout();
            
        }

        private void ModifyLayout()
        {
            //cursor
            this.Cursor = Cursors.Cross;

            //pixbox
            this.pictureBox.Location = new System.Drawing.Point(Controller.TOOLBOX_WIDTH, 0);
            this.pictureBox.Size = new System.Drawing.Size(Controller.PICTURE_BOX_WIDTH, Controller.PICTURE_BOX_HEIGHT);

            //group shape
            this.groupShape.Location = new System.Drawing.Point(2, 12);
            this.groupShape.Size = new System.Drawing.Size(Controller.TOOLBOX_WIDTH, 248);

            //group algo
            this.groupAlgorithm.Location = new System.Drawing.Point(2, 266);
            this.groupAlgorithm.Size = new System.Drawing.Size(Controller.TOOLBOX_WIDTH, 194);

            //btn reset
            this.btnReset.Location = new System.Drawing.Point(0, 483);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(Controller.TOOLBOX_WIDTH, 30);
            //form
            this.ClientSize = new System.Drawing.Size(Controller.WINDOW_WIDTH, Controller.WINDOW_HEIGHT);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setAllAlgorithmDisable();

            this.rbtMidpoint.Enabled = true;
            this.rbtDDA.Enabled = true;
            this.rbtBresenham.Enabled = true;

            this.rbtLine.Checked = true;
            this.rbtDDA.Checked = true;

           // runAlgorithms();

        }

        private Int64 DrawShape()
        {
            var watch = Stopwatch.StartNew();

            controller.drawShape(ref this.pictureBox);
            
            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }

        private void resetPicture()
        {
            controller.resetBitmap();
            this.pictureBox.Image = controller.mBitmap;
            this.pictureBox.Update();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            this.resetPicture();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (controller.mode == DrawMode.MODE_DRAW_BY_MOUSE)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                lbMousePos.Text = x.ToString() + ", " + y.ToString();
                controller.mColor = getRandomizeColor();
                if (controller.mShape is Line)
                {
                    Line l = (Line)controller.mShape;
                    l.p1.x = x;
                    l.p1.y = y;
                    controller.isDrawing = true;
                }
                else if (controller.mShape is Circle)
                {
                    Circle c = (Circle)controller.mShape;
                    c.I.x = x;
                    c.I.y = y;
                    controller.isDrawing = true;
                }
                else if (controller.mShape is Ellipse)
                {
                    Ellipse el = (Ellipse)controller.mShape;
                    el.I.x = x;
                    el.I.y = y;
                    controller.isDrawing = true;
                }
                else if (controller.mShape is Parabola)
                {
                    Parabola el = (Parabola)controller.mShape;
                    el.I.x = x;
                    el.I.y = y;
                    controller.isDrawing = true;
                }
                else if (controller.mShape is Hyperbole)
                {
                    Hyperbole hy = (Hyperbole)controller.mShape;
                    hy.I.x = x;
                    hy.I.y = y;
                    
                    try
                    {
                        int a = Int32.Parse(this.tbHyperA.Text);
                        hy.a = a;
                        controller.isDrawing = true;
                    }
                    catch
                    {
                        MessageBox.Show("Insert a number please.");
                        controller.isDrawing = false;
                    }
                }
            }

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (controller.mode == DrawMode.MODE_DRAW_BY_MOUSE && controller.isDrawing ==true)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                lbMousePos.Text = x.ToString() + ", " + y.ToString();

                if (controller.mShape is Line)
                {
                    Line l = (Line)controller.mShape;
                    l.p2.x = x;
                    l.p2.y = y;
                    if (l.p1 != l.p2)
                        this.DrawShape();
                    controller.isDrawing = false;
                }
                else if (controller.mShape is Circle)
                {
                    Circle c = (Circle)controller.mShape;
                    Point p = new Point(x, y);
                    int r = (int)p.getDistance(c.I);
                    if (r > 0)
                    {
                        c.R = r;
                        this.DrawShape();
                        controller.isDrawing = false;
                    }

                    
                }
                else if (controller.mShape is Ellipse)
                {
                    Ellipse el = (Ellipse)controller.mShape;

                    int ra = Math.Abs(el.I.x - x);
                    int rb = Math.Abs(el.I.y - y);
                    if (ra > 0 && rb > 0)
                    {
                        el.a = ra;
                        el.b = rb;
                        this.DrawShape();
                        controller.isDrawing = false;
                    }

                   
                }
                else if (controller.mShape is Ellipse)
                {
                    Ellipse el = (Ellipse)controller.mShape;

                    int ra = Math.Abs(el.I.x - x);
                    int rb = Math.Abs(el.I.y - y);
                    if (ra > 0 && rb > 0)
                    {
                        el.a = ra;
                        el.b = rb;
                        this.DrawShape();
                        controller.isDrawing = false;
                    }

                    
                }
                else if (controller.mShape is Parabola)
                {
                    Parabola pa = (Parabola)controller.mShape;
                    pa.Bound = new Point(x, y);
                    this.DrawShape();
                    controller.isDrawing = false;
                }
                else if (controller.mShape is Hyperbole)
                {
                    Hyperbole hy = (Hyperbole)controller.mShape;
                    hy.Bound = new Point(x, y);
                    this.DrawShape();
                    controller.isDrawing = false;
                }
            }
        }

        private Color getRandomizeColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }

        private void drawingTemporary()
        {
            controller.drawTemporary(ref this.pictureBox);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (controller.mode == DrawMode.MODE_DRAW_BY_MOUSE && controller.isDrawing==true)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                lbMousePos.Text = x.ToString() + ", " + y.ToString();
                if (controller.mShape is Line)
                {
                    Line l = (Line)controller.mShape;
                    Point p = new Point(x, y);
                    if (x != l.p1.x && y != l.p1.y)
                    {
                        l.p2 = p;
                        drawingTemporary();
                    }
                }

                else if (controller.mShape is Circle)
                {
                    Circle c = (Circle)controller.mShape;
                    Point p = new Point(x, y);
                    int r = (int)p.getDistance(c.I);
                    if (r > 0)
                    {
                        c.R = r;
                        drawingTemporary();

                    }
                }

                else if (controller.mShape is Ellipse)
                {
                    Ellipse el = (Ellipse)controller.mShape;
                    int ra = Math.Abs(el.I.x - x);
                    int rb = Math.Abs(el.I.y - y);
                    if (ra > 0 && rb > 0)
                    {
                        el.a = ra;
                        el.b = rb;

                        drawingTemporary();
                    }
                }
                else if (controller.mShape is Parabola)
                {
                    Parabola pa = (Parabola)controller.mShape;
                    pa.Bound = new Point(x, y);
                    drawingTemporary();
                }
                else if (controller.mShape is Hyperbole)
                {
                    Hyperbole hy = (Hyperbole)controller.mShape;
                    hy.Bound = new Point(x, y);

                    drawingTemporary();
                }
            }
        }

        private void setAllAlgorithmDisable()
        {
            this.rbtDDA.Enabled = false;
            this.rbtBresenham.Enabled = false;
            this.rbtMidpoint.Enabled = false;
            this.rbtXiaolin.Enabled = false;
            this.tbHyperA.Enabled = false;
            controller.isDrawing = false;
        }

        private void rbtHypebole_CheckedChanged(object sender, EventArgs e)
        {
            setAllAlgorithmDisable();
            this.rbtMidpoint.Enabled = true;
            this.rbtMidpoint.Checked = true;
            controller.mAlgorithm = Algorithm.MidPoint_Hyperbole;
            if (rbtHypebole.Checked == true)
            {
                tbHyperA.Enabled = true;
            }
            else
                tbHyperA.Enabled = false;
            if (!(controller.mShape is Hyperbole))
                controller.mShape = new Hyperbole();
        }

        private void rbtParabola_CheckedChanged(object sender, EventArgs e)
        {
            setAllAlgorithmDisable();
            this.rbtMidpoint.Enabled = true;
            this.rbtMidpoint.Checked = true;
            controller.mAlgorithm = Algorithm.MidPoint_Parabola;
            if (!(controller.mShape is Parabola))
                controller.mShape = new Parabola();
        }

        private void rbtEllipse_CheckedChanged(object sender, EventArgs e)
        {
            controller.mAlgorithm = Algorithm.MidPoint_Ellipse;
            setAllAlgorithmDisable();
            this.rbtMidpoint.Enabled = true;
            this.rbtMidpoint.Checked = true;

            if(!(controller.mShape is Ellipse))
                controller.mShape = new Ellipse();
        }

        private void rbtCircle_CheckedChanged(object sender, EventArgs e)
        {

            setAllAlgorithmDisable();
            this.rbtDDA.Enabled = true;
            this.rbtMidpoint.Enabled = true;
            this.rbtMidpoint.Checked = true;
            controller.mAlgorithm = Algorithm.MidPoint_Circle;
            if (!(controller.mShape is Circle))
                controller.mShape = new Circle();
        }

        private void rbtLine_CheckedChanged(object sender, EventArgs e)
        {
            setAllAlgorithmDisable();

            this.rbtMidpoint.Enabled = true;
            this.rbtDDA.Enabled = true;
            this.rbtBresenham.Enabled = true;
            //this.rbtXiaolin.Enabled = true;

            this.rbtDDA.Checked = true;
            controller.mAlgorithm = Algorithm.DDA_Line;
            if(!(controller.mShape is Line))
                controller.mShape = new Line();
        }

        private void rbtDDA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDDA.Checked == true)
            {
                if (rbtLine.Checked == true)
                    controller.mAlgorithm = Algorithm.DDA_Line;
                else if (rbtCircle.Checked == true)
                    controller.mAlgorithm = Algorithm.DDA_Circle;
                else
                    MessageBox.Show("Oops! DDA algorithm is not available for this Shape");
            }
        }

        private void rbtBresenham_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBresenham.Checked == true)
            {
                if (rbtLine.Checked == true)
                    controller.mAlgorithm = Algorithm.Bresenham_Line;
                else
                    MessageBox.Show("Oops! Bresenham algorithm is not available for this Shape");
            }
        }

        private void rbtXiaolin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtXiaolin.Checked == true)
            {
                if (rbtLine.Checked == true)
                    controller.mAlgorithm = Algorithm.Xiaolin_Line;
                else
                    MessageBox.Show("Oops! Xiaolin Wu algorithm is not available for this Shape");
            }
        }
        private void rbtMidpoint_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMidpoint.Checked == true)
            {
                if (rbtLine.Checked == true)
                    controller.mAlgorithm = Algorithm.MidPoint_Line;
                else if (rbtCircle.Checked == true)
                    controller.mAlgorithm = Algorithm.MidPoint_Circle;
                else if (rbtEllipse.Checked == true)
                    controller.mAlgorithm = Algorithm.MidPoint_Ellipse;
                else if (rbtHypebole.Checked == true)
                    controller.mAlgorithm = Algorithm.MidPoint_Hyperbole;
                else if (rbtParabola.Checked == true)
                    controller.mAlgorithm = Algorithm.MidPoint_Parabola;
                else
                    MessageBox.Show("Oops! Midpoint algorithm is not available for this Shape");
            }

        }


        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }


        //For test speed
        private int runAlgorithms()
        {
            controller.mAlgorithm = Algorithm.MidPoint_Line;
            CsvFileReader reader = new CsvFileReader("Testcase_Line.csv");
            CsvFileWriter writer = new CsvFileWriter("Midpoint_Line_Runtime.csv");
            CsvRow row = new CsvRow();
            Random rnd = new Random();
            int count = 0;

            while (reader.ReadRow(row))
            {
                if (row.Count == 4)
                {
                    int x1 = Int32.Parse(row[0]);
                    int y1 = Int32.Parse(row[1]);
                    int x2 = Int32.Parse(row[2]);
                    int y2 = Int32.Parse(row[3]);
                    controller.mShape = new Line(new Point(x1, y1), new Point(x2, y2));
                    Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    try
                    {
                        Int64 runtime = this.DrawShape();
                        row.Add(String.Format(runtime.ToString()));
                        writer.WriteRow(row);
                        count++;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("failed at " + count.ToString());
                    }


                }
                else
                    break;
            }
            reader.Close();
            writer.Close();
            return count;
        }


    }
}
