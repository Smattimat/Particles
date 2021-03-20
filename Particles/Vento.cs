using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Particles
{
    class Vento : Modificatore
    {
        //Attributi
        private Rectangle areaInfluenza;
        private Vector2 forzaSpinta;

        //Properties
        
        public Rectangle AreaInfluenza { get => areaInfluenza; set => areaInfluenza = value; }
        public Vector2 ForzaSpinta { get => forzaSpinta; set => forzaSpinta = value; }

        //Costruttore
        public Vento(Vector2 pos, TimeSpan t, bool g, Rectangle ai, Vector2 Fsp) : base(pos, t, g)
        {
            AreaInfluenza = ai;
            ForzaSpinta = Fsp;
            base.Img = Image.FromFile(@"Res/buconero.jpg");
        }

        //Medoti
        public override void Operazione(List<Elemento> l)
        {

        }

        public Rectangle GiveRect(Vector2 dim, Vector2 orig, Vector2 screen, int zoom)
        {
            Rectangle re = new Rectangle();
            //da fare
            return re;
        }
    }
}
