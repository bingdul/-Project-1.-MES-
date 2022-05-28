using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMainMenu_2
{
    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

                // Extend the CreateParams property of the Button class.
                CreateParams cp = base.CreateParams;
                // Update the button Style.
                cp.Style |= 0x04; // BS_ICON value

                return cp;
            }
        }
    }
}
