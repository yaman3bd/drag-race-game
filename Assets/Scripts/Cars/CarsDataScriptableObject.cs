using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
[CreateAssetMenu(fileName = "NewCarsData", menuName = "ScriptableObjects/Cars/Cars Data")]
public class CarsDataScriptableObject : ScriptableObject
{
    public List<CarDataScriptableObject> CarsDataList;

    public List<CarDataScriptableObject> FilteredCarsDataList;


    public Dictionary<string, Color[]> carColors;


    public void initColors()
    {
        carColors = new Dictionary<string, Color[]>();
        //64526C
        carColors.Add("c_0", new Color[] { convert("9DA571"), convert("FFD1AB"), convert("FFE1FF"),
            convert("8795FF"), convert("5F4D65") });

        carColors.Add("c_1", new Color[] { convert("6D5EFF"), convert("FF5C7B"), convert("1C9767"),
            convert("FFE1FF"), convert("FF9700") });

        carColors.Add("c_2", new Color[] { convert("84DEFF"), convert("FF3F06"), convert("FFF000"),
            convert("FF9737"), convert("FFE1FF") });

        carColors.Add("c_3", new Color[] { convert("FFE1FF"), convert("FC846B"), convert("FF9100"),
            convert("ABFF63"), convert("CD02FF") });

        carColors.Add("c_4", new Color[] { convert("008DFF"), convert("FFE1FF"), convert("FFF820"),
            convert("A010DC"), convert("FF0007") });

        carColors.Add("c_5", new Color[] { convert("56465B"), convert("FF8E00"), convert("0551E3"),
            convert("A3C700"), convert("DB02FF") });

        carColors.Add("c_6", new Color[] { convert("FFE1FF"), convert("56465B"), convert("FF0004"),
            convert("FFF118"), convert("0763FB") });

        carColors.Add("c_7", new Color[] { convert("FFFF00"), convert("1057EB"), convert("FFE1FF"),
            convert("FFFFFF"), convert("FF2039") });

        carColors.Add("c_8", new Color[] { convert("FFE1FF"), convert("FFF100"), convert("E928FF"),
            convert("B0FF6B"), convert("FF00C4") });

        carColors.Add("c_9", new Color[] { convert("FFE1FF"), convert("FFEC00"), convert("018EFF"),
            convert("5A495E"), convert("FF9300") });

        carColors.Add("c_10", new Color[] { convert("FF223A"), convert("108658"), convert("FFE1FF"),
            convert("FFB900"), convert("FF7201") });

        carColors.Add("c_11", new Color[] { convert("0094FF"), convert("695671"), convert("FFF300"),
            convert("FFA100"), convert("FF00BB") });

        carColors.Add("c_12", new Color[] { convert("0E56EC"), convert("46C3FF"), convert("63516B"),
            convert("FF1931"), convert("FFE1FF") });

        carColors.Add("c_13", new Color[] { convert("FFF500"), convert("0952E3"), convert("63516A"),
            convert("FFE1FF"), convert("FF273D") });

        carColors.Add("c_14", new Color[] { convert("FF78FF"), convert("FFDF00"), convert("594DF3"),
            convert("F16401"), convert("CD02FF") });

        carColors.Add("c_15", new Color[] { convert("FFFFFF"), convert("44C0FF"), convert("FFE1FF"),
            convert("FFFB00"), convert("F8F8D2") });

        carColors.Add("c_16", new Color[] { convert("0B8656"), convert("4B3D4F"), convert("5C50F7"),
            convert("FF4C68"), convert("FFF601") });

        carColors.Add("c_17", new Color[] { convert("FF0E6F"), convert("E5FFC3"), convert("FF65FF"),
            convert("7DC0FF"), convert("FF5754") });

        carColors.Add("c_18", new Color[] { convert("9FFF53"), convert("FF1A31"), convert("FF6EFB"),
            convert("007CFF"), convert("FFDEFF") });

        carColors.Add("c_19", new Color[] { convert("FF1D34"), convert("54455A"), convert("138C5E"),
            convert("FFBB67"), convert("FF00A7") });

        carColors.Add("c_20", new Color[] { convert("37ACFF"), convert("9E7FA8"), convert("9EFF5A"),
            convert("FF152E"), convert("FFFFFF") });

        carColors.Add("c_21", new Color[] { convert("FF1B34"), convert("FF6E00"), convert("FFC400"),
            convert("F8DAFF"), convert("2B94FF") });

        carColors.Add("c_22", new Color[] { convert("FFEAFF"), convert("604E67"), convert("FFFFFF"),
            convert("FFFF00"), convert("4742C7") });

        carColors.Add("c_23", new Color[] { convert("FFE9FF"), convert("3C8A68"), convert("35A0FF"),
            convert("CDA3D7"), convert("FFFF1E") });

        carColors.Add("c_24", new Color[] { convert("FFF900"), convert("FF7C00"), convert("FF5EFF"),
            convert("38ABFF"), convert("FF0000") });

        carColors.Add("c_25", new Color[] { convert("FFF500"), convert("FF0A21"), convert("FFE9FF"),
            convert("0E4FD7"), convert("FF9100") });

        carColors.Add("c_26", new Color[] { convert("FFFF00"), convert("4A3D4E"), convert("C2E806"),
            convert("FF344E"), convert("FDE9FD") });

        carColors.Add("c_27", new Color[] { convert("FDE8FD"), convert("FFF623"), convert("715C78"),
            convert("FF0006"), convert("DDFFBB") });

        carColors.Add("c_28", new Color[] { convert("007DFF"), convert("4A3D4F"), convert("FFF1FF"),
            convert("FF1E37"), convert("FFF300") });

        carColors.Add("c_29", new Color[] { convert("6C5EFF"), convert("FFF500"), convert("FF0316"),
            convert("FFE2FF"), convert("6F5A75") });

        carColors.Add("c_30", new Color[] { convert("FF3F5A"), convert("DCE0EF"), convert("705C77"),
            convert("FFB356"), convert("1FA1FF") });

        carColors.Add("c_31", new Color[] { convert("FF273F"), convert("FFA488"), convert("B793BF"),
            convert("FF00A7"), convert("FFFFFF") });

        carColors.Add("c_32", new Color[] { convert("FFFF3F"), convert("745F7B"), convert("FFE3FF"),
            convert("639F6B"), convert("AB4DE7") });

        carColors.Add("c_33", new Color[] { convert("FFF0FF"), convert("FFFF71"), convert("FFFF00"),
            convert("FF0006"), convert("B690C4") });

        carColors.Add("c_34", new Color[] { convert("FF233B"), convert("514255"), convert("3FB94B"),
            convert("FFD9FF"), convert("FFFFFF") });

        carColors.Add("c_35", new Color[] { convert("A381AB"), convert("FF9C84"), convert("FF435E"),
            convert("FFFFFF"), convert("FEFF00") });

        carColors.Add("c_36", new Color[] { convert("FF0000"), convert("FFDBFF"), convert("189E6A"),
            convert("0077FF"), convert("FF3588") });

        carColors.Add("c_37", new Color[] { convert("FFFB00"), convert("9FFFFF"), convert("746EFF"),
            convert("FF5475"), convert("FFE4FF") });

        carColors.Add("c_38", new Color[] { convert("A181AB"), convert("FFDF00"), convert("0087FF"),
            convert("413546"), convert("FF1931") });

        carColors.Add("c_39", new Color[] { convert("FFE0FF"), convert("FFD500"), convert("56455C"),
            convert("BEFF9C"), convert("FF8A01") });

        carColors.Add("c_40", new Color[] { convert("0794FF"), convert("13FF02"), convert("FFF800"),
            convert("FF0000"), convert("FA0BFF") });

        carColors.Add("c_41", new Color[] { convert("4D3F52"), convert("FAD3FF"), convert("1062FF"),
            convert("FFE000"), convert("F9FF53") });

        carColors.Add("c_42", new Color[] { convert("FF0312"), convert("FF9B4F"), convert("477D4C"),
            convert("FFEBFF"), convert("3632A3") });

        carColors.Add("c_43", new Color[] { convert("F1D7F3"), convert("F57F69"), convert("5A4EEF"),
            convert("FF0D28"), convert("5B4E61") });

        carColors.Add("c_44", new Color[] { convert("FFEF00"), convert("FF8C00"), convert("42BAFF"),
            convert("A888B0"), convert("FF009F") });

        carColors.Add("c_45", new Color[] { convert("FFB318"), convert("F58068"), convert("FFFFFF"),
            convert("569F5D"), convert("6B8FFF") });

        carColors.Add("c_46", new Color[] { convert("FB866E"), convert("FF192E"), convert("0C52E0"),
            convert("FFE7FF"), convert("FF9700") });

        carColors.Add("c_47", new Color[] { convert("5D52F7"), convert("FFDDFF"), convert("F20104"),
            convert("FF8A01"), convert("87A3FF") });

        carColors.Add("c_48", new Color[] { convert("5E4C65"), convert("5369FF"), convert("5C4C64"),
            convert("E3D9E7"), convert("FFA088") });

        carColors.Add("c_49", new Color[] { convert("58485D"), convert("4E65FF"), convert("59485F"),
            convert("E5E5E5"), convert("FFA088") });

        carColors.Add("c_50", new Color[] { convert("604E68"), convert("FFFFFF"), convert("DFB3EF"),
            convert("8A96FF"), convert("5F4D67") });

        carColors.Add("c_51", new Color[] { convert("5F4D67"), convert("5469FF"), convert("4A3E4E"),
            convert("E9D7EF"), convert("FF9B83") });

        carColors.Add("c_52", new Color[] { convert("453949"), convert("546CFF"), convert("4A3D4E"),
            convert("F3F3F3"), convert("FFB8A0") });

        carColors.Add("c_53", new Color[] { convert("D10209"), convert("7BCEFF"), convert("FFCA00"),
            convert("56AC24"), convert("D54900") });

        carColors.Add("c_54", new Color[] { convert("FFE500"), convert("FF8500"), convert("5B4FF3"),
            convert("F30000"), convert("00B92C") });

        carColors.Add("c_55", new Color[] { convert("FF0B21"), convert("9D7FA7"), convert("0D8D5D"),
            convert("FFE800"), convert("0256D7") });
    }


