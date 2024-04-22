using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialImage : MonoBehaviour
{
    [SerializeField] private GameObject nextTutorialImage;
    [SerializeField] private GameObject[] otherClickableObjects;

    private void OnMouseDown()
    {
        // Deactivate the current tutorial image
        gameObject.SetActive(false);

        // Disable interaction with other clickable objects
        foreach (GameObject obj in otherClickableObjects)
        {
            Collider collider = obj.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        // Activate the next tutorial image, if available
        if (nextTutorialImage != null)
        {
            nextTutorialImage.SetActive(true);
        }
        else
        {
            // Optionally, you can handle what happens when there is no next tutorial image
            Debug.LogWarning("No next tutorial image specified.");
        }
    }
}
