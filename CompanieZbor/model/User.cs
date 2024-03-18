namespace CompanieZbor.model;

public class User : Entity<int>
{
    private string username;
    private string password;


    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
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
        return username == other.username &&
               password == other.password;
    }

    public override string ToString()
    {
        return username + password + '\n';
    }
}