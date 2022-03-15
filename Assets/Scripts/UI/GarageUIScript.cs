using System.Collections;
using GameManagment;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class GarageUIScript : MonoBehaviour
{
    public ParticleSystem UpgradeEffect;
    [Header("Player Money")]
    public TMP_Text PlayerMoneyText;
    public RectTransform PlayerMoneyRect;
    [Space]
    public TMP_Text CarPriceText;

    public TMP_Text CarName;
    [Header("Car Buttons")]
    public Button NextCarButton;
    public Button PrevCarButton;
    [Header("Buy Car Buttons")]
    public Button SelectCarButton;
    public RectTransform SelectCarButtonRect;
    public GameObject SelectCarGmObj;
    public GameObject WatchAdCarGmObj;
    public GameObject BuyCarGmObj;
    public RectTransform SelectedColorCheckIcon;
    [Header("Buy Car Buttons")]
    public Button RewardsUpgradeButton;
    public Button EngineUpgradeButton;
    public Button NitroUpgradeButton;

    public GarageCarsLoader CarsLoader;
    public Vector3 CarPosition;
    public Vector3 CarPosition_AfterColor;

    public Vector3 CarRotation;
    public Transform CarsParent;

    public int carIndex;
    public GarageCarData activeCar;
    public CarDataScriptableObject SelectedCarData;
    public Button[] CarColorsButtons;
    // Start is called before the first frame update
    public Material[] CarMaterials;
    public UpgradeItem EngineUpgradeItems;
    public UpgradeItem RewardsUpgradeItems;
    public UpgradeItem NitroUpgradeItems;

    public Vector2 v;
    public float d;
    public int vi;
    public float elc;
    private ItemToGetType itemToGetType;
    private UpgradeTypes UpgradeRewardedType;

     
    void Start()
    {
        AdsManager.Instance.OnAdLoaded += OnAdLoaded;

        AdsManager.Instance.OnAdShowComplete += OnAdShowComplete;
        AdsManager.Instance.OnAdsInitializationComplete += OnAdsInitializationComplete;

        NextCarButton.onClick.AddListener(() =>
        {
            NextCarButton_OnClick();
        });

        PrevCarButton.onClick.AddListener(() =>
        {
            PrevCarButton_OnClick();
        });
       

        carIndex = GameManager.Instance.CarsData.GetCarIndex(GameManager.Instance.SelectedCarID);

        UpdateGarageUIandGarage(carIndex, true, true);

        RewardsUpgradeButton.onClick.AddListener(() =>
        {
            UpgradeButton_OnClick(UpgradeTypes.Rewards);
        });

        EngineUpgradeButton.onClick.AddListener(() =>
        {
            UpgradeButton_OnClick(UpgradeTypes.Engine);
        });

        NitroUpgradeButton.onClick.AddListener(() =>
        {
            UpgradeButton_OnClick(UpgradeTypes.Nitro);
        });

        for (int i = 0; i < CarColorsButtons.Length; i++)
        {
            int j = i;
            CarColorsButtons[i].image.color = GameManager.Instance.CarsData.carColors[SelectedCarData.ID][i];
            CarColorsButtons[j].onClick.AddListener(() =>
            {
                MeshRenderer[] coloredMeshes = activeCar.Model.GetComponentsInChildren<MeshRenderer>();
                foreach (var item in coloredMeshes)
                {
                    item.material = CarMaterials[j];
                }
                bool state = EconomyScript.IsCarOwned(SelectedCarData.ID);
                if (state)
                {
                    EconomyScript.SetSelectedColor(SelectedCarData.ID, j);
                }
                SelectedColorCheckIcon.SetParent(CarColorsButtons[j].transform);
                SelectedColorCheckIcon.anchoredPosition = new Vector2();
            });
        }
        SelectCarButton.onClick.AddListener(SelectCarButton_OnClick);


    }

    private void OnAdLoaded(AdType adType)
    {
        SelectCarButton.interactable = AdsManager.Instance.IsAdReay(AdType.REWARDED);
        RewardsUpgradeButton.interactable = AdsManager.Instance.IsAdReay(AdType.REWARDED);
        EngineUpgradeButton.interactable = AdsManager.Instance.IsAdReay(AdType.REWARDED);
        NitroUpgradeButton.interactable = AdsManager.Instance.IsAdReay(AdType.REWARDED);
    }

    private void OnAdsInitializationComplete()
    {
        itemToGetType = ItemToGetType.None;
        AdsManager.Instance.LoadAd(AdType.REWARDED);
    }

    private void OnAdShowComplete(AdType adType)
    {
        UpgradeEffect.Stop();
        switch (itemToGetType)
        {
            case ItemToGetType.None:
                break;
            case ItemToGetType.Upgrade:
                var item = SelectedCarData.GetUpgradeItemData(UpgradeRewardedType);

                int level = EconomyScript.GetUpgradeLevel(SelectedCarData.ID + "_" + UpgradeRewardedType.ToString());
                int money = EconomyScript.GetPlayerMoney();
                EconomyScript.SetPlayerMoney(money - item.Prices[level].Price);
                EconomyScript.GiveUpgrade(SelectedCarData.ID + "_" + UpgradeRewardedType.ToString(), level + 1);
                break;
            case ItemToGetType.Car:
                EconomyScript.SetOwnedCar(SelectedCarData.ID);
                EconomyScript.SetSelectedCar(SelectedCarData.ID);
                break;
            default:
                break;
        }
        UpdateGarageUIandGarage(carIndex, false,true);
        UpgradeEffect.Play();
        AdsManager.Instance.LoadAd(AdType.REWARDED);
    }

    private void UpgradeButton_OnClick(UpgradeTypes upgradeType)
    {
        UpgradeEffect.Stop();
        bool state = EconomyScript.IsCarOwned(SelectedCarData.ID);
        if (!state)
        {
            SelectCarButtonRect.DOPunchAnchorPos(v, d, vi, elc);
        }
        else
        {
            var item = SelectedCarData.GetUpgradeItemData(upgradeType);

            int level = EconomyScript.GetUpgradeLevel(SelectedCarData.ID + "_" + upgradeType.ToString());
            switch (item.Prices[level].BuyType)
            {
                case ItemBuyType.None:
                    break;
                case ItemBuyType.Money:
                    if (EconomyScript.GetPlayerMoney() < item.Prices[level].Price)
                    {
                        PlayerMoneyRect.DOPunchAnchorPos(v, d, vi, elc);
                    }
                    else
                    {
                        int money = EconomyScript.GetPlayerMoney();
                         int toToake = money - item.Prices[level].Price;
                        EconomyScript.SetPlayerMoney(toToake);
                        DOTween.To(() => money, x => PlayerMoneyText.text = x.ToString("n0"), toToake, 1);
                        EconomyScript.GiveUpgrade(SelectedCarData.ID + "_" + upgradeType.ToString(), level + 1);
                        UpdateGarageUIandGarage(carIndex, false,false);
                        UpgradeEffect.Play();
                    }
                    break;
                case ItemBuyType.Ad:
                    UpgradeRewardedType = upgradeType;
                    itemToGetType = ItemToGetType.Upgrade;
                    AdsManager.Instance.ShowAd(AdType.REWARDED);
                    break;
                default:
                    break;
            }
            
        }
    }
    private void initUpgradeUI(UpgradeTypes upgradeType)
    {
        var item = SelectedCarData.GetUpgradeItemData(upgradeType);

        int level = EconomyScript.GetUpgradeLevel(SelectedCarData.ID + "_" + upgradeType.ToString());
        string a = "Money";
        int index = Mathf.Clamp(level, 0, item.Prices.Length - 1);

        switch (item.Prices[index].BuyType)
        {
            case ItemBuyType.None:
                break;
            case ItemBuyType.Money:
                  a = "Money";
               
                break;
            case ItemBuyType.Ad:
                a = "AD";
                break;
            default:
                break;
        }
        if (level >= item.Prices.Length)
        {
            a = "Full";
        }

        bool state = EconomyScript.IsCarOwned(SelectedCarData.ID);

        switch (upgradeType)
        {
            case UpgradeTypes.Rewards:
                RewardsUpgradeItems.Init(level, item.Prices[index].Price, a, state, UpgradeTypes.Rewards);
                break;
            case UpgradeTypes.Engine:
                EngineUpgradeItems.Init(level, item.Prices[index].Price, a, state, UpgradeTypes.Engine);
                break;
            case UpgradeTypes.Nitro:
                NitroUpgradeItems.Init(level, item.Prices[index].Price, a, state, UpgradeTypes.Nitro);
                break;
        }

    }


    private void SelectCarButton_OnClick()
    {
        bool state = EconomyScript.IsCarOwned(SelectedCarData.ID);
        UpgradeEffect.Stop();
        if (state)
        {
            AdsManager.Instance.OnAdShowComplete -= OnAdShowComplete;
            AdsManager.Instance.OnAdsInitializationComplete -= OnAdsInitializationComplete;
            EconomyScript.SetSelectedCar(SelectedCarData.ID);
            SceneManager.LoadScene(1);
        }
        else
        {
            switch (SelectedCarData.BuyType)
            {

                case ItemBuyType.Money:
                    int playerMoney = EconomyScript.GetPlayerMoney();
                    if (playerMoney < SelectedCarData.Price)
                    {
                        PlayerMoneyRect.DOPunchAnchorPos(v, d, vi, elc);
                    }
                    else
                    {
                        int toToake = playerMoney - SelectedCarData.Price;
                        EconomyScript.SetPlayerMoney(toToake);
                        EconomyScript.SetOwnedCar(SelectedCarData.ID);
                        EconomyScript.SetSelectedCar(SelectedCarData.ID);
                        DOTween.To(() => playerMoney, x => PlayerMoneyText.text = x.ToString("n0"), toToake, 1);
                        UpdateGarageUIandGarage(carIndex, false,false);
                        UpgradeEffect.Play();
                    }
                    break;
                case ItemBuyType.Ad:
                    itemToGetType = ItemToGetType.Car;
                    AdsManager.Instance.ShowAd(AdType.REWARDED);
                    break;
                default:
                    break;
            }
        }
    }

    private void NextCarButton_OnClick()
    {
        carIndex = (carIndex + 1) % GameManager.Instance.CarsData.FilteredCarsDataList.Count;

        UpdateGarageUIandGarage(carIndex, true, true);
    }

    private void PrevCarButton_OnClick()
    {
        carIndex--;

        if (carIndex < 0)
        {
            carIndex = GameManager.Instance.CarsData.FilteredCarsDataList.Count - 1;
        }

        UpdateGarageUIandGarage(carIndex, true,true);
    }

    private void UpdateGarageUIandGarage(int carIndex, bool updateCar,bool updateText)
    {
        var carData = GameManager.Instance.CarsData.GetCarByIndex(carIndex);
        UpdateCarID(carData);
        for (int i = 0; i < CarColorsButtons.Length; i++)
        {
            CarColorsButtons[i].image.color = GameManager.Instance.CarsData.carColors[SelectedCarData.ID][i];
        }
        SelectedColorCheckIcon.SetParent(CarColorsButtons[EconomyScript.GetSelectedColorIndex(SelectedCarData.ID)].transform);
        SelectedColorCheckIcon.anchoredPosition = new Vector2();
        if (updateText)
        {
            PlayerMoneyText.text = EconomyScript.GetPlayerMoney().ToString("n0");
        }
        CarName.text = carData.Name;
        
        initUpgradeUI(UpgradeTypes.Rewards);
        initUpgradeUI(UpgradeTypes.Engine);
        initUpgradeUI(UpgradeTypes.Nitro);
        if (updateCar)
        {
            UpdateCar(carData, CarPosition);
        }
        SelectCarGmObj.SetActive(false);
        BuyCarGmObj.SetActive(false);
        WatchAdCarGmObj.SetActive(false);
        SelectCarButton.image.color = Color.white;
         
        bool state = EconomyScript.IsCarOwned(SelectedCarData.ID);
        if (state)
        {
            SelectCarGmObj.SetActive(true);
        }
        else
        {
            switch (SelectedCarData.BuyType)
            {

                case ItemBuyType.Money:
                    CarPriceText.text = SelectedCarData.Price.ToString();
                    BuyCarGmObj.SetActive(true);
                    break;
                case ItemBuyType.Ad:
                    SelectCarButton.interactable = AdsManager.Instance.IsAdReay(AdType.REWARDED);
                      Color col;
                    ColorUtility.TryParseHtmlString("#2D81EA", out col);
                    SelectCarButton.image.color = col;
                    WatchAdCarGmObj.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    private void UpdateCarID(CarDataScriptableObject carData)
    {
        SelectedCarData = carData;
    }
    public Material test;
    private void UpdateCar(CarDataScriptableObject carData, Vector3 CarPosition)
    {

        if (activeCar != null)
        {
            activeCar.Model.SetActive(false);
        }

        activeCar = CarsLoader.GetCar(carData.ID, carData.ID);
        PlaceCar(activeCar.Model, CarPosition, CarRotation, CarsParent);
        activeCar.Model.SetActive(true);
        //activeCar.Model.GetComponent<SyncWheelsValues>().SyncValues();
        int j = EconomyScript.GetSelectedColorIndex(SelectedCarData.ID);
        MeshRenderer[] coloredMeshes = activeCar.Model.GetComponentsInChildren<MeshRenderer>();
        foreach (var item in coloredMeshes)
        {
            item.material = CarMaterials[j];
        }
    }
    private void PlaceCar(GameObject car, Vector3 postion, Vector3 rotation, Transform parent)
    {
        car.transform.localPosition = postion;
        car.transform.localEulerAngles = rotation;
        car.transform.SetParent(parent);
    }
}