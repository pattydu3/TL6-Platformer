using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Image scoreBarFill;
    public static int maxTokens;

    public void UpdateScoreBar(int currentTokens){
        float fillAmount = (float)currentTokens / maxTokens;
        scoreBarFill.fillAmount = fillAmount;
    }
}