    private void initCarPrices(string carID, ItemBuyType carBuyType, int carPrice, Rewards rewardsUpgrades, Engine engineUpgrades, Nitro nitroUpgrades)
    {
        var c_0 = GetCarByID(carID);
        c_0.BuyType = carBuyType;
        c_0.Price = carPrice;
        c_0.Upgradeables = new List<UpgradeableItem>();
        string[] names = { "Rewards", "Engine", "Nitre" };
        UpgradeTypes[] types = { UpgradeTypes.Rewards, UpgradeTypes.Engine, UpgradeTypes.Nitro };
        for (int i = 0; i < 3; i++)
        {
            var item = new UpgradeableItem();
            item.Name = names[i];
            item.UpgradeType = types[i];
            item.Prices = new UpgradePrice[4];
            c_0.Upgradeables.Add(item);

        }
        var engine = c_0.GetUpgradeItemData(UpgradeTypes.Engine);
        for (int i = 0; i < engine.Prices.Length; i++)
        {
            var item = new UpgradePrice();
            item.BuyType = engineUpgrades.upgradeDataItems.buyTypes[i];
            item.Price = engineUpgrades.upgradeDataItems.prices[i];
            engine.Prices[i] = item;
        }

        var rewards = c_0.GetUpgradeItemData(UpgradeTypes.Rewards);
        for (int i = 0; i < engine.Prices.Length; i++)
        {
            var item = new UpgradePrice();
            item.BuyType = rewardsUpgrades.upgradeDataItems.buyTypes[i];
            item.Price = rewardsUpgrades.upgradeDataItems.prices[i];
            rewards.Prices[i] = item;
        }

        var nitro = c_0.GetUpgradeItemData(UpgradeTypes.Nitro);
        for (int i = 0; i < engine.Prices.Length; i++)
        {
            var item = new UpgradePrice();
            item.BuyType = nitroUpgrades.upgradeDataItems.buyTypes[i];
            item.Price = nitroUpgrades.upgradeDataItems.prices[i];
            nitro.Prices[i] = item;
        }

    }


