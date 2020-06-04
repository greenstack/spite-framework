namespace Spite.Actions
{
    /// <summary>
    /// The results of an action.
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        /// If the IActionResult was successful.
        /// </summary>
        bool Success { get; }
    }
}
