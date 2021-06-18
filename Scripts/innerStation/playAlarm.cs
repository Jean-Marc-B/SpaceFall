using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAlarm : MonoBehaviour
{
    private Animator _animator;
    public GameObject redLight;
    public GameObject alarm;
    private Light myLight;
    private bool localAlarmUp = false;
    Material mymat;

    // Start is called before the first frame update
    void Start()
    {
      _animator = GetComponent<Animator>();
      myLight = redLight.GetComponent<Light>();
      mymat = alarm.GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
      if ((sceneManager.launchAlarm == true) && (localAlarmUp == false)){
        localAlarmUp = true;
        sceneManager.alarmUp = true;
        _animator.SetBool("enableAlarm", true);
        myLight.enabled = true;
        mymat.EnableKeyword("_Emission");
      }
    }
}
