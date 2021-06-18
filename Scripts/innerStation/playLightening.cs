using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playLightening : MonoBehaviour
{
    public AudioSource lighteningSound;
    private bool lighteningUp = false;
    private ParticleSystem myParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
      myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
      if ((sceneManager.turnDownLights == true) && (lighteningUp == false)){
        lighteningUp = true;
        myParticleSystem.Play();
        lighteningSound.Play();
      }
    }
}
