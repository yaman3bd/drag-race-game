using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SecPlayerPrefs;
public static class EconomyScript
{
    public static void SetPlayerMoney(int val)
    {
        SecurePlayerPrefs.SetInt("player_money", val);
    }
    public static int GetPlayerMoney()
    {
        return SecurePlayerPrefs.GetInt("player_money");
    }
    public static void SetSelectedCar(string id)
    {
        SecurePlayerPrefs.SetString("car_id", id);
    }
    public static string GetSelectedCarID()
    {
        return SecurePlayerPrefs.GetString("car_id");
    }
    public static void SetSelectedColor(string id, int index)
    {
        SecurePlayerPrefs.SetInt(id + "_selected_color_index", index);
    }
    public static int GetSelectedColorIndex(string id)
    {
        return SecurePlayerPrefs.GetInt(id + "_selected_color_index");
    }

    public static void GiveUpgrade(string type, int level)
    {
        SecurePlayerPrefs.SetInt(type, level);
    }
    public static int GetUpgradeLevel(string id)
    {
        return SecurePlayerPrefs.GetInt(id);
    }
    public static void SetOwnedCar(string id)
    {
        SecurePlayerPrefs.SetBool($"{id}_owned", true);
    }
    public static bool IsCarOwned(string id)
    {
        bool state = SecurePlayerPrefs.GetBool($"{id}_owned");
        return state;
    }
    public static void DeleteAll()
    {
        SecurePlayerPrefs.DeleteAll();

    }

    public static float GetPrevPlayedTime()
    {
        return SecurePlayerPrefs.GetFloat("PrevPlayedTime");
    }

    public static void SetPrevPlayedTime(float val)
    {
        SecurePlayerPrefs.SetFloat("PrevPlayedTime", val);
    }
    public static bool IsNewPlayedTime(float val)
    {
        var old = GetPrevPlayedTime();

        if (old == 0)
        {
            SetPrevPlayedTime(val);
            return true;
        }

        if (val < GetPrevPlayedTime())
        {
            SetPrevPlayedTime(val);
            return true;
        }
        return false;
    }
    public static float GetPrevHighSpeed()
    {
        return SecurePlayerPrefs.GetFloat("HighSpeed");
    }

    public static void SetPrevHighSpeed(float val)
    {
        SecurePlayerPrefs.SetFloat("HighSpeed", val);
    }
    public static bool IsNewHighSpeed(float val)
    {
        var old = GetPrevHighSpeed();
        if (old == 0)
        {
            SetPrevHighSpeed(val);
            return true;
        }
        if (val < GetPrevHighSpeed())
        {
            SetPrevHighSpeed(val);
            return true;
        }
        return false;
    }

    public static float GetPrevUsedBoost()
    {
        return SecurePlayerPrefs.GetFloat("UsedBoost");
    }

    public static void SetPrevUsedBoost(float val)
    {
        SecurePlayerPrefs.SetFloat("UsedBoost", val);
    }
    public static bool IsNewUsedBoost(float val)
    {
        var old = GetPrevUsedBoost();

        if (old == 0)
        {
            SetPrevUsedBoost(val);
            return true;
        }

        if (val < GetPrevUsedBoost())
        {
            SetPrevUsedBoost(val);
            return true;
        }
        return false;
    }
}