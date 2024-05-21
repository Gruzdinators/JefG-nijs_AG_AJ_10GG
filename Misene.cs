using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JefGēnija_Aparāts
{
    public partial class Misene : Form
    {
        private bool isDragging = false;
        private Point lastCursorPosition;

        public Misene()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Magenta;
            SetRoundedForm();
        }

        // Importējam shell32.dll failu ar visiem nepieciešamajiem stringiem un intiem lai varam veikt dzēsšanas funkciju mūsu miskastē!
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

        [Flags]
        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000002,
            SHERB_NOSOUND = 0x00000004
        }

        private void SetRoundedForm()
        {
            //Dizains, apaļi stūri izmantojot System.Drawing
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }
        }    //Pārbaudam vai uz mūsu forma tiek turēts kreisais klikšķis

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDragging)
            {
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }  //Izmanotjot pelīti varam kustināt mūsu formu

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
        }
        // Pārbaudam vai pelīte ir atlaista, ja ir tad beidzam OnMouseMove funkciju

        private void Misene_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //Startojam timeri priekš animācijas

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += 0.8;
        }
        //Amimācija
        // Viss kas šeit ir augšā ir priekš dizaina, gludiem stūriem, iespējai kustināt Form.

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Kontrole formInstance = new Kontrole();
            formInstance.Show();
            // Aizveram ciet šo Form un atveram galveno Form
        }

        private void btn_tirit_Click(object sender, EventArgs e)
        {
            if (Auksa.Visible)
            {
                CleanTempFiles();
            }
            if (Apaksa.Visible)
            {
                EmptyRecycleBin();
            }
        }
        // Parbaudam vai ir picture box ir visable un callojam atbilstošās funkcijas ja nepieciešams

        private void CleanTempFiles()
        {
            string tempFolderPath = Path.GetTempPath(); // Definējam tempfolderPath ir Path.GetTempPath funkcija
            int failedDeletions = 0; //Sākuma skaits izgāzušajiem temp failiem 

            if (Directory.Exists(tempFolderPath))
            {
                DirectoryInfo tempDir = new DirectoryInfo(tempFolderPath);
                //Pārbaudam vai eksistē un definējam direktoriju
                foreach (FileInfo file in tempDir.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                        failedDeletions++;
                    }
                }// Mēģinam izdzēst katru failu iekšā tempDir lokācijā, un ķeram to ja tas nav iespējams

                foreach (DirectoryInfo dir in tempDir.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch
                    {
                        failedDeletions++;
                    }
                    // Mēģinam izdzēst katru folderi iekšā tempDir lokācijā, un ķeram to ja tas nav iespējams
                }

                MessageBox.Show(failedDeletions == 0
                    ? "Viss ir iztīrīts un ir čotka!" // Parādam šo ja nebija nekādu erroru tīrībā un viss izdzēsās
                    : $"Dažus failus nevarēja izdzēst. Rekur failu skaits!: {failedDeletions}"); //Pasakam ka šo to nevarēja izdzēst un parādam skaitu, cik nevarēja izdzēst
            }
            else
            {
                MessageBox.Show("Nevarēja atrast temp failus!");
            }
        }// Pasakam kad lietotājs ir umbraks un kad viņam temp foldera datorā nav

        static void EmptyRecycleBin()
        {
            uint flags = (uint)RecycleFlags.SHERB_NOCONFIRMATION | (uint)RecycleFlags.SHERB_NOPROGRESSUI | (uint)RecycleFlags.SHERB_NOSOUND;
            int result = SHEmptyRecycleBin(IntPtr.Zero, null, flags);

            // Atrodam Recyling binu, un sakam lai tas sevi iztīri, diezgan saprotami...

            if (result == 0)
            {
                MessageBox.Show("Veiksmīgi iztīrīta miskaste!"); // Ja faili visi iztīrīti un viss labi, tad pasakam kad viss labi!
            }
            else
            {
                MessageBox.Show($"Miskasti nevarēja iztīrīt! Rekur error kods: {result}"); // Ja nav failu vai kaut kas cits traucē uzmetam kad bija errors un errora numuru.
            }
        }

        private void Auksa_Click(object sender, EventArgs e)
        {
            Auksa.Visible = false;
            Auksa.SendToBack();
        }

        private void Apaksa_Click(object sender, EventArgs e)
        {
            Apaksa.Visible = false;
            Apaksa.SendToBack();
        }

        private void AuksaTukss_Click(object sender, EventArgs e)
        {
            Auksa.Visible = true;
            Auksa.BringToFront();
        }

        private void ApaksaTukss_Click(object sender, EventArgs e)
        {
            Apaksa.Visible = true;
            Apaksa.BringToFront();
        }
    }
}
