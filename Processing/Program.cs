using System;
using System.Collections.Generic;
using System.Linq;

namespace Processing
{
    public class Program : SmartizSketch
    {
        [STAThread]
        static void Main()
        {
            new Program().Start();
        }

        SnowflakeClass[] Snowflakes;
        Tongue Tongue;
        int Counter;
        double Timer;

        public override void Setup()
        {
            Size(600, 600);
            Background(21, 34, 56);

            Tongue = new Tongue(Width, Height);
            Snowflakes = new SnowflakeClass[50];

            Counter = Snowflakes.Length - 10;
            Timer = 1000 * (Counter + 10);

            for (int i = 0; i < Snowflakes.Length; i++)
            {
                Snowflakes[i] = new SnowflakeClass(Random(Width - 10), Random(Height), Random(7.12), Random(1, 5), 255);
            }
        }

        public override void DrawFrame()
        {
            if (!IsGameover())
            {
                Timer -= DeltaTime;
            }
            Background(21, 34, 56);
            Tongue.Draw();
            Tongue.Move(Width);
            foreach (var snow in Snowflakes)
            {
                snow.Move();
                UpdateSnowflake(snow);
                snow.Draw();
            }
            DrawDashboard();
        }

        private void DrawDashboard()
        {
            Fill(255);
            TextSize(25);
            Text("Timer: " + Round(Timer / 1000), 20, 40);
            Text("Counter: " + Counter, Width - 150, 40);
            Fill(255);

            TextSize(40);
            if (Counter == 0)
            {
                Text("YOU WON! :)", Width / 2 - 100, Height / 2);
            }
            else if (Timer < 0)
            {
                Text("YOU LOST! :(", Width / 2 - 100, Height / 2);
            }
        }

        private void UpdateSnowflake(SnowflakeClass snow)
        {
            if (IsOnTongue(snow))
            {
                snow.Melt();

                if (snow.IsMelted() && !IsGameover())
                {
                    Counter--;
                }
            }
            else if (IsOutsideCanvas(snow))
            {
                snow.Refresh();
            }
        }

        private bool IsOutsideCanvas(SnowflakeClass snow)
        {
            return snow.Y > Height + snow.Size;
        }

        private bool IsOnTongue(SnowflakeClass snow)
        {
            return snow.Y > Tongue.Y + Tongue.Height / 2 && snow.X > Tongue.X + Tongue.Margin && snow.X < Tongue.X + Tongue.Width - Tongue.Margin && snow.Y < Height - Tongue.Margin;
        }

        public override void KeyReleased()
        {
            Tongue.Speed = 0;
        }

        public override void KeyPressed()
        {
            if (KeyCode == KC_LEFT)
            {
                Tongue.Speed = -5;
            }
            else if (KeyCode == KC_RIGHT)
            {
                Tongue.Speed = 5;
            }
        }

        private bool IsGameover()
        {
            return Counter == 0 || Timer < 0;
        }

    }
}