using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager instance;

    public  Image selectedImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedImage(Image image)
    {
        selectedImage = image;
        if (selectedImage != null)
        {
            Debug.Log("Selected image set: " + selectedImage.name);
        }
        else
        {
            Debug.LogWarning("Attempting to set a null image.");
        }
    }

    public Image GetSelectedImage()
    {
        return selectedImage;
    }
}
