using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;




namespace kursaCH
{

    public partial class Simulator : Form
    {

        Point moveStart; // объект для реализации перемещения формы

        int indexOfCurWord, indexOfCurRdLttr, indexOfCurWrtLttr, deltaIndex; 

        Text text; // объект класса для реалезации проверки ввода

        int second, minute, mistakeCount, wordsPerMinute;

        bool writingBoxIsClear, setNewText;

        string lastWrtLttr;

        public string Login { get; set; }

        

        Label[] keys;
        public Simulator(List<string> words)
        {
            InitializeComponent();

            text = new Text(words, readingBox.MaxLength);

            indexOfCurRdLttr = indexOfCurWrtLttr = deltaIndex = 0;

            readingBox.Text = text.SetText();

            second = minute = mistakeCount = wordsPerMinute = 0;

            writingBoxIsClear = true;
            setNewText = false;

            lastWrtLttr = "1";

            List<Label> keys1 = new List<Label>() { key0 };

            keys = new Label[] { key0, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12,
            key13, key14, key15, key16, key17, key18, key19, key20, key21, key22, key23, key24, key25, key26,
            key27, key28, key29, key30, key31, key32, key33, key34, key35, key36, key37, key38, key39, key40,
            key41, key42, key43, key44, key45, key46, key47, key48, key49, key50, key51, key52, key53};

            SetWordColor(Color.Gray);


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        // регестрация изменения writingBox
        private void writingBox_TextChanged(object sender, EventArgs e)
        {
            int countOfAttepmts, averSpeed;
            

            if(setNewText)
            {
                return;
            }
            if (indexOfCurRdLttr + 1 <= readingBox.Text.Length)
            {
                KeyboardManagement();
            }
            
            if (writingBoxIsClear)
            {
                timerForStopWatch.Start();
                timerForWordPerMinute.Start();
                writingBoxIsClear = false;
            }

            if (indexOfCurWord >= text.CountOfWords)
            {
                
                if (text.IsEmpty())
                {
                    timerForStopWatch.Stop();
                    timerForWordPerMinute.Stop();
                    DataBase.SetData("keyboard_simulator", "admin", "root", "localhost", "users");
                    DataBase.SetConnection();
                    DataBase.OpenConnection();
                    DataBase.SetCommandString($"SELECT AverSpeed, CountOfAttempts FROM users WHERE login = '{Login}'");
                    using (MySqlDataReader reader = DataBase.Select())
                    {
                        reader.Read();
                        averSpeed = (int)reader.GetValue(0);
                        countOfAttepmts = (int)reader.GetValue(1);
                        averSpeed = (averSpeed * countOfAttepmts + wordsPerMinute) / (++countOfAttepmts);
                    }
                    DataBase.SetCommandString($"UPDATE users SET AverSpeed = {averSpeed}, CountOfAttempts = {countOfAttepmts} WHERE login = '{Login}'");
                    DataBase.Execute();
                    DataBase.CloseConnection();
                    ResultForm resultForm = new ResultForm(stopWatchLable.Text, mistakeCount.ToString(), wordsPerMinute, averSpeed); ;
                    this.Hide();
                    resultForm.Login = Login;
                    resultForm.Show();
                }
                else
                {
                    
                    lastWrtLttr = "1";
                    deltaIndex += indexOfCurWord;
                    indexOfCurRdLttr = 0;
                    indexOfCurWrtLttr = 0;
                    indexOfCurWord = 0;
                    readingBox.Text = text.SetText();
                    SetWordColor(Color.Gray);
                    setNewText = true;
                    writingBox.Clear();
                    setNewText = false;
                }
            }
               

        }

        // регестрация нажатия клавиш( кроме стрелочек и Delete'а)
        private void writingBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool secondSpaceNotPressed = true;
            if (indexOfCurWord >= text.CountOfWords)
            {
                e.Handled = true;
            }

            if(e.KeyChar == (char)Keys.Space)
            {
                ProcessingOfSpaceKey(secondSpaceNotPressed, e);
            }

            if(e.KeyChar == (char)Keys.Back)
            {
                ProcessingOfBackKey(e);
            }

            if(e.KeyChar == (char)Keys.Enter)
            {
                ProcessingOfEnterKey(e);
            }

        }


        // регестрация нажатия стрелочек и Delete'а
        private void writingBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                ProcessingOfArrowsKey(e);
            }

