namespace Spite.Actions
{
    /// <summary>
    /// A simple implementation of IActionResult for a failed action with no further context.
    /// </summary>
    public class ActionFailedResult : IActionResult
    {
        /// <summary>
        /// Returns false.
        /// </summary>
        public bool Success => false;
    }
}
