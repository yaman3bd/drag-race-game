using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarStuntAnimation : MonoBehaviour
{
    [Header("Car Body Stunt")]
    public Vector3 CarBodyStuntPosition;
    public Vector3 CarBodyStuntRotation;
    public float CarBodyStuntDuration;

    [Header("Front Wheels Stunt")]
    public Vector3 FrontWheelAnimatedMeshesPosition;
    public float FrontWheelStuntDuration;
    public float FrontWheelRotSpeed;

    private Transform CarBody;
    public Transform[] FrontWheelMeshes;
    private Transform FrontWheelAnimatedMeshes;

    // Start is called before the first frame update
    void Start()
    {
        CarBody = this.transform;
        FrontWheelAnimatedMeshes = CarBody.transform.GetChild(0);
        FrontWheelAnimatedMeshes.gameObject.SetActive(false);
    }
    public bool DoingAnimation;

    public void StartStuntAnimation()
    {
        if (DoingAnimation)
        {
            return;
        }
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            DoingAnimation = true;
            FrontWheelAnimatedMeshes.gameObject.SetActive(true);
            for (int i = 0; i < FrontWheelMeshes.Length; i++)
            {
                FrontWheelMeshes[i].gameObject.SetActive(false);
            }
        }).AppendCallback(() =>
        {
            CarBody.DOLocalMove(CarBodyStuntPosition, CarBodyStuntDuration);
            CarBody.DOLocalRotate(CarBodyStuntRotation, CarBodyStuntDuration);
            FrontWheelAnimatedMeshes.DOLocalMove(FrontWheelAnimatedMeshesPosition, FrontWheelStuntDuration);

        }).AppendInterval(CarBodyStuntDuration).
        AppendCallback(() =>
        {
            CarBody.DOLocalMove(Vector3.zero, CarBodyStuntDuration);

            CarBody.DOLocalRotate(Vector3.zero, CarBodyStuntDuration);
           // FrontWheelAnimatedMeshes.DOLocalMove(new Vector3(0, FrontWheelMeshes[0].transform.localPosition.y, 0), FrontWheelStuntDuration);
        }).AppendInterval(CarBodyStuntDuration).AppendCallback(() =>
        {
            DoingAnimation = false;
            FrontWheelAnimatedMeshes.gameObject.SetActive(false);
            for (int i = 0; i < FrontWheelMeshes.Length; i++)
            {
                FrontWheelMeshes[i].gameObject.SetActive(true);
            }
        });
        sequence.Play();


    }
    public
        bool t;
    public void Update()
    {
        if (t)
        {
            t = false;
            StartStuntAnimation();
        }
        for (int i = 0; i < FrontWheelAnimatedMeshes.childCount; i++)
        {
            FrontWheelAnimatedMeshes.GetChild(i).Rotate(new Vector3(1, 0, 0) * FrontWheelRotSpeed);
        }
    }
}
