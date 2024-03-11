namespace CompanieZboruri.model;

public class Trip
{
    private int touristID;
    private int purchaseID;

    public Trip(int flightId, int purchaseId)
    {
        this.touristID = touristID;
        this.purchaseID = purchaseId;
    }

    public int TouristId
    {
        get { return touristID; }
        set { touristID = value; }
    }

    public int PurchaseID
    {
        get { return purchaseID; }
        set { purchaseID = value; }
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Trip other = (Trip)obj;
        return touristID == other.touristID &&
               purchaseID == other.purchaseID;
    }

    public override string ToString()
    {
        return touristID.ToString() + purchaseID.ToString() + '\n';
    }
}