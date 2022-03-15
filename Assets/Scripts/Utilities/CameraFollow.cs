using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using DG.Tweening;
public class CameraFollow : MonoBehaviour
{
	Camera x_camera;
	Transform target;
	public float startDur,endDur;
	public Ease startEase, endEase;
	// Offset from the target position
	[SerializeField] Vector3 offset;



	void Start()
	{
		x_camera = GetComponent<Camera>();
		LoadedLevelManager.Instance.OnRaceStarted += OnRaceStarted;
		LoadedLevelManager.Instance.OnRaceStarted += OnRaceStarted;

		LoadedLevelManager.Instance.Player.OnBoostStarted+= OnBoostStarted;
		LoadedLevelManager.Instance.Player.OnBoostEnded += OnBoostEnded;


		target = LoadedLevelManager.Instance.Player.transform;
	}

    private void OnBoostEnded()
    {
		//x_camera.DOFieldOfView(80, endDur).SetEase(endEase);

	}

	private void OnBoostStarted()
	{
		//x_camera.DOFieldOfView(90, startDur).SetEase(startEase);
	}

	private void OnRaceStarted()
	{
		LoadedLevelManager.Instance.OnRaceEnded -= OnRaceStarted;
	}
	public float Remap(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return outMin + (((value - inMin) / (inMax - inMin)) * (outMax - outMin));
	}
	private void Update()
    {
		x_camera.fieldOfView = Remap(LoadedLevelManager.Instance.Player.GetAvailableBoost(), 1, 0, 80, 90);
	}
    void FixedUpdate()
	{
		transform.position = new Vector3(5, 6, target.position.z + offset.z);
	}
}