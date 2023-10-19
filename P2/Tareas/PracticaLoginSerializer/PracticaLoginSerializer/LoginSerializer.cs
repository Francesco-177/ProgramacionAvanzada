namespace loginSerializer;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;

using Libraries;
using System.Collections.Specialized;

public class LoginSerializer{
    public void SignUP(User newUser, string dirXML, string dirJSON){
        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserializar archivo a lista de usuarios
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        Users.Add(newUser);

        using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
            // serializar la lista de usuarios a xml
            xs.Serialize(stream, Users);
        }

        using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
            // serializar la lista a Json
            Newtonsoft.Json.JsonSerializer jss = new();
            jss.Serialize(jsonStream, Users);
        }
    }
    
    // revisar credenciales
    public bool Login(string Name, string Password, string dirXML){
        string HashName = CalculateHashSHA256(Name);
        string HashPassword = CalculateHashSHA256(Password);

        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));
        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserializar archivo a lista de usuarios
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        foreach (User U in Users){
            if (U.FirstName == HashName && U.Password == HashPassword){
                return true; 
            }
        }
        return false; 
    }

    // Quitar usuario por id
    public bool RemoveUser(int id, string dirXML, string dirJSON){
        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserializar archivo a lista de usuarios
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        for (int i = 0; i < Users.Count; i++){
            if (Users[i].ID == id){
                WriteLine("Removed user");
                Users.RemoveAt(i);

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    //serializar la lista a xml
                    xs.Serialize(stream, Users);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    // serializar la lista a json
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Users);
                }

                return true; 
            }
        }
        return false;
    }


    // Function to update the password of a user by ID
    public bool UpdatePSW(int id, string NewPassword, string dirXML, string dirJSON){
        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            //Deserializar la lista a xml
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        for (int i = 0; i < Users.Count; i++){
            if (Users[i].ID == id){
                NewPassword = CalculateHashSHA256(NewPassword);
                Users[i].Password = NewPassword;
                WriteLine("Updated password");

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    //serializar la lista a xml
                    xs.Serialize(stream, Users);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    //serializar la lista a json
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Users);
                }

                return true; // Exit the loop once the user is found and password is updated
            }
        }
        return false;
    }

    // Agregar nuevo dispositivo
    public void AddDevice(Device device, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            //deserializar xml a lista de dispositivos
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        Devices.Add(device);

        using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
            //serializar la lista a xml
            xs.Serialize(stream, Devices);
        }

        using (StreamWriter jsonStream = new StreamWriter(dirJSON, false))
        {
            //serializar la lista a json
            Newtonsoft.Json.JsonSerializer jss = new();
            jss.Serialize(jsonStream, Devices);
        }
    }

    // agregar dispositivo por id
    public bool UpdateDevice(int id, Device device, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        for (int i = 0; i < Devices.Count; i++){
            if (Devices[i].ID == id){
                Devices[i] = device;
                WriteLine("Updated device");

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    xs.Serialize(stream, Devices);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Devices);
                }

                return true; // salir una vez que se agrego el dispositivo
            }
        }
        return false;
    }

    // eliminar dispositivo por id
    public bool RemoveDevice(int id, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        for (int i = 0; i < Devices.Count; i++){
            if (Devices[i].ID == id){
                WriteLine("Removed device");
                Devices.RemoveAt(i);

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    xs.Serialize(stream, Devices);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Devices);
                }

                return true; 
            }
        }
        return false;
    }

    // elaborar reporte
    public void Report(int I, string dirXmlDevices, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXmlDevices, FileMode.Open)){
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        List<Device>? orderedDevices = null;
        switch (I){
            case 1:
                {
                    orderedDevices = Devices.OrderBy(device => device.ID).ToList();
                }
                break;
            case 2:
                {
                    orderedDevices = Devices.OrderBy(device => device.Model).ToList();
                }
                break;
            case 3:
                {
                    orderedDevices = Devices.OrderBy(device => device.Description).ToList();
                }
                break;
            case 4:
                {
                    orderedDevices = Devices.OrderBy(device => device.YearEntered).ToList();
                }
                break;
            case 5:
                {
                    orderedDevices = Devices.OrderBy(device => device.BrandName).ToList();
                }
                break;
            case 6:
                {
                    orderedDevices = Devices.OrderBy(device => device.Category).ToList();
                }
                break;
            case 7:
                {
                    orderedDevices = Devices.OrderBy(device => device.InitialPrice).ToList();
                }
                break;
            case 8:
                {
                    orderedDevices = Devices.OrderBy(device => device.ActualPrice).ToList();
                }
                break;
        }

        using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
            xs.Serialize(stream, orderedDevices);
        }

        using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
            Newtonsoft.Json.JsonSerializer jss = new();
            jss.Serialize(jsonStream, orderedDevices);
        }
    }

    // Calcular SHA256 hash
    public string CalculateHashSHA256(string? inputS){
        string input = inputS ?? "0";
        using (SHA256 sha256Hash = SHA256.Create()){
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++){
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
