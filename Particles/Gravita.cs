using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Particles
{
    public class Gravita:Modificatore,IGiveDim
    {
        private Vector2 areaInfluenza;

        public Gravita(Vector2 pos, TimeSpan t, bool g, Vector2 ai) : base(pos, t, g)
        {
            AreaInfluenza = ai;
            base.Img = Image.FromFile(@"Res/Gravity.png");
        }

        public Vector2 AreaInfluenza { get => areaInfluenza; set => areaInfluenza = value; }

        public Vector2 GiveDistanceFromCenter()
        {
            return areaInfluenza;
        }

        public override void Operazione(List<Elemento> l)
        {

        }

        
    }
}
