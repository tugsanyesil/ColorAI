using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using static ColorAI.Exts;

namespace ColorAI
{
    public partial class ColorAIForm : Form
    {
        public ColorAIForm()
        {
            InitializeComponent();
        }

        Bitmap ColorMap;
        Brain Brain;
        int Sample = 2;
        int SampleLength = 4;

        private void Form1_Load(object sender, EventArgs e)
        {
            ColorMap = GetImage(Sample);
            PictureBox1_Update();
            panel1.BackColor = Color.Black;
            richTextBox1.Text = "";
            Items = new List<ListBoxItem>(); textBox1.Text = Sample.ToString(); LoadButton_Click(new object(), EventArgs.Empty);
            comboBox1.Items.AddRange(Enum.GetNames(typeof(Colors)));
            comboBox1.SelectedIndex = 0;
            Brain = new Brain(0.36f, new int[] { 4, 20, 10, 5 });
        }

        private void Train_Click(object sender, EventArgs e)
        {
            Brain.Revolution(ClickPoint.PointToKnowledge(), ((Colors)comboBox1.SelectedIndex).ColorEnumToKnowledge());
            Train_Update();
        }

        private void TrainWithSamples_Click(object sender, EventArgs e)
        {
            var Ps = new List<Point>(Items.Select(i => i.Point));
            var Cs = new List<Colors>(Items.Select(i => i.Color));

            Perceptions = Ps.ConvertAll(P => new Point(P.X, P.Y).PointToKnowledge()).ToArray();
            HiddenTruths = Cs.ConvertAll(C => C.ColorEnumToKnowledge()).ToArray();
            TrainWithSamplesButton.BackColor = (TrainTimer.Enabled = !TrainTimer.Enabled) ? SystemColors.ButtonHighlight : SystemColors.ButtonFace;
            //Train_Update();
        }

