namespace CompanieZbor.model;

public class Purchase : Entity<int>
{
    private Flight flight;

    private User user;

    private Tourist tourist;
    
    private string clientAddress;

    private int noBookedSeats;

    public Purchase(Flight flight, User user, Tourist tourist, string clientAddress, int noBookedSeats)
    {
        this.flight = flight;
        this.user = user;
        this.tourist = tourist;
        this.clientAddress = clientAddress;
        this.noBookedSeats = noBookedSeats;
    }

    public Flight Flight
    {
        get { return flight; }
        set { flight = value; }
    }

    public User User
    {
        get { return user; }
        set { user = value; }
    }
    
    public Tourist Tourist
    {
        get { return tourist; }
        set { tourist = value; }
    }
    
    public string ClientAddress
    {
        get { return clientAddress; }
        set { clientAddress = value; }
    }
    
    public int NoBookedSeats
    {
        get { return noBookedSeats; }
        set { noBookedSeats = value; }
    }
    

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Purchase other = (Purchase)obj;
        return flight == other.flight &&
               user == other.user &&
               tourist == other.tourist &&
               clientAddress == other.clientAddress &&
               noBookedSeats == other.noBookedSeats;
    }

    public override string ToString()
    {
        return flight.ToString() + user.ToString() + tourist.ToString() + clientAddress+ noBookedSeats.ToString() + '\n';
    }
}