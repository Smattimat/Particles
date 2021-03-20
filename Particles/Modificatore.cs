using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;

namespace Particles
{
    abstract public class Modificatore : IDisposable
    {
        //Attributi
        private static List<int> IDs = new List<int>() { 0, 1000000000 };

        private int id;
        private Vector2 pos;
        private TimeSpan t;
        private bool global;
        private Image img;

        //Properties
        public int Id { get => id; }
        public Vector2 Pos { get => pos; set => pos = value; }
        public TimeSpan T { get => t; set => t = value; }
        public bool Global { get => global; set => global = value; }
        public Image Img { get => img; set => img = value; }

        //Costruttore
        public Modificatore(Vector2 pos, TimeSpan t, bool G)
        {
            Pos = pos;
            T = t;
            Global = G;
            int i = 0;
            do
            {
                i++;
            }
            while (IDs.Contains(i));
            IDs.Insert(i, i);
            id = i;
        }


        //Metodi
        public void Dispose()
        {
            IDs.Remove(id);
        }

        public void ReassignID()
        {
            IDs.Remove(id);
            int i = 0;
            do
            {
                i++;
            }
            while (IDs.Contains(i));
            IDs.Insert(i, i);
            id = i;
        }

  
        

        abstract public void Operazione(List<Elemento> elementi);

    }
}
