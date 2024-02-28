using UnityEngine;

public class SelectSprite : MonoBehaviour
{
    public Sprite newSprite; // Assign the new sprite in the Unity Editor

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            CharacterSelectManager.instance.SetSelectedSprite(spriteRenderer.sprite);
            Debug.Log("Sprite Selected");
        }
        
        // Check if the new sprite is assigned
        if (newSprite != null)
        {
            // Change the sprite
            spriteRenderer.sprite = newSprite;
            Debug.Log("New sprite is assigned!");
        }
        else
        {
            Debug.LogError("New sprite is not assigned!");
        }
    }
}
/*
private void OnMouseDown()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                CharacterSelectManager.instance.SetSelectedSprite(spriteRenderer.sprite);
                Debug.Log("Sprite Selected");
            }
        }
*/