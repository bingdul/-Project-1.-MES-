using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp16
{
    class GetScreenSize
    {
        public Size GetScreenSize1()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return screenSize;
        }
    }
}
