using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerColl : MonoBehaviour
{
    public Text gemScore;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            score += 1;
            gemScore.text = score.ToString();

            Destroy(collision.gameObject);
        }

        if (score == 5)
        {
            SceneManager.LoadScene("NextScene");
        }
    }
}
