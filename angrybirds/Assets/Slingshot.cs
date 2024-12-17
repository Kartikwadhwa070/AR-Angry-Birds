using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform slingAnchor; // Position of the slingshot
    public Rigidbody projectilePrefab; // Bird prefab (Rigidbody)
    public float launchForce = 500f; // Force for the launch

    private Rigidbody currentProjectile; // The current bird
    private Vector3 dragStart, dragEnd;

    void Start()
    {
        CreateProjectile(); // Instantiate the bird at the start
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = Input.mousePosition; // Capture the start of the drag
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragEnd = Input.mousePosition; // Capture the end of the drag
            LaunchProjectile(); // Launch the projectile when mouse button is released
        }
    }

    void CreateProjectile()
    {
        // Only instantiate if currentProjectile is null (if it's not there already)
        if (currentProjectile == null)
        {
            currentProjectile = Instantiate(projectilePrefab, slingAnchor.position, Quaternion.identity);
            currentProjectile.useGravity = false; // Disable gravity before launch
            currentProjectile.isKinematic = true; // Disable physics before launch
        }
        else
        {
            // If projectile exists, reset it (for re-use)
            currentProjectile.transform.position = slingAnchor.position;
            currentProjectile.velocity = Vector3.zero;
            currentProjectile.angularVelocity = Vector3.zero;
            currentProjectile.isKinematic = true;
            currentProjectile.useGravity = false;
        }
    }

    void LaunchProjectile()
    {
        // Make sure gravity and physics are enabled for the bird after launch
        currentProjectile.isKinematic = false; // Enable physics
        currentProjectile.useGravity = true; // Enable gravity

        // Calculate direction and force for the launch
        Vector3 dragDirection = (dragStart - dragEnd).normalized;
        float dragDistance = Vector3.Distance(dragStart, dragEnd);

        // Apply force to launch the bird
        currentProjectile.AddForce(dragDirection * dragDistance * launchForce);

        // Optional: Reset the bird after a delay (if you want to create a new bird after some time)
        Invoke(nameof(CreateProjectile), 2f); // Create a new bird after 2 seconds
    }
}
