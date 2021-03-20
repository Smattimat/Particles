using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Particles
{
    public class CampoMinato : Modificatore,IGiveDim
    {
        //Attributi
        private Vector2 areaInfluenza;

        //Properties
        public Vector2 AreaInfluenza { get => areaInfluenza; set => areaInfluenza = value; }

        //Costruttore
        public CampoMinato(Vector2 pos, TimeSpan t, bool g, Vector2 a) : base(pos, t, g)
        {
            AreaInfluenza = a;
            base.Img = Image.FromFile(@"Res/Mina.png");
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
