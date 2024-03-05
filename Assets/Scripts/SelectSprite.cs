using UnityEngine;

public class SelectSprite : MonoBehaviour
{
    public Sprite newSprite; // Assign the new sprite in the Unity Editor

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Store the original sprite
    }

    private void OnMouseDown()
    {
        // Change sprite to new sprite if it's assigned
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            Debug.Log("New sprite is assigned!");
        }
        else
        {
            Debug.LogError("New sprite is not assigned!");
        }

        // Invoke a method to revert sprite back to original after a delay
        Invoke("RevertToOriginalSprite", 0.5f);
    }

    private void RevertToOriginalSprite()
    {
        // Change sprite back to original sprite
        spriteRenderer.sprite = originalSprite;
        Debug.Log("Sprite reverted to original!");
    }
}
