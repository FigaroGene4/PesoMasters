using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimController : MonoBehaviour
{
    public Animator animator;
    public float animationDuration = 5f; // Change this to adjust duration

    private float timer = 0f;

    void Start()
    {
        animator.SetBool("PlayAnimation", false); // Start the animation
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= animationDuration)
        {
            animator.SetBool("StopAnimation", true); // Stop the animation
            Destroy(this.gameObject, 1f); // Destroy the GameObject after 1 second (optional)
        }
    }
}

