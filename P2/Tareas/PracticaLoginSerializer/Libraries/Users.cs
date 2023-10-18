namespace Libraries;

public class User{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public int? DoB { get; set; }
    public string? UserType { get; set; }

    public User(){} 
    public User(int id, string firstName, string lastName, string password, int dob, string userType){
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        DoB = dob;
        UserType = userType;
    }
}
