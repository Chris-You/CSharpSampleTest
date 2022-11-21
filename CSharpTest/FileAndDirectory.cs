using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CSharpTest
{
    public class FileAndDirectory
    {

        //file
        public void FileTest()
        {
            string source = @"F:/test/source.txt";
            string target = @"F:/test/test2.txt";
            string moved = @"F:/test/move/test3.txt";

            if (File.Exists(source))
            {
                File.Delete(source);
            }


            if (File.Exists(source))
            {
                File.Delete(source);
            }
            else
            {
                using (var sw = File.CreateText(source))
                {
                    sw.WriteLine("hello");
                    sw.Write("csharp world !!");
                }

                using (StreamReader sr = File.OpenText(source))
                {
                    string read="\r\n==read";
                    while ((read = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(read);
                    }
                }

                using (var sw = File.AppendText(source))
                {
                    sw.Write("append hello~~");
                }

                //Console.WriteLine(File.ReadAllText(source));


                if (File.Exists(target))
                {
                    File.Delete(target);
                }

                if (File.Exists(moved))
                {
                    File.Delete(moved);
                }

                File.Copy(source, target);
                File.Move(target, moved);

            }




            

        }


        public void FileInfoTest()
        {
            string source = @"F:/test/source.txt";
            string target = @"F:/test/test2.txt";
            string moved = @"F:/test/move/test3.txt";

            var fi = new FileInfo(source);

            if (fi.Exists)
            {
                fi.Delete();
            }

            if (fi.Exists)
            {
                fi.Delete();
            }
            else
            {
                using (var sw = fi.CreateText())
                {
                    sw.WriteLine("hello");
                    sw.Write("csharp world !!");
                }

                using (StreamReader sr = fi.OpenText())
                {
                    string read = "";
                    while ((read = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(read);
                    }
                }

                using (var sw = fi.AppendText())
                {
                    sw.Write("append hello~~");
                }

                if (fi.Exists)
                {
                    fi.Delete();
                }

                if (fi.Exists)
                {
                    fi.Delete();
                }

                fi.CopyTo(target);
                fi.MoveTo(moved);

            }



        }



        public void DirectoryTest()
        {
            string source = @"F:/test/";
            string target = @"F:/test/target";
            string move = @"F:/test/move";


            if (Directory.Exists(source))
            {
                var files = Directory.GetFiles(source);
                foreach (var file in files)
                {
                    Console.WriteLine("F: " + file);
                }

                Console.WriteLine(Directory.GetParent(source));

                var dir = Directory.GetDirectories(source);
                foreach (var d in dir)
                {
                    Console.WriteLine("D:" + d);
                }

            }

            if (Directory.Exists(target))
            {
                Directory.Delete(target);
            }
            else
            {
                Directory.CreateDirectory(target);
                                
                if (Directory.Exists(move))
                {
                    Directory.Delete(move);
                }

                Directory.Move(target, move);
            }


            DirectoryInfo di = new DirectoryInfo(source);

            if(di.Exists)
            {
                foreach(var d in di.GetDirectories())
                {
                    Console.WriteLine("directory :" + d.FullName);
                    foreach(var f in d.GetFiles())
                    {
                        Console.WriteLine("    " + f.FullName);
                    }
                }
            }


            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach(var drive in allDrives)
            {
                Console.WriteLine("drive : " + drive.Name);
                Console.WriteLine("   DriveType  " + drive.DriveType);
                Console.WriteLine("   IsReady: " + drive.IsReady);
                if (drive.IsReady)
                {
                    Console.WriteLine("   AvailableFreeSpace: " + drive.AvailableFreeSpace);
                    Console.WriteLine("   TotalFreeSpace: " + drive.TotalFreeSpace);
                    Console.WriteLine("   TotalSize: " + drive.TotalSize);
                }
            }


        }

    }
}

