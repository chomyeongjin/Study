using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerColl : MonoBehaviour
{
    public Text gemScore;
    public int score;

    public Text lifeNum;
    public int num;

    public GameObject resultView;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        num = 3;

        resultView.SetActive(false);
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

        if (collision.gameObject.CompareTag("Home"))
        {
            SceneManager.LoadScene("EndingScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Slime")
        {
            num -= 1;
            lifeNum.text = num.ToString();

            LifeCheck();
        }
    }

    public void LifeCheck()
    {
        if(num <= 0)
        {
            Time.timeScale = 0;

            resultView.SetActive(true);
        }
    }
}
