namespace CompanieZboruri.model;

public class Purchase
{
    private int purchaseID;

    private int flightID;

    private int userID;

    private string clientName;
    
    private string clientAddress;

    private int noSeats;

    public Purchase(int purchaseId, int flightId, int userId, string clientName, string clientAddress, int noSeats)
    {
        this.purchaseID = purchaseId;
        this.flightID = flightId;
        this.userID = userId;
        this.clientName = clientName;
        this.clientAddress = clientAddress;
        this.noSeats = noSeats;
    }

    public int PurchaseId
    {
        get { return purchaseID; }
        set { purchaseID = value; }
    }

    public int FlightId
    {
        get { return flightID; }
        set { flightID = value; }
    }

    public int UserId
    {
        get { return userID; }
        set { userID = value; }
    }
    
    public string ClientName
    {
        get { return clientName; }
        set { clientName = value; }
    }
    
    public string ClientAddress
    {
        get { return clientAddress; }
        set { clientAddress = value; }
    }
    
    public int NoSeats
    {
        get { return noSeats; }
        set { noSeats = value; }
    }
    

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Purchase other = (Purchase)obj;
        return purchaseID == other.purchaseID &&
               flightID == other.flightID &&
               userID == other.userID &&
               clientName == other.clientName &&
               clientAddress == other.clientAddress &&
               noSeats == other.noSeats;
    }

    public override string ToString()
    {
        return purchaseID.ToString() + flightID.ToString() + userID.ToString() + clientName + clientAddress+ noSeats.ToString() + '\n';
    }
}