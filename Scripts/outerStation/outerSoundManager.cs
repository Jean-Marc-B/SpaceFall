using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outerSoundManager : MonoBehaviour
{

    private static gameManager gameManager;
    public outerSceneManager sceneManager;
    public screenManager module;
    private static StressComputation stressComputation;

    private bool corountineRunning = false;


    // TalkieWalkie
    public AudioSource TalkieWalkie;

    //Initial instructions
    private bool initialInstructionsPlayed = false;
    public AudioSource initialInstructions;

    //open box instructions
    private bool canOpenBox = false;
    private bool openBoxInstructionsPlayed = false;
    public AudioSource openBoxInstructions;

    //Confidential datas instructions
    private bool confidentialDataInstructionsPlayed = false;
    public AudioSource confidentialDataInstructions;

    //Data extraction instructions
    private bool canPlayDataExtraction = false;
    private bool dataExtractionInstructionsPlayed = false;
    public AudioSource dataExtractionInstructions;


    //Warnings before explosion :
    bool firstWarningNotPlayed = true;
    bool secondWarningNotPlayed = true;
    bool thirdWarningNotPlayed = true;
    public AudioSource firstWarning;
    public AudioSource secondWarning;
    public AudioSource lastWarning;

    //Parachute instructions
    public AudioSource instructionParachute;
    public AudioSource openParachute;
    private bool notSaidToOpen = true;
    public AudioSource congratulation;
    private bool playedCongratulations = false;

    //Stress indications:
    //without stress :
    public AudioSource noStressIndication;
    //With stress :
    public AudioSource stressIndication;
    private bool firstStressIndicationPlayed = false;
    private bool secondStressIndicationPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      stressComputation = GameObject.Find("StressComputation").GetComponent<StressComputation>();
    }

    IEnumerator play3Sounds(AudioSource sound1, AudioSource sound2, AudioSource sound3){
    sound1.Play();
    yield return new WaitForSeconds(sound1.clip.length);
    sound2.Play();
    yield return new WaitForSeconds(sound2.clip.length);
    sound3.Play();
    yield return new WaitForSeconds(sound3.clip.length);
    corountineRunning = false;
}

  //initial instructions
    public void playInitialInstructions(){
      gameManager.addPosition(System.DateTime.Now, "Debut instructions initiales");
      corountineRunning = true;
      StartCoroutine(play3Sounds(TalkieWalkie, initialInstructions, TalkieWalkie));
      initialInstructionsPlayed = true;
    }

  //first stress indication
    public void playFirstStressIndication(){
      gameManager.addPosition(System.DateTime.Now, "Debut premier retour de stress");
      corountineRunning = true;
      if(stressComputation.stressed){
        StartCoroutine(play3Sounds(TalkieWalkie, stressIndication, TalkieWalkie));
      }
      else{
        StartCoroutine(play3Sounds(TalkieWalkie, noStressIndication, TalkieWalkie));
      }

      firstStressIndicationPlayed = true;
    }

//open box instructions
public void canPlayOpenBox(){
  canOpenBox = true;
}

public void triggerOpenBoxInstruction(){
  if ((canOpenBox == true) && (openBoxInstructionsPlayed == false)){
    gameManager.addPosition(System.DateTime.Now, "Debut instructions ouverture du module electrique");
    corountineRunning = true;
    StartCoroutine(play3Sounds(TalkieWalkie, openBoxInstructions, TalkieWalkie));
    openBoxInstructionsPlayed = true;
  }
}

//Confidential data instructions
public void playConfidentialDataInstructions(){
  if (confidentialDataInstructionsPlayed == false){
    gameManager.addPosition(System.DateTime.Now, "Reprise communication apres apparition des flammes");
    corountineRunning = true;
    StartCoroutine(play3Sounds(TalkieWalkie, confidentialDataInstructions, TalkieWalkie));
    confidentialDataInstructionsPlayed = true;
  }
}

