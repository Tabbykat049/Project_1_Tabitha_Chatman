using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
 
 private int Health = 100;

[SerializeField]
private TextMeshProUGUI text;
 public void decreaseHealth()
    {
        Health = Health - 20;

        text.text = "Health: " + Health;
    }
}

