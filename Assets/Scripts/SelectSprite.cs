using UnityEngine;
using UnityEngine.UI;

public class SelectSprite : MonoBehaviour
{
    public void OnClick()
    {
        Image imageToShow = GetComponent<Image>();
        if (imageToShow != null)
        {
            Debug.Log("Image selected: " + imageToShow.name);
            CharacterSelectManager.instance.SetSelectedImage(imageToShow);
            Debug.Log("Call Character select manager");
        }
        else
        {
            Debug.LogWarning("No image found on button.");
        }
    }

}
