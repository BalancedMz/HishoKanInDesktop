/*  Copyright (C) 2015 BalancedMz

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace HishoKan_InDeskop
{
    public class FileOrganizer
    {
        Random rnd = new Random();
        private static string charFolderPath;
        private string[] idleFiles, onClickFiles, clockFiles, imageFiles, startFiles;
        private string charConfigPath;

        public FileOrganizer(string nowCharFolderName)
        {
            charFolderPath = Directory.GetCurrentDirectory() + @"\chars\" + nowCharFolderName + @"\";
            AssignFiles();
        }

        public void ChangeCharPath(string newCharPath)
        {
            charFolderPath = Directory.GetCurrentDirectory() + @"\chars\" + newCharPath + @"\";
            AssignFiles();
        }


        private void AssignFiles()
        {
            CreateFolderIfNotExist(charFolderPath + @"idle\");
            CreateFolderIfNotExist(charFolderPath + @"onClick\");
            CreateFolderIfNotExist(charFolderPath + @"clock\");
            CreateFolderIfNotExist(charFolderPath + @"start\");

            idleFiles = Directory.GetFiles(charFolderPath + @"idle\");
            onClickFiles = Directory.GetFiles(charFolderPath + @"onClick\");
            clockFiles = Directory.GetFiles(charFolderPath + @"clock\");
            startFiles = Directory.GetFiles(charFolderPath + @"start\");
            
            //http://stackoverflow.com/questions/13301053/directory-getfiles-of-certain-extension
            var ext = new List<string> {".png" , ".jpg"};
            imageFiles = Directory.GetFiles(charFolderPath, "*.*")
                          .Where(s => ext.Any(e => s.EndsWith(e))).ToArray();

            charConfigPath = charFolderPath + @"config.cfg";

        }

        private void CreateFolderIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public string[] GetAllImageName()
        {
            string[] fileNames = imageFiles.Select(path => Path.GetFileName(path)).ToArray();
            return fileNames;
        }

        public Dictionary<string , string> GetAllChars()
        {
            Dictionary<string, string> nameAndPath = new Dictionary<string, string>();
            string[] fullPaths = Directory.GetDirectories( Directory.GetCurrentDirectory() + @"\chars\" );

            for (int i = 0; i < fullPaths.Length; i++)
            {
                nameAndPath.Add(new DirectoryInfo(fullPaths[i]).Name, fullPaths[i]);
            }
            return nameAndPath;
        }

        public string GetCharFolderPath()
        {
            return charFolderPath;
        }

        public string GetRandomIdleFile()
        {
            if (idleFiles.Count() < 1)
                return null;
            int num = rnd.Next(0, idleFiles.Count());
            return idleFiles[num];

        }

        public string GetRandomOnClickFile()
        {
            if (onClickFiles.Count() < 1)
                return null;
            int num = rnd.Next(0, onClickFiles.Count());
            return onClickFiles[num];
        }

        public string GetRandomClockFile()
        {
            if (clockFiles.Count() < 1)
                return null;
            int num = rnd.Next(0, clockFiles.Count());
            return clockFiles[num];
        }

        public string GetRandonImageFile()
        {
            
            if (imageFiles.Count() < 1)
                return null;
            int num = rnd.Next(0, imageFiles.Count());
            return imageFiles[num];
        }

        public string GetRandomStartFile()
        {
            if (startFiles.Count() < 1)
                return null;
            int num = rnd.Next(0, startFiles.Count());
            return startFiles[num];
        }

        public static bool FolderContainsImage(string folderFullPath)
        {
            var ext = new List<string> { ".png", ".jpg" };
            return Directory.GetFiles(folderFullPath, "*.*")
                          .Where(s => ext.Any(e => s.EndsWith(e))).Count() > 0;
        }
    }
}