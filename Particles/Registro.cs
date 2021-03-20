using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Drawing;

namespace Particles
{
    public class Registro
    {
        //Attributi
        Dictionary<int, Elemento> elementi = new Dictionary<int, Elemento>();
        Dictionary<int, Modificatore> modificarori = new Dictionary<int, Modificatore>();

        //Properties
        public Dictionary<int, Elemento> Elementi { get => elementi; }
        public Dictionary<int, Modificatore> Modificarori { get => modificarori; }
                                                                                                           
        //Costruttore
        public Registro() { }

        //Metodi
        public void Add(Elemento el)
        {
            elementi.Add(el.Id, el);
        }

        public void Add(Modificatore m)
        {
            modificarori.Add(m.Id, m);
        }

        public void Modify(Elemento el,Elemento newel)
        {
            el.Dispose();
            elementi.Remove(el.Id);
            newel.ReassignID();
            elementi.Add(newel.Id, newel);
        }

        public void Modify(Modificatore m,Modificatore newm)
        {
            m.Dispose();
            modificarori.Remove(m.Id);
            newm.ReassignID();
            modificarori.Add(newm.Id, newm);
            
        }

        public void Delete(Elemento el)
        {
            el.Dispose();
            elementi.Remove(el.Id);
        }

        public void Delete(Modificatore m)
        {
            m.Dispose();
            modificarori.Remove(m.Id);

        }

        public void Save()
        {
            JsonSerializer serializzatore = new JsonSerializer();
            serializzatore.Formatting = Formatting.Indented;

            //elementi
            StreamWriter sw = new StreamWriter("elementi.123");
            using (JsonWriter scriba = new JsonTextWriter(sw))
            {
                serializzatore.Serialize(scriba, elementi);
            }
            //modificatori
            StreamWriter sw2 = new StreamWriter("modificatori.123");
            using (JsonWriter scriba = new JsonTextWriter(sw2))
            {
                serializzatore.Serialize(scriba, modificarori);
            }
        }

        public void Load()
        {
            if (File.Exists("elementi.123"))
            {
                elementi = JsonConvert.DeserializeObject<Dictionary<int, Elemento>>(File.ReadAllText("elementi.123"));
            }
            else
            {
                throw new FileNotFoundException("File di salvataggio non trovato.");
            }
            if (File.Exists("modificatori.123"))
            {
                modificarori = JsonConvert.DeserializeObject<Dictionary<int, Modificatore>>(File.ReadAllText("modificatori.123"));
            }
            else
            {
                throw new FileNotFoundException("File di salvataggio non trovato.");
            }
        }
    }
}
