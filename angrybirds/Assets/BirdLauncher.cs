using UnityEngine;

public class BirdLauncher : MonoBehaviour
{
    public GameObject birdPrefab;
    public Transform slingshotOrigin;
    public float launchSpeed = 10f;

    private GameObject currentBird;
    private Vector3 startPos;
    private bool isDragging = false;

    void Start()
    {
        // Spawn the first bird
        SpawnBird();
    }

    void Update()
    {
        if (isDragging)
        {
            // Update bird position as user drags it back
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            currentBird.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Start drag when mouse/touch is pressed
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Launch bird when mouse/touch is released
            LaunchBird();
            isDragging = false;
        }
    }

    void LaunchBird()
    {
        Vector3 direction = startPos - currentBird.transform.position;
        currentBird.GetComponent<Rigidbody>().velocity = direction * launchSpeed;
        currentBird = null; // Bird launched, reset
    }

    void SpawnBird()
    {
        currentBird = Instantiate(birdPrefab, slingshotOrigin.position, Quaternion.identity);
    }
}
