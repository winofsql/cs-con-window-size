using System.Diagnostics;

namespace WindowSize
{
    internal class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hwnd, int x, int y,
            int nWidth, int nHeight, int bRepaint);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        const uint SW_RESTORE = 0x09;
        static void Main(string[] args)
        {
            Process[] localByName = Process.GetProcessesByName(args[0]);

            for (int i = 0; i < localByName.Length; i++)
            {
                ShowWindow(localByName[i].MainWindowHandle, SW_RESTORE);
                MoveWindow(localByName[i].MainWindowHandle, int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]), 1);
            }

        }
    }
}