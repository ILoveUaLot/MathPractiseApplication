using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Messages
{
    public class VisibilityChangedMessage
    {
        public bool IsVisible { get; }

        public VisibilityChangedMessage(bool isVisible)
        {
            IsVisible = isVisible;
        }
    }
}
