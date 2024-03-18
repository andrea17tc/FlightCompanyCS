namespace CompanieZbor.model;

public class Flight : Entity<int>
{ 
    private string destination;
    private DateTime dateTime;
    private string airport;
    private int noTotalSeats;

    public Flight(string destination, DateTime dateTime, string airport, int noSeats)
    {
        this.destination = destination;
        this.dateTime = dateTime;
        this.airport = airport;
        this.noTotalSeats = noSeats;
    }

    public string Destination
    {
        get { return destination; }
        set { destination = value; }
    }

    public DateTime DateTime
    {
        get { return dateTime; }
        set { dateTime = value; }
    }

    public string Airport
    {
        get { return airport; }
        set { airport = value; }
    }

    public int NoTotalSeats
    {
        get { return noTotalSeats; }
        set { noTotalSeats = value; }
    }

    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;

        if (obj == null || GetType() != obj.GetType())
            return false;

        Flight flight = (Flight)obj;
        return noTotalSeats == flight.noTotalSeats &&
               destination == flight.destination &&
               dateTime == flight.dateTime &&
               airport == flight.airport;
    }

    public override string ToString()
    {
        return $"Flight{{destination='{destination}', dateTime={dateTime}, airport='{airport}', noSeats={noTotalSeats}}}";
    }
}
