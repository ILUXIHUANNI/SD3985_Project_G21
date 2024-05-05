using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 move;
    Vector2 lookDirection = new Vector2(1, 0);

    Animator animator;
    Vector2 loadPosition;

    AudioManager audioManager;
    int isDeath = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Start()
    {
        LoadPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        flip();
        isRunning();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(move * speed, ForceMode2D.Impulse);
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
    }


    void flip()
    {
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("MoveX", lookDirection.x);
    }

    void isRunning()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    private void Movement()
    {
        if (DeathArea.isDeath)
        {
            if (isDeath == 0)
                audioManager.PlaySFX(audioManager.playerDeath);
            move = new Vector2(0, 0);
            isDeath = 1;
        }
        else
            move = new Vector2(Input.GetAxis("Horizontal"), 0);
    }


    void LoadPosition()
    {
        SaveManager.instance.Load();
        if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && !Restart.restart)
        {
            transform.position = SaveManager.instance.saveFile.position;
            if (SaveManager.instance.saveFile.checkpoint == 1)
            {
                GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Checkpoint1>().setOn();
            }
            else if (SaveManager.instance.saveFile.checkpoint == 2)
            {
                GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Checkpoint2>().setOn();
            }
        }
        else if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && Restart.restart && SaveManager.instance.saveFile.checkpoint == 1)
        {
            GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Checkpoint1>().setOn();
            transform.position = GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Checkpoint1>().transform.position;
        }
        else if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && Restart.restart && SaveManager.instance.saveFile.checkpoint == 2)
        {
            GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Checkpoint2>().setOn();
            transform.position = GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Checkpoint2>().transform.position;
        }
    }

    public Vector2 getPosition()
    {
        return transform.position;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void changePostition(Vector2 pos)
    {
        transform.position = pos;
    }
}
