using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Particles
{
    public class Elemento:IDisposable,IGiveDim
    {
        //Attributi
        private static List<int> IDs = new List<int>() { 0, 1000000000 };
        private int id;
        private Vector2 pos;
        private Vector2 ivel;
        private int mass;
        private double r;
        private Color col;


        //Properties
        public Vector2 Pos
        {
            get => pos;
            set
            {
                if (value.X < 0 || value.X > 3072 || value.Y < 0 || value.Y > 1728)
                {
                    throw new Exception("Posizione esterna al mondo non valida");
                }
                else
                {
                    pos = value;
                }
            }
        }

        public int Mass { get => mass; set => mass = value; }
        public double R
        {
            get => r;
            set
            {
                if (value < 0.1)
                {
                    throw new Exception("raggio negativo non valido");
                }
                else
                {
                    r = value;
                }
            }
        }

        public Color Col { get => col; set => col = value; }
        public Vector2 Ivel { get => ivel; set => ivel = value; }
        public int Id { get => id; }



        //Costruttore
        public Elemento(Vector2 pos, Vector2 ivel, int mass, double r, Color col)
        {
            Pos = pos;
            Ivel = ivel;
            Mass = mass;
            R = r;
            Col = col;
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

        public Vector2 GiveDistanceFromCenter()
        {
            return new Vector2((float)r,(float)r);
        }

        public void Move(int interval, double acceleration = 0)
        {
            if (acceleration != 0)
            {
                //pos.X = (float)(pos.X + (forceDir.X / (forceDir.X + forceDir.Y) * force) * interval);
                //pos.X =(float)( pos.X + (forceDir.Y / (forceDir.X + forceDir.Y) * force) * interval);
            }
            else
            {
                //legge oraria
                //legge velocità
            }
        }

        public void UpdateForce()
        {

        }

        public void Explode()
        {

        }

        
    }
}
