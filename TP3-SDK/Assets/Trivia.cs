using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trivia : MonoBehaviour
{
    public TextMeshProUGUI genderText;

    public void NewGender()
    {
        Gender g = APIHelper.GetDonneGender();
        genderText.text = g.fact;
    }
}
