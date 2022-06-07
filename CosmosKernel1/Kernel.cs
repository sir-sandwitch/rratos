using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using System.IO;



namespace Alpha2
{
    public class Kernel : Sys.Kernel
    {
        CosmosVFS fs = new CosmosVFS();
        
        string txtwrite = "";
        string[] txtbuffer = new string[256];
        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.WriteLine("                           @@@@@@@@@@@@@@@@");
            Console.WriteLine("                         (@@@@@@@@@@@@@@@@@@@(");
            Console.WriteLine("                        @@@@@@@@#       @@@@@@@");
            Console.WriteLine("                       (@@@@  %%%%%@@@@%%  @@@@@");
            Console.WriteLine("                       @@@@@ ,****/###/** ,@@@@@@");
            Console.WriteLine("                      @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                      @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                    ,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                   #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                  &@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("                 /@@@@@@@@            @@@@@@@@@@@@@.");
            Console.WriteLine("                 @@@@@@@@,             @@@@@@@@@@@@");
            Console.WriteLine("                @@@@@@@@@&             @@@@@@@@@@@@");
            Console.WriteLine("       @@@@@@@@@@@@@@@@@@              @@@@@@@@@@@@");
            Console.WriteLine("        &@@@@@@@@@@@@@@#             #@@@@@@@@@@@@@");
            Console.WriteLine("                                @@@@@@@@@@@@@@@@@@&");
            Console.WriteLine("                                 @@@@@@@@@@@@@@");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Boot Successful!");
        }

        protected override void Run()
        {
            string input = "";

            input = Console.ReadLine();


            cmdHandle(input);
            /*Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);*/
        }
        /*public void CanvasInitalize()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();

            canvas.Clear();
            
        }*/

