using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    private void Start()
    {
        // Retrieve the selected sprite from CharacterSelectionManager
        Sprite selectedSprite = CharacterSelectManager.instance.GetSelectedSprite();

        if (selectedSprite != null)
        {
            // Switch to the selected sprite
            GetComponent<SpriteRenderer>().sprite = selectedSprite;
        }
    }
}
