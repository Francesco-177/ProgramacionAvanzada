using System.Xml.Serialization;

using Libraries;
using loginSerializer;

bool aux = false;
LoginSerializer loginSerializer = new();
string dirXmlUsers = @"C:\Users\HP\PracticaLoginSerializer\TestFiles\Users.xml";
string dirJsonUsers = @"C:\Users\HP\PracticaLoginSerializer\TestFiles\Users.json";
string dirXmlDevices = @"C:\Users\HP\PracticaLoginSerializer\TestFiles\Devices.xml";
string dirJsonDevices = @"C:\Users\HP\PracticaLoginSerializer\TestFiles\Devices.json";
string dirXmlReports = @"C:\Users\HP\PracticaLoginSerializer\TestFiles\Reports.xml";
string dirJsonReports = @"C:\Users\HP\PracticaLoginSerializer\TestFiles\Reports.json";

while(aux == false){ 
WriteLine("Select an option \n [1]Login \n [2]SignUP  \n [3]ChangeInfo/Options for devices \n [X]Exit");
string? OP = ReadLine();

switch (OP){
    case "1":{ //entrar con un usuario
        Write("Login");
        WriteLine("Enter first name");
        string? NameN = ReadLine();
        string Name = NameN ?? "";

        WriteLine("Enter password");
        string? passwordRaw = ReadLine();
        string password = passwordRaw ?? "";
        WriteLine(loginSerializer.Login(Name,password,dirXmlUsers));
        aux = loginSerializer.Login(Name,password,dirXmlUsers); 
        break;
    }

    case "2":{ //ingresar nuevo usuario
        WriteLine("Sign UP");
        WriteLine("Enter user's ID:");
        string? idRaw = ReadLine();
        int id = int.Parse(idRaw ?? "0" );

        WriteLine("Enter user's first name");
        string? firstName = ReadLine();
        firstName = loginSerializer.CalculateHashSHA256(firstName);

        WriteLine("Enter user's last name");
        string? lastName = ReadLine();
        lastName = loginSerializer.CalculateHashSHA256(lastName);

        WriteLine("Enter password");
        string? passwordRaw = ReadLine();
        string password = loginSerializer.CalculateHashSHA256(passwordRaw);
        
        WriteLine("Enter DoB");
        String? DoBRaw = ReadLine();
        int DoB = int.Parse(DoBRaw ?? "0");

        WriteLine("Enter user's type");
        String? userTypeRaw = ReadLine();
        string userType = userTypeRaw ?? "";
        User newUser = new User(id, firstName, lastName, password, DoB, userType);
        loginSerializer.SignUP(newUser, dirXmlUsers, dirJsonUsers);
        break;
    }

    case "3":{// manipular las opciones de los dispositivos etc...
        WriteLine("Select an option \n [1]Add a device \n [2]Update a device \n [3]Delete a device");
        WriteLine(" [4]Change your password \n [5]Generate a report \n [6]Remove User \n [X]Exit");
        string? OP2=ReadLine();

        switch(OP2){
            case "1":{
                WriteLine("Add a device");
                WriteLine("Enter the ID");
                int id = int.Parse(ReadLine() ?? "0");

                WriteLine("Enter the model");
                string? ModelRaw = ReadLine();
                string Model = ModelRaw ?? "";

                WriteLine("Enter a description");
                string? DescriptionRaw = ReadLine();
                string Description = DescriptionRaw ?? "";

                WriteLine("Enter the year the device entered");
                string? YearEnteredRaw = ReadLine();
                int YearEntered = int.TryParse(YearEnteredRaw, out int year) ? year : 0;

                WriteLine("Enter the brand");
                string? BrandNameRaw = ReadLine();
                string BrandName = BrandNameRaw ?? "";

                WriteLine("Enter the category; true for teachers only, false if not");
                string? CategoriaN = ReadLine();
                bool Category = bool.TryParse(CategoriaN, out bool category) && category;

                WriteLine("Enter the initial price");
                string? InitialPriceRaw = ReadLine();
                double initialPrice = double.TryParse(InitialPriceRaw, out double price) ? price: 0.0;

                WriteLine("Enter the actual price");
                string? actualPriceRaw = ReadLine();
                double actualPrice = double.TryParse(actualPriceRaw, out double actual) ? actual : 0.0;

                Device NewDevice = new(id, Model, Description, YearEntered, BrandName, Category, initialPrice, actualPrice);
                loginSerializer.AddDevice(NewDevice, dirXmlDevices, dirJsonDevices);
                break;
            }

            case "2":{
                WriteLine("Update");
                WriteLine("Enter the ID");
                int id = int.Parse(ReadLine() ?? "0");

                WriteLine("Enter the model");
                string? ModelRaw = ReadLine();
                string Model = ModelRaw ?? "";

                WriteLine("Enter the description");
                string? DescriptionRaw = ReadLine();
                string Description = DescriptionRaw ?? "";

                WriteLine("Enter the year the device entered");
                string? YearEnteredRaw = ReadLine();
                int YearEntered = int.TryParse(YearEnteredRaw, out int year) ? year : 0;

                WriteLine("Enter the brand");
                string? BrandNameRaw = ReadLine();
                string BrandName = BrandNameRaw ?? "";

                WriteLine("Enter the category; true for teachers only, false if not");
                string? CategoriaN = ReadLine();
                bool Category = bool.TryParse(CategoriaN, out bool category) && category;

                WriteLine("Enter the initial price");
                string? InitialPriceRaw = ReadLine();
                double initialPrice = double.TryParse(InitialPriceRaw, out double price) ? price: 0.0;

                WriteLine("Enter the actual price");
                string? actualPriceRaw = ReadLine();
                double actualPrice = double.TryParse(actualPriceRaw, out double actual) ? actual : 0.0;

                Device updatedDevice = new(id, Model, Description, YearEntered, BrandName, Category, initialPrice, actualPrice);
                WriteLine(loginSerializer.UpdateDevice(id, updatedDevice, dirXmlDevices, dirJsonDevices));
                break;
            }

            case "3":{
                WriteLine("Remove");
                WriteLine("Enter the ID");
                int id = int.Parse(ReadLine() ?? "0");
                WriteLine(loginSerializer.RemoveDevice(id, dirXmlDevices, dirJsonDevices));
                break;
            }

            case "4":{
                WriteLine("Update PSWD");
                WriteLine("Enter the ID");
                int id = int.Parse(ReadLine() ?? "0");

                WriteLine("Enter the new password");
                string? Newpassword = ReadLine();
                Newpassword = Newpassword ?? "";

                WriteLine(loginSerializer.UpdatePSW(id, Newpassword, dirXmlUsers, dirJsonDevices));
                break;
            }

            case "5":{
                WriteLine("Report");
                WriteLine("Order respect with \n [1]ID \n [2]Model \n [3]Description \n [4]Year Entered");
                WriteLine(" [5]Brand Name \n [6]Category \n [7]Initial Price \n [8]Actual Price");
                int order = int.Parse(ReadLine() ?? "1");
                loginSerializer.Report(order, dirXmlDevices, dirXmlReports, dirJsonReports);
                break;
            }

            case "6":{
                WriteLine("Remove user");
                WriteLine("Enter the ID");
                int id = int.Parse(ReadLine() ?? "0");
                WriteLine(loginSerializer.RemoveUser(id, dirXmlUsers, dirJsonUsers));
                break;
            }

            case "X":{
                Write("Exit");
                return;
            }

            default:{
                WriteLine("Enter a valid option");
                break;
            }
        }
        break;
    }

    case "X":{
        Write("Exit");
        return;
    }

    default:{
        WriteLine("Enter a valid option");
        break;
    }
 }
}
