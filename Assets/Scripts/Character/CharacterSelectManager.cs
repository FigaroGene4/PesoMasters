using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager instance;

    private Sprite selectedSprite;

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

    public void SetSelectedSprite(Sprite sprite)
    {
        selectedSprite = sprite;
        Debug.Log("Selected");
    }

    public Sprite GetSelectedSprite()
    {
        return selectedSprite;
    }
}
