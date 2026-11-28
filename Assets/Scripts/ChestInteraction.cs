using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private Animator anim;
    private bool isOpened = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenChest()
    {
        if (isOpened)
            return;

        isOpened = true;
        anim.SetTrigger("Open");
    }
}