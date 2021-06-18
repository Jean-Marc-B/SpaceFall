using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class plateform4Manager : MonoBehaviour
{
    public AudioSource fall;
    public outerSceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator death(){
      yield return new WaitForSeconds(0.1f);
      SceneManager.LoadScene("deathScene");
    }

    void OnTriggerEnter (Collider other)
        {
          if (other.tag == "Player"){
            if (sceneManager.getPlayerState()==7){
              sceneManager.setPlayerState(8);
            }
            if (sceneManager.getPlayerState()<7){
              fall.Play();
              StartCoroutine(death());
            }
          }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
