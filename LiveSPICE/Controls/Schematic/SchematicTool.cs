﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LiveSPICE
{
    public class SchematicTool
    {
        private SchematicControl target;
        public SchematicControl Target { get { return target; } }

        private Cursor cursor;

        public SchematicTool(SchematicControl Target) { target = Target; }

        public virtual ContextMenu BuildContextMenu(Circuit.Coord At) { return null; }

        public virtual void Begin() { cursor = Target.Cursor; Target.Cursor = Cursors.Cross; }
        public virtual void End() { Target.Cursor = cursor; }
        public virtual void Cancel() { }

        public virtual void MouseDoubleClick(Circuit.Coord At) { }
        public virtual void MouseDown(Circuit.Coord At) { }
        public virtual void MouseMove(Circuit.Coord At) { }
        public virtual void MouseUp(Circuit.Coord At) { }
        public virtual void MouseEnter(Circuit.Coord At) { }
        public virtual void MouseLeave(Circuit.Coord At) { }

        public virtual bool KeyDown(KeyEventArgs Event)
        {
            if (Event.Key == Key.Escape)
            {
                Target.Tool = new SchematicTool(Target);
                return true;
            }
            return false;
        }
        public virtual bool KeyUp(KeyEventArgs Event) { return false; }
    }
}