            if (e.KeyCode == Keys.Delete)
            {
                ProcessingOfDeleteKey(e);
            }
        }

       
        // обработка нажатия пробела - ПРОВЕРКА ВВЕДЕННОГО СЛОВА
        private void ProcessingOfSpaceKey(bool secondSpaceNotPressed, KeyPressEventArgs e)
        {
            bool itWasMistake = false;

            // запрет на нажатие второго пробела
            if (writingBox.Text.Length != 0 && writingBox.Text[writingBox.Text.Length - 1] == ' ')
            {
                e.Handled = true;
                secondSpaceNotPressed = false;
            }

            if (secondSpaceNotPressed && !text.Compare(writingBox.Text.Split(new char[] { ' ' })[indexOfCurWord], indexOfCurWord + deltaIndex))
            {
                itWasMistake = true;
                readingBox.Select(text.GetStartPositionOfWords(indexOfCurWord + deltaIndex) - text.GetStartPositionOfWords(deltaIndex), text.GetLenghtOfWord(indexOfCurWord + deltaIndex));
                readingBox.SelectionColor = Color.Pink;
                MistakeLable.Text = (++mistakeCount).ToString();
            }

            if (secondSpaceNotPressed)
            {
                if (!itWasMistake)
                {
                    SetWordColor(Color.FromArgb(187, 251, 247));
                }
                RecountWPM();
                indexOfCurWord++;
                if (indexOfCurWord < text.CountOfWords)
                {
                    SetWordColor(Color.Gray);
                }
                SetKeyColor(readingBox.Text[indexOfCurRdLttr].ToString(), Color.FromArgb(113, 106, 227));
                indexOfCurRdLttr = text.GetStartPositionOfWords(indexOfCurWord + deltaIndex) - text.GetStartPositionOfWords(deltaIndex) - 1;
            }
        }


        private void SetWordColor(Color color)
        {
            readingBox.Select(text.GetStartPositionOfWords(indexOfCurWord + deltaIndex) - text.GetStartPositionOfWords(deltaIndex), text.GetLenghtOfWord(indexOfCurWord + deltaIndex));
            readingBox.SelectionColor = color;
           

        }

        // запрет на нажатие Backspace'а, если пользователь пытается стереть предыдущее слово
        private void ProcessingOfBackKey(KeyPressEventArgs e)
        {
            if (writingBox.Text.Length != 0 && writingBox.Text[writingBox.Text.Length - 1] == ' ')
            {
                e.Handled = true;
            }
        }

        // запрет на нажатие Enter'а
        private void ProcessingOfEnterKey(KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // запрет на нажатие "стрелок"
        private void ProcessingOfArrowsKey(KeyEventArgs e)
        {
            e.Handled = true;
        }

        // запрет на нажатие Delete'а
        private void ProcessingOfDeleteKey(KeyEventArgs e)
        {
            e.Handled = true;
        }


        // реализация перемещения формы
        private void Simulator_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void Simulator_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point delta = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                Location = new Point(Location.X + delta.X, Location.Y + delta.Y);
            }
        }
      


        private void timerForStopWatch_Tick(object sender, EventArgs e)
        {
            second++;
            if(second == 60)
            {
                second = 0;
                minute++;
            }

            stopWatchLable.Text = text.InsertZero(minute) + ":" + text.InsertZero(second);
        }


        private void timerForWordPerMinute_Tick(object sender, EventArgs e)
        {
            RecountWPM();
        }

        private void RecountWPM()
        {
            if (second != 0)
            {
                wordsPerMinute = ((indexOfCurWord + deltaIndex + 1) * 60) / (minute * 60 + second);
                countOfWordsLable.Text = wordsPerMinute.ToString();
            }

        }



        private void SetKeyColor(string inputData, Color color)
        {
            if (inputData == " ")
            {
                keys[53].BackColor = color;
            }
            foreach (var key in keys)
            {
                if(inputData.ToUpper() == key.Text.ToUpper())
                {
                    key.BackColor = color;
                    break;
                }
            }
        }


        private void KeyboardManagement()
        {
            SetKeyColor(lastWrtLttr, Color.FromArgb(113, 106, 227));
            SetKeyColor("Shift", Color.FromArgb(113, 106, 227));
            if (writingBox.Text.Length - 1 >= indexOfCurWrtLttr)
            {
                if (writingBox.Text[indexOfCurWrtLttr] != readingBox.Text[indexOfCurRdLttr])
                {
                    SetKeyColor(writingBox.Text[indexOfCurWrtLttr].ToString(), Color.Pink);
                }
                lastWrtLttr = writingBox.Text[indexOfCurWrtLttr].ToString();
                indexOfCurWrtLttr++;
                SetKeyColor(readingBox.Text[indexOfCurRdLttr].ToString(), Color.FromArgb(113, 106, 227));
                if(indexOfCurRdLttr + 1 < readingBox.Text.Length)
                {
                    indexOfCurRdLttr++;
                    SetKeyColor(readingBox.Text[indexOfCurRdLttr].ToString(), Color.GreenYellow);
                    if(readingBox.Text[indexOfCurRdLttr].ToString() != " " && 
                        readingBox.Text[indexOfCurRdLttr].ToString() == readingBox.Text[indexOfCurRdLttr].ToString().ToUpper() &&
                        readingBox.Text[indexOfCurRdLttr] <= 'Я' && readingBox.Text[indexOfCurRdLttr] >= 'А')
                    {
                        SetKeyColor("Shift", Color.GreenYellow);
                    }
                }
            }
            else
            {
                SetKeyColor(readingBox.Text[indexOfCurRdLttr--].ToString(), Color.FromArgb(113, 106, 227));
                SetKeyColor(readingBox.Text[indexOfCurRdLttr].ToString(), Color.GreenYellow);
                indexOfCurWrtLttr--;
                if (readingBox.Text[indexOfCurRdLttr].ToString() != " " &&
                        readingBox.Text[indexOfCurRdLttr].ToString() == readingBox.Text[indexOfCurRdLttr].ToString().ToUpper() &&
                        readingBox.Text[indexOfCurRdLttr] <= 'Я' && readingBox.Text[indexOfCurRdLttr] >= 'А')
                {
                    SetKeyColor("Shift", Color.GreenYellow);
                }
            }
        }


        // закрытие формы
        private void сloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            timerForStopWatch.Stop();
            timerForWordPerMinute.Stop();

        }

    }
}