        int TrainIteration = 0;
        float J = 0f;
        float mJ = 0f;//max index cost
        float[][] Perceptions;
        float[][] HiddenTruths;
        private void TrainTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Perceptions.Length; i++)
            {
                Brain.Revolution(Perceptions[i], HiddenTruths[i]);
                var iterlim = 0;
                while (MaxIndex(Brain.UseIt(Perceptions[i])) != MaxIndex(HiddenTruths[i]) && iterlim++ < 3) { Brain.Revolution(Perceptions[i], HiddenTruths[i]); }
            }
            J = 0;
            mJ = 0;
            if (++TrainIteration % 20 == 0)
            {
                for (int i = 0; i < Perceptions.Length; i++)
                {
                    var b = Brain.UseIt(Perceptions[i]);
                    J += HiddenTruths[i].Subtract(b).Sum(f => Math.Abs(f));
                    mJ += Convert.ToInt32(MaxIndex(b) != MaxIndex(HiddenTruths[i]));
                }
                J /= Perceptions.Length * Brain.Neurons.Last();
                mJ /= Perceptions.Length;
                chart1.Series[0].Points.AddXY(chart1.Series[0].Points.Count, J);
                chart1.Series[1].Points.AddXY(chart1.Series[1].Points.Count, mJ);
                if (chart1.Series[1].Points.Count >= 100) { chart1.Series[0].Points.Clear(); chart1.Series[1].Points.Clear(); }
                label2.Text = "Iteration : " + TrainIteration + "          J : " + J + "          mJ:" + mJ;
                richTextBox1.Text = Brain.ToString();
                Train_Update();
            }
        }

        void Train_Update()
        {
            Bitmap Bitmap = new Bitmap(256, 256);
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    Bitmap.SetPixel(i, j, Color.FromName((Brain.UseIt(new Point(i, j).PointToKnowledge()).KnowledgeToColorEnum().ToString())));
                }
            }
            pictureBox2.Image = Bitmap;
        }

        private void Q_Click(object sender, EventArgs e)
        {
            Brain.UseIt(ClickPoint.PointToKnowledge());
            string s = "";
            for (int y = 0; y < Brain.Y.Length; y++)
            {
                s += 100 * Brain.Y[y] + "% " + ((Colors)y) + "\n";
            }

            //s += "\n\n" + Brain.ToString();

            richTextBox1.Text = s;
        }

        List<ListBoxItem> Items = new List<ListBoxItem>();
        public class ListBoxItem
        {
            public Point Point;
            public Colors Color;

            public ListBoxItem() : this(Point.Empty, Colors.Black) { }

            public ListBoxItem(Point Point, Colors Color)
            {
                this.Point = Point;
                this.Color = Color;
            }

            public override string ToString()
            {
                return Point.ToString() + " " + Color.ToString();
            }
        }

        private void AddSample_Click(object sender, EventArgs e)
        {
            Items.Add(new ListBoxItem(ClickPoint, (Colors)comboBox1.SelectedIndex));
            listBox1.Items.Add(Items[Items.Count - 1]);
            PictureBox1_Update();
        }

        private void DeleteSample_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var P = Items[listBox1.SelectedIndex].Point;
                panel1.BackColor = ColorMap.GetPixel(P.X, P.Y);
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            PictureBox1_Update();
        }

        void PictureBox1_Update()
        {
            Bitmap Bitmap = (Bitmap)ColorMap.Clone();

            int PointSize = 10;
            Bitmap PointBitmap;
            PointBitmap = new Bitmap(PointSize, PointSize);
            for (int i = 0; i < PointSize; i++)
            {
                for (int j = 0; j < PointSize; j++)
                {
                    Point Coor = new Point(i - (PointSize + 1) / 2, j - (PointSize + 1) / 2);
                    float R = (float)Math.Sqrt(Coor.X * Coor.X + Coor.Y * Coor.Y);
                    PointBitmap.SetPixel(i, j, R > 1 ? R > 2 ? R > 3 ? Color.Transparent : Color.White : Color.Green : Color.Black);
                }
            }

            using (var Graphics = System.Drawing.Graphics.FromImage(Bitmap))
            {
                Items.ForEach(i => Graphics.DrawImage(PointBitmap, i.Point.X - (PointSize + 1) / 2, i.Point.Y - (PointSize + 1) / 2));
            }
            pictureBox1.Image = Bitmap;

            List<ListBoxItem> OldItems = new List<ListBoxItem>(); OldItems.AddRange(Items);
            List<ListBoxItem> NewItems = new List<ListBoxItem>();
            while (OldItems.Count > 0)
            {
                for (int c = 0; c < Enum.GetNames(typeof(Colors)).Length; c++)
                {
                    var f = OldItems.Find(i => i.Color == (Colors)c);
                    if (f != null) { NewItems.Add(f); OldItems.Remove(f); }
                }
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(NewItems.ToArray());
        }

        Point ClickPoint = Point.Empty;
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Text = e.Location.ToString();
            ClickPoint = e.Location;
            panel1.BackColor = ColorMap.GetPixel(e.Location.X, e.Location.Y);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out int Set))
            {
                using (XmlWriter XmlWriter = XmlWriter.Create("Samples_" + Set + ".xml"))
                {
                    new XmlSerializer(typeof(List<ListBoxItem>)).Serialize(XmlWriter, Items);
                }

                PictureBox1_Update();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out int Set) && File.Exists("Samples_" + Set + ".xml"))
            {
                using (XmlReader XmlReader = XmlReader.Create("Samples_" + Set + ".xml"))
                {
                    Items = (List<ListBoxItem>)new XmlSerializer(typeof(List<ListBoxItem>)).Deserialize(XmlReader);
                }
                listBox1.Items.AddRange(Items.ToArray());

                PictureBox1_Update();
            }
        }

        private void SaveBrainButton_Click(object sender, EventArgs e)
        {
            ((BrainData)Brain).Save("Brain.xml");
            Brain = Exts.Load<BrainData>("Brain.xml");
            richTextBox1.Text = ((BrainData)Brain).Ws[0].ToMatrix().ToCSharp();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var b = int.TryParse(textBox1.Text, out int result);
            if (b)
            {
                if (0 < result && result <= SampleLength) { Sample = result; }
                Form1_Load(new object(), EventArgs.Empty);
            }
        }
    }

    public static class Exts
    {
        public static int MaxIndex(float[] Array) => Array.Select((value, index) => new { Value = value, Index = index }).Aggregate((a, b) => (a.Value > b.Value) ? a : b).Index;
        public static float[] PointToKnowledge(this Point P) => new float[] { P.X / 255f, P.Y / 255f, (P.X / 255f) * (P.X / 255f), (P.Y / 255f) * (P.Y / 255f) };
        public static float[] ColorEnumToKnowledge(this Colors C) { var ret = new float[Enum.GetNames(typeof(Colors)).Length]; ret[(int)C] = 1f; return ret; }
        public static Colors KnowledgeToColorEnum(this float[] f) { f.Max(out int i); return (Colors)i; }
        public enum Colors { Black, Red, Blue, Pink, Purple }

        public static Bitmap GetImage(int Sample)
        {
            var Bitmap = new Bitmap(256, 256);

            if (Sample == 1)
            {
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        Bitmap.SetPixel(i, j, Color.FromArgb(i, 0, j));
                    }
                }
            }
            else if (Sample == 2 || Sample == 3)
            {
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        Bitmap.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                    }
                }

                using (Graphics Graphics = Graphics.FromImage(Bitmap))
                {
                    Graphics.FillEllipse(Brushes.Pink, 10, 10, 100, 50);
                    Graphics.FillEllipse(Brushes.Purple, 150, 50, 100, 100);
                    Graphics.FillEllipse(Brushes.Blue, 100, 150, 50, 100);
                    Graphics.FillPolygon(Brushes.Black,
                        new Point[]
                        {
                        new Point(100, 150),
                        new Point(132, 78),
                        new Point(60, 70),
                        new Point(19, 125),
                        new Point(28, 233),
                        new Point(83, 232),
                        new Point(53, 208),
                        new Point(84, 164),
                        new Point(47, 153),
                        new Point(81, 99),
                        new Point(107, 134)
                        });
                }
            }
            else if (Sample == 4)
            {
                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        Bitmap.SetPixel(i, j, i < 128 ? Color.Red : Color.Black);
                    }
                }
            }

            return Bitmap;
        }

        public static void Save(this object Object, string Path)
        {
            if (!File.Exists(Path)) { File.Create(Path).Close(); }
            using (XmlWriter XmlWriter = XmlWriter.Create(Path, new XmlWriterSettings() { Indent = true }))
            {
                new XmlSerializer(Object.GetType()).Serialize(XmlWriter, Object);
            }
        }

        public static T Load<T>(this string Path)
        {
            using (XmlReader XmlReader = XmlReader.Create(Path))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(XmlReader);
            }
        }
    }

    public class BrainData
    {
        public float[][][] Ws;
        public float[][] Bs;

        public BrainData() { }

        public static implicit operator Brain(BrainData d)
        {
            return new Brain()
            {
                Ws = d.Ws.ToList().ConvertAll(W => W.ToMatrix()).ToArray(),
                Bs = d.Bs
            };
        }

        public static implicit operator BrainData(Brain c)
        {
            return new BrainData()
            {
                Ws = c.Ws.ToList().ConvertAll(W => W.ToJagged()).ToArray(),
                Bs = c.Bs
            };
        }
    }

    public class Brain
    {
        public float Sigmoid(float z) => 1f / (1f + (float)Math.Exp(-z));
        public float SigmoidPrime(float z) => Sigmoid(z) * (1 - Sigmoid(z));

        public float LearningRate;
        public int[] Neurons;
        public float[][] As;
        public float[][,] Ws;
        public float[][] Bs;
        public float[][] Zs;

        public float[] X => As[0];
        public float[] Y => As[As.Length - 1];

        public Brain() { }
        public Brain(float LearningRate, int[] Neurons)
        {
            this.LearningRate = LearningRate;
            this.Neurons = Neurons;
            As = new float[Neurons.Length][];
            Ws = new float[Neurons.Length - 1][,];
            Bs = new float[Neurons.Length - 1][];
            Zs = new float[Neurons.Length - 1][];

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                As[n] = new float[Neurons[n]];
                Ws[n] = new float[Neurons[n], Neurons[n + 1]];
                Bs[n] = new float[Neurons[n + 1]];
                Zs[n] = new float[Neurons[n + 1]];

                Ws[n] = Matrix.Random(Neurons[n], Neurons[n + 1], -1f / Neurons[n + 1], 1f / Neurons[n + 1]);
                Bs[n] = Vector.Random(Neurons[n + 1], -1f / Neurons[n + 1], 1f / Neurons[n + 1]);
            }
            As[Neurons.Length - 1] = new float[Neurons[Neurons.Length - 1]];
        }

        public float[] UseIt(float[] Perception)
        {
            As[0] = Perception;
            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                Zs[n] = As[n].Dot(Ws[n]).Add(Bs[n]);
                As[n + 1] = Zs[n].Apply(Sigmoid);
            }

            return Y;
        }

        int iter = 0;
        public void Revolution(float[] Perception, float[] HiddenTruth)
        {
            iter = (iter + 1) % 50;
            LearningRate = (0.63f - 0.001f) * (iter / 50f) + 0.001f;
            var o = FindDerivation(Perception, HiddenTruth);

            float[][,] dWs = (float[][,])o[0];
            float[][] dBs = (float[][])o[1];

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                Ws[n] = Ws[n].Add(dWs[n].Multiply(-LearningRate));
                Bs[n] = Bs[n].Add(dBs[n].Multiply(-LearningRate));
            }
        }

        public void Coup(float[][] AK47, float[][] MilitaryForces)
        {
            float[][,] dWs = new float[Neurons.Length - 1][,];
            float[][] dBs = new float[Neurons.Length - 1][];
            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                dWs[n] = Matrix.Create(Neurons[n], Neurons[n + 1], 0f);
                dBs[n] = Vector.Create(Neurons[n + 1], 0f);
            }

            for (int i = 0; i < AK47.Length; i++)
            {
                var o = FindDerivation(AK47[i], MilitaryForces[i]);

                float[][,] idWs = (float[][,])o[0];
                float[][] idBs = (float[][])o[1];

                for (int n = 0; n < Neurons.Length - 1; n++)
                {
                    dWs[n] = dWs[n].Add(idWs[n]);
                    dBs[n] = dBs[n].Add(idBs[n]);
                }
            }

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                Ws[n] = Ws[n].Subtract(dWs[n].Multiply(LearningRate /* AK47.Length*/));
                Bs[n] = Bs[n].Subtract(dBs[n].Multiply(LearningRate /* AK47.Length*/));
            }
        }

        public object[] FindDerivation(float[] Perception, float[] HiddenTruth)
        {
            this.UseIt(Perception);

            float[][] dBs = new float[Neurons.Length - 1][];

            dBs[Neurons.Length - 2] = Y.Subtract(HiddenTruth).Multiply(Zs[Neurons.Length - 2].Apply(SigmoidPrime));
            for (int n = Neurons.Length - 3; n >= 0; n--)
            {
                dBs[n] = dBs[n + 1].DotWithTransposed(Ws[n + 1]).Multiply(Zs[n].Apply(SigmoidPrime));
            }

            float[][,] dWs = new float[Neurons.Length - 1][,];

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                dWs[n] = Matrix.TransposeAndDot(As[n], dBs[n].ToMatrix());
            }

            return new object[] { dWs, dBs };
        }

        public override string ToString()
        {
            string s = "";

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                s += $"{n}. Layer\n\n\n";
                s += $"As[{n}] " + As[n].ToCSharp() + "\n";
                s += $"Ws[{n}] " + Ws[n].ToCSharp() + "\n";
                s += $"Bs[{n}] " + Bs[n].ToCSharp() + "\n";
                s += $"Zs[{n}] " + Zs[n].ToCSharp() + "\n\n\n";
            }
            s += "Y" + Y.ToCSharp() + "\n\n";

            return s;
        }
    }
}