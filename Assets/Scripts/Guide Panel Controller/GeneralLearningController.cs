using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GeneralLearningController : MonoBehaviour
{
    [SerializeField] GameObject One, Two, Three;
    public Button oneBtn, twoBtn, threeBtn;

    void Start()
    {
        One.SetActive(true);

        Two.SetActive(false);
        Three.SetActive(false);
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
    }
}
