using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outroManager : MonoBehaviour
{
  private static gameManager gameManager;
  private static StressSystem stressSystem;

  //Data extraction debriefing
  public AudioSource confidentialDataFail;
  public AudioSource confidentialDataSucceed;
  //stress debriefing
  public AudioSource stressSucceed;
  public AudioSource stressMiddle;
  public AudioSource stressFail;
  //overall debriefing
  public AudioSource succeed;
  public AudioSource middle;
  public AudioSource fail;

  private int confidentialDataLevel;
  private int stressLevel;

    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      stressSystem = GameObject.Find("StressSystem").GetComponent<StressSystem>();
      gameManager.addPosition(System.DateTime.Now, "Debut outro");
      confidentialDataLevel = gameManager.getExtractionDataLevel();
      stressLevel = stressSystem.getStressLevel();
      StartCoroutine(playDebriefingAfter1Sec());
    }

    IEnumerator playDebriefingAfter1Sec(){
    yield return new WaitForSeconds(1.0f);
    if (confidentialDataLevel == 0){
      gameManager.addPosition(System.DateTime.Now, "Donnes confidentielles : echoue");
      confidentialDataFail.Play();
      yield return new WaitForSeconds(confidentialDataFail.clip.length);
    }
    else{
      gameManager.addPosition(System.DateTime.Now, "Donnes confidentielles : reussi");
      confidentialDataSucceed.Play();
      yield return new WaitForSeconds(confidentialDataSucceed.clip.length);
    }
    if (stressLevel == 0){
      gameManager.addPosition(System.DateTime.Now, "Stress : echoue");
      stressFail.Play();
      yield return new WaitForSeconds(stressFail.clip.length);
    }
    else if (stressLevel == 1){
      gameManager.addPosition(System.DateTime.Now, "Stress : reprise de controle");
      stressMiddle.Play();
      yield return new WaitForSeconds(stressMiddle.clip.length);
    }
    else{
      gameManager.addPosition(System.DateTime.Now, "Stress : parfait");
      stressSucceed.Play();
      yield return new WaitForSeconds(stressSucceed.clip.length);
    }
    if(stressLevel+confidentialDataLevel == 0){
      gameManager.addPosition(System.DateTime.Now, "Global : echoue");
      fail.Play();
      yield return new WaitForSeconds(fail.clip.length);
      gameManager.addPosition(System.DateTime.Now, "Fin outro");
      Application.Quit();
    }
    else if (stressLevel+confidentialDataLevel < 3){
      gameManager.addPosition(System.DateTime.Now, "Global : OK");
      middle.Play();
      yield return new WaitForSeconds(middle.clip.length);
      yield return new WaitForSeconds(1.0f);
      gameManager.addPosition(System.DateTime.Now, "Fin outro");
      Application.Quit();
    }
    else{
      gameManager.addPosition(System.DateTime.Now, "Global : Parfait");
      succeed.Play();
      yield return new WaitForSeconds(succeed.clip.length);
      yield return new WaitForSeconds(1.0f);
      gameManager.addPosition(System.DateTime.Now, "Fin outro");
      Application.Quit();
    }

}

    // Update is called once per frame
    void Update()
    {

    }
}
