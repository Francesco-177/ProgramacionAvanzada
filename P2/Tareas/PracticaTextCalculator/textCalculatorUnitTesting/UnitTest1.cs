namespace textcalculatorunittesting;
using textcalculator;

using static System.IO.Directory; // Create or kill folders
using static System.IO.Path; // Creates URLS // C://Documentos...
using static System.Environment; // OS, Users, permissions
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Diagnostics;

public class UnitTest1{
     [Fact]
    public void AddWithIntegersTest(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile.txt");
        string expectedFile = Combine(dir, "expectedFile.txt");

        List<string> linesToWrite = new List<string>{
            "3", "+", "4", "res ="
        };
        List<string> expectedLines = new List<string>{
            "3", "+", "4", "res =7"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void SubtractWithIntegersTest(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile.txt");
        string expectedFile = Combine(dir, "expectedFile.txt");

        List<string> linesToWrite = new List<string>{
            "5", "-", "3", "res ="
        };
        List<string> expectedLines = new List<string>{
            "5", "-", "3", "res =2"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void MultiplyWithIntegersTest()
    {
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile.txt");
        string expectedFile = Combine(dir, "expectedFile.txt");

        List<string> linesToWrite = new List<string>{
            "2", "*", "3", "res ="
        };
        List<string> expectedLines = new List<string>{
            "2", "*", "3", "res =6"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void DivideWithIntegersTest()
    {
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile.txt");
        string expectedFile = Combine(dir, "expectedFile.txt");

        List<string> linesToWrite = new List<string>{
            "6", "/", "2", "res ="
        };
        List<string> expectedLines = new List<string>{
            "6", "/", "2", "res =3"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void AddWithFractionsTest(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile.txt");
        string expectedFile = Combine(dir, "expectedFile.txt");

        List<string> linesToWrite = new List<string>{
            "1/3", "+", "4/7", "res ="
        };
        List<string> expectedLines = new List<string>{
            "1/3", "+", "4/7", "res =19/21"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void SubtractWithFractionsTest(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile_Subtract.txt");
        string expectedFile = Combine(dir, "expectedFile_Subtract.txt");

        List<string> linesToWrite = new List<string>{
            "3/4", "-", "1/2", "res ="
        };
        List<string> expectedLines = new List<string>{
            "3/4", "-", "1/2", "res =1/4"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void MultiplyWithFractionsTest(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile_Multiply.txt");
        string expectedFile = Combine(dir, "expectedFile_Multiply.txt");

        List<string> linesToWrite = new List<string>{
            "2/3", "*", "5/8", "res ="
        };
        List<string> expectedLines = new List<string>{
            "2/3", "*", "5/8", "res =5/12"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void VariousIntOperations(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile_Multiply.txt");
        string expectedFile = Combine(dir, "expectedFile_Multiply.txt");

        List<string> linesToWrite = new List<string>{
            "3", "*", "8", "res =","5", "+", "3", "res ="
        };
        List<string> expectedLines = new List<string>{
            "3", "*", "8", "res =24","5", "+", "3", "res =8"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void VariousFractionalOperations(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile_Multiply.txt");
        string expectedFile = Combine(dir, "expectedFile_Multiply.txt");

        List<string> linesToWrite = new List<string>{
            "3/4", "*", "8/8", "res =","1/2", "+", "2/2", "res ="
        };
        List<string> expectedLines = new List<string>{
            "3/4", "*", "8/8", "res =3/4","1/2", "+", "2/2", "res =3/2"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    public void VariousFractionalAndIntOperations(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir, "testFile_Multiply.txt");
        string expectedFile = Combine(dir, "expectedFile_Multiply.txt");

        List<string> linesToWrite = new List<string>{
            "4", "+", "8", "res =","1/2", "+", "2/2", "res =","3/4", "*", "8/8", "res =","5", "*", "3", "res ="
        };
        List<string> expectedLines = new List<string>{
            "4", "+", "8", "res =12","1/2", "+", "2/2", "res =3/2","3/4", "*", "8/8", "res =3/4","5", "*", "3", "res =15"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);
        File.WriteAllLines(expectedFile, expectedLines);

        TextCalculator textCalculator = new();

        // Act: Read the file and perform operations
        textCalculator.ProcessFile(testFile);

        // Assert: Read the file again to check if the results were written correctly
        List<string> linesRead = File.ReadAllLines(testFile).ToList();
        List<string> expectedLinesRead = File.ReadAllLines(expectedFile).ToList();

        Assert.Equal(expectedLinesRead, linesRead);

        // Delete the temporary test files
        File.Delete(testFile);
        File.Delete(expectedFile);
    }

    [Fact]
    public void InvalidOperationFormatException(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "8", "@", "7","res ="
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if a FormatException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<FormatException>(ex);
        }
        //Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void AddStringWithInt(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "amongus", "+", "3"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if a FormatException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<FormatException>(ex);
        }

        // Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void DivideByZeroException(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "7", "/", "0","res ="
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if a DivideByZeroException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<DivideByZeroException>(ex);
        }
        //Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void OverflowException(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "9999999999999999", "*", "1000000000"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if an OverflowException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<OverflowException>(ex);
        }

        // Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void UnderflowException(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "-9999999999999999", "*", "1000000000"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if an OverflowException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<OverflowException>(ex);
        }

        // Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void ArgumentNullExceptionTest(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "1", "*", ""
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if an OverflowException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<ArgumentNullException>(ex);
        }

        // Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void ArgumentOfRangeException(){
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFile = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string>{
            "6", "/"
        };

        // Create a temporary test file and write lines to it
        File.WriteAllLines(testFile, linesToWrite);

        TextCalculator textCalculator = new();

        // Act and Assert: Check if an OverflowException is thrown
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<ArgumentOutOfRangeException>(ex);
        }

        // Delete the temporary test file
        File.Delete(testFile);
    }

    [Fact]
    public void FileNotFoundException(){
        string testFile = "textFile.txt";
        TextCalculator textCalculator = new();
        try{
            //Act
            textCalculator.ProcessFile(testFile);
        }
        catch(Exception ex){
            //Assert
            Assert.IsType<FileNotFoundException>(ex);
        }
    }

    [Fact]
    public void ExtractOperandsAndOperatorTest()
    {
        // Arrange
        string operation = "5+3";
        
        // Act
        var result = TextCalculator.ExtractOperandsAndOperator(operation);
        
        // Assert
        Assert.Equal(5, result.num1);
        Assert.Equal(3, result.num2);
        Assert.Equal('+', result.oper);
    }

    // Test for AddFractions method
    [Fact]
    public void AddFractionsTest()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4 }; // 1/2 + 3/4
        
        // Act
        var result = TextCalculator.AddFractions(numbers);
        
        // Assert
        Assert.Equal("5/4", result);
    }

    // Test for ProcessFile method
    [Fact]
    public void ProcessFileTest()
    {
        // Arrange
        string dir = Combine("C:", "Users", "Gusta", "PA17BAgo-Dic2023", "PracticaTextCalculator", "TextFiles");
        string testFilePath = Combine(dir,"testFile.txt");
        List<string> linesToWrite = new List<string> { "1+2", "res =" };
        File.WriteAllLines(testFilePath, linesToWrite);
        TextCalculator textCalculator = new TextCalculator();

        // Act
        var result = textCalculator.ProcessFile(testFilePath);

        // Assert
        Assert.Equal(testFilePath, result);

        // Clean up
        File.Delete(testFilePath);
    }
}
