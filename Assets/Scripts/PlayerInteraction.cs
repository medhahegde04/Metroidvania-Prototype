using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private KeyInteraction nearbyKey;
    private ChestInteraction nearbyChest;
    private bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            nearbyKey = other.GetComponent<KeyInteraction>();
        }

        if (other.CompareTag("Chest"))
        {
            nearbyChest = other.GetComponent<ChestInteraction>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            nearbyKey = null;
        }

        if (other.CompareTag("Chest"))
        {
            nearbyChest = null;
        }
    }

    public void OnInteract(InputValue value)
    {
        if (!value.isPressed)
            return;

        if (nearbyKey != null)
        {
            nearbyKey.Interact();
            hasKey = true;
        }

        else if (nearbyChest != null)
        {
            if (hasKey)
            {
                nearbyChest.OpenChest();
                hasKey = false;
            }
            else
            {
                Debug.Log("You need a key to open this chest!");
            }
        }
    }
}