using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using SecPlayerPrefs;
namespace GameManagment
{
    public class GameManager : Singleton<GameManager>
    {
        public string DefaultCarID;
        public string SelectedCarID
        {
            get
            {
                string id = EconomyScript.GetSelectedCarID();
                if (string.IsNullOrEmpty(id))
                {
                    return this.DefaultCarID;
                }
                return id;
            }
        }


        public CarsDataScriptableObject CarsData;


        protected override void Awake()
        {
            base.Awake();
            EconomyScript.DeleteAll();
            EconomyScript.SetPlayerMoney(100000);
            CarsData.Filter();
            if (!EconomyScript.IsCarOwned(this.SelectedCarID))
            {
                EconomyScript.SetOwnedCar(this.SelectedCarID);
            }
        }
    }
}