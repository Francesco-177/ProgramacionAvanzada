namespace PracticaLoginSerializerUnitTesting;
using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment; 

using Libraries;
using loginSerializer;

public class UnitTest1{

    [Fact]
    public void TestFailedPSWUpdate(){
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.xml";
        string testJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.json";

        string OgXML = File.ReadAllText(testXML);
        string OgJSON = File.ReadAllText(testJSON);

        LoginSerializer loginSerializer = new();
        bool Actual = loginSerializer.UpdatePSW(20300694,"VIVANLOSPUMASYVIVAHAROS", testXML, testJSON); 

        File.WriteAllText(testXML, OgXML);
        File.WriteAllText(testJSON, OgJSON);

        Assert.False(Actual);
    }

     [Fact]
    public void TestFailedLogin(){
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.xml";

        LoginSerializer loginSerializer = new();
        bool Actual = loginSerializer.Login("Francisco", "VIVANLOSPUMASYVIVAHAROS", testXML); // Act
        Assert.False(Actual);
    }

    [Fact]
    public void TestSuccesfullPSWUpdate(){
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.xml";
        string testJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.json";

        //Store guardar contenido original
        string OgXML = File.ReadAllText(testXML);
        string OgJSON = File.ReadAllText(testJSON);

        LoginSerializer loginSerializer = new();
        bool Actual = loginSerializer.UpdatePSW(20300692,"VIVANLOSPUMASYVIVAHAROS", testXML, testJSON); // Act

        File.WriteAllText(testXML, OgXML);
        File.WriteAllText(testJSON, OgJSON);

        Assert.True(Actual);
    }

        [Fact]
    public void TestSignUP(){
        string actualXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\actual.xml";
        string actualJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\actual.json";
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.xml";
        string testJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.json";

        string OgActualXML = File.ReadAllText(actualXML);
        string OgActualJSON = File.ReadAllText(actualJSON);

        LoginSerializer loginSerializer = new();
        User newUser = new User(20300692, loginSerializer.CalculateHashSHA256("Francisco"), loginSerializer.CalculateHashSHA256("Jimenez"), loginSerializer.CalculateHashSHA256("GoyaGoya69"), 2005, "Estudiante");
        loginSerializer.SignUP(newUser, actualXML, actualJSON);

        string ActualXML = File.ReadAllText(actualXML);
        string ActualJSON = File.ReadAllText(actualJSON);
        string TestXML = File.ReadAllText(testXML);
        string TestJSON = File.ReadAllText(testJSON);

        //restaurar valores originales
        File.WriteAllText(actualXML, OgActualXML);
        File.WriteAllText(actualJSON, OgActualJSON);

        Assert.Equal(ActualXML,TestXML); 
        Assert.Equal(ActualJSON,TestJSON); 
    }


    [Fact]
    public void TestFailedDeviceRemoval(){
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test2.xml";
        string testJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test2.json";

         
        string OgXML = File.ReadAllText(testXML);
        string OgJSON = File.ReadAllText(testJSON);

        LoginSerializer loginSerializer = new();
        bool Actual = loginSerializer.RemoveDevice(2, testXML, testJSON); // Act

         
        File.WriteAllText(testXML, OgXML);
        File.WriteAllText(testJSON, OgJSON);

        Assert.False(Actual);
    }

        [Fact]
    public void TestSuccesfullDeviceRemoval(){
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test2.xml";
        string testJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test2.json";

         
        string OgXML = File.ReadAllText(testXML);
        string OgJSON = File.ReadAllText(testJSON);

        LoginSerializer loginSerializer = new();
        bool Actual = loginSerializer.RemoveDevice(1, testXML, testJSON); // Act

         
        File.WriteAllText(testXML, OgXML);
        File.WriteAllText(testJSON, OgJSON);

        Assert.True(Actual);
    }


    [Fact]
    public void TestFailedDeviceUpdate(){
        string testDeviceXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test3.xml";
        string testDeviceJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test3.json";

         
        string OgXML = File.ReadAllText(testDeviceXML);
        string OgJSON = File.ReadAllText(testDeviceJSON);

        LoginSerializer loginSerializer = new();
        Device device = new(1, "A25", "Test", 2018, "IWTKMS", true, 2388713, 2348.6);
        bool Actual = loginSerializer.UpdateDevice(5, device, testDeviceXML, testDeviceJSON); // Act

         
        File.WriteAllText(testDeviceXML, OgXML);
        File.WriteAllText(testDeviceJSON, OgJSON);

        Assert.False(Actual);
    }

    [Fact]
    public void TestGenerateReport(){
        string testDeviceXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test3.xml";
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test2.xml";
        string testJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test2.json";

         
        string OgXML = File.ReadAllText(testXML);
        string OgJSON = File.ReadAllText(testJSON);

        LoginSerializer loginSerializer = new();
        loginSerializer.Report(1, testDeviceXML, testXML, testJSON); // Act

        string expectedContent = File.ReadAllText(testDeviceXML);
        string actualContent = File.ReadAllText(testXML);

         
        File.WriteAllText(testXML, OgXML);
        File.WriteAllText(testJSON, OgJSON);

        Assert.Equal(expectedContent,actualContent);
    }

    [Fact]
    public void TestSuccesfullDeviceUpdate(){
        string testDeviceXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test3.xml";
        string testDeviceJSON = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test3.json";

         
        string OgXML = File.ReadAllText(testDeviceXML);
        string OgJSON = File.ReadAllText(testDeviceJSON);

        LoginSerializer loginSerializer = new();
        Device device = new(1, "A25", "Test", 2018, "IWTKMS", true, 2388713, 2348.6);
        bool Actual = loginSerializer.UpdateDevice(1, device, testDeviceXML, testDeviceJSON); // Act

         
        File.WriteAllText(testDeviceXML, OgXML);
        File.WriteAllText(testDeviceJSON, OgJSON);

        Assert.True(Actual);
    }



    [Fact]
    public void TestSuccesfullLogin(){
        string testXML = @"C:\Users\HP\Documents\ProgramacionAvanzada\P2\Tareas\PracticaLoginSerializer\TestFiles\Test.xml";

        LoginSerializer loginSerializer = new();
        bool Actual = loginSerializer.Login("Francisco", "GoyaGoya69", testXML); // Act
        Assert.True(Actual);
    }

}