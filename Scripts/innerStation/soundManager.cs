using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{

  private static gameManager gameManager;

  private bool corountineRunning = false;

    // TalkieWalkie
    public AudioSource TalkieWalkie;

    //Instructions Radar
    private bool instructionsRadarSoundPlayed = false;
    public AudioSource instructionsRadarSound;
    private bool instructionsRadarEnded = false;

    //Overheat thinking
    private bool overheatSoundPlayed = false;
    public AudioSource overheatSound;
    private bool cracklingSoundPlayed = false;
    public AudioSource cracklingSound;

    // Lights down
    private bool lightsDown = false;
    public AudioSource flashingLight;

    //Alarm
    public AudioSource alarmSound;
    private bool alarmUp = false;

    //Instructions temperature check
    private bool temperatureSoundPlayed = false;
    public AudioSource temperatureSound;
    private bool temperatureSoundEnded = false;

    //Instructions temperature check 2
    private bool electricProblemSoundPlayed = false;
    public AudioSource electricProblemSound;
    private bool electricProblemSoundEnded = false;

    //Instructions parachute
    private bool parachuteSoundPlayed = false;
    public AudioSource parachuteSound;
    private bool parachuteSoundEnded = false;

    //Instructions get out
    private bool getOutSoundPlayed = false;
    public AudioSource getOutSound;


    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
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

IEnumerator play2Sounds(AudioSource sound1, AudioSource sound2){
sound1.Play();
yield return new WaitForSeconds(sound1.clip.length);
sound2.Play();
yield return new WaitForSeconds(sound2.clip.length);
corountineRunning = false;
}

    // Update is called once per frame
    void Update()
    {
      //Instructions Radar
      if(sceneManager.playInstructionsRadarSound == true && instructionsRadarSoundPlayed == false){
        corountineRunning = true;
        gameManager.addPosition(System.DateTime.Now, "Debut instructions radar");
        StartCoroutine(play3Sounds(TalkieWalkie, instructionsRadarSound, TalkieWalkie));
        instructionsRadarSoundPlayed = true;
      }

      if (instructionsRadarSoundPlayed == true && corountineRunning == false && instructionsRadarEnded == false){
        instructionsRadarEnded = true;
        gameManager.addPosition(System.DateTime.Now, "Fin instructions radar");
        sceneManager.instructionsRadarFinished = true;
      }

      //Overheat thinking
      if(sceneManager.playOverheatSound == true && overheatSoundPlayed == false){
        corountineRunning = true;
        gameManager.addPosition(System.DateTime.Now, "Debut analyse du radar");
        StartCoroutine(play2Sounds(TalkieWalkie, overheatSound));
        overheatSoundPlayed = true;
      }

      if (overheatSoundPlayed == true && corountineRunning==false && cracklingSoundPlayed == false){
        gameManager.addPosition(System.DateTime.Now, "Coupure de courant");
        cracklingSound.Play();//Cut of communication
        cracklingSoundPlayed = true;
        sceneManager.overheatThinkingFinished = true;
      }

      // Lights down
      if (sceneManager.playFlashingLights == true && lightsDown == false){
        lightsDown = true;
        flashingLight.Play();
      }

      //Alarm
      if ((sceneManager.launchAlarm == true) && (alarmUp == false)){
        gameManager.addPosition(System.DateTime.Now, "Alarme retentit");
        alarmUp = true;
        alarmSound.Play();
      }

      //Instructions temperature check
      if(sceneManager.playTemperatureSound == true && temperatureSoundPlayed == false){
        gameManager.addPosition(System.DateTime.Now, "Reprise de la communication");
        cracklingSound.Stop();
        corountineRunning = true;
        StartCoroutine(play3Sounds(TalkieWalkie, temperatureSound, TalkieWalkie));
        temperatureSoundPlayed = true;
      }

      if (temperatureSoundPlayed == true && corountineRunning==false && temperatureSoundEnded == false){
        temperatureSoundEnded = true;
        gameManager.addPosition(System.DateTime.Now, "Fin de l'instruction d'aller checker la temperature");
        sceneManager.instructionsTemperatureFinished = true;
      }

      //Instructions temperature check 2
      if(sceneManager.playElectricProblemSound == true && electricProblemSoundPlayed == false){
        gameManager.addPosition(System.DateTime.Now, "Debut audio devant le panneau de temperature");
        corountineRunning = true;
        StartCoroutine(play3Sounds(TalkieWalkie, electricProblemSound, TalkieWalkie));
        electricProblemSoundPlayed = true;
      }

      if (electricProblemSoundPlayed == true && corountineRunning==false && electricProblemSoundEnded == false){
        electricProblemSoundEnded = true;
        gameManager.addPosition(System.DateTime.Now, "Fin audio devant le panneau de temperature");
        sceneManager.instructionsTemperature2Finished = true;
      }

      //Instructions parachute
      if(sceneManager.playParachuteSound == true && parachuteSoundPlayed == false){
        corountineRunning = true;
        gameManager.addPosition(System.DateTime.Now, "Debut audio devant le 2eme panneau de temperature");
        StartCoroutine(play3Sounds(TalkieWalkie, parachuteSound, TalkieWalkie));
        parachuteSoundPlayed = true;
      }

      if (parachuteSoundPlayed == true && corountineRunning == false && parachuteSoundEnded == false){
        parachuteSoundEnded = true;
        gameManager.addPosition(System.DateTime.Now, "Fin audio devant le 2eme panneau de temperature");
        sceneManager.instructionsParachuteFinished = true;
      }

      //Instructions get out
      if(sceneManager.playGetOutSound == true && getOutSoundPlayed == false){
        gameManager.addPosition(System.DateTime.Now, "Parachute recupere");
        StartCoroutine(play3Sounds(TalkieWalkie, getOutSound, TalkieWalkie));
        getOutSoundPlayed = true;
        sceneManager.takeParachuteFinished = true;
      }

    }
}
