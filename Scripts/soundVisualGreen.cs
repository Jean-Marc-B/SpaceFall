using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundVisualGreen : MonoBehaviour
{
  private const int SAMPLE_SIZE = 1024;

  public float rmsValue;
  public float dbValue;
  public float pitchValue;

  public float maxVisualScale = 100.0f;
  public float visualModifier = 30000.0f;
  public float smoothSpeed = 70.0f;
  public float keepPercentage = 0.5f;

  public AudioSource source;
  private float[] samples;
  private float[] spectrum;
  private float sampleRate;

  private Transform[] visualList;
  private float[] visualScale;
  private int amountVisual = 64; //Nomber of movings
  private Vector3 scaleChange;
  private Vector3 positionChange;

    // Start is called before the first frame update
    void Start()
    {
      samples = new float[SAMPLE_SIZE];
      spectrum = new float[SAMPLE_SIZE];
      sampleRate = AudioSettings.outputSampleRate;

      spawnLine();
    }

    private void spawnLine(){
      visualScale = new float[amountVisual];
      visualList = new Transform[amountVisual];
      GameObject goHorizontal = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
      
      goHorizontal.transform.position = transform.parent.position;
      scaleChange = new Vector3(2*amountVisual, 0f, 0f);
      positionChange = new Vector3(amountVisual, 100f, 0);
      goHorizontal.transform.position += positionChange;
      goHorizontal.transform.localScale += scaleChange;
      goHorizontal.GetComponent<Renderer>().material.color = Color.green;
      goHorizontal.layer = LayerMask.NameToLayer("soundLayer");
      for(int i = 0; i<amountVisual;i++){
        positionChange = new Vector3(0f, 100f, 0f);
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
        go.GetComponent<Renderer>().material.color = Color.green;
        visualList[i]=go.transform;
        visualList[i].position = transform.parent.position+Vector3.right*2*i;
        go.transform.position += positionChange;
        go.layer = LayerMask.NameToLayer("soundLayer");
      }
    }

    private void analyzeSound(){
      source.GetOutputData(samples, 0);

      //Get the RMS value:
      int i = 0;
      float sum = 0;
      for(; i < SAMPLE_SIZE; i++){
        sum = samples[i]*samples[i];
      }
      rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

      //Get the DB value :
      dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

      //Get the sound spectrum
      source.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
    }

    // Update is called once per frame
    void Update()
    {
      analyzeSound();
      updateVisual();
    }

    private void updateVisual(){
      int visualIndex = 0;
      int spectrumIndex = 0;
      int averageSize = (int)((SAMPLE_SIZE * keepPercentage) / amountVisual);

      while (visualIndex < amountVisual){
        int j = 0;
        float sum = 0;
        while (j<averageSize){
          sum += spectrum[spectrumIndex];
          spectrumIndex++;
          j++;
        }

        float scaleY = sum / averageSize * visualModifier;
        visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;
        if (visualScale[visualIndex] < scaleY){
          visualScale[visualIndex] = scaleY;
        }

        if(visualScale[visualIndex] > maxVisualScale){
          visualScale[visualIndex] = maxVisualScale;
        }
        visualList[visualIndex].localScale = Vector3.one+Vector3.up * visualScale[visualIndex];
        visualIndex++;
      }
    }
}
