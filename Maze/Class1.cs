using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;


namespace Maze
{

    using System;
    using System.Data;
    using System.Drawing;
    using System.Reflection.Emit;
    using System.Security.AccessControl;
    using System.Threading;

    class Robot1
    {

        public int row;
        public int col;
        public int view_range;
        public Izgara robot_look;
        public List<(int, int)> visited;
        public Queue<(int, int)> tail;

        public Robot1(int row, int col, int rowCount, int colCount)
        {
            this.row = row;
            this.col = col;

            robot_look = new Izgara(rowCount, colCount); // boş map
        }



        public List<Tuple<int, int>> hareket(Izgara main_map)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();

            stack.Push(new Tuple<int, int>(row, col));

            while (stack.Count > 0)
            {
                Tuple<int, int> currPos = stack.Pop();
                int currRow = currPos.Item1;
                int currCol = currPos.Item2;

                if (main_map.map[currRow, currCol] == 9)
                {
                    row = currRow;
                    col = currCol;
                    path.Add(currPos);
                    return path;
                }

                if (!visited.Contains(currPos))
                {
                    visited.Add(currPos);
                    path.Add(currPos);

                    if (currRow > 0 && main_map.map[currRow - 1, currCol] != 1 && !visited.Contains(new Tuple<int, int>(currRow - 1, currCol)))
                    {
                        stack.Push(new Tuple<int, int>(currRow - 1, currCol));
                    }

                    if (currCol > 0 && main_map.map[currRow, currCol - 1] != 1 && !visited.Contains(new Tuple<int, int>(currRow, currCol - 1)))
                    {
                        stack.Push(new Tuple<int, int>(currRow, currCol - 1));
                    }

                    if (currRow < main_map.rowCount - 1 && main_map.map[currRow + 1, currCol] != 1 && !visited.Contains(new Tuple<int, int>(currRow + 1, currCol)))
                    {
                        stack.Push(new Tuple<int, int>(currRow + 1, currCol));
                    }

                    if (currCol < main_map.colCount - 1 && main_map.map[currRow, currCol + 1] != 1 && !visited.Contains(new Tuple<int, int>(currRow, currCol + 1)))
                    {
                        stack.Push(new Tuple<int, int>(currRow, currCol + 1));
                    }
                }
            }

            return path;
        }

