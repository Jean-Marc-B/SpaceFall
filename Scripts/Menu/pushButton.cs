using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pushButton : MonoBehaviour
{
    private Animator _animator;
    public AudioSource pushButtonSound;
    public bool alreadyPlayed = false;
    public string myTagCollider = "Hand";

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    IEnumerator launchNextScene()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene ("innerStation");

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    void playSoundButton()
    {
        pushButtonSound.Play();
    }

    void OnTriggerEnter(Collider other){
      if (other.tag == myTagCollider){
        _animator.SetBool("push", true);
        }
        StartCoroutine(launchNextScene());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
