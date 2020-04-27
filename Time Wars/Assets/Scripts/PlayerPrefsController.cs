using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_MUSIC_KEY = "master music";

    const string MASTER_EFFECTS_KEY = "master effect";

    const string DIFFICULTY_KEY = "difficulty";

    const string LEVEL_KEY = "level index";

    const string LEVEL_REPEATED = "level repeated";

    const int MIN_VOLUME = 0;
    const int MAX_VOLUME = 1;

    const int MIN_EFFECT = 0;
    const int MAX_EFFECT = 1;

    const float MIN_DIFF = 0f;
    const float MAX_DIFF = 3f;


    public static void SetMasterMusic(bool music)
    {
        if (music)
        {
            PlayerPrefs.SetInt(MASTER_MUSIC_KEY, 1);
        }
        else
        {
            PlayerPrefs.SetInt(MASTER_MUSIC_KEY, 0);
        }
    }

    public static void SetMasterEffects(bool effect)
    {
        if (effect)
        {
            PlayerPrefs.SetInt(MASTER_EFFECTS_KEY, 1);
        }
        else
        {
            PlayerPrefs.SetInt(MASTER_EFFECTS_KEY, 0);
        }
    }

    public static void SetDiff(float diff)
    {
        if (diff >= MIN_DIFF && diff <= MAX_DIFF)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.LogError("Difficulty setting is not in range");
        }
    }

    public static void SetLevelIndex(int index)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, index);
    }

    public static void SetLevelRepeated(bool durum)
    {
        if (durum)
        {
            PlayerPrefs.SetInt(LEVEL_REPEATED, 1);
        }
        else
        {
            PlayerPrefs.SetInt(LEVEL_REPEATED, 0);
        }
    }

    public static int GetLevelRepeated()
    {
        return PlayerPrefs.GetInt(LEVEL_REPEATED);
    }

    public static int GetLevelIndex()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static bool GetMasterMusicBool()
    {
        if(PlayerPrefs.GetInt(MASTER_MUSIC_KEY) == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static int GetMasterMusicInt()
    {
        return PlayerPrefs.GetInt(MASTER_MUSIC_KEY);
    }
    public static bool GetMasterEffectBool()
    {
        if (PlayerPrefs.GetInt(MASTER_EFFECTS_KEY) == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static int GetMasterEffectInt()
    {
        return PlayerPrefs.GetInt(MASTER_EFFECTS_KEY);
    }
}
