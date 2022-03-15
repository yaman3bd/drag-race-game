using UnityEngine;
using TMPro;
public class t : MonoBehaviour
{

    public TMP_Text test;
    public float BoostTime;
    public float BoostRefillSpeed;
    public float MaxBoostTime;
    public bool IsBoosting;

    void Update()
    {
        if (!IsBoosting)
        {
            BoostTime += Time.deltaTime * BoostRefillSpeed;
            if (BoostTime > MaxBoostTime)
            {
                BoostTime = MaxBoostTime;
            }
        }
        ActivateBoost();
        Debug.Log(GetAvailableBoost() - 1);
        Debug.Log(GetAvailableBoost());
        test.text = Remap(GetAvailableBoost(), 1, 0, 80, 90).ToString();
    }
    public float Remap(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return outMin + (((value - inMin) / (inMax - inMin)) * (outMax - outMin));
    }
    public float GetAvailableBoost()
    {
        return BoostTime / MaxBoostTime;
    }
    public void ActivateBoost()
    {
        // Boost
        if (IsBoosting && BoostTime > 0.0f)
        {
            BoostTime -= Time.fixedDeltaTime;
            if (BoostTime < 0f)
            {
                BoostTime = 0f;
                IsBoosting = false;
            }
        }
    }
}