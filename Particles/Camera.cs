using System;
using System.Numerics;
using System.Drawing;

namespace Particles
{
    public class Camera
    {
        //Attributi
        private int[] zoomlevels = new int[5] { 1, 2, 4, 8, 16 };
        private Vector2 dims = new Vector2(1536, 864);
        private Vector2 center = new Vector2(1536, 864);
        private Vector2 origin = new Vector2(1536, 864);
        private Vector2 dim = new Vector2(1536, 864);
        private Vector2 screen;
        private int zoom = 1;

        //Properties
        public Vector2 Origin
        {
            get => origin;
            set
            {
                if (value.X < 0 || value.Y < 0)
                {
                    throw new Exception("Valore negativo per la camera non valido");
                }
                origin = value;
            }
        }

        public int Zoom { get => zoom; set => zoom = value; }
        public Vector2 Dim { get => dim; }
        public Vector2 Screen { get => screen; set => screen = value; }

        //Costruttore
        public Camera()
        {
            Origin = new Vector2(1536, 864);
            dim = new Vector2(1536, 864);
            Screen = origin;
            zoom = 1;
        }
        public Camera(Vector2 scre)
        {
            Origin = new Vector2(1536, 864);
            dim = new Vector2(1536, 864);
            Screen = scre;
            zoom = 1;
        }


        //Metodi
        public void UpdateOrigin(Vector2 v)
        {
            Vector2 spos = new Vector2(0, 0);
            spos.X = (dim.X * 2 * v.X / screen.X);
            spos.Y = (dim.Y * 2) * v.Y / screen.Y;
            origin = Vector2.Add(origin, spos);

        }

        public void Updatezoom(bool more)
        {
            int i = 0;
            if (more == true)
            {
                foreach (int a in zoomlevels)
                {
                    if (a == Zoom)
                    {
                        if (a == 16) Zoom = 16;
                        else
                        {
                            Zoom = zoomlevels[i + 1];
                            dim = dims / zoom;
                        }
                        break;
                    }
                    i++;
                }
            }
            else
            {
                foreach (int a in zoomlevels)
                {
                    if (a == Zoom)
                    {
                        if (a == 1) Zoom = 1;
                        else
                        {
                            Zoom = zoomlevels[i - 1];
                            dim = dims / zoom;
                        }
                        break;
                    }
                    i++;
                }
            }
        }

