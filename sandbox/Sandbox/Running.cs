public class Running : Activity
    {
        private double _distance; // in miles

        public Running(string date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;
        public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;
        public override double GetPace() => GetMinutes() / GetDistance();
    }