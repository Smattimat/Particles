using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;

namespace Particles
{
    public class BucoNero : Modificatore,IGiveDim
    {
        //Attributi
        private double massa;
        private double r;

        //Properties
        public double Massa { get => massa; set => massa = value; }
        public double R
        {
            get => r;
            set
            {
                if (value < 25)
                {
                    throw new Exception("raggio inserito troppo piccolo");
                }
                r = value;
            }
        }

        //Costruttore
        public BucoNero(Vector2 pos, TimeSpan t, bool g, double mass, double ra) : base(pos, t, g)
        {
            Massa = mass;
            R = ra;           
            base.Img = Image.FromFile(@"Res/buconero.jpg");
        }

        //Metodi
        public override void Operazione(List<Elemento> l)
        {

        }

        public Vector2 GiveDistanceFromCenter()
        {
            return new Vector2((float)r,(float)r);
        }
    }
}
