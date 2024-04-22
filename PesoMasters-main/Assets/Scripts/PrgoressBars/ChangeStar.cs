using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStar : MonoBehaviour
{
    //Star images
    public Image first;
    public Sprite glow;
    private StarBar starBarInstance;

    public void Start()
    {
        starBarInstance = FindObjectOfType<StarBar>(first);
    }

    public void StarUpdate()
    {
        int current = starBarInstance.current;

        if (current == 1)
        {
            first.sprite = glow;
            Debug.Log("first star glow");
        }
    }
}
