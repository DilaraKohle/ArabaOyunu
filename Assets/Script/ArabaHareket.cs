using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ArabaHareket : MonoBehaviour
{
    public bool oyunBitti = false;
    public int puan = 0;

    void Start()
    {
        puan = 0;
    }

    void Update()
    {
        if (!oyunBitti)
            GetComponent<Rigidbody>().AddForce(Vector3.left * 60, ForceMode.Force);
        else
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 30, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -30, ForceMode.Force);
        }

        if (GetComponent<Rigidbody>().position.x <= -140)
        {
            OyunBitti();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            OyunBitti();
        }
        if (collision.collider.tag == "Coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }

    void OyunBitti()
    {
        oyunBitti = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        PlayerPrefs.SetInt("Skor", puan); // Skoru PlayerPrefs'a kaydet
        Invoke("BitisSahnesineGec", 3f);
    }

    void BitisSahnesineGec()
    {
        SceneManager.LoadScene(2);
    }
}

