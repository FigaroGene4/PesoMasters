using UnityEngine;

public class SelectSprite : MonoBehaviour
{
    private void OnMouseDown()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            CharacterSelectManager.instance.SetSelectedSprite(spriteRenderer.sprite);
            Debug.Log("Sprite Selected");
        }
    }

}
