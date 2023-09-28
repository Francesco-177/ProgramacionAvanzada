using static System.IO.Directory; //creates folders
using static System.IO.Path; //creates system routes
using static System.Environment; //check the OS

#region Knowingdirectory stuff
SelectionTitle("ClosePlataformEnviroment");
WriteLine($"{"Path.PathSeparator", -33}{PathSeparator}");
WriteLine($"{"Path.DirectoryPathSeparator", -33}{DirectorySeparatorChar}");
WriteLine($"{"Directory.GetCurrentDirectory", -33}{GetCurrentDirectory()}");
WriteLine($"{"Directory.CurrentDirectory", -33}{CurrentDirectory}");
WriteLine($"{"Enviroment.SystemDirectory", -33}{SystemDirectory}");
WriteLine($"{"Path.GetTempPath", -33}{GetTempPath}");
WriteLine($"{"Directory.SpecialFolder", -33}{GetFolderPath(SpecialFolder.System)}");
WriteLine($"{"Directory.ApplicationData", -33}{GetFolderPath(SpecialFolder.ApplicationData)}");
WriteLine($"{"Directory.MyDocuments", -33}{GetFolderPath(SpecialFolder.MyDocuments)}");

#endregion

#region Managin drives
    SelectionTitle("ManaginDrives");
    WriteLine($"{"NAME",-30} | {"TYPE",-10} | {"FORMAT",-7} | {"SIZE",-18} | {"FREESPACE",-18}");
    foreach(DriveInfo drive in DriveInfo.GetDrives()){

        if(drive.IsReady){

            WriteLine($"{drive.Name,-30} | {drive.GetType,-10} | {drive.DriveFormat,-7} | {drive.TotalSize,-18} | {drive.TotalFreeSpace,-18}");


        }
    }

#endregion

#region Manage Directories
    SelectionTitle("Manage Directories");
    string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "New Folder");
    WriteLine("Working with new folder");
    WriteLine("Creating New Folder");
    CreateDirectory(newFolder);
    WriteLine($"Does it exists? : {Path.Exists(newFolder)}");
    ReadLine();
#endregion

#region Managing files
    SelectionTitle("Managing Files");
    string dir = Combine(GetFolderPath(SpecialFolder.MyDocuments), "OutPutFiles");
    CreateDirectory(dir);
    string textFile = Combine(dir, "Dummy.txt");
    string backupFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with {textFile}");
    WriteLine($"Does it exists? : {Path.Exists(textFile)}");
     //Writing on files
     //StreamWriter
     StreamWriter textWriter = File.CreateText(textFile); //create
     textWriter.WriteLine("Hello my bruuther");
     textWriter.Close();
     //close, if not, you cn corrupt the file
     WriteLine($"Does it exists? : {Path.Exists(textFile)}");

     //backup
     //copy the data from the original file into .bak file
     File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite:true);
     WriteLine($"Does backup exists? : {Path.Exists(backupFile)}");

     //assasinate File
     File.Delete(textFile);
     WriteLine($"Does it exists? : {Path.Exists(textFile)}");

     //READ from file
     WriteLine($"Reading Contents from {backupFile}");
     StreamReader textReader = File.OpenText(backupFile);
     WriteLine(textReader.ReadToEnd());
     textReader.Close();
    
#endregion