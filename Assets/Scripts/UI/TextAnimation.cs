using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class TextAnimation : MonoBehaviour
{
    public TMP_Text Target;
    [Header("Transform Scale")]
    public bool Scale;
    public Vector3 FromScale;
    public Vector3 ToScale;
    public float ScaleDuration;
    [Header("Transform Position")]
    public bool Position;
    public Vector3 FromPosition;
    public Vector3 ToPosition;
    public float PositionDuration;
    [Header("Transform Rotation")]
    public bool Rotation;
    public Vector3 FromRotation;
    public Vector3 ToRotation;
    public float RotationDuration;
    [Header("Text Color")]
    public bool Color;
    public Color FromColor;
    public Color ToColor;
    public float ColorDuration;
    [Header("Text Fade")]
    public bool Fade;
    public float FromFade;
    public float ToFade;
    public float FadeDuration;

    public void ScaleAnimaton()
    {
        if (!Scale)
        {
            return;
        }
        Target.transform.localScale = FromScale;
        Target.transform.DOScale(ToScale, ScaleDuration).SetLoops(-1, LoopType.Yoyo);
    }
    public void PositionAnimaton()
    {
        if (!Position)
        {
            return;
        }
        Target.transform.position = FromPosition;
        Target.transform.DOLocalMove(ToPosition, PositionDuration).SetLoops(-1, LoopType.Yoyo);
    }
    public void RotationAnimaton()
    {
        if (!Rotation)
        {
            return;
        }

        Target.transform.eulerAngles= FromRotation;
        Target.transform.DORotate(ToRotation, RotationDuration).SetLoops(-1, LoopType.Yoyo);
    }
    public void ColorAnimaton()
    {
        if (!Color)
        {
            return;
        }
        Target.color = FromColor;
        Target.DOColor(ToColor, ColorDuration).SetLoops(-1, LoopType.Yoyo);
    }

    public void FadeAnimaton()
    {
        if (!Fade)
        {
            return;
        }
        Target.color = new Color(Target.color.r, Target.color.g, Target.color.b, FromFade);
        Target.DOFade(ToFade, FadeDuration).SetLoops(-1, LoopType.Yoyo);
    }
    // Start is called before the first frame update
    void Start()
    {
        ScaleAnimaton();
        PositionAnimaton();
        RotationAnimaton();
        ColorAnimaton();
        FadeAnimaton();
      /*  Target.color = new Color(Target.color.r, Target.color.g, Target.color.b, FromFade);
        Target.transform.localScale = FromScale;

        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            Target.transform.DOScale(ToScale, ScaleDuration);
        }).AppendInterval(ScaleDuration).AppendCallback(() =>
        {
            Target.transform.DOScale(FromScale, ScaleDuration);
        }).AppendInterval(ScaleDuration).AppendCallback(() =>
        {
            Target.transform.DOScale(ToScale, ScaleDuration);
        }).AppendInterval(ScaleDuration).AppendCallback(() =>
        {
            Target.DOFade(ToFade, FadeDuration);
        });*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
