using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button btn, btn1;
    public Text mycar,cc1Text;
    public CarController cc;
    public CarController cc1;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => 
        {
            cc.ChangeGear(true);
        });

        btn1.onClick.AddListener(() =>
        {
            cc.ActiveBoost();
        });
    }

    // Update is called once per frame
    void Update()
    {
        mycar.text = $"My car speed: {(int)cc.KPH} gear: {cc.CurrentGear}";
        cc1Text.text = $"other car speed: {(int)cc1.KPH} gear: {cc1.CurrentGear}";

    }
}
