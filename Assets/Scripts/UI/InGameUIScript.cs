using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameUIScript : MonoBehaviour
{
    public static InGameUIScript Instance;
    public TMP_Text GearUpText;
    public EndUIScript EndUI;
    public CountDownUIScript CountDownUI;
    private CarController PCC
    {
        get
        {
            return LoadedLevelManager.Instance.Player;
        }
    }
    public TMP_Text CurrentSpeedText;
    public TMP_Text CurrentGearText;
    public TMP_Text PlayerMoney;
    [Space]
    public Transform SpeedNeedleTransform;
    public float SpeedNeedle_SpeedFactor;
    public float SpeedNeedle_DeSpeedFactor;
    public float SpeedNeedle_Speed;
    public float SpeedNeedle_MaxSpeed;
    [Space]
    public Button GearUpButton;
    public Button GearDownButton;
    public Button NitroButton;
    [Space]
    public Slider PlayerProgressSlider;
    public Slider AIProgressSlider;
    [Space]
    public Image NitroFillImage;

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PCC.OnDangerZooneStarted += OnDangerZooneStarted;
        PCC.OnDangerZooneEned += OnDangerZooneEned;

        PlayerMoney.text = EconomyScript.GetPlayerMoney().ToString("n0");
        GearUpButton.onClick.AddListener(GearUpButton_OnClick);
        GearDownButton.onClick.AddListener(GearDownButton_OnClick);
        NitroButton.onClick.AddListener(NitroButton_OnClick);
        StartCoroutine(Countdown(3));
    }

    private void OnDangerZooneEned()
    {
        GearUpText.gameObject.SetActive(false);
    }

    private void OnDangerZooneStarted()
    {

        GearUpText.gameObject.SetActive(true);
    }

    private void NitroButton_OnClick()
    {
        PCC.ActiveBoost();
    }

    private void GearUpButton_OnClick()
    {

        ResetSpeedNeedleSpeed();
        PCC.ChangeGear(true);
    }
    private void GearDownButton_OnClick()
    {
        ResetSpeedNeedleSpeed();
        PCC.ChangeGear(false);
    }
    private void ResetSpeedNeedleSpeed()
    {
        SpeedNeedle_Speed = 0;
    }
    public float smoothTime = 0.3f;
    public float yVelocity = 0.0f;
    public float z;
    // Update is called once per frame
    void Update()
    {
        CurrentSpeedText.text = ((int)PCC.KPH).ToString();
        CurrentGearText.text = (PCC.currentGear + 1).ToString();


        float gearLenght = PCC.CarMaxSpeedPerGear[1] - PCC.CarMaxSpeedPerGear[0];

        var y = PCC.KPH - PCC.GetPrevSpeed();

        var x = (180 * y) / gearLenght;
       

        x = Mathf.Clamp(x, 0, (165 + PCC.GetTimeToGear()));


        SpeedNeedleTransform.localEulerAngles = new Vector3(0, 0, x * -1);
        Progress();
        NitroFillImage.fillAmount = PCC.GetAvailableBoost();
    }
    private void Progress()
    {

        float playerProgress = PCC.DistancTravled / LoadedLevelManager.Instance.EndLine.transform.position.z;
        float aiProgress = LoadedLevelManager.Instance.AI.DistancTravled / 700;

        PlayerProgressSlider.value = playerProgress;
        AIProgressSlider.value = aiProgress;

    }
    private bool VectorInRage(Vector3 v, Vector3 target, float min, float max)
    {
        float dis = Vector3.Distance(v, target);

        return dis > min && dis < max;
    }



    IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        int index = 0;
        while (count > 0)
        {
            CountDownUI.SetLight(index++, count);
            yield return new WaitForSeconds(1);
            count--;
        }
        LoadedLevelManager.Instance.StartRace();
    }
}
