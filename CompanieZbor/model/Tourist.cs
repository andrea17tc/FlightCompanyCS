namespace CompanieZboruri.model;

public class Tourist
{
    private int touristID;

    private string touristName;
    
    public Tourist(int touristID, String touristName) {
        this.touristID = touristID;
        this.touristName = touristName;
    }

    public int TouristID
    {
        get { return touristID; }
        set { touristID = value; }
    }

    public string TouristName
    {
        get { return touristName;  }
        set { touristName = value; }
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Tourist other = (Tourist)obj;
        return touristID == other.touristID &&
               touristName == other.touristName;
    }

    public override string ToString()
    {
        return touristID.ToString() + touristName+ '\n';
    }
}