    public void initPrices()
    {
        Engine c_0_Engine = new Engine();
        c_0_Engine.upgradeDataItems = new UpgradeDataItem();
        c_0_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_0_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_0_Rewards = new Rewards();
        c_0_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_0_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_0_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_0_Nitro = new Nitro();
        c_0_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_0_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_0_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_1_Engine = new Engine();
        c_1_Engine.upgradeDataItems = new UpgradeDataItem();
        c_1_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_1_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_1_Rewards = new Rewards();
        c_1_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_1_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_1_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_1_Nitro = new Nitro();
        c_1_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_1_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_1_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_2_Engine = new Engine();
        c_2_Engine.upgradeDataItems = new UpgradeDataItem();
        c_2_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_2_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_2_Rewards = new Rewards();
        c_2_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_2_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_2_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_2_Nitro = new Nitro();
        c_2_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_2_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_2_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_3_Engine = new Engine();
        c_3_Engine.upgradeDataItems = new UpgradeDataItem();
        c_3_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_3_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_3_Rewards = new Rewards();
        c_3_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_3_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_3_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_3_Nitro = new Nitro();
        c_3_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_3_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_3_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_4_Engine = new Engine();
        c_4_Engine.upgradeDataItems = new UpgradeDataItem();
        c_4_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_4_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_4_Rewards = new Rewards();
        c_4_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_4_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_4_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_4_Nitro = new Nitro();
        c_4_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_4_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_4_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_5_Engine = new Engine();
        c_5_Engine.upgradeDataItems = new UpgradeDataItem();
        c_5_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_5_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_5_Rewards = new Rewards();
        c_5_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_5_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_5_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_5_Nitro = new Nitro();
        c_5_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_5_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_5_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_6_Engine = new Engine();
        c_6_Engine.upgradeDataItems = new UpgradeDataItem();
        c_6_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_6_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_6_Rewards = new Rewards();
        c_6_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_6_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_6_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_6_Nitro = new Nitro();
        c_6_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_6_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_6_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_7_Engine = new Engine();
        c_7_Engine.upgradeDataItems = new UpgradeDataItem();
        c_7_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_7_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_7_Rewards = new Rewards();
        c_7_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_7_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_7_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_7_Nitro = new Nitro();
        c_7_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_7_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_7_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_8_Engine = new Engine();
        c_8_Engine.upgradeDataItems = new UpgradeDataItem();
        c_8_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_8_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_8_Rewards = new Rewards();
        c_8_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_8_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_8_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_8_Nitro = new Nitro();
        c_8_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_8_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_8_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_9_Engine = new Engine();
        c_9_Engine.upgradeDataItems = new UpgradeDataItem();
        c_9_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_9_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_9_Rewards = new Rewards();
        c_9_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_9_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_9_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_9_Nitro = new Nitro();
        c_9_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_9_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_9_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_10_Engine = new Engine();
        c_10_Engine.upgradeDataItems = new UpgradeDataItem();
        c_10_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_10_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_10_Rewards = new Rewards();
        c_10_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_10_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_10_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_10_Nitro = new Nitro();
        c_10_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_10_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_10_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_11_Engine = new Engine();
        c_11_Engine.upgradeDataItems = new UpgradeDataItem();
        c_11_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_11_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_11_Rewards = new Rewards();
        c_11_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_11_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_11_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_11_Nitro = new Nitro();
        c_11_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_11_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_11_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_12_Engine = new Engine();
        c_12_Engine.upgradeDataItems = new UpgradeDataItem();
        c_12_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_12_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_12_Rewards = new Rewards();
        c_12_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_12_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_12_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_12_Nitro = new Nitro();
        c_12_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_12_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_12_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_13_Engine = new Engine();
        c_13_Engine.upgradeDataItems = new UpgradeDataItem();
        c_13_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_13_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_13_Rewards = new Rewards();
        c_13_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_13_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_13_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_13_Nitro = new Nitro();
        c_13_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_13_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_13_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_14_Engine = new Engine();
        c_14_Engine.upgradeDataItems = new UpgradeDataItem();
        c_14_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_14_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_14_Rewards = new Rewards();
        c_14_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_14_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_14_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_14_Nitro = new Nitro();
        c_14_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_14_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_14_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_15_Engine = new Engine();
        c_15_Engine.upgradeDataItems = new UpgradeDataItem();
        c_15_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_15_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_15_Rewards = new Rewards();
        c_15_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_15_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_15_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_15_Nitro = new Nitro();
        c_15_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_15_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_15_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_16_Engine = new Engine();
        c_16_Engine.upgradeDataItems = new UpgradeDataItem();
        c_16_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_16_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_16_Rewards = new Rewards();
        c_16_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_16_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_16_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_16_Nitro = new Nitro();
        c_16_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_16_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_16_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_17_Engine = new Engine();
        c_17_Engine.upgradeDataItems = new UpgradeDataItem();
        c_17_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_17_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_17_Rewards = new Rewards();
        c_17_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_17_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_17_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_17_Nitro = new Nitro();
        c_17_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_17_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_17_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_18_Engine = new Engine();
        c_18_Engine.upgradeDataItems = new UpgradeDataItem();
        c_18_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_18_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_18_Rewards = new Rewards();
        c_18_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_18_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_18_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_18_Nitro = new Nitro();
        c_18_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_18_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_18_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_19_Engine = new Engine();
        c_19_Engine.upgradeDataItems = new UpgradeDataItem();
        c_19_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_19_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_19_Rewards = new Rewards();
        c_19_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_19_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_19_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_19_Nitro = new Nitro();
        c_19_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_19_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_19_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_20_Engine = new Engine();
        c_20_Engine.upgradeDataItems = new UpgradeDataItem();
        c_20_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_20_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_20_Rewards = new Rewards();
        c_20_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_20_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_20_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_20_Nitro = new Nitro();
        c_20_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_20_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_20_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        Engine c_21_Engine = new Engine();
        c_21_Engine.upgradeDataItems = new UpgradeDataItem();
        c_21_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_21_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_21_Rewards = new Rewards();
        c_21_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_21_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_21_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_21_Nitro = new Nitro();
        c_21_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_21_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_21_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_22_Engine = new Engine();
        c_22_Engine.upgradeDataItems = new UpgradeDataItem();
        c_22_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_22_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_22_Rewards = new Rewards();
        c_22_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_22_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_22_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_22_Nitro = new Nitro();
        c_22_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_22_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_22_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_23_Engine = new Engine();
        c_23_Engine.upgradeDataItems = new UpgradeDataItem();
        c_23_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_23_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_23_Rewards = new Rewards();
        c_23_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_23_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_23_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_23_Nitro = new Nitro();
        c_23_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_23_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_23_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_24_Engine = new Engine();
        c_24_Engine.upgradeDataItems = new UpgradeDataItem();
        c_24_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_24_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_24_Rewards = new Rewards();
        c_24_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_24_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_24_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_24_Nitro = new Nitro();
        c_24_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_24_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_24_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };

