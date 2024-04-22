using UnityEngine;

public class SelectSprite : MonoBehaviour
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
        Debug.Log("Sprite clicked!");

        // Reset all sprites to original state
        ResetAllSprites();

        // Set the selected sprite to the clicked sprite
        spriteRenderer.sprite = clickedSprite;

        // Set the selected sprite to the CharacterSelectManager
        CharacterSelectManager.instance.SetSelectedSprite(originalSprite);
    }

    private void ResetAllSprites()
    {
        // Find all sprite GameObjects in the scene
        GameObject[] sprites = GameObject.FindGameObjectsWithTag("Sprite");

        // Reset each sprite to its original state
        foreach (GameObject spriteObject in sprites)
        {
            SelectSprite selectSprite = spriteObject.GetComponent<SelectSprite>();
            if (selectSprite != null)
            {
                spriteObject.GetComponent<SpriteRenderer>().sprite = selectSprite.originalSprite;
            }
        }
    }
}
