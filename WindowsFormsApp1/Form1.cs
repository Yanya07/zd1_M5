using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Point endPoint;
        private string selectedShape = "Line";
        private bool isDrawing = false;
        private Color currentColor = Color.Black;
        private int lineWidth = 2;

        // Создаем список для хранения нарисованных фигур
        private List<Shape> shapes = new List<Shape>();
        private bool isErasing = false;

        public Form1()
        {
            InitializeComponent();

            // Устанавливаем события для рисования
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.Paint += pictureBox1_Paint; // Событие для перерисовки при каждом обновлении PictureBox

            btnLine.Click += (s, e) =>// Кнопки для выбора формы
            {
                selectedShape = "Line";
                isErasing = false; // Выключаем режим стирателя
            };
            btnCircle.Click += (s, e) =>
            {
                selectedShape = "Circle";
                isErasing = false; // Выключаем режим стирателя
            };
            btnSquare.Click += (s, e) =>
            {
                selectedShape = "Square";
                isErasing = false; // Выключаем режим стирателя
            };

            btnColor.Click += (s, e) => ChooseColor();// Кнопка для выбора цвета
            trackBarThickness.Scroll += (s, e) => lineWidth = trackBarThickness.Value;// Ползунок для выбора толщины
        }

        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)// Когда мышь нажата
        {
            if (isErasing)
            {
                RemoveShapeAt(e.Location);
            }
            else
            {
                isDrawing = true;
                startPoint = e.Location;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)// Когда мышь перемещается
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                pictureBox1.Invalidate(); // Обновляем холст
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)// Когда кнопка мыши отпущена
        {
            if (isErasing)
            {
                return;
            }

            isDrawing = false;
            endPoint = e.Location;

            shapes.Add(new Shape// Добавляем новую фигуру в список
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                ShapeType = selectedShape,
                Color = currentColor,
                LineWidth = lineWidth
            });

            pictureBox1.Invalidate();// Обновляем PictureBox для перерисовки всех фигур
        }
        private void DrawShape(Graphics g, Shape shape) // Рисуем фигуру
        {
            Pen pen = new Pen(shape.Color, shape.LineWidth);

            switch (shape.ShapeType)
            {
                case "Line":
                    g.DrawLine(pen, shape.StartPoint, shape.EndPoint);
                    break;
                case "Circle":
                    int radius = Math.Min(Math.Abs(shape.EndPoint.X - shape.StartPoint.X), Math.Abs(shape.EndPoint.Y - shape.StartPoint.Y));
                    g.DrawEllipse(pen, shape.StartPoint.X, shape.StartPoint.Y, radius, radius);
                    break;
                case "Square":
                    int side = Math.Min(Math.Abs(shape.EndPoint.X - shape.StartPoint.X), Math.Abs(shape.EndPoint.Y - shape.StartPoint.Y));
                    g.DrawRectangle(pen, shape.StartPoint.X, shape.StartPoint.Y, side, side);
                    break;
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e) // Обработчик события Paint для перерисовки всех фигур
        {
            Graphics g = e.Graphics;

            foreach (var shape in shapes)// Перерисовываем все фигуры
            {
                DrawShape(g, shape);
            }

            if (isDrawing)// Рисуем текущую фигуру, если мы находимся в процессе рисования
            {
                DrawShape(g, new Shape
                {
                    StartPoint = startPoint,
                    EndPoint = endPoint,
                    ShapeType = selectedShape,
                    Color = currentColor,
                    LineWidth = lineWidth
                });
            }
        }
        private void ChooseColor()// Выбор цвета
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentColor = colorDialog.Color;
                    btnColor.BackColor = currentColor; // Отображаем выбранный цвет на кнопке
                }
            }
        }

        private void RemoveShapeAt(Point location) // Удаление фигуры по месту клика
        {
            var remainingShapes = new List<Shape>(); // Создаем временный список для хранения фигур, которые нужно сохранить

            foreach (var shape in shapes)
            {
                if (!IsPointInShape(location, shape)) // Проверяем, попадает ли курсор в фигуру
                {
                    remainingShapes.Add(shape);
                }
            }

            shapes = remainingShapes;// Обновляем список фигур
            pictureBox1.Invalidate(); // Обновляем PictureBox для перерисовки
        }

        private bool IsPointInShape(Point point, Shape shape)// Проверка, находится ли точка в фигуре
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                switch (shape.ShapeType)
                {
                    case "Line":
                        path.AddLine(shape.StartPoint, shape.EndPoint);
                        break;
                    case "Circle":
                        int radius = Math.Min(Math.Abs(shape.EndPoint.X - shape.StartPoint.X), Math.Abs(shape.EndPoint.Y - shape.StartPoint.Y));
                        path.AddEllipse(shape.StartPoint.X, shape.StartPoint.Y, radius, radius);
                        break;
                    case "Square":
                        int side = Math.Min(Math.Abs(shape.EndPoint.X - shape.StartPoint.X), Math.Abs(shape.EndPoint.Y - shape.StartPoint.Y));
                        path.AddRectangle(new Rectangle(shape.StartPoint.X, shape.StartPoint.Y, side, side));
                        break;
                }
                return path.IsVisible(point);
            }
        }
                private class Shape // Класс для хранения информации о нарисованных фигурах
        {
            public Point StartPoint { get; set; }
            public Point EndPoint { get; set; }
            public string ShapeType { get; set; }
            public Color Color { get; set; }
            public int LineWidth { get; set; }
        }
    }
}
