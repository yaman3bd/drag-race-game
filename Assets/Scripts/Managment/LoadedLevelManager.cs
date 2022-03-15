using GameManagment;
using Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedLevelManager : MonoBehaviour
{
    public static LoadedLevelManager Instance;
    public Action OnRaceStarted;
    public Action OnRaceEnded;
    public Action OnBeforeRaceStarted;

    public Material[] CarMaterials;

    public Canvas PlayerNameCanvas;
    public GameObject EndLine;
    [HideInInspector]
    public CarController Player;
    [HideInInspector]
    public CarController AI;
    [HideInInspector]
    public bool DidWin;

    public Material sunsetSkybox;
    public Material daylightSkybox;
    public Color ambientLightSunsetColor;
    public Color ambientLightDaylightColor;
    public Color fogSunsetColor;
    public Color fogDaylightColor;

    private string[] names;
    private void SetSunset()
    {
        RenderSettings.skybox = sunsetSkybox;
        RenderSettings.ambientLight = (Vector4)ambientLightSunsetColor;
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogSunsetColor;
    }
    private void SetDaylight()
    {

        RenderSettings.skybox = daylightSkybox;
        RenderSettings.ambientLight = (Vector4)ambientLightDaylightColor;
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogDaylightColor;
    }
    private void Awake()
    {
        names = new string[] { "Ali", "Dani", "Lara", "Alex", "Y3bd", "Emma", "Mia", "Sara", "Alma", "Jak" };
        int envVal = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

        if (envVal % 2 == 0)
        {
            SetDaylight();
        }
        else
        {
            SetSunset();
        }

        Instance = this;
        DidWin = false;
        envVal = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        if (envVal % 2 == 0)
        {
            var environment = Instantiate(Resources.Load<GameObject>("Environment/Forest"));
        }
        else
        {
            var environment = Instantiate(Resources.Load<GameObject>("Environment/Desert"));
        }




        var playerCar = Instantiate(Resources.Load<GameObject>("InGameCars/" + GameManager.Instance.SelectedCarID));
        Player = playerCar.GetComponent<CarController>();
         GenerateName(playerCar.transform, "You");

         Player.tag = "Player";

        MeshRenderer[] coloredMeshes = playerCar.GetComponentsInChildren<MeshRenderer>();
        int j = EconomyScript.GetSelectedColorIndex(GameManager.Instance.SelectedCarID);

        foreach (var item in coloredMeshes)
        {
            item.material = CarMaterials[j];
        }
        Player.SetCarPosition(-2.0f);

        int carID = UnityEngine.Random.Range(0, GameManager.Instance.CarsData.FilteredCarsDataList.Count - 1);
        var aiCar = Instantiate(Resources.Load<GameObject>("InGameCars/c_" + carID));
        AI = aiCar.GetComponent<CarController>();
        AI.AutoGear = true;
        GenerateName(aiCar.transform, names[UnityEngine.Random.Range(0, names.Length)]);

        AI.SetCarPosition(2.0f);
        AI.tag = "AI";

        MeshRenderer[] aiColoredMeshes = aiCar.GetComponentsInChildren<MeshRenderer>();
        int index = Mathf.Clamp(UnityEngine.Random.Range(0, CarMaterials.Length), 0, CarMaterials.Length - 1);
        foreach (var item in aiColoredMeshes)
        {
            item.material = CarMaterials[index];
        }

    }
    private void GenerateName(Transform parent,string plyrname)
    {
        var name = Instantiate<Canvas>(PlayerNameCanvas, PlayerNameCanvas.transform.position, PlayerNameCanvas.transform.rotation, parent);
        name.renderMode = RenderMode.WorldSpace;
        name.worldCamera = Camera.main;
        name.GetComponentInChildren<TMPro.TMP_Text>().text = plyrname;
    }
    public void StartRace()
    {
        if (OnRaceStarted != null)
        {
            OnRaceStarted();
        }
    }

    public void EndRace(bool winner)
    {
        DidWin = winner;

        if (OnRaceEnded != null)
        {
            OnRaceEnded();
        }
    }
}