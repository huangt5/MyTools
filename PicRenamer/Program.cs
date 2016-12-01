using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TLib.Core.Text;

namespace PicRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 3)
            {
                PrintHelp();
                return;
            }

            string folder = args[0];
            DirectoryInfo dir = new DirectoryInfo(folder);

            var sortedFiles = from file in dir.GetFiles("*.jpg")
                              orderby GetPicTakenDate(file)
                              select file;

            // Get file name pattern
            string pattern = args[1];
            int digitLength = int.Parse(pattern.Match1(@"\{(\d+)\}"));
            int index = int.Parse(args[2]);

            foreach (var file in sortedFiles)
            {
                string newName = pattern.Replace("{" + digitLength + "}", index.ToString().PadLeft(digitLength, '0')) + ".JPG";
                Console.WriteLine(newName + " <= " + file.Name + " " + GetPicTakenDate(file));

                if (args.Length <=3 || args[3].ToLower() != "preview")
                {
                    file.MoveTo(dir.FullName + "\\" + newName);
                }
                
                index++;
            }



            Console.WriteLine("Done.");
            Console.WriteLine("Press enter to finish...");
            Console.Read();
        }

        private static string GetPicTakenDate(FileInfo file)
        {
            using (Image img = Image.FromFile(file.FullName))
            {
                var takenDateItem = img.PropertyItems.FirstOrDefault(
                    x => x.Id == 0x0132 || x.Id == 36867 || x.Id == 36868);
                if (takenDateItem != null)
                {
                    return GetValueOfType2(takenDateItem.Value);
                }
                return file.LastWriteTime.ToString("yyyy:MM:dd HH:mm:ss\0");
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Usage: PicRenamer.exe <folder> <patter> <start from> [preview]");
            Console.WriteLine("Pattern sample: Prefix-{4}");
            Console.WriteLine("Prefix-0001.jpg");
            Console.WriteLine("Prefix-0002.jpg");
            Console.WriteLine("Prefix-0003.jpg");
        }

        #region Read Exif data
        private static string GetValueOfType2(byte[] b)// 对type=2 的value值进行读取
        {
            return Encoding.ASCII.GetString(b);
        }
        private static string GetValueOfType3(byte[] b) //对type=3 的value值进行读取
        {
            if (b.Length != 2) return "unknow";
            return Convert.ToUInt16(b[1] << 8 | b[0]).ToString();
        }
        private static string GetValueOfType5(byte[] b) //对type=5 的value值进行读取
        {
            if (b.Length != 8) return "unknow";
            UInt32 fm, fz;
            fm = 0;
            fz = 0;
            fz = Convert.ToUInt32(b[7] << 24 | b[6] << 16 | b[5] << 8 | b[4]);
            fm = Convert.ToUInt32(b[3] << 24 | b[2] << 16 | b[1] << 8 | b[0]);
            return fm.ToString() + "/" + fz.ToString() + " sec";
        }
        private static string GetValueOfType5A(byte[] b)//获取光圈的值
        {
            if (b.Length != 8) return "unknow";
            UInt32 fm, fz;
            fm = 0;
            fz = 0;
            fz = Convert.ToUInt32(b[7] << 24 | b[6] << 16 | b[5] << 8 | b[4]);
            fm = Convert.ToUInt32(b[3] << 24 | b[2] << 16 | b[1] << 8 | b[0]);
            double temp = (double)fm / fz;
            return (temp).ToString();
        }
        #endregion
    }
}
