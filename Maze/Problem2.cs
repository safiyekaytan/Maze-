using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class Problem2 : Form
    {
        Uygulama saat;

        public int saatKontrol = 0;
        Izgara labirent;
        int map_x = 20;
        int map_y = 20;
        public SoundPlayer ses = new SoundPlayer();
        Label label_robo;
        Label[,] labels_bulut;
        int scale;
        int boyut;
        public int f = 0;
        public int l = 0;
        public int temp = 0;
        public bool kontrolKonum = false;
        int[,] harita;


        public Problem2()
        {
            BackColor = Color.Black;
            do
            {
                boyut = Convert.ToInt32(Interaction.InputBox("Boyutu giriniz :", "Bilgi Girişi", "5", 600, 400));

            } while (boyut < 5);

            scale = 400 / boyut;


            if (boyut % 2 == 0)
                boyut--;


            labels_bulut = new Label[boyut, boyut];
            labirent = new Izgara(boyut);



            Robot2 robot = new Robot2(labirent.map, boyut);

            harita = robot.getHarita(labirent.map, boyut);


            label_robo = new Label();
            label_robo.Size = new Size(scale - 6, scale - 6);
            label_robo.Location = new Point(map_x + 3, map_y + 3);
            label_robo.BackColor = Color.Blue; // duvarlar


            InitializeComponent();

            panel1.Controls.Add(label_robo);

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    Label bulut = new Label();
                    bulut.Size = new Size(scale - 1, scale - 1);
                    bulut.Location = new Point((i * scale) + map_x, (j * scale) + map_y);
                    bulut.BackColor = Color.Transparent;

                    panel1.Controls.Add(bulut);
                    labels_bulut[i, j] = bulut;
                }
            }
            saat = new Uygulama();


            string ss = saat.dakika.ToString() + " dk " + saat.sn.ToString() + " sn";


        }



        private void Bulutla_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    labels_bulut[i, j].BackColor = Color.DarkSlateGray;

                }
            }
            labels_bulut[0, 0].Dispose();
            labels_bulut[0, 1].Dispose();



        }

        void bulut_kaldir(int x, int y)
        {

            if (x > 0 && y > 0)
            {

                labels_bulut[x, y - 1].Dispose();
                labels_bulut[x - 1, y].Dispose(); labels_bulut[x, y].Dispose(); labels_bulut[x + 1, y].Dispose();
                labels_bulut[x, y + 1].Dispose();

                if (x == boyut - 2 && y == boyut - 2)
                {
                    timer1.Stop();
                }
            }

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            String dizin = Application.StartupPath + "\\ses.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            map_x = 23;
            map_y = 23;
            saat.add_time();
            saatKontrol++;
            string ss = saat.dakika.ToString() + " dk " + saat.sn.ToString() + " sn";

            if (saatKontrol % 2 == 0)
            {

                label1.Text = ss;

            }

            Label iz = new Label();
            iz.Size = new Size(scale - 6, scale - 6);
            iz.Location = new Point((f * scale) + map_x, (l * scale) + map_y);
            iz.BackColor = Color.LightGreen; // duvarlar

            panel1.Controls.Add(iz);

            bulut_kaldir(f, l);

            if (kontrolKonum == false)
            {

                if (harita[f + 1, l] == 8)
                {
                    label_robo.Location = new Point(((f + 1) * scale) + map_x, (l * scale) + map_y);
                    harita[f + 1, l] = 9;
                    f++;
                }
                else if (harita[f, l + 1] == 8)
                {
                    label_robo.Location = new Point((f * scale) + map_x, ((l + 1) * scale) + map_y);
                    harita[f, l + 1] = 9;
                    l++;
                }
                else if (harita[f - 1, l] == 8)
                {
                    label_robo.Location = new Point(((f - 1) * scale) + map_x, (l * scale) + map_y);
                    harita[f - 1, l] = 9;
                    f--;
                }
                else if (harita[f, l - 1] == 8)
                {
                    label_robo.Location = new Point((f * scale) + map_x, ((l - 1) * scale) + map_y);
                    harita[f, l - 1] = 9;
                    l--;
                }
            }
            if (label_robo.Location.X == ((boyut - 2) * scale) + map_x && label_robo.Location.Y == ((boyut - 1) * scale) + map_y)
            {
                kontrolKonum = true;
                temp++;
            }
            if (temp == 2)
            {
                timer1.Stop();
                DialogResult result1 = MessageBox.Show(" Çıkışa Ulaştınız!!! ",
                "Uygulama Çıkış", MessageBoxButtons.OK);
                if (result1 == DialogResult.Yes)
                {
                    //Hide();
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen kalem = new Pen(Color.Black, 2);

            SolidBrush kalem2 = new SolidBrush(Color.Gray);
            int x, y;

            g.FillRectangle(kalem2, map_x, map_y, scale * labirent.map.GetLength(0), scale * labirent.map.GetLength(1));

            for (int i = 0; i < labirent.map.GetLength(0); i++)
            {
                for (int j = 0; j < labirent.map.GetLength(1); j++)
                {
                    x = (i * scale) + map_x;
                    y = (j * scale) + map_y;

                    g.DrawRectangle(kalem, x, y, scale, scale);

                    kalem.Color = Color.White;

                    g.DrawRectangle(kalem, x, y, scale, scale);

                    if (labirent.map[i, j] == 1)
                    {
                        g.FillRectangle(kalem2, x, y, scale, scale);
                        g.DrawRectangle(kalem, x, y, scale, scale);

                    }



                    kalem2.Color = Color.Black;
                    kalem.Color = Color.Black;

                }
            }
        }

        private void Basla_Click(object sender, EventArgs e)
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
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    labels_bulut[i, j].Dispose();

                }
            }
            while (kontrolKonum == false)
            {
                map_x = 23;
                map_y = 23;
                saat.add_time();

                string ss = saat.dakika.ToString() + " dk " + saat.sn.ToString() + " sn";
                label1.Text = ss;



                Label iz = new Label();
                iz.Size = new Size(scale - 6, scale - 6);
                iz.Location = new Point((f * scale) + map_x, (l * scale) + map_y);
                iz.BackColor = Color.LightGreen; // duvarlar

                panel1.Controls.Add(iz);

                if (kontrolKonum == false)
                {

                    if (harita[f + 1, l] == 8)
                    {
                        label_robo.Location = new Point(((f + 1) * scale) + map_x, (l * scale) + map_y);
                        harita[f + 1, l] = 9;
                        f++;
                    }
                    else if (harita[f, l + 1] == 8)
                    {
                        label_robo.Location = new Point((f * scale) + map_x, ((l + 1) * scale) + map_y);
                        harita[f, l + 1] = 9;
                        l++;
                    }
                    else if (harita[f - 1, l] == 8)
                    {
                        label_robo.Location = new Point(((f - 1) * scale) + map_x, (l * scale) + map_y);
                        harita[f - 1, l] = 9;
                        f--;
                    }
                    else if (harita[f, l - 1] == 8)
                    {
                        label_robo.Location = new Point((f * scale) + map_x, ((l - 1) * scale) + map_y);
                        harita[f, l - 1] = 9;
                        l--;
                    }
                }
                if (label_robo.Location.X == ((boyut - 2) * scale) + map_x && label_robo.Location.Y == ((boyut - 1) * scale) + map_y)
                {
                    kontrolKonum = true;
                    temp++;
                }
                if (temp == 2)
                {
                    timer1.Stop();
                    DialogResult result1 = MessageBox.Show(" Çıkışa Ulaştınız!!! ",
                    "Uygulama Çıkış", MessageBoxButtons.OK);
                    if (result1 == DialogResult.Yes)
                    {
                        //Hide();
                    }
                }
            }
        }
    }
}
