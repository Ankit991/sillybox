using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Gameobject line
    public GameObject winimage;
    public GameObject Gameovertext, Retrybutton;
    public GameObject coin;
    public GameObject[] box, box1;
    public GameObject triangle, triangle1, environment1, environment2;
    public GameObject envtri1, env1;
    public GameObject imagebackgournd;

    //Text & TextMeshProUGUI
    public Text score;
    public Text Cointext;
    public TextMeshProUGUI HighScore;

    // Data types 
    public int scorePoint;
    public int coinpoint;
    private int hightscorepoint;
    public bool isgameover, youhavecompleted;
    Scene scene;
    // Start is called before the first frame update
    private void Awake()
    {
        //setting background active
        imagebackgournd.SetActive(false);

        envtri1.SetActive(false);
        env1.SetActive(true);



        triangle.SetActive(false);
        triangle1.SetActive(false);
        for (int i = 0; i < box.Length; i++)
        {
            box[i].SetActive(false);
            box1[i].SetActive(false);
        }
        Gameovertext.SetActive(false);
        Retrybutton.SetActive(false);
    }
    void Start()
    {
       
        
        Cointext.text = PlayerPrefs.GetInt("Point").ToString();
        coinpoint = PlayerPrefs.GetInt("Point");
        StartCoroutine(spawning());
        StartCoroutine(Scorepoint());
    }
 
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("maas") <= hightscorepoint)
        {
            PlayerPrefs.SetInt("maas", hightscorepoint);

        }

        #region this section for object on /off
        if (!isgameover)
        {
            if (scorePoint >= 40)
            {
                for (int i = 0; i < box.Length; i++)
                {
                    box[i].SetActive(true);
                    box1[i].SetActive(true);
                }
            }
            if (scorePoint >= 80)
            {
                triangle.SetActive(true);
                triangle1.SetActive(true);
            }
            if (scorePoint >= 200)
            {
                environment1.SetActive(false);
                environment2.SetActive(true);
            }
            if (scorePoint >= 330)
            {
                envtri1.SetActive(true);
                env1.SetActive(false);
            }
            if (scorePoint >= 700)
            {
                winimage.SetActive(true);
                isgameover = false;
                youhavecompleted = true;
            }
        }
       

        #endregion
        score.text ="Score: "+ scorePoint.ToString();
        Cointext.text = coinpoint.ToString()+":";
        PlayerPrefs.SetInt("Point", coinpoint);
        scene = SceneManager.GetActiveScene();
        //PlayerPrefs.DeleteAll();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    IEnumerator spawning()
    {
        yield return new WaitForSeconds(2f);
        while (!isgameover)
        {
            Vector2 spawnpostion = new Vector2(9.3f, Random.Range(-3.2f, 3.5f));
            Instantiate(coin, spawnpostion, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

    }
    IEnumerator Scorepoint()
    {
        while (!isgameover) 
        {
            yield return new WaitForSeconds(0.5f);
            scorePoint += 1;
            hightscorepoint += 1;
        }
    }
    public void GameOver()
    {
        if (!youhavecompleted)
        {
            StartCoroutine(Adsshowing());
            imagebackgournd.SetActive(true);
            HighScore.text = "HighScore:" + PlayerPrefs.GetInt("maas").ToString();
            Gameovertext.SetActive(true);
            Retrybutton.SetActive(true);
        }
        isgameover = true;
    }
    IEnumerator Adsshowing()
    {
        while (true)
        {
            Ads.instace.ShowInterstitialAd();
            yield return new WaitForSeconds(5f);

        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(scene.name);
    }
    #region method for menu
    public void purchasemenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single) ;
    }
    #endregion
}
