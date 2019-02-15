using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour {

    int counter;
    public GameObject wallpart;
    public Transform player;
    Vector3 lastBlockPos;
    float offset = 0.707f;
	// Use this for initialization
	void Start () {
        lastBlockPos = wallpart.transform.position;
    }

    public void CreateWall()
    {
        InvokeRepeating("CreateWallParts", 0.5f, Time.deltaTime);
    }
	
	void CreateWallParts () {
        float distance = Vector3.Distance(lastBlockPos, player.position);
        float screenSize = Camera.main.orthographicSize*2;

        if (distance > screenSize+3) return;
        
        Vector3 newPos = Vector3.zero;
        int chance = Random.Range(0, 100);

        if (chance<50) // duvari yana (sola) yada degilse saga (arkaya) oluştur.
        {
           // newPos = lastBlockPos + new Vector3(offset, 0, offset);
            newPos = new Vector3(lastBlockPos.x + offset, 0, lastBlockPos.z + offset);
        }
        else
            newPos = new Vector3(lastBlockPos.x - offset, 0, lastBlockPos.z + offset);

        GameObject newWalPart = Instantiate(wallpart, newPos, Quaternion.Euler(0, 45, 0));

        lastBlockPos = newPos;

        if (counter++ % Random.Range(3,5)== 0)
        {
            newWalPart.transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
