using System;

public class Flight
{
    private int flightID;

    private string destination;

    private DateTime dateTime;

    private string airport;

    private int noSeats;

    public Flight(int flightID, string destination, DateTime dateTime, string airport, int noSeats)
    {
        this.flightID = flightID;
        this.destination = destination;
        this.dateTime = dateTime;
        this.airport = airport;
        this.noSeats = noSeats;
    }

    public int FlightID
    {
        get { return flightID; }
        set { flightID = value; }
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

        Flight other = (Flight)obj;
        return flightID == other.flightID &&
               destination == other.destination &&
               dateTime == other.dateTime &&
               airport == other.airport &&
               noSeats == other.noSeats;
    }

    public override string ToString()
    {
        return flightID.ToString() + destination + dateTime.ToString() + airport + noSeats.ToString() + '\n';
    }
}