        Engine c_25_Engine = new Engine();
        c_25_Engine.upgradeDataItems = new UpgradeDataItem();
        c_25_Engine.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Ad, ItemBuyType.Money, ItemBuyType.Money };
        c_25_Engine.upgradeDataItems.prices = new int[] { 100, 0, 110, 120 };

        Rewards c_25_Rewards = new Rewards();
        c_25_Rewards.upgradeDataItems = new UpgradeDataItem();
        c_25_Rewards.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money, ItemBuyType.Money };
        c_25_Rewards.upgradeDataItems.prices = new int[] { 100, 110, 120, 130 };

        Nitro c_25_Nitro = new Nitro();
        c_25_Nitro.upgradeDataItems = new UpgradeDataItem();
        c_25_Nitro.upgradeDataItems.buyTypes = new ItemBuyType[] { ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad, ItemBuyType.Ad };
        c_25_Nitro.upgradeDataItems.prices = new int[] { 0, 0, 0, 0 };


        initCarPrices("c_0", ItemBuyType.Money, 300, c_0_Rewards, c_0_Engine, c_0_Nitro);
        initCarPrices("c_1", ItemBuyType.Money, 300, c_1_Rewards, c_1_Engine, c_1_Nitro);
        initCarPrices("c_2", ItemBuyType.Money, 300, c_2_Rewards, c_2_Engine, c_2_Nitro);
        initCarPrices("c_3", ItemBuyType.Money, 300, c_3_Rewards, c_3_Engine, c_3_Nitro);
        initCarPrices("c_4", ItemBuyType.Money, 300, c_4_Rewards, c_4_Engine, c_4_Nitro);
        initCarPrices("c_5", ItemBuyType.Money, 300, c_5_Rewards, c_5_Engine, c_5_Nitro);
        initCarPrices("c_6", ItemBuyType.Money, 300, c_6_Rewards, c_6_Engine, c_6_Nitro);
        initCarPrices("c_7", ItemBuyType.Money, 300, c_7_Rewards, c_7_Engine, c_7_Nitro);
        initCarPrices("c_8", ItemBuyType.Money, 300, c_8_Rewards, c_8_Engine, c_8_Nitro);
        initCarPrices("c_9", ItemBuyType.Money, 300, c_9_Rewards, c_9_Engine, c_9_Nitro);
        initCarPrices("c_10", ItemBuyType.Money, 300, c_10_Rewards, c_10_Engine, c_10_Nitro);
        initCarPrices("c_11", ItemBuyType.Money, 300, c_11_Rewards, c_11_Engine, c_11_Nitro);
        initCarPrices("c_12", ItemBuyType.Money, 300, c_12_Rewards, c_12_Engine, c_12_Nitro);
        initCarPrices("c_13", ItemBuyType.Money, 300, c_13_Rewards, c_13_Engine, c_13_Nitro);
        initCarPrices("c_14", ItemBuyType.Money, 300, c_14_Rewards, c_14_Engine, c_14_Nitro);
        initCarPrices("c_15", ItemBuyType.Money, 300, c_15_Rewards, c_15_Engine, c_15_Nitro);
        initCarPrices("c_16", ItemBuyType.Money, 300, c_16_Rewards, c_16_Engine, c_16_Nitro);
        initCarPrices("c_17", ItemBuyType.Money, 300, c_17_Rewards, c_17_Engine, c_17_Nitro);
        initCarPrices("c_18", ItemBuyType.Money, 300, c_18_Rewards, c_18_Engine, c_18_Nitro);
        initCarPrices("c_20", ItemBuyType.Money, 300, c_20_Rewards, c_20_Engine, c_20_Nitro);
        initCarPrices("c_21", ItemBuyType.Money, 300, c_21_Rewards, c_21_Engine, c_21_Nitro);
        initCarPrices("c_22", ItemBuyType.Money, 300, c_22_Rewards, c_22_Engine, c_22_Nitro);
        initCarPrices("c_23", ItemBuyType.Money, 300, c_23_Rewards, c_23_Engine, c_23_Nitro);
        initCarPrices("c_24", ItemBuyType.Money, 300, c_24_Rewards, c_24_Engine, c_24_Nitro);
        initCarPrices("c_25", ItemBuyType.Money, 300, c_25_Rewards, c_25_Engine, c_25_Nitro);


    }
    public Color convert(string hex)
    {
        hex = "#" + hex;
        Color col;
        ColorUtility.TryParseHtmlString(hex, out col);

        return col;
    }
    public CarDataScriptableObject GetCarByIndex(int index)
    {
        return FilteredCarsDataList[index];
    }
    public CarDataScriptableObject GetCarByID(string id)
    {
        return FilteredCarsDataList.Where(c => c.ID == id).FirstOrDefault();
    }
    public CarDataScriptableObject GetRandomCar()
    {
        var id = Random.Range(0, FilteredCarsDataList.Count - 1);

        return GetCarByIndex(id);

    }
    public int GetCarIndex(string id)
    {
        return FilteredCarsDataList.IndexOf(GetCarByID(id));
    }
    public void Filter()
    {
        FilteredCarsDataList = CarsDataList.Where(c => c.IsAvailable).ToList();
        initColors();
        initPrices();
    }
}

public class UpgradeDataItem
{
    public ItemBuyType[] buyTypes;
    public int[] prices;
}

public class Rewards
{
    public UpgradeDataItem upgradeDataItems;
}
public class Engine
{
    public UpgradeDataItem upgradeDataItems;

}

public class Nitro
{
    public UpgradeDataItem upgradeDataItems;

}