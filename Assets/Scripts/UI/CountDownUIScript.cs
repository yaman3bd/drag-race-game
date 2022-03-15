using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownUIScript : MonoBehaviour
{
    public Image[] LightImages;
    public TMPro.TMP_Text TimeText;
    private void Start()
    {
        LoadedLevelManager.Instance.OnRaceStarted += Destroy;
    }

  
    public void SetLight(int index,int time)
    {
        TimeText.text = time.ToString();
        LightImages[index].color = new Color(LightImages[index].color.r, LightImages[index].color.g, LightImages[index].color.b, 1);
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
