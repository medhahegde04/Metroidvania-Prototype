
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    private bool playerInRange = false;

    public void Interact()
    {
        if (playerInRange)
        {
            Debug.Log("Key collected!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to collect key");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
