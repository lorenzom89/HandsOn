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


        public void ResetAll()
        {
            ShowAirport=false;
            ShowBaggage=false;
            ShowCity=false;
            ShowFlight=false;
            ShowFlightClass=false;
            ShowPassenger=false;
            ShowTicket = false;
        }

    }
}
