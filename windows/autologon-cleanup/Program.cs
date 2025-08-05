using System;

class Program
{
    static void Main()
    {

    }

    static void DisableAutoLogon()
    {
        const string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

        using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(keyPath, writable: true))
        {
            if (key != null)
            {
                key.DeleteValue("AutoAdminLogon", false);
                key.DeleteValue("DefaultUserName", false);
                key.DeleteValue("DefaultPassword", false);
                key.DeleteValue("DefaultDomainName", false);
                Console.WriteLine("Autologon registry keys set.");
            }
            else
            {
                Console.WriteLine("Failed to open registry key.");
            }
        }
    }
}