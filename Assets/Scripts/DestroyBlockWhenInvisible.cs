using UnityEngine;

public class DestroyBlockWhenInvisible : MonoBehaviour {

    Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.z > player.position.z) return;
        
        float mesafe = Vector3.Distance(player.position, transform.position);
        if (mesafe > Camera.main.orthographicSize *2)
        {
            Destroy(gameObject);
        }
	}
}
