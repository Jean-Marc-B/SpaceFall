using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class deathSceneManager : MonoBehaviour
{
  private static gameManager gameManager;
  public AudioSource deathMusic;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      gameManager.addPosition(System.DateTime.Now, "Mort");
      Debug.Log("Mort");
    }

    // Update is called once per frame
    void Update()
    {
      if (!deathMusic.isPlaying){
        SceneManager.LoadScene("outerStation");
      }
    }
}
