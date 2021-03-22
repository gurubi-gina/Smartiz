﻿using Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: input refactor
//TODO: zérushelyek kirajzolása
//TODO: tick-ek és rács rajzolása
//TODO: skálázás állítása külön + és - gombokkal
//TODO: grafikus integrálszámítás
//TODO: polinomok kirajzolása
//TODO: pplinomok analízise: x0, min/max -> numerikusv v. diszkrét megoldás?

//TODO: kör kirajzolása Circle hívás nélkül
//TODO: kocka kirajzolása izometrikusan
//TODO: kocka forgatása Y tengely körül
namespace Quadratic_Equation_Plot
{
    public struct Rectangle
    {
        public int Left;
        public int Top;
        public int Width;
        public int Height;

        public Rectangle(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }

    public struct Button
    {
        public Rectangle Bounds;

        public Direction Direction;

        public Button(int left, int top, int width, int height, Direction direction)
        {
            Bounds = new Rectangle(left, top, width, height);
            Direction = direction;
        }
    }

    public enum Direction
    {
        Up,
        Down
    }

    public class Program : SmartizSketch
    {
        [STAThread]
        static void Main()
        {
            new Program().Start();
        }

        double a = 0.1;
        double b = 10;
        double c = -8;
        double scale = 50;
        int TposX = 20;
        int TposY = 40;
        int RposX;
        const int ButtonWidth = 20;
        const int ButtonHeight = 10;
        Button Button1;
        Button Button2;
        Button Button3;
        Button Button4;
        Button Button5;
        Button Button6;
        Button ButtonPlus;
        Button ButtonMinus;
        //RposX = TposX + 50; //Variable assignment := statement

        public override void Setup()
        {
            Size(800, 600);
            Background(0);
            RposX = TposX + 60;
            Button1 = new Button(RposX, TposY - 15, ButtonWidth, ButtonHeight, Direction.Up); //20 := expression
            Button2 = new Button(RposX, TposY - 15 + ButtonHeight, ButtonWidth, ButtonHeight, Direction.Down);
            Button3 = new Button(RposX, TposY + 25, ButtonWidth, ButtonHeight, Direction.Up);
            Button4 = new Button(RposX, TposY + 25 + ButtonHeight, ButtonWidth, ButtonHeight, Direction.Down);
            Button5 = new Button(RposX, TposY + 65, ButtonWidth, ButtonHeight, Direction.Up);
            Button6 = new Button(RposX, TposY + 65 + ButtonHeight, ButtonWidth, ButtonHeight, Direction.Down);
            ButtonPlus = new Button(Width - 60, TposY - 15, ButtonWidth + 10, ButtonHeight + 10, Direction.Up);
            ButtonMinus = new Button(Width - 60, TposY - 15 + ButtonHeight + 10, ButtonWidth + 10, ButtonHeight + 10, Direction.Down);
        }

        public override void DrawFrame()
        {
            Background(0);
            DrawCoordinateSystem();
            DrawDashboard();
            DrawParabola(a, b, c);
        }

        public void DrawCoordinateSystem()
        {
            Stroke(255);
            StrokeWeight(1);
            Line(Width / 2, 0, Width / 2, Height);
            Line(0, Height / 2, Width, Height / 2);
            double stepX = Width / scale;
            double stepY = Height / scale;
            for (double i = 0; i < Width; i += stepX)
            {
                Stroke(113, 114, 120, 150);
                Line(0, i, Width, i);
                Stroke(255);
                Line(Width / 2 - 2, i, Width / 2 + 2, i);
            }
            for (double i = 0; i < Width; i += stepY)
            {
                Stroke(113, 114, 120, 150);
                Line(i, 0, i, Height);
                Stroke(255);
                Line(i, Height / 2 - 2, i, Height / 2 + 2);
            }
        }

        private void DrawDashboard()
        {
            Fill(255);
            TextSize(15);

            Text("A = " + a, TposX, TposY);
            DrawButton(Button1);
            DrawButton(Button2);

            Text("B = " + b, TposX, TposY + 40);
            DrawButton(Button3);
            DrawButton(Button4);

            Text("C = " + c, TposX, TposY + 80);
            DrawButton(Button5);
            DrawButton(Button6);

            Text("Scale: " + scale, Width - 150, TposY);
            DrawButton(ButtonPlus);
            DrawButton(ButtonMinus);
        }

        public void DrawButton(Button b)
        {
            int s = 4;
            NoFill();
            Stroke(255);
            Rect(b.Bounds.Left, b.Bounds.Top, b.Bounds.Width, b.Bounds.Height);
            Fill(255);
            if (b.Direction == Direction.Up)
            {
                Triangle(b.Bounds.Left + s, b.Bounds.Top + b.Bounds.Height - s, b.Bounds.Left + b.Bounds.Width / 2, b.Bounds.Top + s, b.Bounds.Left + b.Bounds.Width - s, b.Bounds.Top + b.Bounds.Height - s);
            }
            else
            {
                Triangle(b.Bounds.Left + s, b.Bounds.Top + s, b.Bounds.Left + b.Bounds.Width - s, b.Bounds.Top + s, b.Bounds.Left + b.Bounds.Width / 2, b.Bounds.Top + b.Bounds.Height - s);
            }
        }

        public bool IsOn(Button b)
        {
            return PMouseX >= b.Bounds.Left && PMouseX <= b.Bounds.Left + b.Bounds.Width && PMouseY >= b.Bounds.Top && PMouseY <= b.Bounds.Top + b.Bounds.Height;
        }

        public override void MouseClicked()
        {
            if (IsOn(Button1))
            {
                a = Math.Round(a + 0.1, 1);
            }
            else if (IsOn(Button2))
            {
                a = Math.Round(a - 0.1, 1);
            }
            else if (IsOn(Button3))
            {
                b = Math.Round(b + 1, 1);
            }
            else if (IsOn(Button4))
            {
                b = Math.Round(b - 1, 1);
            }
            else if (IsOn(Button5))
            {
                c = Math.Round(c + 1, 1);
            }
            else if (IsOn(Button6))
            {
                c = Math.Round(c - 1, 1);
            }

            if (IsOn(ButtonPlus))
            {
                scale = Math.Round(scale - 1, 1);
            }
            else if (IsOn(ButtonMinus))
            {
                scale = Math.Round(scale + 1, 1);
            }
        }

        public void DrawParabola(double a, double b, double c)
        {
            double pX = 0;
            double pY = 0;

            for (var x = -Width / 2; x < Width; x++)
            {
                var y = a * x * x + b * x + c;
                Stroke(80, 133, 188);
                StrokeWeight(2);
                double X = x + Width / 2;
                double Y = -y + Height / 2;
                Line(X, Y, pX, pY);
                pX = X;
                pY = Y;
            }
        }
    }
}