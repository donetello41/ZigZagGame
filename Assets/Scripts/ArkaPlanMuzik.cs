using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanMuzik : MonoBehaviour {

    static ArkaPlanMuzik instance;

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }



        DontDestroyOnLoad(instance);
	}



}
