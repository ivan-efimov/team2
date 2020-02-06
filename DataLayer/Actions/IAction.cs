using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DataLayer.Actions
{
    public interface IAction
    {
        public Point ActionPoint { get; set; }
    }

    public class SuccessAction : IAction
    {
        public Point ActionPoint { get; set; }
    }
}
