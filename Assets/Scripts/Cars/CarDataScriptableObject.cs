using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum ItemToGetType
{
    None,
    Upgrade,
    Car,
}
public enum TypesOfCars
{
    Common,
    Rare,
    Epic,
    Legendary
}
public enum DrivingTypes
{
    None,
    Front,
    Rear,
    All
}
public enum UpgradeTypes
{
    None,
    Rewards,
    Engine,
    Nitro,
}
[Serializable]
public class UpgradeableItem
{
    public string Name;
    public UpgradeTypes UpgradeType;
    public UpgradePrice[] Prices;

}
[Serializable]
public class UpgradePrice
{
    public ItemBuyType BuyType;
    public int Price;

}
public enum ItemBuyType
{
    None,
    Money,
    Ad,
}
[CreateAssetMenu(fileName = "NewCarData", menuName = "ScriptableObjects/Cars/Car Data")]
public class CarDataScriptableObject : ScriptableObject
{
    public ItemBuyType BuyType;

    [Header("Movement")]
    public float[] DefaultGearRatio;
    public float[] DefaultEngineTorquesPerGear;
    public float[] DefaultMaxSpeedsPerGear;
    public float CarMaxSpeed;
    public int CarMaxGearsCount;
    public float FinalDriveRatio;

    public float EngineAddedValue
    {
        get
        {
            float val = EconomyScript.GetUpgradeLevel(this.ID) + 1;
            val = (val / 4) * 80;
            return val;
        }
    }

    public bool AutoGear;
    [Header("Boost")]
    public float MaxBoostTime;
    public float BoostRefillSpeed;
    public float BoostForce;
    public float BoostForceAddedValue
    {
        get
        {
            float val = EconomyScript.GetUpgradeLevel(this.ID) + 1;
            val = (val / 4) * 80;
            return val;
        }
    }

    public float RewardsAddedValue
    {
        get
        {
            float val = EconomyScript.GetUpgradeLevel(this.ID) + 1;
            val = (val / 4) * 80;
            return val;
        }
    }
    public float DownForce;

    public bool IsAddStartAccForceAllowed;
    public float StartAccForce;

    [Header("Sounds")]
    public AudioClip EngineSound;
    public AudioClip NitroSound;
    public AudioClip GearChangeSound;
    [Header("Store")]
    public bool IsAvailable;
    public string Name;
    public string ID;
    public string ClassName;
    public TypesOfCars CarType;
    public DrivingTypes DrivingType;
    public int Price;
    public int Rank;

    [Header("Upgrades")]
    public List<UpgradeableItem> Upgradeables;

    public bool IsBoostAllowed()
    {
        return true;
    }
    public string GetRankName()
    {

        return CarType.ToString();
    }

    public float GetAddedValue(string key, float value)
    {
        //m1
        var a = (EngineAddedValue / 100) * value;
        //m2
        //var aa = 1 + 0.1f * value;
        return a;
    }
    public UpgradeableItem GetUpgradeItemData(UpgradeTypes upgradeType)
    {
        return Upgradeables.Where(item => item.UpgradeType == upgradeType).FirstOrDefault();
    }
}