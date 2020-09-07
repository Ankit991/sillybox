using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menumanager : MonoBehaviour
{
   public int howmuchcoin;
  //  public Button[] Levelbutton;
   
    public GameObject[] levelbutton;
   public  int nextsceneload,levelat;
    bool levelone;
    // Start is called before the first frame update
    private void Start()
    {
        nextsceneload = PlayerPrefs.GetInt("Levelat", levelat);
        howmuchcoin = PlayerPrefs.GetInt("Point");
       //  levelat = PlayerPrefs.GetInt("Levelat", levelat);
       
      
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
       
    }

   
    public void LevelbuttonOne()
    {

        SceneManager.LoadScene("Level1", LoadSceneMode.Single);

    }
    public void LevelbuttonTwo()
    {
        if (nextsceneload >= 2)
        {
            howmuchcoin += 200;
          
        }

        {
            if (howmuchcoin >= 200)
            {
                howmuchcoin -= 200;
                PlayerPrefs.SetInt("Point", howmuchcoin);
                if (nextsceneload > PlayerPrefs.GetInt("Levelat"))
                {
                    PlayerPrefs.SetInt("Levelat", nextsceneload);
                }
               
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);

                PlayerPrefs.SetInt("Levelat", 2);
            }
            else
            {
                levelbutton[0].SetActive(true);
            }
           
        }
       
           
        
    }
    public void LevelbuttonThree ()
    {
        
        if (nextsceneload >= 3)
        {
            howmuchcoin += 300;
        }
        {
            if (howmuchcoin >= 300)
            {
                howmuchcoin -= 300;
                PlayerPrefs.SetInt("Point", howmuchcoin);
                if (nextsceneload > PlayerPrefs.GetInt("Levelat"))
                {
                    PlayerPrefs.SetInt("Levelat", nextsceneload);
                }
               
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                PlayerPrefs.SetInt("Levelat", 3);
            }
            else
            {
                levelbutton[1].SetActive(true);
                print("you don't have enough money ");
            }

        }
       


    }


    public void Levelbuttonfour()
    {
      
        if (nextsceneload >= 4)
        {
            howmuchcoin += 400;
        }
        {
            if (howmuchcoin >= 400)
            {
                howmuchcoin -= 400;
                PlayerPrefs.SetInt("Point", howmuchcoin);
                if (nextsceneload > PlayerPrefs.GetInt("Levelat"))
                {
                    PlayerPrefs.SetInt("Levelat", nextsceneload);
                }
              
                SceneManager.LoadScene("Level4", LoadSceneMode.Single);
                PlayerPrefs.SetInt("Levelat", 4);
            }
            else
            {
                levelbutton[2].SetActive(true);
                print("you don't have enough money ");
            }

        }



    }

public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

}
