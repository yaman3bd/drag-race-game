using System.Collections;
using System.Linq;

using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
#if UNITY_EDITOR
[ExecuteInEditMode]
public class CarsInitializer : MonoBehaviour
{

    const string AllCarsPath = "Assets/ARCADE - Ultimate Vehicles Pack/Prefabs (With Colliders)/Land";
    const string MaterialsPath = "Assets/ARCADE - Ultimate Vehicles Pack/Materials/Color Variations";
    const string CarSoundsPath = "Assets/Audio";

    static void cars()
    {

        int carIndex = 0;

        AssetDatabase.DeleteAsset("Assets/Resources");
        AssetDatabase.DeleteAsset("Assets/GameData");

        string resourcesFolderGuid = AssetDatabase.CreateFolder("Assets", "Resources");
        string gameDataFolderGuid = AssetDatabase.CreateFolder("Assets", "GameData");
        string gameDataPath = AssetDatabase.GUIDToAssetPath(gameDataFolderGuid);
        string carsDataFolderGuid = AssetDatabase.CreateFolder(gameDataPath, "CarsData");

        string carsDataFolderPath = AssetDatabase.GUIDToAssetPath(carsDataFolderGuid);

        //string resourcesFolderPath = AssetDatabase.GUIDToAssetPath(resourcesFolderGuid);

        string inGameFolderGuid = AssetDatabase.CreateFolder("Assets/Resources", "InGameCars");

        string inGameFolderPath = AssetDatabase.GUIDToAssetPath(inGameFolderGuid);

        var paranetFolder = AssetDatabase.GetSubFolders(AllCarsPath);


        foreach (var folder in paranetFolder)
        {

            var subFolder = AssetDatabase.GetSubFolders(folder);
            if (subFolder.Length > 0)
            {

                foreach (var assetRoot in subFolder)
                {
                    var assetsPath = GetAssetsFromPath(assetRoot, "*.prefab");

                    foreach (var asset in assetsPath)
                    {
                        CopyCarAtPath(asset, inGameFolderPath, carIndex, carsDataFolderPath);
                        carIndex++;
                    }
                }
            }
            else
            {

                var assetsPath = GetAssetsFromPath(folder, "*.prefab");
                foreach (var asset in assetsPath)
                {
                    CopyCarAtPath(asset, inGameFolderPath, carIndex, carsDataFolderPath);
                    carIndex++;
                }
            }

        }

        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

    }
    static void intGarageCar(FileInfo asset, string resourcesFolderPath, int carIndex)
    {

        //change directory absolute path to assets folder path
        string carAssetPath = asset.FullName.Substring(asset.FullName.IndexOf("Assets"));
 
        //get car name to copy it as an asset
        string assetName = AssetDatabase.LoadMainAssetAtPath(carAssetPath).name;
        if (assetName == "Camilla-107" || assetName == "Hebe_Trailer")
        {
            return;
        }


        //load the car as GameObject
        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(asset.FullName);
 
        //save change
        PrefabUtility.SaveAsPrefabAsset(contentsRoot, $"{resourcesFolderPath}/c_{carIndex}{asset.Extension}");
        //unload the car GameObject 
        PrefabUtility.UnloadPrefabContents(contentsRoot);
    }
    static void CopyCarAtPath(FileInfo asset, string resourcesFolderPath, int carIndex, string carsDataFolderPath)
    {

        //change directory absolute path to assets folder path
        string carAssetPath = asset.FullName.Substring(asset.FullName.IndexOf("Assets"));
        string carParentAssetName = asset.Directory.FullName.Substring(asset.Directory.FullName.LastIndexOf("\\")).Replace("\\", "");

        //get car name to copy it as an asset
        string assetName = AssetDatabase.LoadMainAssetAtPath(carAssetPath).name;
        if (assetName == "Camilla-107" || assetName == "Hebe_Trailer")
        {
            return;
        }


        //load the car as GameObject
        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(asset.FullName);
        InitCarStuntAnimation(contentsRoot);
        InitCarMats(contentsRoot);
        InitCarSounds(contentsRoot);
        InitCarBodyColliders(contentsRoot);

        CarController cc = contentsRoot.AddComponent<CarController>();
        InitCarEffects(contentsRoot, cc);

        cc.CarData = GetCarData(assetName, carParentAssetName, carsDataFolderPath, carIndex);
        cc.CenterOfMass = GetCenterOfMess(contentsRoot);

        //get the colorable meshes to assign car desired color
        InitCarWheels(contentsRoot, cc);
        //save change
        PrefabUtility.SaveAsPrefabAsset(contentsRoot, $"{resourcesFolderPath}/{cc.CarData.ID}{asset.Extension}");
        //unload the car GameObject 
        PrefabUtility.UnloadPrefabContents(contentsRoot);

    }
    static FileInfo[] GetAssetsFromPath(string path, string type)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        return dir.GetFiles(type);
    }
    [MenuItem("Cars/Init In Game Cars")]
    static void InitInGameCars()
    {
        cars();
    }
    [MenuItem("Cars/Init Garage Cars")]
    static void InitInGarageCars()
    {
      
        int carIndex = 0;

        AssetDatabase.DeleteAsset("Assets/Resources/GarageCars");



        //string resourcesFolderPath = AssetDatabase.GUIDToAssetPath(resourcesFolderGuid);

        string garageCarsFolderGuid = AssetDatabase.CreateFolder("Assets/Resources", "GarageCars");

        string garageCarsFolderPath = AssetDatabase.GUIDToAssetPath(garageCarsFolderGuid);

        var paranetFolder = AssetDatabase.GetSubFolders(AllCarsPath);


        foreach (var folder in paranetFolder)
        {

            var subFolder = AssetDatabase.GetSubFolders(folder);
            if (subFolder.Length > 0)
            {

                foreach (var assetRoot in subFolder)
                {
                    var assetsPath = GetAssetsFromPath(assetRoot, "*.prefab");

                    foreach (var asset in assetsPath)
                    {
                        intGarageCar(asset, garageCarsFolderPath, carIndex);
                        carIndex++;
                    }
                }
            }
            else
            {

                var assetsPath = GetAssetsFromPath(folder, "*.prefab");
                foreach (var asset in assetsPath)
                {
                    intGarageCar(asset, garageCarsFolderPath, carIndex);
                    carIndex++;
                }
            }

        }

        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

        
    }

    private static Transform GetCenterOfMess(GameObject car)
    {
        Transform centerOfMess = new GameObject("CenterOfMess").transform;
        centerOfMess.SetParent(car.transform);
        centerOfMess.localPosition = new Vector3(0, 0.3853133f, 0);
        return centerOfMess;
    }
    private static CarDataScriptableObject GetCarData(string assetName, string carParentAssetName, string carsDataFolderPath, int carIndex)
    {
        CarDataScriptableObject car = ScriptableObject.CreateInstance<CarDataScriptableObject>();

        car.Name = assetName;
        car.DefaultGearRatio = new float[] { 4.171f, 2.340f, 1.521f, 1.143f, 0.867f, 0.691f };
        car.DefaultEngineTorquesPerGear = new float[] { 150.0f, 180.0f, 200.0f, 250.0f, 400.0f, 600.0f };
        car.DefaultMaxSpeedsPerGear = new float[] { 30.0f, 50.0f, 80.0f, 150.0f, 200.0f, 240.0f };

        car.CarMaxSpeed = 150.0f;
        car.CarMaxGearsCount = 5;
        car.IsAvailable = true;
        car.FinalDriveRatio = 3.460f;
        car.MaxBoostTime = 1.5f;
        car.BoostRefillSpeed = 1;
        car.BoostForce = 7500.0f;
        car.DownForce = 500.0f;
        car.Price = UnityEngine.Random.Range(100, 1500);

        car.DrivingType = DrivingTypes.All;
        car.ClassName = carParentAssetName;
        car.ID = "c_" + carIndex;
        
        string path = carsDataFolderPath + "/" + car.ID + ".asset";
        AssetDatabase.CreateAsset(car, path);


        AssetDatabase.SaveAssets();

        return car;
    }

    private static void InitCarBodyColliders(GameObject car)
    {
        Transform carBody = car.transform.Find("Body");
        Mesh mesh = carBody.gameObject.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;

        BoxCollider bodyBox = carBody.gameObject.GetComponent<BoxCollider>();

        DestroyImmediate(bodyBox);

        for (int i = 0; i < 2; i++)
        {
            CapsuleCollider bodyCollider = carBody.gameObject.AddComponent<CapsuleCollider>();
            bodyCollider.center = new Vector3(i > 0 ? 0.4530767f : 0.4530767f * -1, bounds.center.y, bounds.center.z);
            bodyCollider.radius = 0.4946867f;
            bodyCollider.height = bounds.size.z;
            bodyCollider.direction = 2;
        }
    }
    private static void InitCarWheels(GameObject car, CarController cc)
    {
        //get the wheels parent 
        Transform wheelsParent = car.transform.Find("Wheels");
        if (wheelsParent)
        {

            //get wheel colliders
            WheelCollider[] wheelColliders = wheelsParent.GetComponentsInChildren<WheelCollider>();
            //get wheel meshes to assign them to the rotatable wheels
            MeshRenderer[] wheelMeshes = wheelsParent.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < wheelColliders.Length; i++)
            {
                WheelCollider wheelCollider = wheelColliders[i];
                MeshRenderer wheelMeshe = wheelMeshes[i];

                Suspension suspension = wheelCollider.gameObject.AddComponent<Suspension>();
                suspension.wheelCollider = wheelCollider;
                suspension.wheelMeshe = wheelMeshe.transform;
            }

            cc.FrontWheels = wheelColliders.Where(wheel => wheel.name.Contains("Front")).ToArray();
            cc.RearontWheels = wheelColliders.Where(wheel => wheel.name.Contains("Rear")).ToArray();
            cc.AllWheels = wheelColliders;
        }
    }
    private static void InitCarSounds(GameObject car)
    {
        // var carSoundsFolder = AssetDatabase.GetAssetPath(CarSoundsPath);

        /* var soundsFolders = AssetDatabase.GetSubFolders(CarSoundsPath);
         foreach (var soundsFolder in soundsFolders)
         {
             var subFolder = AssetDatabase.GetSubFolders(soundsFolder);
             foreach (var folder in subFolder)
             {
                 var assetsPath = GetAssetsFromPath(folder, "*.wav");
                 foreach (var asset in assetsPath)
                 {
                     string carAssetPath = asset.FullName.Substring(asset.FullName.IndexOf("Assets"));
                    var a = (AudioClip)AssetDatabase.LoadAssetAtPath(carAssetPath, typeof(AudioClip));

                 }

             }

         }*/
        CarAudio ca = car.AddComponent<CarAudio>();
        ca.EngineSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets\\Audio\\CarSounds\\Engine\\EngineSound.wav", typeof(AudioClip));
        ca.BoostSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets\\Audio\\CarSounds\\Boost\\BoostSound.wav", typeof(AudioClip));

    }
    private static void InitCarEffects(GameObject car, CarController cc)
    {
        Transform effectsParent = new GameObject("Effects").transform;
        effectsParent.SetParent(car.transform);
        effectsParent.localPosition = Vector3.zero;

        var body = car.transform.Find("Body");

        var bodySize = body.GetComponent<Renderer>().bounds.center;
        var bodySizes = body.GetComponent<Renderer>().bounds.size;
        var bodySizesmin = body.GetComponent<Renderer>().bounds.min;

        Debug.Log(bodySizesmin);
        var GasParticles = (GameObject)AssetDatabase.LoadAssetAtPath("Assets\\Prefabs\\Effects\\FX_Fire_AC.prefab", typeof(GameObject));
        var GasParticlesPrefab = (GameObject)PrefabUtility.InstantiatePrefab(GasParticles);
        GasParticlesPrefab.name = GasParticlesPrefab.name.Replace("(clone)", "");
        GasParticlesPrefab.transform.SetParent(effectsParent);
        GasParticlesPrefab.transform.localPosition = new Vector3(bodySize.x, bodySizesmin.y, bodySizes.z / 2 * -1);
        GasParticlesPrefab.transform.eulerAngles = new Vector3(-60, 0, 0);
        cc.BoostEffect = GasParticlesPrefab;

    }
    private static void InitCarMats(GameObject car)
    {
        //load mats
        DirectoryInfo dir = new DirectoryInfo(MaterialsPath);
        var a = dir.GetFiles("*.mat");
        foreach (var item in a)
        {
            string assetPath = item.FullName.Substring(item.FullName.IndexOf("Assets"));

            var mat = (Material)AssetDatabase.LoadAssetAtPath(assetPath, typeof(Material));

        }
        //end load mats
        MeshRenderer[] coloredMeshes = car.GetComponentsInChildren<MeshRenderer>();

    }

    private static void InitCarStuntAnimation(GameObject car)
    {
        Transform carBody = car.transform.Find("Body");

        Transform frontAnimatedWheels = new GameObject("FrontAnimatedWheels").transform;
        frontAnimatedWheels.SetParent(carBody);
        frontAnimatedWheels.localPosition = Vector3.zero;

        CarStuntAnimation csa = carBody.gameObject.AddComponent<CarStuntAnimation>();

        csa.CarBodyStuntPosition = new Vector3(0, 0.15f, 0);
        csa.CarBodyStuntRotation = new Vector3(-10, 0, 0);
        csa.CarBodyStuntDuration = 0.5f;


        csa.FrontWheelAnimatedMeshesPosition = new Vector3(0, -0.1f, 0);
        csa.FrontWheelStuntDuration = 0.2f;
        csa.FrontWheelRotSpeed = 5;


        Transform wheelsParent = car.transform.Find("Wheels");
        if (wheelsParent)
        {


            MeshRenderer[] wheelMeshes = wheelsParent.GetComponentsInChildren<MeshRenderer>();
            var frontWheels = wheelMeshes.Where(wheel => wheel.name.Contains("Front")).ToArray();
            csa.FrontWheelMeshes = new Transform[2];


            for (int i = 0; i < 2; i++)
            {
                csa.FrontWheelMeshes[i] = frontWheels[i].transform;
                var frontWheel = Instantiate(frontWheels[i]);
                frontWheel.transform.SetParent(frontAnimatedWheels);
                frontWheel.transform.localPosition = frontWheels[i].transform.localPosition;
                frontWheel.name = frontWheel.name.Replace("(Clone)", "");
            }
        }
    }
}
#endif