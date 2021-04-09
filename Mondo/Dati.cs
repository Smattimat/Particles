using System;
using System.Collections.Generic;
using System.Numerics;

namespace Mondo {
    public class Dati {
        // Controllo applicazione
        public bool programmaAttivo = true;
        public Vector2 offset = new Vector2();
        public float zoom = 10;


        // Dati simulazione
        public List<Elemento> p = new List<Elemento>();

    }
}
