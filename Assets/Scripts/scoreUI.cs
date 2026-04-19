using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
 
 public static int Score = 0;

 

[SerializeField]
private TextMeshProUGUI text;
 public void IncreaseScore()
    {
        Score = Score + 1;

        text.text = "Score: " + Score;
    }
}
