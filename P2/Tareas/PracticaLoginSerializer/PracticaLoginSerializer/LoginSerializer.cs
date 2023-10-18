namespace loginSerializer;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text;

using Libraries;
using System.Collections.Specialized;

public class LoginSerializer{
    // Function to add a new user
    public void SignUP(User newUser, string dirXML, string dirJSON){
        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of users
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        Users.Add(newUser);

        using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
            // Serialize the updated list of users back to XML
            xs.Serialize(stream, Users);
        }

        using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
            // Serialize the updated list of users to JSON
            Newtonsoft.Json.JsonSerializer jss = new();
            jss.Serialize(jsonStream, Users);
        }
    }
    
    // Function to check login credentials
    public bool Login(string Name, string Password, string dirXML){
        string HashName = CalculateHashSHA256(Name);
        string HashPassword = CalculateHashSHA256(Password);

        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));
        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of users
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        foreach (User U in Users){
            if (U.FirstName == HashName && U.Password == HashPassword){
                return true; // Successful login
            }
        }
        return false; // Login failed
    }

    // Function to remove a user by ID
    public bool RemoveUser(int id, string dirXML, string dirJSON){
        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of devices
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        for (int i = 0; i < Users.Count; i++){
            if (Users[i].ID == id){
                WriteLine("Removed user");
                Users.RemoveAt(i);

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    // Serialize the updated list of devices back to XML
                    xs.Serialize(stream, Users);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    // Serialize the updated list of devices to JSON
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Users);
                }

                return true; // Exit the loop once the device is found and removed
            }
        }
        return false;
    }


    // Function to update the password of a user by ID
    public bool UpdatePSW(int id, string NewPassword, string dirXML, string dirJSON){
        List<User>? Users = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<User>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of users
            Users = xs.Deserialize(xmlLoad) as List<User> ?? new List<User>();
        }

        for (int i = 0; i < Users.Count; i++){
            if (Users[i].ID == id){
                NewPassword = CalculateHashSHA256(NewPassword);
                Users[i].Password = NewPassword;
                WriteLine("Updated password");

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    // Serialize the updated list of users back to XML
                    xs.Serialize(stream, Users);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    // Serialize the updated list of users to JSON
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Users);
                }

                return true; // Exit the loop once the user is found and password is updated
            }
        }
        return false;
    }

    // Function to add a new device
    public void AddDevice(Device device, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of 'Device'
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        Devices.Add(device);

        using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
            // Serialize the updated list of 'Device' back to XML
            xs.Serialize(stream, Devices);
        }

        using (StreamWriter jsonStream = new StreamWriter(dirJSON, false))
        {
            // Serialize the updated list of 'Device' to JSON
            Newtonsoft.Json.JsonSerializer jss = new();
            jss.Serialize(jsonStream, Devices);
        }
    }

    // Function to update an existing device by ID
    public bool UpdateDevice(int id, Device device, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of 'Device'
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        for (int i = 0; i < Devices.Count; i++){
            if (Devices[i].ID == id){
                Devices[i] = device;
                WriteLine("Updated device");

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    // Serialize the updated list of 'Device' back to XML
                    xs.Serialize(stream, Devices);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    // Serialize the updated list of 'Device' to JSON
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Devices);
                }

                return true; // Exit the loop once the 'Device' is found and updated
            }
        }
        return false;
    }

    // Function to remove an device by ID
    public bool RemoveDevice(int id, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXML, FileMode.Open)){
            // Deserialize XML file into a list of devices
            Devices = xs.Deserialize(xmlLoad) as List<Device> ?? new List<Device>();
        }

        for (int i = 0; i < Devices.Count; i++){
            if (Devices[i].ID == id){
                WriteLine("Removed device");
                Devices.RemoveAt(i);

                using (FileStream stream = new FileStream(dirXML, FileMode.Create)){
                    // Serialize the updated list of devices back to XML
                    xs.Serialize(stream, Devices);
                }

                using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
                    // Serialize the updated list of devices to JSON
                    Newtonsoft.Json.JsonSerializer jss = new();
                    jss.Serialize(jsonStream, Devices);
                }

                return true; // Exit the loop once the device is found and removed
            }
        }
        return false;
    }

    // Function to generate a report based on specified criteria
    public void Report(int I, string dirXmlDevices, string dirXML, string dirJSON){
        List<Device>? Devices = null;
        XmlSerializer xs = new XmlSerializer(typeof(List<Device>));

        using (FileStream xmlLoad = File.Open(dirXmlDevices, FileMode.Open)){
            // Deserialize XML file into a list of 'Device'
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
            // Serialize the ordered list of 'Device' back to XML
            xs.Serialize(stream, orderedDevices);
        }

        using (StreamWriter jsonStream = new StreamWriter(dirJSON, false)){
            // Serialize the ordered list of 'Device' to JSON
            Newtonsoft.Json.JsonSerializer jss = new();
            jss.Serialize(jsonStream, orderedDevices);
        }
    }

    // Function to calculate SHA256 hash
    public string CalculateHashSHA256(string? inputS){
        string input = inputS ?? "0";
        using (SHA256 sha256Hash = SHA256.Create()){
            // Convert the text to bytes and calculate the hash
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert the hash to a hexadecimal string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++){
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
