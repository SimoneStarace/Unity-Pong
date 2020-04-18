namespace Managers
{
    /// <summary>
    /// Class that contains some options.
    /// </summary>
    public static class GameManager
    {
        /// <summary>
        /// Static int that tells how many points each player must reach for win the game.
        /// </summary>
        public static int MaxScore { get; set; } = 10;
        /// <summary>
        /// Static property that tells if the sounds should be played.
        /// </summary>
        public static bool IsSoundOn { get; set; } = true;
        /// <summary>
        /// Enumerator for specify the difficulty of the AI
        /// </summary>
        public enum Difficulty : byte { Easy, Normal, Hard }
        /// <summary>
        /// The difficulty of the AI
        /// </summary>
        public static Difficulty AIDiff { get; set; } = Difficulty.Normal;
        /// <summary>
        /// Boolean that tells if player 2 is controlled by AI.
        /// </summary>
        public static bool IsPlayer2AIOn { get; set; } = false;
    } 
}