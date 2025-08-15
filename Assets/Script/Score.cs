using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI Skor1;

    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Bitis")
        {
            int skor = PlayerPrefs.GetInt("Skor"); // PlayerPrefs'tan skoru al�yoruz
            Skor1.text = "Score: " + skor.ToString();
        }
    }

    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Oyun")
        {
            // ArabaHareket scriptine eri�erek puan de�erini al�yoruz
            int scoreValue = FindObjectOfType<ArabaHareket>().puan;
            Skor1.text = "Score: " + scoreValue.ToString();
        }
    }
}