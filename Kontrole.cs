using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;



namespace JefGēnija_Aparāts
{
    public partial class Kontrole : Form
    {
        private bool isDragging = false;
        private Point lastCursorPosition; 
        public Kontrole()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Magenta;
            SetRoundedForm();
        }
        //Šito pat umbraks saprastu kas te aukšā, bool ir setots false jo mēs negribam mūsu formu jau sākumā kustināt apkārt

            private void SetRoundedForm()
        {
          
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();      
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);

             //Izmantojot drawing metodes izveidojam apļveida stūrus mūsu aplikācijai
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
     
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
        
                lastCursorPosition = e.Location;
            }
        }
        //Pārbaudam vai uz mūsu forma tiek turēts kreisais klikšķis
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
   
            if (isDragging)
            {
     
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;
 
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }
  //Izmanotjot pelīti varam kustināt mūsu formu
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
 
            isDragging = false;
        }
        // Pārbaudam vai pelīte ir atlaista, ja ir tad beidzam OnMouseMove funkciju

        private void Kontrole_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //Uzsākam timeri priekš mūsu animācijas

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += 0.8;
        }
        //Animācija
        // Viss kas šeit ir augšā ir priekš dizaina, gludiem stūriem, iespējai kustināt Form.
        private void Izeja_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("JefGēnija_Aparāts");
            foreach (Process p in localByName)
            {
                p.Kill();
            }
            // Izmantojam processkill komandu lai terminētu aplikāciju, savādāk izmantojot this.close, aplikācija tehniski joprojām paliek atvērta
        }
        private void button1_Click(object sender, EventArgs e)
        {
           this.Hide();
           Misene misene = new Misene();
           misene.Show();
            // Poga ar kuras palīdzību tiekam pie rīka Nr.1
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GPT robots = new GPT();
            robots.Show();
            // Poga ar kuras palīdzību tiekam pie rīka Nr.2
        }



        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¯\\_( ͡° ͜ʖ ͡°)_/¯", "Kruta", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //Izziņo par to kad lietotājs uzspiež uz konkrēta LennyFace
        }
    }
}
