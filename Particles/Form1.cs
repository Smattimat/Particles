using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Particles
{
    public partial class Form1 : Form
    {
        Point p = new Point();
        Vector2 app;
        Elemento ell;
        BucoNero b;

        private Bitmap img;
        private Graphics G;
        private Timer t = new Timer();
        private int selected = 0;
        private Camera c;
        private Registro r = new Registro();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //r.Load();
            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(img);
            pictureBox1.Image = img;

            app = new Vector2(1536, 864);
            ell = new Elemento(app, app, 10, 100, Color.Red);
            r.Add(ell);
            app = new Vector2(1336, 864);
            ell = new Elemento(app, app, 10, 100, Color.Blue);
            r.Add(ell);
            app = new Vector2(1136, 864);
            ell = new Elemento(app, app, 10, 30, Color.Yellow);
            r.Add(ell);
            app = new Vector2(1336, 564);
            ell = new Elemento(app, app, 10, 50, Color.Green);
            r.Add(ell);
            app = new Vector2(936, 864);
            ell = new Elemento(app, app, 10, 100, Color.Magenta);
            r.Add(ell);

            app = new Vector2(300, 864);
            TimeSpan time = new TimeSpan(0, 10, 20);
            b = new BucoNero(app, time, false, 10, 900);
            r.Add(b);

            app = new Vector2(300, 364);
            Gravita g = new Gravita(app, new TimeSpan(10, 10, 10),false, new Vector2(100, 50));
            r.Add(g);

            app = new Vector2(100, 164);
            Attrito at = new Attrito(app, new TimeSpan(10, 10, 10), false, new Vector2(100, 50),5);
            r.Add(at);

            app = new Vector2(1000, 164);
            CampoMinato min = new CampoMinato(app,new TimeSpan(20,2,2),false, new Vector2(400, 50));
            r.Add(min);
            //r.Save();

            app.X = pictureBox1.Width;
            app.Y = pictureBox1.Height;
            c = new Camera(app);

            //clock
            t.Interval = 5;
            t.Tick += T_Tick;
            t.Start();
        }


        private void Form1_Resize_1(object sender, EventArgs e)
        {
            if (pictureBox1.Width > 10)
            {
                img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                G = Graphics.FromImage(img);
                pictureBox1.Image = img;


                app.X = pictureBox1.Width;
                app.Y = pictureBox1.Height;
                if (c == null)
                {
                    c = new Camera(app);
                }
                c.Screen = app;
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Aggfis();
            Draw();
        }

        public void Aggfis() 
        {
            /*non mio*/
        }
        public void Draw()
        {
            G.Clear(Color.Black);
           /* Elemento ee = new Elemento(app, app, 10, 30, Color.AliceBlue);
            r.Modify(ell, ee);*/
            float dpiX = G.DpiX;
            double multiplier = 1 - ((((dpiX/96)-1)*4) * 0.4);
            foreach (KeyValuePair<int, Modificatore> kv in r.Modificarori)
            {
                bool Todraw = true;
                switch (kv.Value.GetType().Name.ToString())
                {
                    case "Attrito":
                        Attrito m = (Attrito)kv.Value;
                        if (m.Pos.X + m.GiveDistanceFromCenter().X < c.Origin.X - c.Dim.X || m.Pos.X - m.GiveDistanceFromCenter().X > c.Origin.X + c.Dim.X || m.Pos.Y - m.GiveDistanceFromCenter().Y > c.Origin.Y + c.Dim.Y || m.Pos.Y + m.GiveDistanceFromCenter().Y < c.Origin.Y - c.Dim.Y)
                        {
                            Todraw = false;
                        }
                        break;
                    case "CampoMinato":
                        CampoMinato mc = (CampoMinato)kv.Value;
                        if (mc.Pos.X + mc.GiveDistanceFromCenter().X < c.Origin.X - c.Dim.X || mc.Pos.X - mc.GiveDistanceFromCenter().X > c.Origin.X + c.Dim.X || mc.Pos.Y - mc.GiveDistanceFromCenter().Y > c.Origin.Y + c.Dim.Y || mc.Pos.Y + mc.GiveDistanceFromCenter().Y < c.Origin.Y - c.Dim.Y)
                        {
                            Todraw = false;
                        }
                        break;
                    case "Gravita":
                        Gravita mg = (Gravita)kv.Value;
                        if (mg.Pos.X + mg.GiveDistanceFromCenter().X < c.Origin.X - c.Dim.X || mg.Pos.X - mg.GiveDistanceFromCenter().X > c.Origin.X + c.Dim.X || mg.Pos.Y - mg.GiveDistanceFromCenter().Y > c.Origin.Y + c.Dim.Y || mg.Pos.Y + mg.GiveDistanceFromCenter().Y < c.Origin.Y - c.Dim.Y)
                        {
                            Todraw = false;
                        }
                        break;
                    case "Vento":
                        break;
                    case "BucoNero":
                        BucoNero mb = (BucoNero)kv.Value;
                        if (mb.Pos.X + mb.GiveDistanceFromCenter().X < c.Origin.X - c.Dim.X || mb.Pos.X - mb.GiveDistanceFromCenter().X > c.Origin.X + c.Dim.X || mb.Pos.Y - mb.GiveDistanceFromCenter().Y > c.Origin.Y + c.Dim.Y || mb.Pos.Y + mb.GiveDistanceFromCenter().Y < c.Origin.Y - c.Dim.Y)
                        {
                            Todraw = false;
                        }
                        break;
                }
                
                if (Todraw==true)
                {
                    Rectangle rApp = c.GiveIconDim(kv.Value);
                    G.DrawImage(ResizeImage(kv.Value.Img, (int)(rApp.Width * multiplier), (int)(rApp.Height * multiplier)), rApp.Location);
                    if (kv.Value.GetType().Name.ToString() == "BucoNero")
                    {
                        G.DrawEllipse(Pens.White, c.GiveRect(kv.Value));
                    }
                    else
                    {
                        G.DrawRectangle(Pens.White, c.GiveRect(kv.Value));
                    }
                    
                }
            }
            foreach (KeyValuePair<int, Elemento> kv in r.Elementi)
            {

                if (kv.Value.Pos.X + kv.Value.R < c.Origin.X - c.Dim.X || kv.Value.Pos.X - kv.Value.R > c.Origin.X + c.Dim.X || kv.Value.Pos.Y - kv.Value.R > c.Origin.Y + c.Dim.Y || kv.Value.Pos.Y + kv.Value.R < c.Origin.Y - c.Dim.Y)
                {

                }
                else
                {
                    SolidBrush b = new SolidBrush(kv.Value.Col);
                    G.FillEllipse(b, c.GiveRect(kv.Value));
                    label3.Text = c.GiveRect(kv.Value).Location.ToString();
                    label4.Text = c.GiveRect(kv.Value).Width.ToString();
                }
            }

            G.DrawLine(Pens.White, c.Screen.X / 2 - 10, c.Screen.Y / 2, c.Screen.X / 2 + 10, c.Screen.Y / 2);
            G.DrawLine(Pens.White, c.Screen.X / 2, c.Screen.Y / 2 - 10, c.Screen.X / 2, c.Screen.Y / 2 + 10);
            pictureBox1.Refresh();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /*private void btnElemCol_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btnElemCol.BackColor = c.Color;
            }
            if (c.Color.GetBrightness() < 0.5)
            {
                btnElemCol.ForeColor = Color.White;
            }
            else
            {
                btnElemCol.ForeColor = Color.Black;
            }

        }*/


        //Mouse Controls     click,drag,zoom
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {

                if (c.Zoom != 16)
                {
                    DeltaMove.X = (pictureBox1.Width / 2) - e.X;
                    DeltaMove.Y = (pictureBox1.Height / 2) - e.Y;
                    c.UpdateOrigin(-DeltaMove);
                    p.Y = (int)c.Screen.Y / 2 + pictureBox1.Location.Y + this.Location.Y + 35;
                    p.X = (int)c.Screen.X / 2 + pictureBox1.Location.X + this.Location.X + 10;
                    Cursor.Position = p;
                }
                c.Updatezoom(true);


            }
            else
            {
                c.Updatezoom(false);

            }
            label1.Text = c.Origin.ToString();
            label2.Text = c.Dim.ToString();
            base.OnMouseWheel(e);
        }

        Vector2 DeltaMove;
        bool _mousePress;
        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (_mousePress == true)
            {
                DeltaMove.X = DeltaMove.X - e.X;
                DeltaMove.Y = DeltaMove.Y - e.Y;
                c.UpdateOrigin(DeltaMove);
                DeltaMove.X = e.X;
                DeltaMove.Y = e.Y;
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            _mousePress = false;
            DeltaMove.X = DeltaMove.X - e.X;
            DeltaMove.Y = DeltaMove.Y - e.Y;
            c.UpdateOrigin(DeltaMove);
            label1.Text = c.Origin.ToString();
            label2.Text = c.Dim.ToString();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            _mousePress = true;
            DeltaMove.X = e.X;
            DeltaMove.Y = e.Y;
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            bool found = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (KeyValuePair<int, Elemento> kv in r.Elementi)
                {
                    if (kv.Value.Pos.X + kv.Value.R < c.Origin.X - c.Dim.X || kv.Value.Pos.X - kv.Value.R > c.Origin.X + c.Dim.X || kv.Value.Pos.Y - kv.Value.R > c.Origin.Y + c.Dim.Y || kv.Value.Pos.Y + kv.Value.R < c.Origin.Y - c.Dim.Y)
                    {

                    }
                    else
                    {
                        Rectangle r = c.GiveRect(kv.Value);
                        if (r.Contains(e.Location))
                        {
                            found = true;
                        }
                    }
                }
                if (found == false)
                {
                    //modificatori
                }

                if (gbxElemento.Visible == true)
                {
                    gbxElemento.Visible = false;    //predere pos in cui si clicca per posizione elemento
                }
                else
                {
                    gbxElemento.Visible = true;
                }
            }
            else if (selected != 0)
            {

            }
        }

       

        /*
        //Create Selection
        private void btnElemento_Click(object sender, EventArgs e)
        {
            selected = 1;
            foreach (Button b in pnlSelection.Controls)
            {
                b.BackColor = Color.Gray;
            }
            btnElemento.BackColor = Color.Yellow;

        }

        private void btnAttrito_Click(object sender, EventArgs e)
        {
            selected = 2;
            foreach (Button b in pnlSelection.Controls)
            {
                b.BackColor = Color.Gray;
            }
            btnAttrito.BackColor = Color.Yellow;
        }

        private void btnBucoNero_Click(object sender, EventArgs e)
        {
            selected = 3;
            foreach (Button b in pnlSelection.Controls)
            {
                b.BackColor = Color.Gray;
            }
            btnBucoNero.BackColor = Color.Yellow;
        }

        private void btnCampoMinato_Click(object sender, EventArgs e)
        {
            selected = 4;
            foreach (Button b in pnlSelection.Controls)
            {
                b.BackColor = Color.Gray;
            }
            btnCampoMinato.BackColor = Color.Yellow;
        }

        private void btnGravita_Click(object sender, EventArgs e)
        {
            selected = 5;
            foreach (Button b in pnlSelection.Controls)
            {
                b.BackColor = Color.Gray;
            }
            btnGravita.BackColor = Color.Yellow;
        }

        private void btnVento_Click(object sender, EventArgs e)
        {
            selected = 6;
            foreach (Button b in pnlSelection.Controls)
            {
                b.BackColor = Color.Gray;
            }
            btnVento.BackColor = Color.Yellow;
        }
        */

    }
}
