using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ComputerFiller2012
{
    class Program
    {
        static void Main(string[] args)
        {
            /* YOU CAN MODIFY VALUES IN THIS PART OF CODE */

            // before using this program, please read online documentation @ https://zilxen.eu/projects/computer_filler/documentation.html

            int amountOfFiles = 1;
            int lc = 33;
            int tc = 1;
            int amountOfCharactersInFilename = 16;
            string filePath = "D:";
            string fileExtension = "txt";
            string charsInFiles = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string charsInFilenames = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            /* DO NOT MODIFY CODE PAST HERE, IF YOU DONT KNOW WHAT ARE YOU DOING */
            /* DO NOT MODIFY CODE PAST HERE, IF YOU DONT KNOW WHAT ARE YOU DOING */

            char[] chars = charsInFiles.ToCharArray();
            char[] filenameChars = charsInFilenames.ToCharArray();
            Random rand = new Random();
            DateTime startTime = DateTime.Now;
            int successfulFiles = 0;

            if (lc <= -1 || tc <= -1 || lc > tc || amountOfCharactersInFilename <= 3 || filePath == "" || fileExtension == "" || charsInFiles == "" || charsInFilenames == ""|| !Directory.Exists(filePath))
            {
                Console.WriteLine("Cannot make files in your selected directory due to wrong input values. Please review them and try again...\nFor solutions check documenation @ https://zilxen.eu/projects/computer_filler/documentation.html \n=-=-=-=-=-=-=-=");
                //Console.WriteLine("Value 'lc'/'tc' is smaller than 0/bigger than 2147483000 - please use values in range 0 - 2147483000");
                if (lc <= -1)
                {
                    Console.WriteLine("Err 10 - Value 'lc' falls short of minimum limit (0)");
                }
                else if (lc >= 2147483000)
                {
                    Console.WriteLine("Err 11 - Value 'lc' exceeds limit (2147483000)");
                }

                if (tc <= -1)
                {
                    Console.WriteLine("Err 20 - Value 'tc' falls short of minimum limit (0)");
                }
                else if (tc >= 2147483000)
                {
                    Console.WriteLine("Err 21 - Value 'tc' exceeds limit (2147483000)");
                }

                if (lc > tc)
                {
                    //Console.WriteLine("Value 'tc' is smaller than 'lc' - please review and change value to be smaller than 'lc' and keep them in range 0 - 2147483000");
                    Console.WriteLine("Err 90 - Value 'tc' falls short of 'lc'");
                }

                if (amountOfCharactersInFilename <= 3)
                {
                    //Console.WriteLine("Value 'amountOfCharactersInFilename' is smaller or equal to 3, which is not enough to make test files. Please review this and use values between 4 - 20");
                    Console.WriteLine("Err 100 - Value 'amountOfCharactersInFilename' falls short of minimum limit (0)");
                }
                else if (amountOfCharactersInFilename >= 21)
                {
                    //Console.WriteLine("Value 'amountOfCharactersInFilename' is smaller or equal to 3, which is not enough to make test files. Please review this and use values between 4 - 20");
                    Console.WriteLine("Err 101 - Value 'amountOfCharactersInFilename' exceeds limit (20)");
                }
                if (filePath == "")
                {
                    //Console.WriteLine("Value 'amountOfCharactersInFilename' is smaller or equal to 3, which is not enough to make test files. Please review this and use values between 4 - 20");
                    Console.WriteLine("Err 200 - Value 'filePath' is empty");
                }
                if (!Directory.Exists(filePath))
                {
                    Console.WriteLine("Err 201 - Cannot make files/subdirectories in this directory - " + filePath);
                }

                if (fileExtension == "")
                {
                    //Console.WriteLine("Value 'amountOfCharactersInFilename' is smaller or equal to 3, which is not enough to make test files. Please review this and use values between 4 - 20");
                    Console.WriteLine("Err 300 - Value 'fileExtension' is empty");
                }
                if (charsInFiles == "")
                {
                    //Console.WriteLine("Value 'amountOfCharactersInFilename' is smaller or equal to 3, which is not enough to make test files. Please review this and use values between 4 - 20");
                    Console.WriteLine("Err 400 - Value 'charsInFiles' is empty");
                }
                if (charsInFilenames == "")
                {
                    //Console.WriteLine("Value 'amountOfCharactersInFilename' is smaller or equal to 3, which is not enough to make test files. Please review this and use values between 4 - 20");
                    Console.WriteLine("Err 500 - Value 'charsInFilenames' is empty");
                }
                
                Console.ReadLine();
                Environment.Exit(1);
            }

            if (amountOfFiles <= 0)
            {
                Environment.Exit(1);
            }
            else if (amountOfFiles == 1)
            {
                Console.WriteLine("Creating " + amountOfFiles + " file in " + filePath + " directory.\n=-=-=-=-=-=-=-=");
            }
            else
            {
                Console.WriteLine("Creating " + amountOfFiles + " files in " + filePath + " directory.\n=-=-=-=-=-=-=-=");
            }

            for (int j = 0; j < amountOfFiles; j++)
            {
                int j1 = j + 1;
                double perc = ((double)j1 / amountOfFiles) * 100;

                char[] fileContent;
                try
                {
                    fileContent = new char[rand.Next(lc, tc + 1)];
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        fileContent[i] = chars[rand.Next(chars.Length)];
                    }
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine("Failed to create file " + j1 + "/" + amountOfFiles + " (Error: " + e.Message + ")");
                    if (j1 == amountOfFiles)
                    {
                        DateTime endTime = DateTime.Now;
                        TimeSpan duration = endTime - startTime;
                        int failedFiles = amountOfFiles - successfulFiles;

                        if (successfulFiles == 1)
                        {
                            Console.WriteLine("=-=-=-=-=-=-=-=\nSaved " + amountOfFiles + " file to: " + filePath);
                        }
                        else if (successfulFiles >= 2)
                        {
                            Console.WriteLine("=-=-=-=-=-=-=-=\nSaved " + amountOfFiles + " files to: " + filePath);
                        }

                        if (failedFiles == 1)
                        {
                            Console.WriteLine("Task completed with " + failedFiles + " error in " + duration.TotalSeconds + " seconds.");
                        }
                        else if (failedFiles >= 2)
                        {
                            Console.WriteLine("Task completed with " + failedFiles + " errors in " + duration.TotalSeconds + " seconds.");
                        }
                        Console.ReadLine();
                    }
                    continue;
                }

                string filename = "";
                for (int i = 0; i < amountOfCharactersInFilename; i++)
                {
                    filename += filenameChars[rand.Next(filenameChars.Length)];
                }

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                try
                {
                    string fullFilePath = Path.Combine(filePath, filename + "." + fileExtension);
                    using (StreamWriter writer = new StreamWriter(fullFilePath))
                    {
                        int bufferSize = 4096;
                        int totalBytesWritten = 0;

                        while (totalBytesWritten < fileContent.Length)
                        {
                            int bytesToWrite = Math.Min(bufferSize, fileContent.Length - totalBytesWritten);
                            writer.Write(fileContent, totalBytesWritten, bytesToWrite);
                            totalBytesWritten += bytesToWrite;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to create file " + j1 + "/" + amountOfFiles + " (Error: " + e.Message + ")");
                    if (j1 == amountOfFiles)
                    {
                        DateTime endTime = DateTime.Now;
                        TimeSpan duration = endTime - startTime;
                        int failedFiles = amountOfFiles - successfulFiles;

                        if (successfulFiles <= 1)
                        {
                            Console.WriteLine("=-=-=-=-=-=-=-=\nSaved " + amountOfFiles + " file to: " + filePath);
                        }
                        else if (successfulFiles >= 2)
                        {
                            Console.WriteLine("=-=-=-=-=-=-=-=\nSaved " + amountOfFiles + " files to: " + filePath);
                        }

                        if (failedFiles == 1)
                        {
                            Console.WriteLine("Task completed with " + failedFiles + " error in " + duration.TotalSeconds + " seconds.");
                        }
                        else if (failedFiles >= 2)
                        {
                            Console.WriteLine("Task completed with " + failedFiles + " errors in " + duration.TotalSeconds + " seconds.");
                        }
                        Console.ReadLine();
                    }
                    continue;
                }

                Console.WriteLine("Successfully made " + j1 + "/" + amountOfFiles + " files (" + perc.ToString("0.00") + "%) - " + filename + "." + fileExtension);
                successfulFiles++;

                if (j1 == amountOfFiles)
                {
                    DateTime endTime = DateTime.Now;
                    TimeSpan duration = endTime - startTime;
                    Console.WriteLine("=-=-=-=-=-=-=-=\nSaved all files to: " + filePath);
                    Console.WriteLine("Task completed in " + duration.TotalSeconds + " seconds.");
                }
            }

            Console.ReadLine();
        }
    }
}
