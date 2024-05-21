using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace JefGēnija_Aparāts
{
    public partial class GPT : Form
    {
        private bool isDragging = false;
        private Point lastCursorPosition;

        public GPT()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Magenta;
            SetRoundedForm();
        }
        //Kroč tas pats ko citur komentēju, dizains un jā umbraks pat saprastu

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public ushort fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        //Imporējam DLL failus lai varam veikt neķītrības un lai mums ir kaut kādi priviligi izmantot viņus sakarā ar to kad mums viņus vaijg lai jā
        private void SetRoundedForm()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
        // Dizains protams, apaļi stūŗīši
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }
        }
    // Pārbaudam vai mouse down ir holdots protams kā jau iepriekš minēju, man jau apnīk rakstīt šito bazaru.

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDragging)
            {
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        } // Kustinam formu funkcija, manuprāt saportami 

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDragging = false;
        }
        //Pārbaudam kad atlaiž

        private async void button2_Click(object sender, EventArgs e)
        {
            string question = textBox1.Text;
            string response = await GetChatGptResponse(question);
            richTextBox1.Text = response;
        }
        // Sakārtojam lai uzspiežot pogu tiek nolasīts teksts aizsūtīts jautājums uz GetChatGptResponse funkciju
        private async Task<string> GetChatGptResponse(string prompt)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer sk-proj-lRP6hI9fjsR6mlZpqF1wT3BlbkFJSWi7cu2JqcufDPZ1ys1T");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "user", content = prompt }
                    }
                };

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                    string responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        JObject jsonResponse = JObject.Parse(responseString);
                        return jsonResponse["choices"][0]["message"]["content"].ToString();
                    }
                    else
                    {
                        JObject errorResponse = JObject.Parse(responseString);
                        return $"Error: {errorResponse["error"]["message"]}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Exception: {ex.Message}";
                }
                // Cenšamies izmanot API keju lai sazinātos ar CHATGPT tiešākajā nozīmē, izmantojam gpt-3.5-turbo modeli kā mūsu engine. sakārtojam arī to lai ķer errorus
            }
        }

        private void GPT_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //Startojam timeri priekš animācijām

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += 0.8;
        }
        // Animācijas piegarša
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Kontrole formInstance = new Kontrole();
            formInstance.Show();
        }
        //Šī poga aizver šo form un atver galveno izvēlni

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Šī divi private void ir tas kas notiek kad spiež to ko nevajeg, protams nedrīkst dzēst savādāk forms corruptosies.... :D
    }
}
