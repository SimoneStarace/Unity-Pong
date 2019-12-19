﻿using UnityEngine;
/// <summary>
/// Class that contains some options.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Enumerator for specify the difficulty of the AI
    /// </summary>
    public enum Difficulty { Easy,Normal,Hard}
    /// <summary>
    /// The difficulty of the AI
    /// </summary>
    public static Difficulty AIDiff { get; set; } = Difficulty.Normal;
    /// <summary>
    /// Boolean that tells if player 2 is controlled by AI.
    /// </summary>
    public static bool IsPlayer2AIOn { get; set; } = false;
}