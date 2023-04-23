using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace oop4_1
{

    public partial class Form1 : Form
    {

        enum FigureType { Circle, Square, Triangle }
        private FigureType currentFigure;

        private List<Figure> figure = new List<Figure>();  //������� ������ ��������

        public Form1()
        {
            InitializeComponent();
            cbColor.SelectedIndex = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)  //�������� ������� ������� ������� �� ����������
        {
            if (ModifierKeys == Keys.Control)  //��� Control
            {
                chb_Ctrl.Checked = true;
            }
            else if (e.KeyCode == Keys.Delete)  //��� Delete
            {
                int count = 0;
                for (int i = 0; i < figure.Count;)
                {
                    if (figure[i].DecoratorCheck())
                    {
                        figure.RemoveAt(i);
                        continue;
                        count++;
                    }
                    ++i;
                }
                if (figure.Count != 0 && count>0)
                {
                    Figure decoratedFigure = new Decorator(figure.Last());
                    figure.RemoveAt(figure.Count - 1); // ������� ��������� ������� �� ������
                    figure.Add(decoratedFigure); // �������� �������������� ������ � ������
                }
                Refresh();
            }
            else if (e.KeyCode == Keys.Z) //���������� ���������� ��������
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.SizeUp(-1, pictureBox1.Width, pictureBox1.Height);

                    }
                    Refresh();
                }
            }
            else if (e.KeyCode == Keys.X) //���������� ���������� ��������
            {
                foreach (Figure f in figure)
                {
                    if (f.DecoratorCheck())
                    {
                        f.SizeUp(1, pictureBox1.Width, pictureBox1.Height);

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
                        f.move(-1, 0, pictureBox1.Width, pictureBox1.Height);
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
                        f.move(1, 0, pictureBox1.Width, pictureBox1.Height);
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
                        f.move(0, -1, pictureBox1.Width, pictureBox1.Height);
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
                        f.move(0, 1, pictureBox1.Width, pictureBox1.Height);
                    }
                }
                Refresh();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)  //�������� ������� ���������� ������� 
        {
            if (chb_Ctrl.Checked == true) //�������� ������� ���������� ������� Control
                chb_Ctrl.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)  //�������� ������� ������ ��������
        {
            for (int i = 0; i < figure.Count;)
            {
                figure.Remove(figure[i]);
            }
            if (figure.Count != 0)
            {
                Figure decoratedFigure = new Decorator(figure.Last());
                figure.RemoveAt(figure.Count - 1); // ������� ��������� ������� �� ������
                figure.Add(decoratedFigure); // �������� �������������� ������ � ������
            }
            Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)  //�������� ������� ������� ����
        {
            if (chb_Ctrl.Checked == false)  //������� ����� ������
            {
                Figure newFigure = null;
                for (int i = 0; i < figure.Count; i++)
                {
                    if (figure[i] is Decorator decorator)
                    {
                        figure[i] = decorator.GetOriginalFigure();
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
            else  //�������� ������ ��� ������� Control
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)  //�������� ������� Paint
        {
            foreach (Figure f in figure)
            {
                f.Draw(e.Graphics);
            }
        }

        private void rbCircle_CheckedChanged(object sender, EventArgs e)
        {
            currentFigure = FigureType.Circle;
        }

        private void rbSquare_CheckedChanged(object sender, EventArgs e)
        {
            currentFigure = FigureType.Square;
        }

        private void rbTriangle_CheckedChanged(object sender, EventArgs e)
        {
            currentFigure = FigureType.Triangle;
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
                    continue;
                    count++;
                }
                ++i;
            }
            if (figure.Count != 0 && count > 0)
            {
                Figure decoratedFigure = new Decorator(figure.Last());
                figure.RemoveAt(figure.Count - 1); // ������� ��������� ������� �� ������
                figure.Add(decoratedFigure); // �������� �������������� ������ � ������
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
            }
            Refresh();
        }
    }
}