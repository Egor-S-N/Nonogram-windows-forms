using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace Kursovik_NONOGRAMM
{
    public class Logic
    {
        public static Control Lcontrol;
        public static int selector;// Выбор размера уровня
        public static int SizeX; // Размеры экрана 
        public static int SizeY;
        public static int cout; // кол-во шагов 
        public static int value; // случайный выбор уровня 
        public static string select; // выбор уровня 
        public static List<Button> Buttons = new List<Button>(); // список кнопок на поле
        public static List<Label> HorizontalLabels = new List<Label>(); // горизонтальные подсказки
        public static List<Label> VerticalLabels = new List<Label>(); // вертикальные подсказки 
        public static Label CongratulationsLabel = new Label(); // сообщение о прохождении 
        public static List<bool> Answer = new List<bool>(); // заполнение схемы ответов





        public static List<bool> Choise()
        {
            List<bool> Solution = new List<bool>();
            using (StreamReader sr = new StreamReader("..\\..\\levels.txt"))
            {
                string[] lines = sr.ReadToEnd().Split('\n');
                if (selector == 1)
                {
                    SizeX = 5;
                    SizeY = 5;
                    select = lines[value];
                }
                if (selector == 2)
                {
                    SizeX = 6;
                    SizeY = 6;
                    select = lines[value];
                }
                if (selector == 3)
                {
                    SizeX = 10;
                    SizeY = 10;
                    select = lines[value];
                }

                foreach (char c in select)
                {
                    if (c == '1')
                    {
                        Solution.Add(true);
                    }
                    else if (c == '0')
                    {
                        Solution.Add(false);
                    }
                }


            }
           
            return Solution;
        }



        public static void CreateButtons(Control control)
        {
            for (int x = 0; x < SizeX; x ++)
            {
                for (int y = 0; y < SizeY; y ++)
                {
                    Button newbutton = new Button();
                    control.Controls.Add(newbutton);
                    newbutton.Text = "";

                    newbutton.Location = new Point((control.ClientSize.Width / 2 - ((SizeX * 35) / 2)) + x * 35,
                                                   (control.ClientSize.Height / 2 - ((SizeY * 25) / 2)) + y * 35); // задаем позиции кнопкам
                    newbutton.Size = new Size(35, 35); // задаем размер кнопок

                    //свойства кнопок
                    Answer.Add(false);
                    newbutton.BackColor = Color.White;

                    newbutton.FlatStyle = FlatStyle.Flat;
                    newbutton.FlatAppearance.BorderColor = Color.Black;
                    newbutton.FlatAppearance.BorderSize = 1;
                    Buttons.Add(newbutton);
                    newbutton.MouseDown += Button_MouseDown;

                }
            }
        }

        public static void Button_MouseDown(object sender, MouseEventArgs e) // метод закрашивания ячеек 
        {
            if (e.Button == MouseButtons.Left) // при нажатии на левую кнопку мышки
            {
                
                if (((Button)sender).BackColor == Color.White) // если ячейка не закрашена
                {
                    ((Button)sender).BackColor = Color.Black;
                    Answer[Buttons.IndexOf(((Button)sender))] = true;
                    cout++;

                }
                else if (((Button)sender).BackColor == Color.Black) // если ячейка закрашена
                {
                    ((Button)sender).BackColor = Color.White;
                    Answer[Buttons.IndexOf(((Button)sender))] = false;
                    cout++;

                }
                CheckIfGameEnd();

            }



        }


        public static void CreateLabels(Control control) // создание подсказок
        {

            List<List<int>> Horizontal = new List<List<int>>(); // список числа значений подсказок - горизонтальный
            List<string> HorizontalLabelStrings = new List<string>(); // список значений подсказок - горизонтальный
            List<bool> Solution = Choise();
           
            int HorizontalCounter; // счетчик заполненных ячеек
            //проверка всех ячеек
            for (int j = 0; j < SizeY; j++)// проверка по столбам 
            {
                List<int> tmp = new List<int>();// временный список номеров ячеек, которые должны быть заполненны 
                HorizontalCounter = 0;
                for (int i = 0; i < SizeX; i++)
                {
                    if (Solution[SizeY * i + j] == true) // если ячейка должна быть заполненной 
                    {
                        HorizontalCounter++;
                        if (i == SizeX - 1) 
                        {
                            tmp.Add(HorizontalCounter);
                        }
                    }
                    else //если ячейка должна быть пустой 
                    {
                        if (HorizontalCounter != 0) // если счетчик заполненых ячеек не равен 0
                        {
                            tmp.Add(HorizontalCounter);
                        }
                        HorizontalCounter = 0;
                    }
                }
                Horizontal.Add(tmp);
            }
            List<List<int>> Vertical = new List<List<int>>();// список числа значений подсказок - вертикальный
            List<string> VerticalLabelStrings = new List<string>();// список значений подсказок - вертикальный
            int VerticalCounter;// счетчик заполненных ячеек
            //проверка всех ячеек
            for (int i = 0; i < SizeX; i++)// проверка по строкам
            {
                List<int> tmp2 = new List<int>();
                VerticalCounter = 0;
                for (int j = 0; j < SizeY; j++)
                {

                    if (Solution[i * SizeY + j] == true)// если ячейка должна быть заполненной 
                    {
                        VerticalCounter++;
                        if (j == SizeY - 1)
                        {
                            tmp2.Add(VerticalCounter);
                        }
                    }
                    else//если ячейка должна быть пустой 
                    {
                        if (VerticalCounter != 0) // если счетчик заполненых ячеек не равен 0
                        {
                            tmp2.Add(VerticalCounter);
                        }
                        VerticalCounter = 0;
                    }
                }
                Vertical.Add(tmp2);
            }
            foreach (var h in Horizontal)
            {
                string str = "";
                foreach (var e in h)
                {
                    str += e.ToString() + " ";
                }
                HorizontalLabelStrings.Add(str); 
            }
            foreach (var v in Vertical)
            {
                string str = "";
                foreach (var e in v)
                {
                    str += e.ToString() + "\n";
                }
                VerticalLabelStrings.Add(str);
            }
            //Добавление горизонтальных подсказок
            for (int i = 0; i < SizeY; i++)
            {
                Label NewHorizontalLabel = new Label();
                control.Controls.Add(NewHorizontalLabel);
                NewHorizontalLabel.AutoSize = true;
                NewHorizontalLabel.Text = HorizontalLabelStrings[i] == "" ? "0" : HorizontalLabelStrings[i];
                NewHorizontalLabel.Font = new Font(NewHorizontalLabel.Font.Name, 10);
                //размешение горизонтальных подсказок
                NewHorizontalLabel.Location = new Point(Buttons[i].Location.X - NewHorizontalLabel.Size.Width,
                                                        Buttons[i].Location.Y + Buttons[i].Size.Height / 2 - NewHorizontalLabel.Size.Height / 2);
                HorizontalLabels.Add(NewHorizontalLabel);
            }
            //Добавление вертикальных подсказок

            for (int i = 0; i < SizeX; i++)
            {
                Label NewVerticalLabel = new Label();
                control.Controls.Add(NewVerticalLabel);
                NewVerticalLabel.AutoSize = true;
                NewVerticalLabel.Text = VerticalLabelStrings[i] == "" ? "0" : VerticalLabelStrings[i];
                NewVerticalLabel.Font = new Font(NewVerticalLabel.Font.Name, 10);
                //размешение горизонтальных подсказок
                NewVerticalLabel.Location = new Point(Buttons[i * SizeY].Location.X + Buttons[i * SizeY].Size.Width / 2 - NewVerticalLabel.Size.Width / 2,
                                                      Buttons[i * SizeY].Location.Y - NewVerticalLabel.Size.Height);
                VerticalLabels.Add(NewVerticalLabel);
            }
        }
        public static void CheckIfGameEnd()
        {

            if (Choise().SequenceEqual(Answer))
            {
                foreach (var b in Buttons)
                {
                    b.Enabled = false;
                }
                CongratulationsLabel = new Label();
                Lcontrol.Controls.Add(CongratulationsLabel);
                CongratulationsLabel.AutoSize = true;
                CongratulationsLabel.Text = $"Вы прошли уровень!\nКол-во шагов которое вы потратили: {cout}";
                CongratulationsLabel.Font = new Font("Arial", 18, FontStyle.Regular);
                CongratulationsLabel.Location = new Point(Lcontrol.ClientSize.Width / 2 - CongratulationsLabel.Size.Width / 2,
                                                          Lcontrol.ClientSize.Height - CongratulationsLabel.Size.Height);
                
                using (StreamWriter sw = new StreamWriter("..\\..\\Results.txt", true, Encoding.GetEncoding(1251)))
                {
                    sw.WriteLine($"Уровень № {value} был пройден за: {cout} шага-ов");
                }
                cout = 0;
            }
        }

        public static void RemoveButtons(Control control)
        {
            foreach (var b in Buttons)
            {
                b.MouseClick -= Button_MouseDown;
                control.Controls.Remove(b);
                b.Dispose();
            }
            Buttons.Clear();
        }

        public static void RemoveLabels(Control control)
        {
            foreach (var l in HorizontalLabels)
            {
                control.Controls.Remove(l);
                l.Dispose();
            }
            HorizontalLabels.Clear();
            foreach (var l in VerticalLabels)
            {
                control.Controls.Remove(l);
                l.Dispose();
            }
            VerticalLabels.Clear();
        }

        public static void RemoveCongratulationsLabel(Control control)
        {
            control.Controls.Remove(CongratulationsLabel);
            CongratulationsLabel.Dispose();
        }

        public static void ClearAnswer()
        {
            Answer.Clear();
        }
    }
}
