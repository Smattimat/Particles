using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Mondo {
    public class Elemento {
        public Vector2 posizione; // metro
        public Vector2 velocita; // metro/sec
        public float massa; // kilogrammo
        public float raggio; // metro
        public Color colore;

        public Elemento() {
            posizione = new Vector2(0, 0);
            velocita = new Vector2(0, 0);
            massa = 1;
            raggio = 1;
            colore = Color.Red;
        }

        public Elemento(Vector2 posIniziale) : this() {
            posizione = posIniziale;
        }
        public Elemento(Vector2 posIniziale, Vector2 dirVelocita) : this() {
            posizione = posIniziale;
            velocita = dirVelocita;
        }
        public Elemento(Vector2 posIniziale, Vector2 dirVelocita, float rIniziale) : this() {
            posizione = posIniziale;
            velocita = dirVelocita;
            raggio = rIniziale;
        }
        public Elemento(Vector2 posIniziale, Vector2 dirVelocita, 
            float rIniziale, float mIniziale) : this() {
            posizione = posIniziale;
            velocita = dirVelocita;
            raggio = rIniziale;
            massa = mIniziale;
        }
        public Elemento(Vector2 posIniziale, Vector2 dirVelocita,
            float rIniziale, float mIniziale, Color cIniziale) {
            posizione = posIniziale;
            velocita = dirVelocita;
            raggio = rIniziale;
            massa = mIniziale;
            colore = cIniziale;
        }

        public float distanza(Elemento altra) {
            return MathF.Sqrt(
            (altra.posizione.X - posizione.X) * (altra.posizione.X - posizione.X) +
            (altra.posizione.Y - posizione.Y) * (altra.posizione.Y - posizione.Y)
            );
        }

        public bool collide(Elemento altra) {
            if (distanza(altra) <= (raggio + altra.raggio)) return true;
            return false;
        }

        public float modVelocita() {
            return velocita.Length();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
