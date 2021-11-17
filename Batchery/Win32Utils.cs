﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Win32Utils
{
    public Win32Utils()
    {

    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

    private const int WM_SETREDRAW = 11;

    public static void SuspendDrawing(Control parent)
    {
        parent.SuspendLayout();
        SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
    }

    public static void ResumeDrawing(Control parent)
    {
        SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
        parent.ResumeLayout();
        parent.Invalidate();
    }
}
