using ActiveDirectoryOperateCore.Enum;
using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace ActiveDirectoryOperateCore.Helper
{
    public static class WindowsOperateHelper
    {
        // Account disable flag
        private const int ACCOUNTDISABLE_FLAG = (int)AdsUserFlag.ADS_UF_ACCOUNTDISABLE;

        /// <summary>
        /// Get actived windows user directory entries
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryEntry> GetWindowsActiveUserDirectoryEntries()
        {
            List<DirectoryEntry> directoryEntries = new List<DirectoryEntry>();

            // Get local machine directory entry
            DirectoryEntry localMachineDirectoryEntry = new DirectoryEntry("WinNT://" + Environment.MachineName);

            foreach (DirectoryEntry childDirectoryEntry in localMachineDirectoryEntry.Children)
            {
                // Focus user directory entry
                if (childDirectoryEntry.SchemaClassName == "User")
                {
                    var userflags = (int)childDirectoryEntry.Properties["UserFlags"].Value;

                    // If userflags bitwise and accountDisableFlag equal two, mean this windows user state is inactive
                    if ((userflags & ACCOUNTDISABLE_FLAG) != ACCOUNTDISABLE_FLAG)
                    {
                        directoryEntries.Add(childDirectoryEntry);
                    }
                }
            }

            return directoryEntries;
        }
    }
}
