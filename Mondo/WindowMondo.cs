using System;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Raylib_cs;

namespace Mondo {
    public class WindowMondo {
        public Dati datiMondo { get; init; }
        private int width, height;
        private Random r = new Random();
        private Vector2 pm1, pm2, pmDiff; // mouse delta

        private float metriPerPixel;
        private Vector2 posCentro;

        private Stopwatch time = new Stopwatch();
        private ulong nframe = 1;

        public WindowMondo(int offT, int offR, int offB, int offL) {
            Raylib.SetConfigFlags(ConfigFlag.FLAG_WINDOW_UNDECORATED | ConfigFlag.FLAG_MSAA_4X_HINT);
            Raylib.InitWindow(640, 360, "Hello World");
            Raylib.SetWindowPosition(offL, offT);
            width = Raylib.GetMonitorWidth(0) - offR - offL - 5;
            height = Raylib.GetMonitorHeight(0) - offB - offT - 5;
            Raylib.SetWindowSize(width, height);

            if (Raylib.IsWindowReady() == false) throw new Exception("Inizializzazione fallita!");
        }
        private int XtoScreen(float dist) {
            return (int)((dist + posCentro.X) / metriPerPixel);
        }
        private int YtoScreen(float dist) {
            return height - (int)((dist + posCentro.Y) / metriPerPixel);
        }
        public void Run() {
            long elapsedms = 0, totalTemp;
            time.Start();

            Init();
            //Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose() && datiMondo.programmaAttivo) {
                totalTemp = time.ElapsedMilliseconds;
                Update(elapsedms);
                Render(elapsedms);
                nframe++;
                elapsedms = time.ElapsedMilliseconds - totalTemp;
            }

            Raylib.CloseWindow();
            datiMondo.programmaAttivo = false;
        }

        // Predisposizione della configurazione iniziale della simulazione (finestra ed elementi).
        public void Init() {
            // Impostazione iniziale finestra
            metriPerPixel = 100.0f / width;
            posCentro.X = -45.0f + metriPerPixel * (width / 2);
            posCentro.Y = -20.0f + metriPerPixel * (height / 2);

            // Predisposizione iniziale elementi
            Elemento p;
            /*p = new Particella(new Vector2(0, 0), new Vector2(0.1f, 0.1f), 1, 1, System.Drawing.Color.Blue);
            datiMondo.p.Add(p);
            p = new Particella(new Vector2(0, 0), new Vector2(0.05f, 0.01f), 1, 1, System.Drawing.Color.Green);
            datiMondo.p.Add(p);
            p = new Particella(new Vector2(0, 0), new Vector2(0, 0), 0.5f, 1, System.Drawing.Color.Red);
            datiMondo.p.Add(p);
            */

            /*for(int i= 0; i<500; i++) {
                p = new Particella(new Vector2(r.Next(10), r.Next(10)), new Vector2(r.Next(1000) / 1000.0f, r.Next(1000) / 1000.0f), 0.5f, 1, System.Drawing.Color.Red);
                datiMondo.p.Add(p);
            }*/
            /*for(int i=0; i<300; i++) {
                p = new Particella(new Vector2(r.Next(15)*3, r.Next(15)*3), new Vector2(-0.3f,0.02f));
                datiMondo.p.Add(p);
            }*/

            //datiMondo.p.Add(new Elemento(new Vector2(0, 10), new Vector2(5f, 0.3f), 0.5f, 1, System.Drawing.Color.Red));
            //datiMondo.p.Add(new Elemento(new Vector2(0, 0), new Vector2(1, 0), 0.5f, 1, System.Drawing.Color.Bisque));
            //datiMondo.p.Add(new Elemento(new Vector2(0, 0), new Vector2(0, 20), 10f, 1, System.Drawing.Color.DarkSeaGreen));

            // 40kg e la velocità alla volata è di 400 m/s

            datiMondo.p.Add(new Elemento(new Vector2(0, 10), new Vector2(1f, 0.3f), 0.5f, 1, System.Drawing.Color.Red));
            datiMondo.p.Add(new Elemento(new Vector2(20, 10), new Vector2(-1f, 0.3f), 0.5f, 1, System.Drawing.Color.Green));
        }

