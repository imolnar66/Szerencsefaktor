using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szerencsefaktor.Other_classes
{
    class KiIrBoxba
    {
        public static DialogResult MitIrjonKi(string mitirjonki, Uzenetek miatipus)
        {
            DialogResult valasz = new DialogResult();
            switch (miatipus)
            {
                case Uzenetek.hiba:
                    MessageBox.Show(mitirjonki, "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Uzenetek.informació:
                    MessageBox.Show(mitirjonki, "INFORMÁCIÓ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Uzenetek.figyelmeztetés:
                    MessageBox.Show(mitirjonki, "FIGYELMEZTETÉS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Uzenetek.kérdés:
                    valasz = MessageBox.Show(mitirjonki, "Kérdés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
            }
            return valasz;
        }

    }
}
