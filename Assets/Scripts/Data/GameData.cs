using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public static class GameData {
    public enum WeaponType
    {
        beam
    }
    public  static int CurrentScene = 0;
    public static int Money;
    public static int Score;
    public static int HighScore;
    public static WeaponType CurrentWeapon = WeaponType.beam;
    public static int BeamLevel = 0;
    public static bool GameOver = false;

    public static void UpgradeCurrentWeapon()
    {
        switch (CurrentWeapon)
        {
            case WeaponType.beam:
                BeamLevel++;
                break;
        }
    }
    public static void AddScore(int inc)
    {
        Score += inc;
        if (Score > HighScore)
            HighScore = Score;
    }
    public static void RestartLevel()
    {
        if (Score > HighScore)
            HighScore = Score;
        Score = 0;
        GameOver = false;
        BeamLevel = 0;
        SceneManager.LoadScene(CurrentScene);
    }
}
