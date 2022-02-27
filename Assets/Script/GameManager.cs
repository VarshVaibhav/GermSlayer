using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    private const float requiredForce = 400.0f;

    private List<Bacteria> bacts = new List<Bacteria>();
    public GameObject bPrefab;

    private List<Bacteria2> bacts2 = new List<Bacteria2>();
    public GameObject bPrefab2;

    private List<Bacteria3> bacts3 = new List<Bacteria3>();
    public GameObject bPrefab3;

    private List<Bacteria4> bacts4 = new List<Bacteria4>();
    public GameObject bPrefab4;

    private List<Red> redCells = new List<Red>();
    public GameObject redPrefab;

    private float lastSpwanBact;
    private float deltaSpwanBact;
    private float lastSpwanBact1;
    private float deltaSpwanBact1;

    private float lastSpwanRed;
    private float deltaSpwanRed;

    private Collider2D[] bactsCols;
    private Collider2D[] bactsCols2;
    private Collider2D[] bactsCols3;
    private Collider2D[] bactsCols4;
    private Collider2D[] redCols;
    private Vector3 lastMousePos;

    private int lifepoint;
    public Image[] lifepoints;

    public GameObject pausePanel;
    public GameObject pauseButton;

    public GameObject deathPanel;
    public GameObject RewardPanel;
    public GameObject messagePanel;

    public bool isPaused = false;

    public Animator camAnim;

    public GameObject Level1;
    public GameObject Level2;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        bactsCols = new Collider2D[0];
        bactsCols2 = new Collider2D[0];
        bactsCols3 = new Collider2D[0];
        bactsCols4 = new Collider2D[0];
        redCols = new Collider2D[0];
        NewGame();
    }

    public void NewGame()
    {
        lifepoint = 3;
        Time.timeScale = 1;
        isPaused = false;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
        RewardPanel.SetActive(false);
        messagePanel.SetActive(false);

        foreach (Image i in lifepoints)
            i.enabled = true;

        foreach (Bacteria b in bacts)
            Destroy(b.gameObject);
        bacts.Clear();

        foreach(Bacteria2 b2 in bacts2)
            Destroy(b2.gameObject);
        bacts.Clear();

        foreach (Bacteria3 b3 in bacts3)
            Destroy(b3.gameObject);
        bacts.Clear();

        foreach (Bacteria4 b4 in bacts4)
            Destroy(b4.gameObject);
        bacts.Clear();

        foreach (Red r in redCells)
            Destroy(r.gameObject);
        redCells.Clear();
    }

    private void Update()
    {
        if (isPaused)
            return;

        if (Level1.activeSelf)
        {
            if (ScoreLevel1.Instance.score < 100)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel1.Instance.score > 100 && ScoreLevel1.Instance.score < 250)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel1.Instance.score > 250 && ScoreLevel1.Instance.score < 400)
                deltaSpwanBact = Random.Range(1f, 2f);
        }
        if (Level2.activeSelf)
        {
            if (ScoreLevel2.Instance.score < 100)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel2.Instance.score > 100 && ScoreLevel2.Instance.score < 250)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel2.Instance.score > 250 && ScoreLevel2.Instance.score < 400)
                deltaSpwanBact = Random.Range(1f, 2f);
        }

        if(Time.time - lastSpwanBact>deltaSpwanBact)
        {
            Bacteria b = GetBacteria();
            float randomX = Random.Range(-8.25f, 8.25f);
            b.LaunchBacteria(Random.Range(10f, 14f), randomX, -randomX);
            lastSpwanBact = Time.time;
        }

        if (Level1.activeSelf)
        {
            if (ScoreLevel1.Instance.score < 100)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel1.Instance.score > 100 && ScoreLevel1.Instance.score < 250)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel1.Instance.score > 250 && ScoreLevel1.Instance.score < 400)
                deltaSpwanBact = Random.Range(1f, 2f);
        }
        if (Level2.activeSelf)
        {
            if (ScoreLevel2.Instance.score < 100)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel2.Instance.score > 100 && ScoreLevel2.Instance.score < 250)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel2.Instance.score > 250 && ScoreLevel2.Instance.score < 400)
                deltaSpwanBact = Random.Range(1f, 2f);
        }

        if (Time.time - lastSpwanBact > deltaSpwanBact)
        {
            Bacteria2 b2 = GetBacteria2();
            float randomX = Random.Range(-8.25f, 8.25f);
            b2.LaunchBacteria2(Random.Range(10f, 14f), randomX, -randomX);
            lastSpwanBact = Time.time;
        }

        if (Level1.activeSelf)
        {
            if (ScoreLevel1.Instance.score < 100)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel1.Instance.score > 100 && ScoreLevel1.Instance.score < 250)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel1.Instance.score > 250 && ScoreLevel1.Instance.score < 400)
                deltaSpwanBact = Random.Range(1f, 2f);
        }
        if (Level2.activeSelf)
        {
            if (ScoreLevel2.Instance.score < 100)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel2.Instance.score > 100 && ScoreLevel2.Instance.score < 250)
                deltaSpwanBact = Random.Range(2f, 2.5f);
            else if (ScoreLevel2.Instance.score > 250 && ScoreLevel2.Instance.score < 400)
                deltaSpwanBact = Random.Range(1f, 2f);
        }

        if (Time.time - lastSpwanBact > deltaSpwanBact)
        {
            Bacteria3 b3 = GetBacteria3();
            float randomX = Random.Range(-8.25f, 8.25f);
            b3.LaunchBacteria3(Random.Range(10f, 14f), randomX, -randomX);
            lastSpwanBact = Time.time;
        }

        if (Level1.activeSelf)
        {
            if (ScoreLevel1.Instance.score < 200)
                deltaSpwanBact1 = Random.Range(3f, 3.5f);
            else if (ScoreLevel1.Instance.score > 200 && ScoreLevel1.Instance.score < 500)
                deltaSpwanBact1 = Random.Range(1.5f, 3f);
        }
        if (Level2.activeSelf)
        {
            if (ScoreLevel2.Instance.score < 200)
                deltaSpwanBact1 = Random.Range(3f, 3.5f);
            else if (ScoreLevel2.Instance.score > 200 && ScoreLevel2.Instance.score < 500)
                deltaSpwanBact1 = Random.Range(1.5f, 3f);
        }

        if (Time.time - lastSpwanBact1 > deltaSpwanBact1)
        {
            Bacteria4 b4 = GetBacteria4();
            float randomX = Random.Range(-8.25f, 8.25f);
            b4.LaunchBacteria4(Random.Range(10f, 14f), randomX, -randomX);
            lastSpwanBact1 = Time.time;
        }

        if (Level1.activeSelf)
        {
            if (ScoreLevel1.Instance.score < 50)
            {
                deltaSpwanRed = Random.Range(5.5f, 6f);
            }
            else if (ScoreLevel1.Instance.score > 50 && ScoreLevel1.Instance.score < 100)
            {
                deltaSpwanRed = Random.Range(5f, 5.5f);
            }
            else if (ScoreLevel1.Instance.score > 100 && ScoreLevel1.Instance.score < 200)
            {
                deltaSpwanRed = Random.Range(4.5f, 5f);
            }
            else if (ScoreLevel1.Instance.score > 200 && ScoreLevel1.Instance.score < 300)
            {
                deltaSpwanRed = Random.Range(4f, 4.5f);
            }
            else if (ScoreLevel1.Instance.score > 400 && ScoreLevel1.Instance.score < 500)
            {
                deltaSpwanRed = Random.Range(3.5f, 4f);
            }
            else if (ScoreLevel1.Instance.score > 500 && ScoreLevel1.Instance.score < 700)
            {
                deltaSpwanRed = Random.Range(3f, 3.5f);
            }
            else if (ScoreLevel1.Instance.score > 700 && ScoreLevel1.Instance.score < 900)
            {
                deltaSpwanRed = Random.Range(2.5f, 3f);
            }
            else if (ScoreLevel1.Instance.score > 900 && ScoreLevel1.Instance.score < 1100)
            {
                deltaSpwanRed = Random.Range(2f, 2.5f);
            }
            else if (ScoreLevel1.Instance.score > 1100)
            {
                deltaSpwanRed = Random.Range(1.7f, 2f);
            }
        }
        if (Level2.activeSelf)
        {
            if (ScoreLevel2.Instance.score < 50)
            {
                deltaSpwanRed = Random.Range(5.5f, 6f);
            }
            else if (ScoreLevel2.Instance.score > 50 && ScoreLevel2.Instance.score < 100)
            {
                deltaSpwanRed = Random.Range(5f, 5.5f);
            }
            else if (ScoreLevel2.Instance.score > 100 && ScoreLevel2.Instance.score < 200)
            {
                deltaSpwanRed = Random.Range(4.5f, 5f);
            }
            else if (ScoreLevel2.Instance.score > 200 && ScoreLevel2.Instance.score < 300)
            {
                deltaSpwanRed = Random.Range(4f, 4.5f);
            }
            else if (ScoreLevel2.Instance.score > 400 && ScoreLevel2.Instance.score < 500)
            {
                deltaSpwanRed = Random.Range(3.5f, 4f);
            }
            else if (ScoreLevel2.Instance.score > 500 && ScoreLevel2.Instance.score < 700)
            {
                deltaSpwanRed = Random.Range(3f, 3.5f);
            }
            else if (ScoreLevel2.Instance.score > 700 && ScoreLevel2.Instance.score < 900)
            {
                deltaSpwanRed = Random.Range(2.5f, 3f);
            }
            else if (ScoreLevel2.Instance.score > 900 && ScoreLevel2.Instance.score < 1100)
            {
                deltaSpwanRed = Random.Range(2f, 2.5f);
            }
            else if (ScoreLevel2.Instance.score > 1100)
            {
                deltaSpwanRed = Random.Range(1.7f, 2f);
            }
        }
        if (Time.time - lastSpwanRed > deltaSpwanRed)
        {
            Red r = GetRed();
            float randomY = Random.Range(-8.25f, 8.25f);
            r.LaunchRed(Random.Range(10f, 14f), randomY, -randomY);
            lastSpwanRed = Time.time;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySound(0);
        }
            
        if (Input.GetMouseButton(0))
            {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -1;
            Collider2D[] thisFrameBacts = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bacteria"));
            Collider2D[] thisFrameBacts2 = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bacteria2"));
            Collider2D[] thisFrameBacts3 = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bacteria3"));
            Collider2D[] thisFrameBacts4 = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bacteria4"));

            Collider2D[] thisFrameRed = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Red"));

            if ((Input.mousePosition - lastMousePos).sqrMagnitude > requiredForce)
            {
                
                foreach (Collider2D c1 in bactsCols)
                {
                    for (int i = 0; i < bactsCols.Length; i++)
                    {
                        if (c1 == bactsCols[i])
                        {
                            c1.GetComponent<Bacteria>().Slice();
                        }
                    }
                }

                foreach (Collider2D c12 in bactsCols2)
                {
                    for (int i = 0; i < bactsCols2.Length; i++)
                    {
                        if (c12 == bactsCols2[i])
                        {
                            c12.GetComponent<Bacteria2>().Slice2();
                        }
                    }
                }

                foreach (Collider2D c13 in bactsCols3)
                {
                    for (int i = 0; i < bactsCols3.Length; i++)
                    {
                        if (c13 == bactsCols3[i])
                        {
                            c13.GetComponent<Bacteria3>().Slice3();
                        }
                    }
                }

                foreach (Collider2D c14 in bactsCols4)
                {
                    for (int i = 0; i < bactsCols4.Length; i++)
                    {
                        if (c14 == bactsCols4[i])
                        {
                            c14.GetComponent<Bacteria4>().Slice4();
                        }
                    }
                }

                foreach (Collider2D c2 in redCols)
                {
                    for(int j = 0; j< redCols.Length; j++)
                    {
                        if(c2 == redCols[j])
                        {
                            c2.GetComponent<Red>().rSlice();
                        }
                    }
                }
            }
            lastMousePos = Input.mousePosition;
            bactsCols = thisFrameBacts;
            bactsCols2 = thisFrameBacts2;
            bactsCols3 = thisFrameBacts3;
            bactsCols4 = thisFrameBacts4;

            redCols = thisFrameRed;      
        }
    }
    private Bacteria GetBacteria()
    {
        Bacteria b = bacts.Find(x => !x.IsActive);
        if(b == null)
        {
            b = Instantiate(bPrefab).GetComponent<Bacteria>();
            bacts.Add(b);
        }
        return b;
    }

    private Bacteria2 GetBacteria2()
    {
        Bacteria2 b2 = bacts2.Find(x => !x.IsActive);
        if (b2 == null)
        {
            b2 = Instantiate(bPrefab2).GetComponent<Bacteria2>();
            bacts2.Add(b2);
        }
        return b2;
    }

    private Bacteria3 GetBacteria3()
    {
        Bacteria3 b3 = bacts3.Find(x => !x.IsActive);
        if (b3 == null)
        {
            b3 = Instantiate(bPrefab3).GetComponent<Bacteria3>();
            bacts3.Add(b3);
        }
        return b3;
    }

    private Bacteria4 GetBacteria4()
    {
        Bacteria4 b4 = bacts4.Find(x => !x.IsActive);
        if (b4 == null)
        {
            b4 = Instantiate(bPrefab4).GetComponent<Bacteria4>();
            bacts4.Add(b4);
        }
        return b4;
    }

    private Red GetRed()
    {
        Red r = redCells.Find(x => !x.IsActive);
        if (r == null)
        {
            r = Instantiate(redPrefab).GetComponent<Red>();
            redCells.Add(r);
        }
        return r;
    }
    public void GainLpp()
    {      
        lifepoint = lifepoint + 1;
        lifepoints[0].enabled = true;
        isPaused = false;
        RewardPanel.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void LoseLP()
    {
        if (lifepoint == 0)
            return;
        lifepoint--;
        lifepoints[lifepoint].enabled = false;
        if (lifepoint == 0)
            Death();
    }
    public void Death()
    {
        isPaused = true;
        deathPanel.SetActive(true);
        pauseButton.SetActive(false);
        messagePanel.SetActive(false);
    }
    public void messageAdFailed()
    {
        
        messagePanel.SetActive(true);
        deathPanel.SetActive(false);
    }
    public void PauseAD()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        pauseButton.SetActive(!pauseButton.activeSelf);
        isPaused = pausePanel.activeSelf;
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
    }
    public void menuLoadByDeath()
    {
        Destroy(GameObject.FindWithTag("Trails"));
        Destroy(GameObject.FindWithTag("SoundManager"));
        SceneManager.LoadScene("Menu");
    }
    public void menuLoad()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        Destroy(GameObject.FindWithTag("Trails"));
        Destroy(GameObject.FindWithTag("SoundManager"));
        SceneManager.LoadScene("Menu");
    }
    public void Level1Load()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        SceneManager.LoadScene("Level1");
    }
    public void Level2Load()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        SceneManager.LoadScene("Level2");
    }
    public void CamShake()
    {
        int r = Random.Range(0, 9);
        if (r == 0)
            camAnim.SetTrigger("shake");
        if (r == 1)
            camAnim.SetTrigger("shake02");
        if (r == 2)
            camAnim.SetTrigger("shake03");
        if (r == 3)
            camAnim.SetTrigger("shake04");
        if (r == 4)
            camAnim.SetTrigger("shake05");
        if (r == 5)
            camAnim.SetTrigger("shake06");
        if (r == 6)
            camAnim.SetTrigger("shake07");
        if (r == 7)
            camAnim.SetTrigger("shake08");
    }
}
