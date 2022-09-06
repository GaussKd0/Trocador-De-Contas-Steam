using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace TrocadorContas
{
    class Contas
    {
        public void Conta(string user)
        {

            string[] p = { "set username=",
                "reg add \"HKCU\\Software\\Valve\\Steam\" /v AutoLoginUser /t REG_SZ /d %username% /f\n",
                "reg add \"HKCU\\Software\\Valve\\Steam\" /v RememberPassword /t REG_DWORD /d 1 /f\n",
                "start steam://open/main" };

            string Processo = "Steam";

            if (Process.GetProcessesByName(Processo).Length > 0)
            {

                Process[] processes = Process.GetProcessesByName("Steam");

                foreach (Process process in processes)
                {
                    process.Kill();

                }
            }
            StreamWriter sw = new StreamWriter(@"C:/Windows/Temp/conta.bat", true, Encoding.Default);
            sw.WriteLine(p[0] + user + "\n" + p[1] + p[2] + p[3]);
            sw.Dispose();
            Process.Start(@"C:/Windows/Temp/conta.bat");
            Thread.Sleep(2000);
            File.Delete(@"C:/Windows/Temp/conta.bat");
        }
    }
}
