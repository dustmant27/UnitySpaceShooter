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

    public static void RestartLevel()
    {
        GameOver = false;
        SceneManager.LoadScene(CurrentScene);
    }
}