        public void Update(long elapsedms) {
            pm1 = Raylib.GetMousePosition();
            pmDiff = pm1 - pm2;
            pm2 = pm1;

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_RIGHT_BUTTON)) {
                pmDiff.Y = -pmDiff.Y;
                posCentro = posCentro + (pmDiff * metriPerPixel);
            }
            if (Raylib.GetMouseWheelMove() > 0) {
                metriPerPixel = metriPerPixel * 1.1f;
                posCentro = posCentro * 1.1f;
            }
            if (Raylib.GetMouseWheelMove() < 0) {
                metriPerPixel = metriPerPixel / 1.1f;
                posCentro = posCentro / 1.1f;
            }

            float dt = elapsedms / 1000.0f;

            foreach (Elemento p in datiMondo.p) {
                p.posizione += (p.velocita * dt);
                //p.velocita += (new Vector2(0, -9.81f)*dt); // Gravità
            }

            for (int i = 0; i < datiMondo.p.Count - 1; i++)
                for (int j = i + 1; j < datiMondo.p.Count; j++) {
                    if (datiMondo.p[i].collide(datiMondo.p[j]) == true) {
                        datiMondo.p[i].colore = System.Drawing.Color.Yellow;
                        datiMondo.p[j].colore = System.Drawing.Color.Yellow;
                        // Cosa si fà adesso?
                        // potrebbe essere utile il:
                        // principio di conservazione della quantità di moto

                    }
                }


        }

        public void Render(long elapsedms) {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawRectangleLines(1, 1, width - 1, height - 1, Color.RED);

            Raylib.DrawFPS(10, 10);
            Raylib.DrawText("Tempo totale: " + time.ElapsedMilliseconds + " ms", 20, 40, 30, Color.BLACK);

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON)) Raylib.DrawRectangle(20, 80, 25, 30, Color.RED);
            else Raylib.DrawRectangleLines(20, 80, 25, 30, Color.RED);
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_MIDDLE_BUTTON)) Raylib.DrawRectangle(50, 80, 12, 30, Color.RED);
            else Raylib.DrawRectangleLines(50, 80, 12, 30, Color.RED);
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_RIGHT_BUTTON)) Raylib.DrawRectangle(67, 80, 25, 30, Color.RED);
            else Raylib.DrawRectangleLines(67, 80, 25, 30, Color.RED);

            Raylib.DrawText("x: " + Raylib.GetMouseX() + " y: " + Raylib.GetMouseY() + " w: " +
                Raylib.GetMouseWheelMove(), 110, 80, 30, Color.BLACK);


            foreach (Elemento p in datiMondo.p) {
                Raylib.DrawCircle(XtoScreen(p.posizione.X), YtoScreen(p.posizione.Y), p.raggio / metriPerPixel, p.colore.toRaylibColor());
                Raylib.DrawCircleLines(XtoScreen(p.posizione.X), YtoScreen(p.posizione.Y), p.raggio / metriPerPixel, Color.BLACK);

                Vector2 dir = Vector2.Normalize(p.velocita) * p.raggio;
                Raylib.DrawLine(XtoScreen(p.posizione.X), YtoScreen(p.posizione.Y),
                    XtoScreen(p.posizione.X + dir.X), YtoScreen(p.posizione.Y + dir.Y), Color.BLACK);

            }


            // Riferimenti
            int fontSizeRif = (int)(0.25f / metriPerPixel);
            for (int i = 1; i <= 100; i++) {
                Raylib.DrawLine(XtoScreen(i), YtoScreen(0.1f), XtoScreen(i), YtoScreen(-0.1f), Color.PINK);
                Raylib.DrawText(i.ToString(), XtoScreen(i - 0.1f), YtoScreen(-0.3f), fontSizeRif, Color.LIGHTGRAY);
            }
            for (int i = 1; i <= 20; i++) {
                Raylib.DrawLine(XtoScreen(-0.1f), YtoScreen(i), XtoScreen(0.1f), YtoScreen(i), Color.PURPLE);
                Raylib.DrawText(i.ToString(), XtoScreen(-0.5f), YtoScreen(i), fontSizeRif, Color.LIGHTGRAY);
            }
            Raylib.DrawLine(XtoScreen(0), YtoScreen(0), XtoScreen(100), YtoScreen(0), Color.LIGHTGRAY);
            Raylib.DrawLine(XtoScreen(0), YtoScreen(0), XtoScreen(0), YtoScreen(20), Color.LIGHTGRAY);

            // Assi
            int fontSize = (int)(0.8f / metriPerPixel);
            Raylib.DrawLine(XtoScreen(0), YtoScreen(0), XtoScreen(1), YtoScreen(0), Color.DARKBLUE);
            Raylib.DrawTriangleLines(new Vector2(XtoScreen(0.9f), YtoScreen(0.1f)), new Vector2(XtoScreen(1), YtoScreen(0)), new Vector2(XtoScreen(0.9f), YtoScreen(-0.1f)), Color.DARKBLUE);
            Raylib.DrawText("X", XtoScreen(1.3f), YtoScreen(0.38f), fontSize, Color.BLUE);

            Raylib.DrawLine(XtoScreen(0), YtoScreen(0), XtoScreen(0), YtoScreen(1), Color.DARKGREEN);
            Raylib.DrawTriangleLines(new Vector2(XtoScreen(0), YtoScreen(1)), new Vector2(XtoScreen(-0.1f), YtoScreen(0.9f)), new Vector2(XtoScreen(0.1f), YtoScreen(0.9f)), Color.DARKBLUE);
            Raylib.DrawText("Y", XtoScreen(-0.28f), YtoScreen(2.0f), fontSize, Color.GREEN);

            // Scala
            Raylib.DrawLine(50, height - 50, 50 + width / 10, height - 50, Color.GRAY);
            Raylib.DrawLine(50, height - 50, 50, height - 65, Color.GRAY);
            Raylib.DrawLine(50 + width / 10, height - 50, 50 + width / 10, height - 65, Color.GRAY);
            Raylib.DrawText(metriPerPixel * (width / 10.0f) + " m", 60, height - 85, 30, Color.GRAY);

            Raylib.EndDrawing();
        }





    }
}
