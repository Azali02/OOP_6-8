using System.Collections.Generic;
using System.Windows.Forms;
using oop4_1.FactoryMethod;
using oop4_1.Figures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace oop4_1
{

    public partial class Form1 : Form
    {

        enum FigureType { Circle, Square, Triangle }
        private FigureType currentFigure;

        private List<Figure> figure = new List<Figure>();  //создаем список объектов
        private string filename = "C:/Users/Азалия/source/repos/oop4_1/oop4_1/FactoryMethod/save_figures.txt";

        public Form1()
        {
            InitializeComponent();
            cbColor.SelectedIndex = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)  //описание события нажатия клавиши на клавиатуре
        {
            if (ModifierKeys == Keys.Control)  //для Control
            {
                chb_Ctrl.Checked = true;
            }
            else if (e.KeyCode == Keys.Delete)  //для Delete
            {
                int count = 0;
                for (int i = 0; i < figure.Count;)
                {
                    if (figure[i].DecoratorCheck())
                    {
                        figure.RemoveAt(i);
                        count++;
                        continue;
                    }
                    ++i;
                }
                if (figure.Count != 0 && count > 0)
                {
                    Figure decoratedFigure = new Decorator(figure.Last());
                    figure.RemoveAt(figure.Count - 1); // удалить последний элемент из списка
                    figure.Add(decoratedFigure); // добавить декорированный объект в список
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.Z) //уменьшение выделенных объектов
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.SizeUp(-2, pictureBox1.Width, pictureBox1.Height);
                    }
                    Refresh();
                }
            }
            else if (e.KeyCode == Keys.X) //увеличение выделенных объектов
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.SizeUp(2, pictureBox1.Width, pictureBox1.Height);
                    }
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.A)
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.move(-2, 0, pictureBox1.Width, pictureBox1.Height);
                    }
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.D)
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.move(2, 0, pictureBox1.Width, pictureBox1.Height);
                    }
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.W)
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.move(0, -2, pictureBox1.Width, pictureBox1.Height);
                    }
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.S)
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.move(0, 2, pictureBox1.Width, pictureBox1.Height);
                    }
                }
                Refresh();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)  //описание события отпускания клавиши 
        {
            if (chb_Ctrl.Checked == true) //описание события отпускания клавиши Control
                chb_Ctrl.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)  //описание события кнопки Очистить
        {
            for (int i = 0; i < figure.Count;)
            {
                figure.Remove(figure[i]);
            }
            Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)  //Описание события нажатия мыши
        {
            if (chb_Ctrl.Checked == false)  //создаем новую фигуру
            {
                Figure newFigure = null;
                for (int i = 0; i < figure.Count; i++)
                {
                    if (figure[i] is Decorator decorator)
                    {
                        figure[i] = decorator.GetOriginalFigure();
                    }
                    else if (figure[i].DecoratorCheck()) //выделенная группа
                    {
                        figure[i].UndecoratedGroup();
                    }
                }
                switch (currentFigure)
                {
                    case FigureType.Circle:
                        newFigure = new CCircle(e.X, e.Y);
                        break;
                    case FigureType.Square:
                        newFigure = new Square(e.X, e.Y);
                        break;
                    case FigureType.Triangle:
                        newFigure = new Triangle(e.X, e.Y);
                        break;
                    default:
                        return;
                }
                newFigure.SetColor(Color.FromName(cbColor.SelectedItem.ToString()));
                Figure decC = new Decorator(newFigure);
                figure.Add(decC);
                pictureBox1.Invalidate();
            }
            else  //выделяем фигуру при отжатии Control
            {
                for (int i = 0; i < figure.Count; i++)
                {
                    Figure f = figure[i];
                    if (f.isClickedOnFigure(e.X, e.Y) && !f.DecoratorCheck())
                    {
                        Figure decoratedFigure = new Decorator(f);
                        figure.RemoveAt(i);
                        figure.Insert(i, decoratedFigure);
                        if (!chb_flag.Checked)
                            break;
                    }
                }
            }
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)  //Описание события Paint
        {
            foreach (Figure f in figure)
            {
                f.Draw(e.Graphics);
            }
        }

        private void rbCircle_CheckedChanged(object sender, EventArgs e)
        {
            currentFigure = FigureType.Circle;
            Refresh();
        }

        private void rbSquare_CheckedChanged(object sender, EventArgs e)
        {
            currentFigure = FigureType.Square;
            //for (int i = 0; i < figure.Count; i++)
            //{
            //    if (figure[i] is Decorator decorator)
            //    {
            //        Figure originalFigure = decorator.GetOriginalFigure();
            //        Figure newFigure = new Square(originalFigure.x, originalFigure.y);
            //        newFigure.SetColor(originalFigure.GetColor());
            //        newFigure.a = originalFigure.a;
            //        Figure decC = new Decorator(newFigure);
            //        figure.Insert(i, decC);
            //        figure.RemoveAt(i + 1);
            //    }
            //}
            Refresh();
        }

        private void rbTriangle_CheckedChanged(object sender, EventArgs e)
        {
            currentFigure = FigureType.Triangle;
            //for (int i = 0; i < figure.Count; i++)
            //{
            //    if (figure[i] is Decorator decorator)
            //    {
            //        Figure originalFigure = decorator.GetOriginalFigure();
            //        Figure newFigure = new Triangle(originalFigure.x, originalFigure.y);
            //        newFigure.SetColor(originalFigure.GetColor());
            //        newFigure.a = originalFigure.a;
            //        Figure decC = new Decorator(newFigure);
            //        figure.Insert(i, decC);
            //        figure.RemoveAt(i + 1);
            //    }
            //}
            Refresh();
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Figure f in figure)
            {
                if (f.DecoratorCheck())
                {
                    f.SetColor(Color.FromName(cbColor.SelectedItem.ToString()));
                }
            }
            Refresh();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width - 40;
            pictureBox1.Height = this.Height - 160;
        }

        private void cbColor_MouseEnter(object sender, EventArgs e)
        {
            cbColor.DroppedDown = true;
        }

        private void button_dlt_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < figure.Count;)
            {
                if (figure[i].DecoratorCheck())
                {
                    figure.RemoveAt(i);
                    count++;
                    continue;
                }
                ++i;
            }
            if (figure.Count != 0 && count > 0)
            {
                Figure decoratedFigure = new Decorator(figure.Last());
                figure.RemoveAt(figure.Count - 1); // удалить последний элемент из списка
                figure.Add(decoratedFigure); // добавить декорированный объект в список
            }
            Refresh();
        }

        private void btn_notSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figure.Count; i++)
            {
                if (figure[i] is Decorator decorator)
                {
                    figure[i] = decorator.GetOriginalFigure();
                }
                else if (figure[i].DecoratorCheck() == true) //выделенная группа
                {
                    figure[i].UndecoratedGroup();
                }
            }
            Refresh();
        }

        private void btnGroup_Click(object sender, EventArgs e) //группировка
        {
            int k = 0;
            for (int i = 0; i < figure.Count; i++)
            {
                if (figure[i].DecoratorCheck())
                {
                    k++;
                }
            }
            if (k > 1)
            {
                var gGroup = new GGroup();
                for (int i = 0; i < figure.Count;)
                {
                    if (figure[i].DecoratorCheck())
                    {
                        gGroup.Add(figure[i]);
                        figure.Remove(figure[i]);
                    }
                    else i++;
                }
                figure.Add(gGroup);
                Refresh();
            }

        }

        private void btnUngroup_Click(object sender, EventArgs e) //разгруппировка
        {
            for (int i = 0; i < figure.Count;)
            {
                if (figure[i] is Decorator decorator)
                {
                    if (decorator.GetOriginalFigure() is GGroup gGroup)
                    {
                        while (gGroup.Count() > 1)
                        {
                            figure.Add(gGroup.GetOriginalFigure());
                            gGroup.RemoveAt();
                        }
                        figure.Add(gGroup.GetOriginalFigure());
                        figure.Remove(figure[i]);
                    }
                }
                ++i;
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //выгрузка из файла
        {
            Method factory = new Method(); // create a new factory method object
            ShapeArray array = new ShapeArray(); // create a new shape array object
            array.LoadShapes(filename, factory, figure); // call the LoadShapes method with the initialized objects and figure list
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e) //сохранение в файл
        {
            SaveArray array = new SaveArray();
            array.save(figure, filename);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {


        }
    }
}