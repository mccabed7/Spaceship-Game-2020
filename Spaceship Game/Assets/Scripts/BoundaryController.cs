using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    public Camera mainCamera;
    public Collider2D boundaryCollider;
    public Vector3 screenSize;
    void Start()
    {
        
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }


}
