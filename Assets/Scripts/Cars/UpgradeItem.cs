using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeItem : MonoBehaviour
{

    public TMP_Text UpgeadeLevelText;

    public Image[] UpgradeLevelImages;
    public Image Background;
    public Image ItemBackground;
    public Image ItemIcon;
    public GameObject FullUpgraded;
    public GameObject WatchAddUpgrade;
    public GameObject MoneyUpgrade;
    public TMP_Text UpgradePriceText;
    public Button UpgradeButton;
    public Color ItemLevelImageUpgradedColor;
    public Color ItemLevelImageColor;

    public Color ItemDisabledColor;
    public Color ItemFullUpgradeColor;
    public Color ItemWatchAddUpgradeColor;
    public Color ItemMoneyUpgradeColor;
    [Space]
    public Color ItemRewardsColor;
    public Color ItemEngineColor;
    public Color ItemNitroColor;


    public void SetItemAsWatchAdUpgrade(bool owned, UpgradeTypes upgradeType)
    {
        FullUpgraded.SetActive(false);
        MoneyUpgrade.SetActive(false);
        WatchAddUpgrade.SetActive(true);
         UpgradeButton.gameObject.SetActive(true);
        if (owned)
        {
            Background.color = ItemWatchAddUpgradeColor;
            switch (upgradeType)
            {

                case UpgradeTypes.Rewards:
                    ItemBackground.color = ItemRewardsColor;
                    break;
                case UpgradeTypes.Engine:
                    ItemBackground.color = ItemEngineColor;
                    break;
                case UpgradeTypes.Nitro:
                    ItemBackground.color = ItemNitroColor;
                    break;
            }
            ItemIcon.color = Color.white;
        }
        else
        {

            Background.color = ItemDisabledColor;
            ItemBackground.color = ItemDisabledColor;
            ItemIcon.color = ItemDisabledColor;
        }
    }
    public void SetItemAsMoneyUpgrade(int upgradePrice, bool owned, UpgradeTypes upgradeType)
    {
        FullUpgraded.SetActive(false);
        WatchAddUpgrade.SetActive(false);
        MoneyUpgrade.SetActive(true);
        if (owned)
        {
            Background.color = ItemMoneyUpgradeColor;
            switch (upgradeType)
            {

                case UpgradeTypes.Rewards:
                    ItemBackground.color = ItemRewardsColor;
                    break;
                case UpgradeTypes.Engine:
                    ItemBackground.color = ItemEngineColor;
                    break;
                case UpgradeTypes.Nitro:
                    ItemBackground.color = ItemNitroColor;
                    break;
            }
            ItemIcon.color = Color.white;
        }
        else
        {

            Background.color = ItemDisabledColor;
            ItemBackground.color = ItemDisabledColor;
            ItemIcon.color = ItemDisabledColor;
        }
        UpgradePriceText.text = upgradePrice.ToString();
        UpgradeButton.gameObject.SetActive(true);

    }
    public void SetItemAsFullUpgraded(UpgradeTypes upgradeType)
    {
        FullUpgraded.SetActive(true);
        WatchAddUpgrade.SetActive(false);
        MoneyUpgrade.SetActive(false);
        Background.color = ItemFullUpgradeColor;
        switch (upgradeType)
        {

            case UpgradeTypes.Rewards:
                ItemBackground.color = ItemRewardsColor;
                break;
            case UpgradeTypes.Engine:
                ItemBackground.color = ItemEngineColor;
                break;
            case UpgradeTypes.Nitro:
                ItemBackground.color = ItemNitroColor;
                break;
        }
        ItemIcon.color = Color.white;
        UpgradeButton.gameObject.SetActive(false);
    }
    public void SetItemAsDisabledUpgrade(int upgradePrice)
    {
        FullUpgraded.SetActive(false);
        WatchAddUpgrade.SetActive(false);
        MoneyUpgrade.SetActive(true);
        Background.color = ItemDisabledColor;
        UpgeadeLevelText.text = upgradePrice.ToString();
    }
    public void SetUpgradeLevel(int upgradedIndex, bool owned)
    {
        if (owned)
        {


            for (int i = 0; i < UpgradeLevelImages.Length; i++)
            {
                UpgradeLevelImages[i].color = ItemLevelImageColor;

            }
            var index = Mathf.Clamp(upgradedIndex, 0, UpgradeLevelImages.Length);
            for (int i = 0; i < upgradedIndex; i++)
            {
                UpgradeLevelImages[i].color = ItemLevelImageUpgradedColor;

            }
        }
        else
        {
            for (int i = 0; i < UpgradeLevelImages.Length; i++)
            {
                UpgradeLevelImages[i].color = ItemDisabledColor;

            }
        }
        UpgeadeLevelText.text = upgradedIndex.ToString();
    }

    public void Init(int upgradedIndex, int upgradePrice, string type, bool owned, UpgradeTypes upgradeType)
    {
        SetUpgradeLevel(upgradedIndex, owned);

        switch (type)
        {
            case "AD":
                SetItemAsWatchAdUpgrade(owned, upgradeType);
                break;
            case "Money":
                SetItemAsMoneyUpgrade(upgradePrice, owned, upgradeType);
                break;
            case "Full":
                SetItemAsFullUpgraded(upgradeType);
                break;
            default:
                break;
        }

    }
}
