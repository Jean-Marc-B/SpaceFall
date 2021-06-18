using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
  static gameManager instance;

  private int percentage;
  private int thresholdDataExtraction = 50;
  private List<string> positions = new List<string>();
  private List<System.DateTime> timestamps = new List<System.DateTime>();
  private string filePath = @"E:\SpaceFall\Data\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + @"\positionData.csv";



  void Awake()
  {
      if (instance != null)
      {
          Destroy(gameObject);
      }
      else
      {
          instance = this;
          DontDestroyOnLoad(gameObject);
      }

  }

  void OnApplicationQuit()
  {
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    sb.AppendLine("Time,Position");
    for (int i = 0; i < positions.Count; i++)
    {
      sb.AppendLine(timestamps[i] + "," + positions[i]);
    }
    System.IO.FileInfo file = new System.IO.FileInfo(filePath);
    file.Directory.Create();
    System.IO.File.WriteAllText(
      file.FullName,
      sb.ToString());
  }

  public void addPosition(System.DateTime timeStamp, string position){
    timestamps.Add(timeStamp);
    positions.Add(position);
  }

  public void setPercentage(int p){
    percentage = p;
  }

  public int getExtractionDataLevel(){
    if (percentage < thresholdDataExtraction){
    return 0;
    }
    else{
      return 1;
    }
  }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("n")){
        if (SceneManager.GetActiveScene().name == "Menu"){
          SceneManager.LoadScene ("innerStation");
        }
        else{
          SceneManager.LoadScene ("outerStation");
        }
      }
    }
}
