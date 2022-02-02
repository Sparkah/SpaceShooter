using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text coordinates;
    [SerializeField]
    private Text speed;
    [SerializeField]
    private Text angle;
    [SerializeField]
    private Text laserAmount;
    [SerializeField]
    private int maxLaserAmount = 3;
    public int currentLaserAmmount = 0;
    [SerializeField]
    private Image laserReloadTime;

    [SerializeField]
    private GameObject Player;

    private float speedCalculated;
    private float startPos;
    private float endPos;
    private float time;

    private int score =0;

    public Canvas EndGameCanvas;
    [SerializeField]
    private Text EndGameScoreText;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void FixedUpdate()
    {
        Coordinates();
        Angle();
        Speed();
        LaserReload();
    }

    public void LaserReload()
    {
        laserAmount.text = "Лазеров = " + currentLaserAmmount.ToString();
        if (laserReloadTime.fillAmount < 1)
            {
                laserReloadTime.fillAmount += 0.1f * Time.deltaTime;
            }
            else
            {
            if (currentLaserAmmount < maxLaserAmount)
            {
                laserReloadTime.fillAmount = 0;
                currentLaserAmmount += 1;
            }
            }
    }

    public void Coordinates()
    {
        coordinates.text = "координаты = " + Player.transform.position.ToString();
    }

    public void Angle()
    {
        angle.text = "угол вращения = " + (-Player.transform.rotation.z *180).ToString();
    }

    public void Speed()
    {
        time += Time.deltaTime;
        if (time<0.1)
            startPos = Player.transform.position.y;

        if (time > 0.2)
        {
            endPos = Player.transform.position.y;

            if (endPos > startPos)
            {
                speedCalculated = Mathf.Abs(endPos - startPos);
                speed.text = "скорость = " + speedCalculated.ToString();
            }
            if(endPos==startPos)
            {
                speed.text = "скорость = 0";
            }

            time = 0;
        } 
    }

    public void ScoreCounter()
    {
        score += 1;
        return;
    }

    public void ShowScoreOnGameEnd()
    {
        EndGameCanvas.enabled = true;
        EndGameScoreText.text = "ваши очки : " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }    
}