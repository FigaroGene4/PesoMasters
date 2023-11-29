using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Card", menuName ="cards")]
public class Cards : ScriptableObject
{
    public string nameOfCard;
    public int energy;
    public int gold;
    public int star;
}

public class CardHolder : MonoBehaviour
{
    public Cards Income1, Income2, Income3, Income4;
}


