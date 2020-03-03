using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;

namespace DesktopClient
{
    public partial class Main : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection FontCollection = new PrivateFontCollection();

        Font RalewayFont;

        public Main()
        {
            InitializeComponent();

            // Load the Raleway font into the application...
            byte[] fontData = Properties.Resources.Raleway_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            FontCollection.AddMemoryFont(fontPtr, Properties.Resources.Raleway_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Raleway_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            RalewayFont = new Font(FontCollection.Families[0], 16.0F);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label1.Font = RalewayFont;
            label2.Font = RalewayFont;
        }
    }
}
