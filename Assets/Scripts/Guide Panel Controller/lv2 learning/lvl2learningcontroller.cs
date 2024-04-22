using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
public class lvl2learningcontroller : MonoBehaviour
{
    [SerializeField] GameObject One, Two, Three, Four, Five;
    public Button oneBtn, twoBtn, threeBtn, fourBtn, fiveBtn;

    void Start()
    {
        One.SetActive(true);

        Two.SetActive(false);
        Three.SetActive(false);
        Four.SetActive(false);
        Five.SetActive(false);
    }

    public void OneFunction()
    {
        One.SetActive(false);

        Two.SetActive(true);
    }
    public void TwoFunction()
    {
        Two.SetActive(false);

        Three.SetActive(true);
    }
    public void ThreeFunction()
    {
        Three.SetActive(false);

        Four.SetActive(true);
    }
    public void FourFunction()
    {
        Four.SetActive(false);

        Five.SetActive(true);
    }

    public void FiveFunction()
    {
        Five.SetActive(false);
    }
}
