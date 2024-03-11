namespace CompanieZboruri.model;

public class User
{
    private int userID;
    private string username;
    private string password;


    public User(int userId, string username, string password)
    {
        this.userID = userId;
        this.username = username;
        this.password = password;
    }

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        User other = (User)obj;
        return userID == other.userID &&
               username == other.username &&
               password == other.password;
    }

    public override string ToString()
    {
        return userID.ToString() + username + password + '\n';
    }
}