using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            other.transform.parent.GetComponent<Movement>().FloorDetected();
        }
    }
}
