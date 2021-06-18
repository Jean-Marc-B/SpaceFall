using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricArc : MonoBehaviour
{
  public AudioSource lighteningSound;
  private ParticleSystem myParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
      myParticleSystem = GetComponent<ParticleSystem>();
    }

    public void launchElectricArc(){
      myParticleSystem.Play();
      lighteningSound.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