//Data extraction instructions
//second stress indication
  public void playSecondStressIndication(){
    gameManager.addPosition(System.DateTime.Now, "Debut deuxieme retour de stress");
    corountineRunning = true;
    if(stressComputation.stressed){
      StartCoroutine(play3Sounds(TalkieWalkie, stressIndication, TalkieWalkie));
    }
    else{
      StartCoroutine(play3Sounds(TalkieWalkie, noStressIndication, TalkieWalkie));
    }
    secondStressIndicationPlayed = true;
  }



public void triggerDataExtractionInstruction(){
  if (canPlayDataExtraction == true && dataExtractionInstructionsPlayed == false){
    gameManager.addPosition(System.DateTime.Now, "Debut instructions pour extraire les donnees");
    corountineRunning = true;
    StartCoroutine(play3Sounds(TalkieWalkie, dataExtractionInstructions, TalkieWalkie));
    dataExtractionInstructionsPlayed = true;
  }
}


//Warnings before explosion :
public void playFirstWarning(){
    if (firstWarningNotPlayed)
    {
        firstWarningNotPlayed = false;
        gameManager.addPosition(System.DateTime.Now, "Debut premier warning");
        StartCoroutine(play3Sounds(TalkieWalkie, firstWarning, TalkieWalkie));
    }
  
}
public void playSecondWarning(){
    if (secondWarningNotPlayed)
    {
        secondWarningNotPlayed = false;
        gameManager.addPosition(System.DateTime.Now, "Debut deuxieme warning");
        StartCoroutine(play3Sounds(TalkieWalkie, secondWarning, TalkieWalkie));
    }
}
public void playLastWarning(){
    if (thirdWarningNotPlayed)
    {
        thirdWarningNotPlayed = false;
        gameManager.addPosition(System.DateTime.Now, "Debut dernier warning");
        StartCoroutine(play3Sounds(TalkieWalkie, lastWarning, TalkieWalkie));
    }
}

//Parachute instructions :
public void playInstructionParachute(){
  gameManager.addPosition(System.DateTime.Now, "Debut instructions parachute");
  StartCoroutine(play3Sounds(TalkieWalkie, instructionParachute, TalkieWalkie));
}
public void playOpenParachute(){
        if  (notSaidToOpen)
        {
            notSaidToOpen = false;
            gameManager.addPosition(System.DateTime.Now, "Debut demande d'ouverture du parachute");
            StartCoroutine(play3Sounds(TalkieWalkie, openParachute, TalkieWalkie));   
        }
}
public void playCongratulation(){
  gameManager.addPosition(System.DateTime.Now, "Debut felicitations de l'ouverture du parachute");
  corountineRunning = true;
  StartCoroutine(play3Sounds(TalkieWalkie, congratulation, TalkieWalkie));
  playedCongratulations = true;
}
IEnumerator launchOutro(){
yield return new WaitForSeconds(5);
  SceneManager.LoadScene("Outro");
}




    // Update is called once per frame
    void Update()
    {
      //initial instructions and stress indication
      if (sceneManager.getPlayerState()>=3 && firstStressIndicationPlayed == false && initialInstructionsPlayed == true && corountineRunning == false){
        playFirstStressIndication();
      }

      if (firstStressIndicationPlayed == true && corountineRunning == false){
        sceneManager.endInitialInstructions();
      }



      //second stress indication
      if (sceneManager.getPlayerState()>=10 && secondStressIndicationPlayed == false && confidentialDataInstructionsPlayed == true && corountineRunning == false){
        playSecondStressIndication();
      }

      //confidential data instructions
      if (secondStressIndicationPlayed == true && corountineRunning == false){
        canPlayDataExtraction = true;
        module.canUseModule(); //Player can use the computer module
      }



      //Final congratulation
      if (playedCongratulations == true && corountineRunning == false){
        StartCoroutine(launchOutro());
      }

    }
}
