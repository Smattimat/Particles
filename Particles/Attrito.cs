using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Particles
{
    public class Attrito : Modificatore,IGiveDim
    {
        //Attributi
        private Vector2 areaInfluenza;
        private double coefficienteAttr;

        //Properties
        public Vector2 AreaInfluenza
        {
            get => areaInfluenza;
            set => areaInfluenza = value;
        }
        public double CoefficienteAttr
        {
            get => coefficienteAttr;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Valore negativo attrito non valido");
                }
                coefficienteAttr = value;
            }

        }

        //Costruttore
        public Attrito(Vector2 pos, TimeSpan t, bool g, Vector2 areaInfluenza, double Coeffatr) : base(pos, t, g)
        {
            AreaInfluenza = areaInfluenza;
            CoefficienteAttr = Coeffatr;
            base.Img = Image.FromFile(@"Res/Colla.png");
        }



        //Metodi
        public override void Operazione(List<Elemento> l)
        {

        }

        public Vector2 GiveDistanceFromCenter()
        {
            return areaInfluenza;
        }
    }
}