        public void Look(Izgara main_map)
        {
            int x = row - 1;
            int y = col - 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (x + i >= 0 && x + i < main_map.rowCount && y + j >= 0 && y + j < main_map.colCount)
                    {
                        robot_look.map[x + i, y + j] = main_map.map[x + i, y + j];

                    }
                }
            }
        }
    }

    public class Robot2
    {
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        bool kontrol1 = false;
        bool kontrol2 = false;
        bool kontrol3 = false;
        public int[,] maze;
        public int size;
        public Stack<int> xStack = new Stack<int>();
        public Stack<int> yStack = new Stack<int>();
        public int[,] labirent;



        public Robot2(int[,] maze, int size)
        {
            this.maze = maze;
            this.size = size;
            getHarita(maze, size);
        }
        public int[,] getHarita(int[,] icMatris, int boyut) //içerdeki matrisi parametre olarak ver
        {

            return getRobot(icMatris, boyut, 0, 1);
        }

        int[,] getRobot(int[,] robotHareketleri, int mazeSize, int aps, int ord)
        {
            kontrol1 = false;
            kontrol2 = false;
            robotHareketleri[aps, ord] = 8; //robotun bulundugu yerler 8 olsun. şu an ilk adımda 1,1 konumu = 8 oldu

            xStack.Push(aps); //0 ekle
            yStack.Push(ord); //1 ekle

            if (robotHareketleri[mazeSize - 2, mazeSize - 1] != 8)           // çıkış noktasına gelmediyse devam et
            {
                if (aps < mazeSize - 1 && ord < mazeSize - 1)
                {
                    kontrol3 = false;
                    if (robotHareketleri[aps + 1, ord] == 0 && a != 2) //sağı boş bir yolsa
                    {
                        a = 1;
                        b = 0;
                        c = 0;
                        d = 0;
                        kontrol3 = true;
                        return getRobot(robotHareketleri, mazeSize, aps + 1, ord);
                    }
                    else if (robotHareketleri[aps, ord + 1] == 0 && b != 2) //altı boş bir yolsa
                    {
                        a = 0;
                        b = 1;
                        c = 0;
                        d = 0;
                        kontrol3 = true;
                        return getRobot(robotHareketleri, mazeSize, aps, ord + 1);
                    }

                    else if (aps > 0 && kontrol2 == false)
                    {
                        kontrol2 = true;
                        if (robotHareketleri[aps - 1, ord] == 0 && c != 2) // solu boş bir yolsa
                        {
                            a = 0;
                            b = 0;
                            c = 1;
                            d = 0;
                            kontrol3 = true;
                            return getRobot(robotHareketleri, mazeSize, aps - 1, ord);
                        }
                    }
                    if (kontrol3 == false)
                    {
                        if (ord > 0 && kontrol1 == false)
                        {
                            kontrol1 = true;
                            if (robotHareketleri[aps, ord - 1] == 0 && d != 2) // üstü boş bir yolsa
                            {
                                a = 0;
                                b = 0;
                                c = 0;
                                d = 1;
                                kontrol3 = true;
                                return getRobot(robotHareketleri, mazeSize, aps, ord - 1);
                            }
                        }
                    }

                    if (kontrol3 == false) //gidilecek hiçbir yer yoksa
                    {
                        // !!!!!!!!!!!!!!!!!!!! cevre de full ziyret edilmişse patlıyor, üstte sadece 0 ise gir dedin çünkü  !!!!!!!!!!!!!!!!!
                        if (a != 0)
                        {
                            a = 2;
                        }
                        else if (b != 0)
                        {
                            b = 2;
                        }
                        else if (c != 0)
                        {
                            c = 2;
                        }
                        else if (d != 0)
                        {
                            d = 2;
                        }
                        aps = xStack.Peek();
                        ord = yStack.Peek();
                        robotHareketleri[aps, ord] = 0;
                        xStack.Pop(); // indisi çıkardın
                        yStack.Pop(); // indisi çıkardın

                        aps = xStack.Peek();
                        ord = yStack.Peek();
                        return getRobot(robotHareketleri, mazeSize, aps, ord);
                    }
                }
            }
            return robotHareketleri;
        }

    }



    class Izgara
    {
        public int[,] map;

        public string url;

        public int[] baslangic;//baslangic -1 degeri verilir
        public int[] hedef;//hedef 9 degeri verilir
                           //5 degeri atanmamis
        public List<int[]> way_list = new List<int[]>();// 0 yani yolların listesi problem 1 in hedef ve baslangic secimi icin

        public int rowCount;
        public int colCount;


        private Random randomSayi;




        /*
            ------------------------------------------------------------------
            rastgele labirent üretme

        */


        private int rows_cols_count;
        public Izgara(int rows_cols_count)
        {

            this.rows_cols_count = rows_cols_count;
            map = new int[rows_cols_count, rows_cols_count];
            randomSayi = new Random();
            GenerateMaze();
        }

        private void GenerateMaze()
        {

            for (int i = 0; i < rows_cols_count; i++)
            {
                for (int j = 0; j < rows_cols_count; j++)
                {
                    map[i, j] = 1;
                }
            }


            int startRow = 1;
            int startCol = 1;
            CreateRandomMaze(startRow, startCol);

            map[startRow, startCol] = 0;
            map[startRow, startCol - 1] = 0;
            map[rows_cols_count - 2, rows_cols_count - 1] = 0;
            map[rows_cols_count - 1, rows_cols_count - 1] = 0;

        }

        private void CreateRandomMaze(int rows, int cols)
        {
            map[rows, cols] = 0;

            List<int> yonler = new List<int> { 1, 2, 3, 4 };
            Rastgele(yonler);

            foreach (int yon in yonler)
            {
                int nRow = rows;
                int nCol = cols;
                switch (yon)
                {
                    case 1:
                        nRow -= 2;
                        break;
                    case 2:
                        nCol += 2;
                        break;
                    case 3:
                        nRow += 2;
                        break;
                    case 4:
                        nCol -= 2;
                        break;


                }

                if (nRow >= 0 && nRow < rows_cols_count && nCol >= 0 && nCol < rows_cols_count && map[nRow, nCol] == 1)
                {
                    int satitOrt = (nRow + rows) / 2;
                    int sutunOrt = (nCol + cols) / 2;
                    map[satitOrt, sutunOrt] = 0;
                    CreateRandomMaze(nRow, nCol);
                }
            }
        }

        private void Rastgele(List<int> yonlerList)
        {
            int m = yonlerList.Count;

            while (m > 1)
            {
                m = m - 1;
                int n = randomSayi.Next(m + 1);
                (yonlerList[m], yonlerList[n]) = (yonlerList[n], yonlerList[m]);
            }
        }

        /*
            ------------------------------------------------------------------
            url den labirent üretme

        */


        public Izgara(string Url)
        {
            this.url = Url;
            GenerateMap();

        }

        private void GenerateMap()
        {

            WebClient client = new WebClient();



            string inputString = client.DownloadString(url);

            string[] rows = inputString.Split('\n');

            rowCount = rows.Length;
            colCount = rows[0].Length;

            int[,] matrix = new int[rowCount, colCount];


            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = int.Parse(rows[i][j].ToString());
                }
            }

            map = new int[rowCount + 2, colCount + 2];



            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1 || j == 0 || j == map.GetLength(1) - 1) // kenarları kontrol et
                        map[i, j] = 1; // kenarlara 1                     
                    else
                        map[i, j] = matrix[i - 1, j - 1];
                }
            }

            Random rastgele = new Random();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    if (map[i, j] == 2)
                    {
                        int secim = rastgele.Next(1, 6);


                        Engel engel2 = new Engel(2);
                        engel2.TipBelirle(secim);

                        map[i, j] = engel2.sekil[0, 0];
                        map[i, j + 1] = engel2.sekil[0, 1];
                        map[i + 1, j] = engel2.sekil[1, 0];
                        map[i + 1, j + 1] = engel2.sekil[1, 1];


                    }
                    else if (map[i, j] == 3)
                    {
                        int secim = rastgele.Next(1, 8);

                        Engel engel3 = new Engel(3);
                        engel3.TipBelirle(secim);

                        map[i, j] = engel3.sekil[0, 0];
                        map[i, j + 1] = engel3.sekil[0, 1];
                        map[i, j + 2] = engel3.sekil[0, 2];
                        map[i + 1, j] = engel3.sekil[1, 0];
                        map[i + 1, j + 1] = engel3.sekil[1, 1];
                        map[i + 1, j + 2] = engel3.sekil[1, 2];
                        map[i + 2, j] = engel3.sekil[2, 0];
                        map[i + 2, j + 1] = engel3.sekil[2, 1];
                        map[i + 2, j + 2] = engel3.sekil[2, 2];

                    }


                    if (map[i, j] == 0)
                    {
                        int[] tmp = new int[2];

                        tmp[0] = i;
                        tmp[1] = j;

                        way_list.Add(tmp);
                    }
                }
            }


            // Matrisi yazdırma işlemi
            GenerateIO();




        }

        public void GenerateIO()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (map[i, j] == -1 || map[i, j] == 9)
                        map[i, j] = 0;
                }
            }

            Random random = new Random();
            int tmp_random = random.Next(0, way_list.Count);

            baslangic = way_list[tmp_random];
            way_list.RemoveAt(tmp_random);

            hedef = way_list[random.Next(0, way_list.Count)];
            way_list.Add(baslangic);


            map[baslangic[0], baslangic[1]] = -1;
            map[hedef[0], hedef[1]] = 9;



        }



        /*
            ------------------------------------------------------------------
             Bos izgara üretme

        */


        public Izgara(int x_count, int y_count)
        {
            rowCount = x_count;
            colCount = y_count;

            map = new int[x_count, y_count];


            for (int i = 0; i < x_count; i++)
            {
                for (int j = 0; j < y_count; j++)
                {
                    map[i, j] = 5;

                }
            }
        }
    }

    class Engel
    {
        public int tip;
        public int[,] sekil;

        public Engel(int tip)
        {
            this.tip = tip;
        }


        public void TipBelirle(int secilenSayi)
        {
            if (tip == 2)
            {
                sekil = new int[tip, tip];
                switch (secilenSayi)
                {
                    case 1:
                        sekil = new int[,] { { 1, 1 },
                                             { 1, 1 } };

                        break;
                    case 2:
                        sekil = new int[,] { { 1, 1 },
                                             { 0, 0 } };

                        break;
                    case 3:
                        sekil = new int[,] { { 0, 1 },
                                             { 0, 1 } };
                        break;
                    case 4:
                        sekil = new int[,] { { 1, 1 },
                                             { 1, 0 } };
                        break;
                    case 5:
                        sekil = new int[,] { { 0, 1 },
                                             { 1, 1 } };
                        break;
                    default:
                        break;
                }
            }
            else if (tip == 3)
            {

                switch (secilenSayi)
                {
                    case 1:

                        sekil = new int[,] { { 0, 1, 0 },
                                             { 0, 1, 0 },
                                             { 0, 1, 0 } };

                        break;
                    case 2:

                        sekil = new int[,] { { 0, 0, 0 },
                                             { 1, 1, 1 },
                                             { 0, 0, 0 } };

                        break;
                    case 3:

                        sekil = new int[,] { { 1, 1, 1 },
                                             { 1, 0, 0 },
                                             { 1, 0, 0 } };

                        break;
                    case 4:

                        sekil = new int[,] { { 0, 0, 1 },
                                             { 0, 0, 1 },
                                             { 1, 1, 1 } };

                        break;
                    case 5:

                        sekil = new int[,] { { 1, 1, 1 },
                                             { 1, 1, 1 },
                                             { 1, 1, 1 } };

                        break;
                    case 6:

                        sekil = new int[,] { { 0, 0, 1 },
                                             { 0, 1, 1 },
                                             { 0, 0, 1 } };

                        break;
                    case 7:

                        sekil = new int[,] { { 1, 0, 0 },
                                             { 1, 1, 0 },
                                             { 1, 0, 0 } };

                        break;
                    default:
                        break;
                }
            }
        }

    }

    class Uygulama
    {

        public int dakika;
        public double sn;
        public Uygulama()
        {
            dakika = 0;
            sn = 0;
        }

        public void add_time()
        {
            sn += 0.5;

            if (sn >= 60)
            {
                dakika++;
                sn = 0;
            }
        }

    }


}

