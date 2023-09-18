using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifCreator.Tools
{
    /// <summary>
    /// Версия Panel, которая не позволяет прокручивать автоматически
    /// </summary>
    public class StaticPanel : Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }
    }
}
