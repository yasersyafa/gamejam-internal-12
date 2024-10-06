using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Periksa input pergerakan (misalnya, tombol WASD atau arah)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Jika player bergerak, trigger animasi "isRun"
        if (moveX != 0 || moveY != 0)
        {
            animator.SetTrigger("isRun");
        }
        else
        {
            animator.ResetTrigger("isRun"); // Reset trigger jika player berhenti bergerak
        }
    }
}
