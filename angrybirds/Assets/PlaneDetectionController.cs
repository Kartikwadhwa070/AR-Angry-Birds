using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class PlaneDetectionController : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Get the ARPlaneManager component attached to the GameObject
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    // OnEnable is called when the object becomes enabled and active.
    private void OnEnable()
    {
        // Subscribe to the planesChanged event
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    // OnDisable is called when the object becomes disabled or inactive.
    private void OnDisable()
    {
        // Unsubscribe from the planesChanged event to prevent memory leaks
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    // This function is called whenever planes are added, updated, or removed.
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // Handle added planes
        foreach (ARPlane plane in args.added)
        {
            // Plane added, do something
            Debug.Log("Plane added: " + plane.trackableId);
        }

        // Handle updated planes
        foreach (ARPlane plane in args.updated)
        {
            // Plane updated, do something
            Debug.Log("Plane updated: " + plane.trackableId);
        }

        // Handle removed planes
        foreach (ARPlane plane in args.removed)
        {
            // Plane removed, do something
            Debug.Log("Plane removed: " + plane.trackableId);
        }
    }
}
