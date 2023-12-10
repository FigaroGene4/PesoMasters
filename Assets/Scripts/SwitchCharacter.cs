using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCharacter : MonoBehaviour
{
    private void Start()
    {
        // Retrieve the selected sprite from CharacterSelectionManager
        Sprite selectedSprite = CharacterSelectManager.instance.GetSelectedSprite();

        if (selectedSprite != null)
        {
            // Switch to the selected sprite
            Image image = GetComponent<Image>();
            image.sprite = selectedSprite;
        }
    }
}