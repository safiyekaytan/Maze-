using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace Maze
{
    public partial class Problem1 : Form
    {

        Uygulama saat;
        
        bool hedefe_ulasildi;
        List<Tuple<int, int>> path;
        public SoundPlayer ses = new SoundPlayer();
        public int saatKontrol = 0;
        int x = 0;

        Izgara map;
        int map_x = 40;
        int map_y = 40;
        Robot1 robot;
        int scale;


        Label[,] labels_bulut;

        Label label_robo;
        public Problem1()
        {

            saat = new Uygulama();

            string url;
            do
            {
                url = Interaction.InputBox("Url adresini giriniz :", "Bilgi Girişi", "http://bilgisayar.kocaeli.edu.tr/prolab2/url1.txt", 600, 400);
            } while (url == "" || url.IndexOf(".txt") == -1);


            map = new Izgara(url);
            int r_x = map.baslangic[0];
            int r_y = map.baslangic[1];

            robot = new Robot1(r_x, r_y, map.rowCount, map.colCount);


            path = robot.hareket(map);


            scale = 400 / map.rowCount;


            label_robo = new Label();
            label_robo.Size = new Size(scale - 4, scale - 4);
            label_robo.Location = new Point((r_x * scale) + map_x + 2, (r_y * scale) + map_y + 2);
            label_robo.BackColor = Color.Blue;


            labels_bulut = new Label[map.rowCount + 2, map.colCount + 2];


            InitializeComponent();

            panel1.Controls.Add(label_robo);

            robot.Look(map);

            for (int i = 0; i < map.rowCount + 2; i++)
            {
                for (int j = 0; j < map.colCount + 2; j++)
                {
                    Label bulut = new Label();
                    bulut.Size = new Size(scale - 1, scale - 1);
                    bulut.Location = new Point((i * scale) + map_x, (j * scale) + map_y);
                    bulut.BackColor = Color.Transparent;

                    panel1.Controls.Add(bulut);
                    labels_bulut[i, j] = bulut;
                }
            }

            Tuple<int, int> start = new Tuple<int, int>(map.baslangic[0], map.baslangic[1]);
            Tuple<int, int> end = new Tuple<int, int>(map.hedef[0], map.hedef[1]);



            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen kalem = new Pen(Color.White, 2);

            SolidBrush kalem2 = new SolidBrush(Color.Silver);


            int x, y;

            g.FillRectangle(kalem2, map_x, map_y, scale * map.map.GetLength(0), scale * map.map.GetLength(1));





            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {
                    kalem2.Color = Color.Black;

                    x = (i * scale) + map_x;
                    y = (j * scale) + map_y;

                    if (map.map[i, j] == 1)
                    {
                        g.FillRectangle(kalem2, x, y, scale, scale);
                    }
                    else if (map.map[i, j] == 8)
                    {
                        kalem2.Color = Color.Orange;
                        g.FillRectangle(kalem2, x, y, scale, scale);
                        kalem2.Color = Color.Black;
                    }
                    else if (map.map[i, j] == 9)
                    {
                        kalem2.Color = Color.Red;
                        g.FillRectangle(kalem2, x, y, scale, scale);
                        kalem2.Color = Color.Black;
                    }
                    else if (map.map[i, j] == 7)
                    {
                        kalem2.Color = Color.Blue;
                        g.FillRectangle(kalem2, x, y, scale, scale);
                        kalem2.Color = Color.Black;
                    }


                    g.DrawRectangle(kalem, x, y, scale, scale);


                }

            }

        }

        private void Bulutla_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < map.rowCount + 2; i++)
            {
                for (int j = 0; j < map.colCount + 2; j++)
                {

                    labels_bulut[i, j].BackColor = Color.DarkSlateGray; 

                }
            }
        }


        void bulut_kaldir(int x, int y)
        {


            labels_bulut[x, y - 1].Dispose();
            labels_bulut[x - 1, y].Dispose(); labels_bulut[x, y].Dispose(); labels_bulut[x + 1, y].Dispose();
            labels_bulut[x, y + 1].Dispose();

            if (x == map.hedef[0] && y + 1 == map.hedef[1] ||
                x + 1 == map.hedef[0] && y == map.hedef[1] ||
                x == map.hedef[0] && y - 1 == map.hedef[1] ||
                x - 1 == map.hedef[0] && y == map.hedef[1])
            {
                hedefe_ulasildi = true;
                panel1.Refresh();
                timer1.Stop();
            }

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            String dizin = Application.StartupPath + "\\ses.wav";
            ses.SoundLocation = dizin;
            ses.Play();

            saat.add_time();
            saatKontrol++;
            string ss = saat.dakika.ToString() + " dk " + saat.sn.ToString() + " sn";
            if(saatKontrol % 2 == 0)
            {
                label1.Text = ss;
                
            }
            

            Label baslangic = new Label();
            baslangic.Size = new Size(scale - 4, scale - 4);
            baslangic.Location = new Point((map.baslangic[0] * scale) + map_x + 2, (map.baslangic[1] * scale) + map_y + 2);
            baslangic.BackColor = Color.Orange;

            panel1.Controls.Add(baslangic);

            robot.Look(map);

            if (hedefe_ulasildi == false)
            {
                Label iz = new Label();
                iz.Size = new Size(scale - 6, scale - 6);
                iz.Location = new Point((path[x].Item1 * scale) + map_x + 3, (path[x].Item2 * scale) + map_y + 3);
                iz.BackColor = Color.LightGreen; // duvarlar

                panel1.Controls.Add(iz);

                if (path.Count - 1 <= x)
                {
                    timer1.Stop();
                    panel1.Refresh();

                }
                else
                {
                    x++;

                    label_robo.Location = new Point((path[x].Item1 * scale) + map_x + 2, (path[x].Item2 * scale) + map_y + 2);
                    bulut_kaldir(path[x].Item1, path[x].Item2);
                }
            }
            else
            {
                panel1.Refresh();
                timer1.Stop();
            }


        }

        private void button1_Click(object sender, EventArgs e)//basla
        {

            timer1.Interval = 500;

            if (timer1.Enabled == true)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }

        }

        private void Bitir_Click(object sender, EventArgs e)
        {
            

            timer1.Stop();

            while(hedefe_ulasildi==false)
            {
                saat.add_time();
                string ss = saat.dakika.ToString() + " dk " + saat.sn.ToString() + " sn";
                    label1.Text = ss;
              
                

                Label baslangic = new Label();
                baslangic.Size = new Size(scale - 4, scale - 4);
                baslangic.Location = new Point((map.baslangic[0] * scale) + map_x + 2, (map.baslangic[1] * scale) + map_y + 2);
                baslangic.BackColor = Color.Orange;

                panel1.Controls.Add(baslangic);

                robot.Look(map);

                if (hedefe_ulasildi == false)
                {
                    Label iz = new Label();
                    iz.Size = new Size(scale - 6, scale - 6);
                    iz.Location = new Point((path[x].Item1 * scale) + map_x + 3, (path[x].Item2 * scale) + map_y + 3);
                    iz.BackColor = Color.LightGreen; // duvarlar

                    panel1.Controls.Add(iz);

                    if (path.Count - 1 <= x)
                    {
                        timer1.Stop();
                        panel1.Refresh();

                    }
                    else
                    {
                        x++;

                        label_robo.Location = new Point((path[x].Item1 * scale) + map_x + 2, (path[x].Item2 * scale) + map_y + 2);
                        bulut_kaldir(path[x].Item1, path[x].Item2);
                    }
                }
                else
                {
                    panel1.Refresh();
                    timer1.Stop();
                }

            }


        }
    }
}