        private void cmdHandle(string input)
        {
            
            bool ArgParser = true;
            string[] input2 = new string[128];
            
            //txtbuffer[0] = "";
            if (input.Contains(' '))
            {
                input2 = input.Split(' ');
            }
            else//(!input.Contains(' '))
            {
                ArgParser = false;
                //Console.WriteLine("Invalid Syntax!");
                //return;
                switch (input)
                {
                    case "cls":
                        Console.Clear();
                        break;
                    case "help":
                        Console.WriteLine("help #### Shows list of commands and their usages. Can be used with an argument to display info on a specific command. Ex: help echo");
                        Console.WriteLine("color ### Sets the color of onscreen text, Type 'color [color]' (without the []) to change the color of text. Ex: color red");
                        Console.WriteLine("echo #### Echos back what you type, Type 'echo [text]' (without the []) to have [text] appear in console. Ex: echo test");
                        Console.WriteLine("cls ##### Clears the screen of all text. This command has no arguments.");
                        Console.WriteLine("beep #### Beeps. This command has no arguments.");
                        Console.WriteLine("amogus ## Draws an among us. This command has no arguments.");
                        Console.WriteLine("ospc #### Displays the amount of unused space in the file system in bytes. This command has no arguments.");
                        Console.WriteLine("write ### Writes the contents of 'texted' command to the file you define in the argument. Type 'write [filename.txt]' (without the []) to write to the file. Ex: write this is a test.");
                        Console.WriteLine("txted ### This command is currently disabled as it is not yet completed.");
                        Console.WriteLine("txtmk ### Creates a text file. Type 'txtmk [filename without extension]' (without the []) to create a text file. Ex: txtmk test");
                        break;
                    default:
                        Console.WriteLine("Invalid Syntax! Type help [command] for information on a command!");
                        break;
                    case "beep":
                        Console.Beep();
                        break;
                    case "amogus":
                        Console.WriteLine("                           @@@@@@@@@@@@@@@@");
                        Console.WriteLine("                         (@@@@@@@@@@@@@@@@@@@(");
                        Console.WriteLine("                        @@@@@@@@#       @@@@@@@");
                        Console.WriteLine("                       (@@@@  %%%%%@@@@%%  @@@@@");
                        Console.WriteLine("                       @@@@@ ,****/###/** ,@@@@@@");
                        Console.WriteLine("                      @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                      @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                    ,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                   #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                  &@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                 /@@@@@@@@            @@@@@@@@@@@@@.");
                        Console.WriteLine("                 @@@@@@@@,             @@@@@@@@@@@@");
                        Console.WriteLine("                @@@@@@@@@&             @@@@@@@@@@@@");
                        Console.WriteLine("       @@@@@@@@@@@@@@@@@@              @@@@@@@@@@@@");
                        Console.WriteLine("        &@@@@@@@@@@@@@@#             #@@@@@@@@@@@@@");
                        Console.WriteLine("                                @@@@@@@@@@@@@@@@@@&");
                        Console.WriteLine("                                 @@@@@@@@@@@@@@");
                        break;
                    /*case "gui":
                        CanvasInitalize();
                        break;*/
                    case "ospc":
                        var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        Console.WriteLine("Available Free Space: " + available_space);
                        break;
                    case "dir":
                        var directory_list = VFSManager.GetDirectoryListing("0:\\");
                        foreach (var directoryEntry in directory_list)
                        {
                            Console.WriteLine(directoryEntry.mName);
                        }
                        break;
                        
                   





                }

            }

            if (ArgParser == true)
            {
                switch (input2[0])
                {
                    case "echo":
                        Console.WriteLine(input2[1]);
                        break;
                    case "color":
                        switch (input2[1])
                        {
                            case "red":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "blue":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "green":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "yellow":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case "white":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case "pink":
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case "orange":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;

                        }
                        break;
                    case "help":
                        switch (input2[1])
                        {
                            case "echo":
                                Console.WriteLine("echo #### Echos back what you type, Type 'echo [text]' (without the []) to have [text] appear in console. Ex: echo test");
                                break;
                            case "color":
                                Console.WriteLine("color #### Sets the color of onscreen text, Type 'color [color]' (without the []) to change the color of text. Ex: color red");
                                break;
                            case "cls":
                                Console.WriteLine("cls ##### Clears the screen of all text. This command has no arguments.");
                                break;
                            case "beep":
                                Console.WriteLine("beep #### Beeps. This command has no arguments.");
                                break;
                            case "amogus":
                                Console.WriteLine("amogus ## Draws an among us. This command has no arguments.");
                                break;
                            default:
                                Console.WriteLine("Invalid Argument for 'help'!");
                                break;

                        }
                        break;
                    case "txtmk":
                        try
                        {
                            VFSManager.CreateFile(@"0:\" + input2[1] + ".txt");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        
                        break;
                    case "del":
                        try
                        {
                            VFSManager.DeleteFile(@"0:\" + input2[1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case "open":
                        try
                        {
                            var file = VFSManager.GetFile(@"0:\" + input2[1]);
                            var file_stream = file.GetFileStream();

                            if (file_stream.CanRead)
                            {
                                byte[] text_to_read = new byte[file_stream.Length];
                                file_stream.Read(text_to_read, 0, (int)file_stream.Length);
                                Console.WriteLine(Encoding.Default.GetString(text_to_read));
                            }
                        }
                        
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case "write":
                        try
                        {
                            var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + input2[1]);
                            var file_stream = file.GetFileStream();


                            if (file_stream.CanWrite)
                            {
                                byte[] text_to_write = Encoding.ASCII.GetBytes(txtwrite);
                                file_stream.Write(text_to_write, 0, text_to_write.Length);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case "txted":
                        int i = 1;

                        while (i < input2.Length)
                        {
                            txtbuffer[i] = input2[i];
                            i++;
                            txtwrite = string.Join(" ", txtbuffer);
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid Syntax! Type help [command] for information on a command!");
                        break;

                }
            }






            /*if (input2[0] == "echo")
            {
                Console.WriteLine(input2[1]);
            }
            else if(input2[0] == "help")
            {
                
                
                
                if(input2[0] == "help" && input2[1] == "echo")
                {
                    Console.WriteLine("echo #### Echos back what you type, Type 'echo [text] (without the []) to have [text] appear in console. Ex: echo test.");
                    
                }
                
                

            }*/
        }
    }
}
