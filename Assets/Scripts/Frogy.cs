using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Frogy : MonoBehaviour
{
    Rigidbody rb;

    /*[SerializeField]
    Canvas frogyCanvas;
    [SerializeField]
    GameObject frogObject;*/

    [Header("ANIMATION")]
    [SerializeField]
    Animator frogAnimator;

    [Header("RESPAWN")]
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    Image fadeImage;

    [Header("AUDIO")]
    [SerializeField]
    AudioSource jumpAudio;

    [Header("JUMP")]
    bool isJumping = false;
    float jumpTimer = 0.0f;
    [SerializeField]
    float maxJump = 1.0f;
    [SerializeField]
    float jumpStrength = 1.0f;

    [Header("TURN")]
    [SerializeField]
    float turnSpeed = 10.0f;

    bool isRotatingLeft = false;
    bool isRotatingRight = false;
    bool doubleRotateSpeed = false;

    int flyCount = 0;
    int displayedFlies = 0;

    bool isRespawning = false;

    [Header("UI")]
    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    TextMeshProUGUI flyCountText;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    CanvasGroup loader;

    [SerializeField]
    CanvasGroup endGameScreen;

    [SerializeField]
    TextMeshProUGUI endGameTimer;

    float timePassed = 0;

    List<GameObject> collectedFlies = new List<GameObject>();

    bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            timePassed += Time.deltaTime;

            timerText.text = GetTimerText(timePassed);


            flyCountText.text = displayedFlies.ToString();

            if (!isRespawning)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Start Jump Animation
                    frogAnimator.SetTrigger("PrepareJump");
                    isJumping = true;
                }
                else if (Input.GetKey(KeyCode.Space) && isJumping)
                {
                    // Increase Jump Time
                    jumpTimer += Time.deltaTime;

                    jumpTimer = Mathf.Clamp(jumpTimer, 0, maxJump);

                    float jumpPercentage = jumpTimer / maxJump;
                }
                else if (Input.GetKeyUp(KeyCode.Space) && isJumping)
                {
                    isJumping = false;
                    // Play leap animation
                    frogAnimator.ResetTrigger("PrepareJump");
                    frogAnimator.SetBool("IsJumping", true);

                    if (jumpTimer / maxJump < 0.2f)
                    {
                        StartCoroutine(ExitJumpEarly());
                    }

                    // Jump
                    rb.AddRelativeForce(new Vector3(0.0f, jumpTimer * jumpStrength, jumpTimer * jumpStrength), ForceMode.Impulse);
                    jumpAudio.pitch = 1 + ((1 - jumpTimer / maxJump) * 0.5f) - Random.Range(0.05f, 0.1f);
                    jumpAudio.Play();
                    jumpTimer = 0;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    // Rotate left
                    isRotatingLeft = true;
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    isRotatingLeft = false;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    // Rotate right
                    isRotatingRight = true;
                }
                else if (Input.GetKeyUp(KeyCode.D))
                {
                    isRotatingRight = false;
                }

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    doubleRotateSpeed = true;
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    doubleRotateSpeed = false;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                }
            }
        }
    }

    IEnumerator ExitJumpEarly()
    {
        yield return new WaitForSeconds(0.1f);
        frogAnimator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        if(isRotatingLeft)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0.0f, doubleRotateSpeed ? -turnSpeed * 2 : -turnSpeed, 0.0f) * Time.fixedDeltaTime);
            rb.MoveRotation(deltaRotation * rb.rotation);
        }
        else if(isRotatingRight)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0.0f, doubleRotateSpeed ? turnSpeed * 2 : turnSpeed, 0.0f) * Time.fixedDeltaTime);
            rb.MoveRotation(deltaRotation * rb.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        frogAnimator.SetBool("IsJumping", false);

        if (collision.collider.transform.CompareTag("Water"))
        {
            Debug.Log("Collided with water!");

            foreach(GameObject fly in collectedFlies)
            {
                fly.SetActive(true);
                flyCount--;
            }

            collectedFlies.Clear();

            isRespawning = true;

            // Fade in before this, then fade out after
            fadeImage.DOFade(1.0f, 0.5f).OnComplete(Respawn);

            doubleRotateSpeed = false;
            isRotatingLeft = false;
            isRotatingRight = false;
            isJumping = false;
            jumpTimer = 0.0f;
        }
    }

    void Respawn()
    {
        flyCount = 0;
        displayedFlies = 0;

        rb.velocity = Vector3.zero;
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        fadeImage.DOFade(0.0f, 0.5f).SetDelay(0.5f).OnComplete(() => isRespawning = false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fly"))
        {
            Debug.Log("Found Fly!");
            flyCount++;
            DOTween.To(() => displayedFlies, x => displayedFlies = x, flyCount * 20, 2).SetEase(Ease.OutQuart);
            other.gameObject.SetActive(false);
            // Add to array of collected flies
            collectedFlies.Add(other.gameObject);
        }
        else if(other.CompareTag("Home"))
        {
            Debug.Log("Depositing Flies!");
            HomeManager home = other.GetComponent<HomeManager>();
            home.DepositFlies(flyCount);
            flyCount = 0;
            DOTween.To(() => displayedFlies, x => displayedFlies = x, flyCount * 20, 2).SetEase(Ease.OutQuart);
            // Empty array of collected flies
            collectedFlies.Clear();
        }
    }

    public void FinishGame()
    {
        isPlaying = false;

        float finalTime = timePassed;

        endGameTimer.text = GetTimerText(finalTime);

        loader.gameObject.SetActive(true);
        endGameScreen.gameObject.SetActive(true);

        loader.DOFade(1.0f, 0.5f);
        endGameScreen.DOFade(1.0f, 0.5f);
    }

    string GetTimerText(float _time)
    {
        int hours = (int)_time / 3600;
        int minutes = ((int)_time - (hours * 3600)) / 60;
        int seconds = (int)_time - (hours * 3600) - (minutes * 60);

        return(hours.ToString() + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"));
    }
}
