using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ini
{
    /// <summary>

    /// Create a New INI file to store or load data

    /// </summary>

    public class IniFile
    {
        private string _pathFileName;

        [DllImport("kernel32.dll")]
        private static extern Int32 WritePrivateProfileString(string section, 
                                                             string key, 
                                                             string val,
                                                             string filePathName);
        [DllImport("kernel32.dll")]
        private static extern Int32 GetPrivateProfileString(string section,
                                                          string key, 
                                                          string defaultValue, 
                                                          StringBuilder retVal,
                                                          int size,
                                                          string filePathName);

        [DllImport("kernel32.dll")]
        static extern Int32 GetPrivateProfileSectionNames(IntPtr returnBuffer,
                                                          Int32 bufferSize, string filePathName);


        /// <summary>

        /// INIFile Constructor.

        /// </summary>

        /// <PARAM name="INIPath"></PARAM>

        public IniFile(string pathFileName)
        {
            _pathFileName = pathFileName;
        }
        /// <summary>

        /// Write Data to the INI File

        /// </summary>

        /// <PARAM name="Section"></PARAM>

        /// Section name

        /// <PARAM name="Key"></PARAM>

        /// Key Name

        /// <PARAM name="Value"></PARAM>

        /// Value Name

        public void writeValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, _pathFileName);
        }

        /// <summary>

        /// Read Data Value From the Ini File

        /// </summary>

        /// <PARAM name="Section"></PARAM>

        /// <PARAM name="Key"></PARAM>

        /// <PARAM name="Path"></PARAM>

        /// <returns></returns>

        public string readValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(1024);
            Int32 ret = GetPrivateProfileString(Section, 
                                            Key, 
                                            "-1", 
                                            temp,
                                            1024,
                                            _pathFileName);
            return temp.ToString();
        }


        public string[] getSectionNames()
        {
            Int32 MAX_BUFFER = 32767;
            IntPtr returnedString = Marshal.AllocCoTaskMem((Int32)MAX_BUFFER);
            Int32 bytesReturned = GetPrivateProfileSectionNames(returnedString, MAX_BUFFER, _pathFileName);
            if (bytesReturned == 0)
            {
                Marshal.FreeCoTaskMem(returnedString);
                return null;
            }

            string sectionNames = Marshal.PtrToStringAnsi(returnedString, (Int32)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(returnedString);

            //use of Substring below removes terminating null for split
            return sectionNames.Substring(0, sectionNames.Length - 1).Split('\0');
        }
    }
}