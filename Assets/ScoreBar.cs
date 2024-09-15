using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Image scoreBarFill;
    public int maxTokens = 1;

    public void UpdateScoreBar(int currentTokens){
        float fillAmount = (float)currentTokens / maxTokens;
        scoreBarFill.fillAmount = fillAmount;
    }
}
