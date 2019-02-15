using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator playerAnim;
    public GameObject effectPrefab;
    public Transform rayOrigin;
    Rigidbody rb;
    public GameManager gameManager;
    bool isRight = true;
    float moveSpeed = 1.5f;
    float elapsedTime = 2;
	// Use this for initialization

	void Start () {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Time.time > elapsedTime)
        {
            moveSpeed *= 1.1f;
            elapsedTime = Time.time + 2;
        }



        if (transform.position.y < -3)
        {
            gameManager.RestartGame();
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RotatePlayer();
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RotatePlayer();
        }
    }



    private void FixedUpdate()
    {
        if (!gameManager.isGameStarted) return;
        

        playerAnim.SetTrigger("gameStarted");

        rb.position += transform.forward * moveSpeed * Time.deltaTime;


        if (!Physics.Raycast(rayOrigin.position, Vector3.down))
        {
            playerAnim.SetTrigger("falling");
        }

    }

    private void RotatePlayer()
    {
        isRight = !isRight;

        if (isRight)
            rb.rotation = Quaternion.Euler(0, 45, 0);
        else
            rb.rotation = Quaternion.Euler(0, -45, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Crystal")
        {
            GameObject effect = Instantiate(effectPrefab, transform);

            Destroy(effect, 1f);

            gameManager.MakeScore();
            Destroy(other.gameObject);
        }

    }
}
