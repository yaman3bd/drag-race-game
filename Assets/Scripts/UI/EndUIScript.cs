using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;
using GameManagment;

public class EndUIScript : MonoBehaviour
{
    public static EndUIScript Instance;

    public TMP_Text PlayerMoney;
    public TMP_Text WinLoseText;

    public TMP_Text ScoreText;
    public TMP_Text SpeedText;
    public TMP_Text NitroText;
    public TMP_Text FinalScoreText;
    public TMP_Text RewardsText;

    public TMP_Text NextStageText;
    public Button NextStageButton;
    public Button GarageButton;
    public Button DoubleCashButton;
    public Button SoundToggleButton;
    [Space]
    public GameObject ScoreTextNew;
    public GameObject SpeedTextNew;
    public GameObject NitroTextNew;
    [Space]
    public float TextsAnimationDuration;
    public float TextsAnimationInterval;
    public void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        AdsManager.Instance.OnAdShowComplete -= OnAdShowComplete;
    }
    public void Start()
    {
        PlayerMoney.text = EconomyScript.GetPlayerMoney().ToString("n0");
        AdsManager.Instance.OnAdShowComplete += OnAdShowComplete;
        AdsManager.Instance.LoadAd(AdType.REWARDED);
        NextStageButton.onClick.AddListener(NextStageButton_OnClick);
        GarageButton.onClick.AddListener(GarageButton_OnClick);
        DoubleCashButton.onClick.AddListener(DoubleCashButton_OnClick);
        SoundToggleButton.onClick.AddListener(SoundToggleButton_OnClick);
    }
    private int rewareds;
    private void OnAdShowComplete(AdType adType)
    {
        DoubleCashButton.gameObject.SetActive(false);


        int val = (int)LoadedLevelManager.Instance.Player.PlayedTime() + (int)LoadedLevelManager.Instance.Player.PlayedSpeed() + (int)LoadedLevelManager.Instance.Player.BoostUsed();
        int test = 0;


        float Rewards = EconomyScript.GetUpgradeLevel(GameManager.Instance.SelectedCarID + "_" + UpgradeTypes.Rewards.ToString());
        Rewards = (Rewards / 4) * val;
        var tests = (int)val + (int)Rewards;
        DOTween.To(() => test, x => RewardsText.text = x.ToString("n0"), rewareds + tests, TextsAnimationDuration);
        DOTween.To(() => EconomyScript.GetPlayerMoney(), x => PlayerMoney.text = x.ToString("n0"), EconomyScript.GetPlayerMoney()  + tests, TextsAnimationDuration);
        EconomyScript.SetPlayerMoney(EconomyScript.GetPlayerMoney() + rewareds + tests);

    }

    private void SoundToggleButton_OnClick()
    {
    }

    private void DoubleCashButton_OnClick()
    {
        AdsManager.Instance.ShowAd(AdType.REWARDED);

    }

    private void GarageButton_OnClick()
    {
        SceneManager.LoadScene("Garage");

    }

    private void NextStageButton_OnClick()
    {
        SceneManager.LoadScene("InGame");
    }

    private bool playerRewarded = false;
    public void TextsAnimation()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            int val = (int)LoadedLevelManager.Instance.Player.PlayedTime();

            int test = 0;
            DOTween.To(() => test, x => ScoreText.text = x.ToString("n0"), val, TextsAnimationDuration);
        }).AppendInterval(TextsAnimationInterval)
        .AppendCallback(() =>
        {

            ScoreTextNew.SetActive(EconomyScript.IsNewPlayedTime(LoadedLevelManager.Instance.Player.PlayedTime()));

            int val = (int)LoadedLevelManager.Instance.Player.PlayedSpeed();
            int test = 0;
            DOTween.To(() => test, x => SpeedText.text = x.ToString("n0"), val, TextsAnimationDuration);
        }).AppendInterval(TextsAnimationInterval*Mathf.Clamp((int)LoadedLevelManager.Instance.Player.BoostUsed(), 0,1)).AppendCallback(() =>
        {

            SpeedTextNew.SetActive(EconomyScript.IsNewHighSpeed(LoadedLevelManager.Instance.Player.PlayedSpeed()));

            int val = (int)LoadedLevelManager.Instance.Player.BoostUsed();

            int test = 0;
            DOTween.To(() => test, x => NitroText.text = x.ToString("n0"), val, TextsAnimationDuration);
        }).AppendInterval(TextsAnimationInterval).AppendCallback(() =>
        {
            var boot = LoadedLevelManager.Instance.Player.BoostUsed();
            if (boot > 0)
            {

                NitroTextNew.SetActive(EconomyScript.IsNewUsedBoost(LoadedLevelManager.Instance.Player.BoostUsed()));
            }
            int val = (int)LoadedLevelManager.Instance.Player.PlayedTime() + (int)LoadedLevelManager.Instance.Player.PlayedSpeed() + (int)LoadedLevelManager.Instance.Player.BoostUsed();

            int test = 0;
            DOTween.To(() => test, x => FinalScoreText.text = x.ToString("n0"), val, TextsAnimationDuration);
        }).AppendInterval(TextsAnimationInterval).AppendCallback(() =>
        {
            if (playerRewarded)
            {
                return;
            }
            playerRewarded = true;
            int val = (int)LoadedLevelManager.Instance.Player.PlayedTime() + (int)LoadedLevelManager.Instance.Player.PlayedSpeed() + (int)LoadedLevelManager.Instance.Player.BoostUsed();
            int test = 0;


            float Rewards = EconomyScript.GetUpgradeLevel(GameManager.Instance.SelectedCarID + "_" + UpgradeTypes.Rewards.ToString());
            Rewards = (Rewards / 4) * val;
            rewareds = (int)(val + Rewards);

            var old = EconomyScript.GetPlayerMoney();


            DOTween.To(() => test, x => RewardsText.text = x.ToString("n0"), rewareds, TextsAnimationDuration);

            DOTween.To(() => old, x => PlayerMoney.text = x.ToString("n0"), old + rewareds, TextsAnimationDuration);
            EconomyScript.SetPlayerMoney(EconomyScript.GetPlayerMoney() + rewareds);
        });

    }

    public void Show()
    {
        gameObject.SetActive(true);
        ScoreTextNew.SetActive(false);
        SpeedTextNew.SetActive(false);
        NitroTextNew.SetActive(false);
        ScoreText.text = "0";
        SpeedText.text = "0";
        NitroText.text = "0";
        RewardsText.text = "0";
        TextsAnimation();

        if (LoadedLevelManager.Instance.DidWin)
        {
            NextStageText.text = "Next Stage";
            WinLoseText.text = "WINNER";
        }
        else
        {
            NextStageText.text = "Retry";
            WinLoseText.text = "LOSER";
        }

    }
}