public abstract class Activity
    {
        private string _date;
        private int _minutes;

        protected Activity(string date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public string GetDate() => _date;
        public int GetMinutes() => _minutes;

        // Abstract methods to be implemented by derived classes
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Virtual method to get the activity summary
        public virtual string GetSummary()
        {
            return $"{_date} ({_minutes} min): Distance {GetDistance():0.0} miles, " +
                   $"Speed {GetSpeed():0.0} mph, Pace {GetPace():0.0} min per mile";
        }
    }