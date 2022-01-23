using LR4_VAR9_TIKHONOVA_MIVS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace LR4_VAR9_TIKHONOVA_MIVS
{
    public partial class Form1 : Form
    {
        private int n = 0;
        private ListEvents free = new ListEvents();
        private ListEvents holiday = new ListEvents();
        private ListEvents study = new ListEvents();
        private ListEvents sun = new ListEvents();
        private ListEvents rain = new ListEvents();
        private ListEvents cold = new ListEvents();
        private ListLogicalConditions listL = new ListLogicalConditions();
        private string info = "День: ";
        private int day;  int weth;
        private Random rnd = new Random();
        private ResourceManager rm = Resources.ResourceManager;
        public Form1()
        {
            InitializeComponent();
            button3.Visible = false;
            textBox2.Visible = false;
            listBox1.Visible = false;
            button4.Visible = false;
            free.AddFirst("тренировка", 2, Properties.Resources.треня);
            free.AddFirst("друзья", 3, Properties.Resources.кафе);
            holiday.AddFirst("ужин", 2, Properties.Resources.ужин);
            holiday.AddFirst("цветы", 1, Properties.Resources.цветочный);
            study.AddFirst("дз", 3, Properties.Resources.дз);
            study.AddFirst("вуз", 3, Properties.Resources.вуз);
            sun.AddFirst("погулять с собакой",1, Properties.Resources.x);
            rain.AddFirst("зонт",1, Properties.Resources.x);
            cold.AddFirst("шапка",1, Properties.Resources.x);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            button4.Visible = false;
            listL.DeleteAll();
            n++;
            {
                info = "День: " + n;
                int value = rnd.Next(1, 8);
                switch (value)
                {
                    case 2: case 3: case 4:
                        day = 2;
                        info = info + ", учебный";
                        listL.AddFirst(true, study, "учебный день", Properties.Resources.будни_старт); 
                        break;
                    case 1: case 5:
                        day = 3;
                        info = info + ", праздничный ";
                        listL.AddFirst(true, holiday, "праздничный день", Properties.Resources.праздник_старт); 
                        break;
                    case 6: case 7:
                        day = 1;
                        info = info + ", выходной";
                        listL.AddFirst(true, free, "выходной день", Properties.Resources.выходной_старт); 
                        break;
                }
                value = rnd.Next(1, 4);
                switch (value)
                {
                    case 1:
                        weth = 1;
                        info = info + ", солнечно";
                        listL.AddFirst(true, sun, "солнечный день", Properties.Resources.собака);
                        break;
                    case 2:
                        weth = 2;
                        info = info + ", дождь";
                        listL.AddFirst(true, rain, "дождливый день", Properties.Resources.зонт);
                        break;
                    case 3:
                        weth = 3;
                        info = info + ", холодно";
                        listL.AddFirst(true, cold, "холодный день", Properties.Resources.холодно);
                        break;
                }
                listBox1.Items.Add(info);

                Thread t = new Thread(new ThreadStart(EventMy));
                t.Start();
            }
        }
        private void EventMy (){
            this.Invoke(new MethodInvoker(() =>{
                textBox2.Text = info;
                textBox2.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                textBox1.Visible = false;
                button3.Visible = false;
                this.BackgroundImage = listL.GetStart();
            }));
            Thread.Sleep(2000);
            if (listL.GetWether()== "дождливый день" || listL.GetWether() == "холодный день")
            {
                this.Invoke(new MethodInvoker(() => { this.BackgroundImage = listL.GetWetherChoice(); }));
                Thread.Sleep(2000);
                ListEvents events = listL.GetEventDay();
                Event p = events.Head.Next;
                while (p != events.Head)
                {
                    this.Invoke(new MethodInvoker(() => { this.BackgroundImage = (p.Picture); }));
                    Thread.Sleep(p.Time*2000);
                    p = p.Next;
                }
            }
            else
            {
                ListEvents events = listL.GetEventDay();
                Event p = events.Head.Next;
                while (p != events.Head)
                {
                    this.Invoke(new MethodInvoker(() => { this.BackgroundImage = (p.Picture); }));
                    Thread.Sleep(p.Time * 2000);
                    p = p.Next;
                }
                this.Invoke(new MethodInvoker(() => { this.BackgroundImage = (listL.GetWetherChoice()); }));
                Thread.Sleep(2000);
            }
            this.Invoke(new MethodInvoker(() =>
            {
                button4.Visible = true;
                button3.Visible = true;
                listL.Print(listBox1);
                listBox1.Visible = true;
            }));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
