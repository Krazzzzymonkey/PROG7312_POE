using System;
using System.Runtime.InteropServices;
using System.Text;

public class ToastNotification
{
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessageTimeout(
        IntPtr hWnd,
        uint Msg,
        IntPtr wParam,
        IntPtr lParam,
        uint uFlags,
        uint uTimeout,
        out IntPtr lpdwResult);

    private const uint WM_SETTINGCHANGE = 0x001A;
    private const uint SMTO_ABORTIFHUNG = 0x0002;
    private const uint SMTO_NORMAL = 0x0000;

    public static void Show(string message)
    {
        IntPtr result;
        SendMessageTimeout(
            IntPtr.Zero,
            WM_SETTINGCHANGE,
            IntPtr.Zero,
            Marshal.StringToHGlobalUni(message),
            SMTO_ABORTIFHUNG,
            5000,
            out result);
    }
}
