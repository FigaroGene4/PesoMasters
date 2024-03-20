using UnityEngine;

public class GenderManager : MonoBehaviour
{
    public Sprite clickedSprite; // Assign the clicked sprite in the Unity Editor
    private Sprite originalSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Store the original sprite
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked!");

        // Reset all sprites to original state
        ResetAllSprites();

        // Set the selected sprite to the clicked sprite
        spriteRenderer.sprite = clickedSprite;
    }

    private void ResetAllSprites()
    {
        // Find all sprite GameObjects in the scene
        GameObject[] sprites = GameObject.FindGameObjectsWithTag("Sprite");

        // Reset each sprite to its original state
        foreach (GameObject spriteObject in sprites)
        {
            GenderManager genderManager = spriteObject.GetComponent<GenderManager>();
            if (genderManager != null)
            {
                spriteObject.GetComponent<SpriteRenderer>().sprite = genderManager.originalSprite;
            }
        }
    }
}
