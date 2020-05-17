namespace SpiteBattleship
{
    struct ShipSegment
    {
        bool WasHit;

        public readonly ShipEntity Ship;

        public ShipSegment(ShipEntity ship)
        {
            Ship = ship;
            WasHit = false;
        }

        public void Hit()
        {
            if (WasHit) return;
            WasHit = true;
            if (Ship != null)
            {
                Ship.TakeHit();
            }
        }

        public override string ToString()
        {
            if (WasHit && Ship != null)
                return "H";
            else if (WasHit && Ship == null)
                return "M";
            else if (Ship != null)
                return "S";
            else
                return ".";
        }
    }
}
