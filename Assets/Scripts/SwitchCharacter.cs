using UnityEngine;
using UnityEngine.UI;

public class SwitchCharacter : MonoBehaviour
{
    public Image characterImage;

    private void Start()
    {
        Debug.Log("SwitchCharacter Start method called.");
        UpdateCharacterImage();
    }

    public void UpdateCharacterImage()
    {
        Debug.Log("SwitchCharacter UpdateCharacterImage method called.");

        // Get the selected image from CharacterSelectManager
        Image selectedImage = CharacterSelectManager.instance.GetSelectedImage();

        // If no image is selected, log a warning
        if (selectedImage == null)
        {
            Debug.LogWarning("No selected image found.");
            return; // Exit the method early if no image is found
        }

        // Set the sprite of the characterImage to the sprite of the selectedImage
        characterImage.sprite = selectedImage.sprite;
    }
}
