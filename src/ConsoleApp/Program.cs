using ActiveDirectoryOperateCore.Helper;
using System;
using System.Linq;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                var methodName = args[0];

                switch (methodName)
                {
                    case "DisplayWindowsActiveUserNames":
                        DisplayWindowsActiveUserNames();
                        break;
                    default:
                        break;
                }
            } 
            else
            {
                DisplayWindowsActiveUserNames();
            }
        }

        /// <summary>
        /// Display actived windows user names
        /// </summary>
        private static void DisplayWindowsActiveUserNames()
        {
            // Get actived windows user names
            var windowsActiveUserNames =
                WindowsOperateHelper.GetWindowsActiveUserDirectoryEntries()
                                    .Select(windowsActiveUserDirectoryEntry => windowsActiveUserDirectoryEntry.Name);

            foreach (var windowsActiveUserName in windowsActiveUserNames)
            {
                Console.WriteLine(windowsActiveUserName);
            }
        }
    }
}