        public Rectangle GiveRect(Elemento el)
        {
                Rectangle re = new Rectangle();
                re.Width = (int)(screen.X * (el.R * 2) / (dim.X * 2));
                re.Height = re.Width;
                re.X = (int)(screen.X * (el.Pos.X + (center.X - origin.X)) / (dim.X * 2) - (re.Width / 2));
                re.Y = (int)(screen.Y * (el.Pos.Y + (center.Y - origin.Y)) / (dim.Y * 2) - (re.Width / 2));
                //mettere funzione o qualcosa di +intelligente
                if (zoom == 1)
                {
                    re.X = (int)(re.X - screen.X * 0);
                    re.Y = (int)(re.Y - screen.Y * 0);
                }
                if (zoom == 2)
                {
                    re.X = (int)(re.X - screen.X * 0.5);
                    re.Y = (int)(re.Y - screen.Y * 0.5);
                }
                if (zoom == 4)
                {
                    re.X = (int)(re.X - screen.X * 1.5);
                    re.Y = (int)(re.Y - screen.Y * 1.5);
                }
                if (zoom == 8)
                {
                    re.X = (int)(re.X - screen.X * 3.5);
                    re.Y = (int)(re.Y - screen.Y * 3.5);
                }
                if (zoom == 16)
                {
                    re.X = (int)(re.X - screen.X * 7.5);
                    re.Y = (int)(re.Y - screen.Y * 7.5);
                }
                return re;
        }
        public  Rectangle GiveRect(Modificatore m)
        {
            Rectangle re = new Rectangle();
            switch (m.GetType().Name.ToString())
            {
                case "Attrito":
                    Attrito mAt = (Attrito)m;
                    re.Width = (int)(screen.X * (mAt.AreaInfluenza.X * 2) / (dim.X * 2));
                    re.Height = (int)(screen.Y * (mAt.AreaInfluenza.Y * 2) / (dim.Y * 2));
                    break;
                case "CampoMinato":
                    CampoMinato mCM = (CampoMinato)m;
                    re.Width = (int)(screen.X * (mCM.AreaInfluenza.X * 2) / (dim.X * 2));
                    re.Height = (int)(screen.Y * (mCM.AreaInfluenza.Y * 2) / (dim.Y * 2));
                    break;
                case "Gravita":
                    Gravita mG = (Gravita)m;
                    re.Width = (int)(screen.X * (mG.AreaInfluenza.X * 2) / (dim.X * 2));
                    re.Height = (int)(screen.Y * (mG.AreaInfluenza.Y * 2) / (dim.Y * 2));
                    break;
                case "Vento":
                    break;
                case "BucoNero":
                    BucoNero mBN = (BucoNero)m;
                    re.Width = (int)(screen.X * (mBN.R * 2) / (dim.X * 2));
                    re.Height = re.Width;
                    break;
            }
            re.X = (int)(screen.X * (m.Pos.X + (center.X - origin.X)) / (dim.X * 2) - (re.Width / 2));
            re.Y = (int)(screen.Y * (m.Pos.Y + (center.Y - origin.Y)) / (dim.Y * 2) - (re.Height / 2));
            //mettere funzione o qualcosa di +intelligente
            if (zoom == 1)
            {
                re.X = (int)(re.X - screen.X * 0);
                re.Y = (int)(re.Y - screen.Y * 0);
            }
            if (zoom == 2)
            {
                re.X = (int)(re.X - screen.X * 0.5);
                re.Y = (int)(re.Y - screen.Y * 0.5);
            }
            if (zoom == 4)
            {
                re.X = (int)(re.X - screen.X * 1.5);
                re.Y = (int)(re.Y - screen.Y * 1.5);
            }
            if (zoom == 8)
            {
                re.X = (int)(re.X - screen.X * 3.5);
                re.Y = (int)(re.Y - screen.Y * 3.5);
            }
            if (zoom == 16)
            {
                re.X = (int)(re.X - screen.X * 7.5);
                re.Y = (int)(re.Y - screen.Y * 7.5);
            }
            return re;
        }
        public Rectangle GiveIconDim(Modificatore m)
        {
            Rectangle re = new Rectangle();
            re.Width = (int)(screen.X * 50 / (dim.X * 2));
            re.Height = re.Width;
            re.X = (int)(screen.X * (m.Pos.X + (center.X - origin.X)) / (dim.X * 2) - (re.Width / 2));
            re.Y = (int)(screen.Y * (m.Pos.Y + (center.Y - origin.Y)) / (dim.Y * 2) - (re.Width / 2));
            if (zoom == 1)
            {
                re.X = (int)(re.X - screen.X * 0);
                re.Y = (int)(re.Y - screen.Y * 0);
            }
            if (zoom == 2)
            {
                re.X = (int)(re.X - screen.X * 0.5);
                re.Y = (int)(re.Y - screen.Y * 0.5);
            }
            if (zoom == 4)
            {
                re.X = (int)(re.X - screen.X * 1.5);
                re.Y = (int)(re.Y - screen.Y * 1.5);
            }
            if (zoom == 8)
            {
                re.X = (int)(re.X - screen.X * 3.5);
                re.Y = (int)(re.Y - screen.Y * 3.5);
            }
            if (zoom == 16)
            {
                re.X = (int)(re.X - screen.X * 7.5);
                re.Y = (int)(re.Y - screen.Y * 7.5);
            }
            return re;

        }
    }
}
