namespace Client.ApplicationStates
{
    public class AllState
    {
        //Scope action
        public Action? Action { get; set; }

        //Airport
        public bool ShowAirport { get; set; }
        public void AirportClicked()
        {
            ResetAll();
            ShowAirport = true;
            Action?.Invoke();
        }

        //Baggage
        public bool ShowBaggage { get; set; }
        public void BaggageClicked()
        {
            ResetAll();
            ShowBaggage = true;
            Action?.Invoke();
        }

        //City
        public bool ShowCity { get; set; }
        public void CityClicked()
        {
            ResetAll();
            ShowCity = true;
            Action?.Invoke();
        }

        //Flight
        public bool ShowFlight { get; set; }
        public void FlightClicked()
        {
            ResetAll();
            ShowFlight = true;
            Action?.Invoke();
        }
       
        //FlightClass
        public bool ShowFlightClass { get; set; }
        public void FlightClassClicked()
        {
            ResetAll();
            ShowFlightClass = true;
            Action?.Invoke();
        }

        //Passenger
        public bool ShowPassenger { get; set; }
        public void PassengerClicked()
        {
            ResetAll();
            ShowPassenger = true;
            Action?.Invoke();
        }
        
        //Ticket
        public bool ShowTicket { get; set; }
        public void TicketClicked()
        {
            ResetAll();
            ShowTicket = true;
            Action?.Invoke();
        }

        //User
        public bool ShowUser { get; set; }
        public void UserClicked()
        {
            ResetAll();
            ShowUser = true;
            Action?.Invoke();
        }

        //SearchFligh
        public bool ShowSearchFlight { get; set; } = true;
        public void SearchFlightClicked()
        {
            ResetAll();
            ShowSearchFlight = true;
            Action?.Invoke();
        }

        //Checkin
        public bool ShowCheckInCard { get; set; } = true;
        public void CheckInCard()
        {
            ResetAll();
            ShowCheckInCard = true;
            Action?.Invoke();
        }

        //Checkin
        public bool ShowBagTag { get; set; } = true;
        public void CheckBagTag()
        {
            ResetAll();
            ShowBagTag = true;
            Action?.Invoke();
        }

        public void ResetAll()
        {
            ShowAirport=false;
            ShowBaggage=false;
            ShowCity=false;
            ShowFlight=false;
            ShowFlightClass=false;
            ShowPassenger=false;
            ShowTicket = false;
            ShowUser = false;
            ShowSearchFlight=false;
            ShowCheckInCard = false;
            ShowBagTag=false;   
        }

    }
}
