using TMPro;
using UnityEngine;

// The example 'game' generates a random number and updates UI. 
public class GameExample : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public static int Score;

    [SerializeField] private int _min = 0, _max = 101;
    // This is called from a button. Containts the greatest gameplay example ever. Random number generation.
    public void Btn_GenerateNumber()
    {
        int randomVal = Random.Range(_min, _max);

        Score = randomVal;
        _scoreText.text = Score.ToString();
    }

}
