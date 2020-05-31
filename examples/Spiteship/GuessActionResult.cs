namespace SpiteBattleship
{
    class GuessActionResult : Spite.Actions.IActionResult
    {
        public bool Success { get; }

        public GuessActionResult(bool success)
        {
            Success = success;
        }
    }
}
