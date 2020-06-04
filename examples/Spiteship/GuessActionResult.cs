namespace SpiteBattleship
{
    class GuessActionResult : Spite.Actions.IActionResult
    {
        public bool Success { get; }

        public readonly int TargetedX;

        public readonly int TargetedY;

        public GuessActionResult(bool success, int x, int y)
        {
            Success = success;
            TargetedX = x;
            TargetedY = y;
        }
    }
}
