using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace grafinho_1
{
    public partial class Form1 : Form
    {
        private List<vertice> Vertices = null;
        private List<canto> Cantos = null;

        private int i_global = 0;
        private int j_global = 0;

        private int global_hor = 0;
        private int global_ver = 0;

        public int global_count = 0;

        private List<gotardo> matrizGeral;
        private List<aresta> arestas;

        int soma_user = 0;
        int menor = 0;

        public Form1()
        {
            InitializeComponent();
            panelBtns.AutoScroll = true;

            txtHoriz.Text = "5";
            txtVertic.Text = "5";



        }

        private void btnGeraMatriz_Click(object sender, EventArgs e)
        {

            txtHoriz.Text = Regex.Replace(txtHoriz.Text, @"[^\d]", "");
            txtVertic.Text = Regex.Replace(txtVertic.Text, @"[^\d]", "");

            if (string.IsNullOrEmpty(txtHoriz.Text) || string.IsNullOrEmpty(txtVertic.Text))
            {
                MessageBox.Show("É necessário preencher os 2 campos sua TOPEIRA.", "AVISO", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            try
            {
                soma_user = 0;
                lblSomaUser.Text = "Soma caminho usuário: " + soma_user;


                var hor = int.Parse(txtHoriz.Text);
                var ver = int.Parse(txtVertic.Text);

                if (hor == 0 || ver == 0)
                {
                    MessageBox.Show("Sorry, não aceito 0.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (hor == 1 && ver == 1)
                {
                    MessageBox.Show("Matriz muito pequena!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                global_count = 0;
                i_global = 0;
                j_global = 0;

                global_hor = 0;
                global_ver = 0;

                global_hor = hor;
                global_ver = ver;

                panelBtns.Invalidate();


                Vertices = new List<vertice>();
                Cantos = new List<canto>();

                matrizGeral = new List<gotardo>();
                arestas = new List<aresta>();
                listBox1.Items.Clear();

                geraMatriz(hor, ver);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tenho um erro: " + ex.Message);
            }
        }

        private void geraMatriz(int i, int j)
        {


            panelBtns.Controls.Clear();
            var k = 0;
            var y = 0;
            var r = 0;
            var u = 2;
            var d = 2;
            for (int o = 0; o < i; o++)
            {
                for (int f = 0; f < j; f++)
                {
                    var btn = new Button();
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Location = new Point(k, y);
                    btn.Click += new EventHandler(btn_Click);
                    btn.Name = "btn" + r;
                    k += 65;
                    r++;
                    panelBtns.Controls.Add(btn);
                    matrizGeral.Add(new gotardo {i = o, j = f, namecomp = btn.Name});

                    Vertices.Add(new vertice(new Point(o, f), global_count));
                    global_count++;

                    if (o + f%2 == 0)
                    {
                        btn.Text = new Random().Next(1, d*2).ToString();
                        d = 2;
                        u += 2;
                    }
                    else
                    {
                        btn.Text = new Random().Next(1, u*2).ToString();
                        u = 2;
                        d += 2;
                    }
                    Thread.Sleep(3);



                }
                k = 0;
                y += 65;
            }



            foreach (var item in matrizGeral)
            {
                if (item.i + 1 > int.Parse(txtHoriz.Text))
                    continue;
                if (item.j + 1 > int.Parse(txtVertic.Text))
                    continue;

                var f1 = matrizGeral.Find(t => t.i == item.i + 1 && t.j == item.j) ??
                         new gotardo {i = -1, j = -1, namecomp = " NULO "};
                var f2 = matrizGeral.Find(t => t.i == item.i && t.j == item.j + 1) ??
                         new gotardo {i = -1, j = -1, namecomp = " NULO "};

                if (item.i == 0 && item.j == 0)
                    continue;

                arestas.Add(new aresta
                {
                    atual = new gotardo {i = item.i, j = item.j, namecomp = item.namecomp},
                    um = new gotardo {i = item.i + 1, j = item.j, namecomp = f1.namecomp},
                    dois = new gotardo {i = item.i, j = item.j + 1, namecomp = f2.namecomp},
                    custo = int.Parse(panelBtns.Controls[item.namecomp].Text)
                });


                if (item.namecomp != " NULO ")
                {
                    var from = item.i;
                    var to = item.j;
                    var weight = int.Parse(panelBtns.Controls[item.namecomp].Text);

                    Cantos.Add(new canto(from, to, weight));
                }
                if (f1.namecomp != " NULO ")
                {
                    var from = item.i + 1;
                    var to = item.j;
                    var weight = int.Parse(panelBtns.Controls[f1.namecomp].Text);

                    Cantos.Add(new canto(from, to, weight));
                }
                if (f2.namecomp != " NULO ")
                {
                    var from = item.i;
                    var to = item.j + 1;
                    var weight = int.Parse(panelBtns.Controls[f2.namecomp].Text);

                    Cantos.Add(new canto(from, to, weight));
                }

            }




            /* Create the array containing the adjacency matrix */
            double[,] G = new double[Vertices.Count, Vertices.Count];

            /* Set the connections and weights based on each edge in the collection */
            foreach (var canto in Cantos)
            {
                G[canto.de, canto.para] = canto.peso;
            }

            /* Runs dijkstra */
            /*try
            {
                Dijkstra dijk = new Dijkstra(G, 0);
                double[] dist = dijk.dist;
                int[] path = dijk.path;

              
                for (int x = 0; x < dist.Length; x++)
                {
                    if (dist[x] == Double.PositiveInfinity)
                        continue;

                    var asdasd = Vertices[x];
                    var found = matrizGeral.Find(p => p.i == asdasd.p.X && p.j == asdasd.p.Y);
                    if (found != null)
                        panelBtns.Controls[found.namecomp].BackColor = Color.Red;
                }
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }*/

            /*
            foreach (var item in arestas)
            {
                var find = panelBtns.Controls[item.um.namecomp];
                if (find == null)
                    continue;

                panelBtns.Controls[item.um.namecomp].BackColor = Color.Red;

                var find2 = panelBtns.Controls[item.dois.namecomp];
                if (find2 == null)
                    continue;
                panelBtns.Controls[item.dois.namecomp].BackColor = Color.Yellow;

                //Thread.Sleep(5000);
                break;
            }*/


            panelBtns.Controls[0].Text = "i";
            panelBtns.Controls[0].BackColor = Color.LightBlue;
            panelBtns.Controls[panelBtns.Controls.Count - 1].Text = "f";
            panelBtns.Controls[panelBtns.Controls.Count - 1].BackColor = Color.LightBlue;

            achaMenorCaminho(arestas);

            button1_Click(null, new EventArgs());

        }

        void btn_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;


            switch (b.Text)
            {
                case "i":
                    return;
                case "f":
                    return;
                /*default:
                    if (b.BackColor == Color.Green)
                        return;
                    break;*/
            }


            var find = matrizGeral.Find(p => p.namecomp == b.Name);
            if (find == null)
                return;

            MessageBox.Show(find.i + " " + find.j + " " + find.namecomp);


            var find2 = matrizGeral.Find(t => t.i == find.i - 1 && t.j == find.j);
            var find3 = matrizGeral.Find(t => t.i == find.i && t.j == find.j + 1);
            var find4 = matrizGeral.Find(t => t.i == find.i + 1 && t.j == find.j);
            var find5 = matrizGeral.Find(t => t.i == find.i && t.j == find.j - 1);

            if (find2 != null)
            {
                if (panelBtns.Controls[find2.namecomp].BackColor == Color.Green)
                {
                    b.BackColor = Color.Green;
                    marcaScore(b);
                    return;
                }
            }
            if (find3 != null)
            {
                if (panelBtns.Controls[find3.namecomp].BackColor == Color.Green)
                {
                    b.BackColor = Color.Green;
                    marcaScore(b);
                    return;
                }
            }
            if (find4 != null)
            {
                if (panelBtns.Controls[find4.namecomp].BackColor == Color.Green)
                {
                    b.BackColor = Color.Green;
                    marcaScore(b);
                    return;
                }
            }
            if (find5 != null)
            {
                if (panelBtns.Controls[find5.namecomp].BackColor == Color.Green)
                {
                    b.BackColor = Color.Green;
                    marcaScore(b);
                    return;
                }
            }

            if ((find.i != 0 || find.j != 1) && (find.i != 1 || find.j != 0))
                return;

            b.BackColor = Color.Green;
            marcaScore(b);
        }

        private void achaMenorCaminho(List<aresta> matriz)
        {
            foreach (var item in matriz)
                listBox1.Items.Add("Atual i: " + item.atual.i + " j: " + item.atual.j + " ( nome comp: " +
                                   item.atual.namecomp + ") @ " + "Prox lado: " + item.um.i + " j: " + item.um.j +
                                   " nome comp: " + item.um.namecomp + " @ " +
                                   "Prox baixo: " + item.dois.i + " j: " + item.dois.j + " nome comp: " +
                                   item.dois.namecomp + " ");
        }

        //private void findthefuckpath(gotardo )

        private void marcaScore(Button b)
        {
            soma_user += int.Parse(b.Text);
            lblSomaUser.Text = "Soma caminho usuário: " + soma_user;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var total = (global_hor*global_ver) - 1;
            for (int i = 0; i < global_hor; i++)
            {
                for (int j = 0; j < global_ver; j++)
                {
                    /*if (i == 0 && j == 0)
                        continue;
                        */
                    var found = matrizGeral.Find(p => p.i == i && p.j == j);
                    if (found != null)
                    {
                        Pen pen = new Pen(Color.Black, 3);
                        Graphics g = panelBtns.CreateGraphics();

                        var pFrom = new Point(panelBtns.Controls[found.namecomp].Location.X,
                            panelBtns.Controls[found.namecomp].Location.Y + 25);
                        var pTo = new Point(panelBtns.Controls[found.namecomp].Location.X - 20,
                            panelBtns.Controls[found.namecomp].Location.Y + 25);

                        var pFrom2 = new Point(panelBtns.Controls[found.namecomp].Location.X + 25,
                            panelBtns.Controls[found.namecomp].Location.Y + 25);
                        var pTo2 = new Point(panelBtns.Controls[found.namecomp].Location.X + 25,
                            panelBtns.Controls[found.namecomp].Location.Y - 25);

                        g.DrawLine(pen, pFrom2, pTo2);
                        g.DrawLine(pen, pFrom, pTo);

                        g.Dispose();

                         if (i_global == global_hor - 1 && j_global == global_ver - 1)
                            continue;
                            


                        
                        var find2 = matrizGeral.Find(t => t.i == i - 1 && t.j == j);
                        var find3 = matrizGeral.Find(t => t.i == i && t.j == j + 1);
                        var find4 = matrizGeral.Find(t => t.i == i + 1 && t.j == j);
                        var find5 = matrizGeral.Find(t => t.i == i && t.j == j - 1);
                        
                        if (find2 != null)
                        {
                            if (find2.namecomp == "btn0")
                                continue;
                            if (find2.namecomp == "btn" + total)
                                continue;

                            //panelBtns.Controls[find2.namecomp].BackColor = Color.Red;

                            var weight = int.Parse(panelBtns.Controls[find2.namecomp].Text);

                            Cantos.Add(new canto(find2.i, find2.j, weight));

                            Cantos.Add(new canto(find2.i - 1, find2.j, weight));
                            Cantos.Add(new canto(find2.i, find2.j + 1, weight));
                            Cantos.Add(new canto(find2.i + 1, find2.j, weight));
                            Cantos.Add(new canto(find2.i, find2.j - 1, weight));
                        }
                        
                        if (find3 != null)
                        {
                            if (find3.namecomp == "btn0")
                                continue;
                            if (find3.namecomp == "btn" + total)
                                continue;
                            //panelBtns.Controls[find3.namecomp].BackColor = Color.Red;

                            var weight = int.Parse(panelBtns.Controls[find3.namecomp].Text);

                            Cantos.Add(new canto(find3.i, find3.j, weight));

                            Cantos.Add(new canto(find3.i - 1, find3.j, weight));
                            Cantos.Add(new canto(find3.i, find3.j + 1, weight));
                            Cantos.Add(new canto(find3.i + 1, find3.j, weight));
                            Cantos.Add(new canto(find3.i, find3.j - 1, weight));
                        }
                        if (find4 != null)
                        {
                            if (find4.namecomp == "btn0")
                                continue;
                            if (find4.namecomp == "btn" + total)
                                continue;
                            // panelBtns.Controls[find4.namecomp].BackColor = Color.Red;

                            var weight = int.Parse(panelBtns.Controls[find4.namecomp].Text);

                            Cantos.Add(new canto(find4.i, find4.j, weight));

                            Cantos.Add(new canto(find4.i - 1, find4.j, weight));
                            Cantos.Add(new canto(find4.i, find4.j + 1, weight));
                            Cantos.Add(new canto(find4.i + 1, find4.j, weight));
                            Cantos.Add(new canto(find4.i, find4.j - 1, weight));
                        }
                        
                        if (find5 != null)
                        {
                            if (find5.namecomp == "btn0")
                                continue;
                            if (find5.namecomp == "btn" + total)
                                continue;
                            //panelBtns.Controls[find5.namecomp].BackColor = Color.Red;

                            var weight = int.Parse(panelBtns.Controls[find5.namecomp].Text);

                            Cantos.Add(new canto(find5.i, find5.j, weight));

                            Cantos.Add(new canto(find5.i - 1, find5.j, weight));
                            Cantos.Add(new canto(find5.i, find5.j + 1, weight));
                            Cantos.Add(new canto(find5.i + 1, find5.j, weight));
                            Cantos.Add(new canto(find5.i, find5.j - 1, weight));
                        }
                        
                       
                            

                    }
                    


                }

                //MessageBox.Show(i.ToString());
            }

            double[,] G = new double[Vertices.Count, Vertices.Count];

            try
            {

                foreach (var canto in Cantos)
                {
                    if (canto.de < 0)
                        continue;
                    if (canto.para < 0)
                        continue;

                    G[canto.de, canto.para] = canto.peso;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            /* Runs dijkstra */
            try
            {
                Dijkstra dijk = new Dijkstra(G, 0);
                double[] dist = dijk.dist;
                int[] path = dijk.path;

              
                for (int x = 0; x < dist.Length; x++)
                {
                    if (dist[x] == Double.PositiveInfinity)
                        continue;

                    var asdasd = Vertices[x];
                    var found = matrizGeral.Find(p => p.i == asdasd.p.X && p.j == asdasd.p.Y);

                    if (asdasd.p.X == 0 && asdasd.p.Y == 0)
                        continue;
                    if (found != null)
                        panelBtns.Controls[found.namecomp].BackColor = Color.Red;
                }
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }

            /*
            for (int i = 0; i <= global_hor*global_ver; i++)
            {
                if (i_global == 0 && j_global == 0)
                {
                    //i_global++;
                    j_global++;
                    continue;
                }


                if (j_global == global_hor)
                {
                    j_global = 0;
                    i_global++;
                }

                var found = matrizGeral.Find(p => p.i == i_global && p.j == j_global);
                if (found != null)
                {
                    Pen pen = new Pen(Color.Black, 3);
                    Graphics g = panelBtns.CreateGraphics();

                    var pFrom = new Point(panelBtns.Controls[found.namecomp].Location.X,panelBtns.Controls[found.namecomp].Location.Y + 25);
                    var pTo = new Point(panelBtns.Controls[found.namecomp].Location.X - 20,panelBtns.Controls[found.namecomp].Location.Y + 25);

                    
                    g.DrawLine(pen, pFrom, pTo);

                    g.Dispose();

                    if (i_global == global_hor - 1 && j_global == global_ver - 1)
                        continue;
                    panelBtns.Controls[found.namecomp].BackColor = Color.Red;
                }

                //i_global++;
                j_global++;
            }

            i_global = 0;
            j_global = 0;

            for (int i = 0; i <= global_hor * global_ver; i++)
            {
                if (i_global == 0 && j_global == 0)
                {
                    i_global++;
                    //j_global++;
                    continue;
                }


                if (i_global == global_ver)
                {
                    i_global = 0;
                    j_global++;
                }

                var found = matrizGeral.Find(p => p.i == i_global && p.j == j_global);
                if (found != null)
                {
                    Pen pen = new Pen(Color.Black, 3);
                    Graphics g = panelBtns.CreateGraphics();

                    var pFrom = new Point(panelBtns.Controls[found.namecomp].Location.X +25,panelBtns.Controls[found.namecomp].Location.Y +25);
                    var pTo = new Point(panelBtns.Controls[found.namecomp].Location.X + 25, panelBtns.Controls[found.namecomp].Location.Y - 25);


                    g.DrawLine(pen, pFrom, pTo);

                    g.Dispose();

                    if (i_global == global_hor - 1 && j_global == global_ver - 1)
                        continue;
                    panelBtns.Controls[found.namecomp].BackColor = Color.Red;
                }

                i_global++;
                //j_global++;
            }*/

        }
    }

    public class gotardo
    {
        public int i { get; set; }
        public int j { get; set; }
        public string namecomp { get; set; }
    }
    
    public class aresta
    { 
        public gotardo atual { get; set; }

        public gotardo um { get; set; }

        public gotardo dois { get; set; }

        public int dist { get; set; }

        public int custo { get; set; }
    }


}
