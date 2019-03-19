using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Settings")]
    public int startingLife= 3;
    public int startingScore = 0;
    [Header("References")]
    public AudioSource source;
    public Text lives;
    public Text scores;
    public Text g;
    public bool over = false;
    public bool game = false;

    public int currentLife;
    public int currentScore;
    private void Awake() 
    {
        g.text = "Press LMB to start";
        currentLife = startingLife;
        currentScore = startingScore;
        SetLifeText();
        SetScoreText();
    }

   public void addScore()
    {
        currentScore += 10;
    }

    public void startOver()
    {
        game = false;
        over = true;
        currentLife = startingLife;
        currentScore = startingScore;
        SetLifeText();
        SetScoreText();
        g.text = "GAME OVER (Press LMB to restart)";
        var clones = GameObject.FindGameObjectsWithTag("Hit");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        Vector2 o = new Vector2(0f, -22f);
        this.transform.position = o;
    }

    public void SetLifeText()
    {
        lives.text = $"Lives: {currentLife}/{startingLife}";
    }

    public void SetScoreText()
    {
        scores.text = $"Score: {currentScore}";
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game) {
            if (currentLife == 0)
            {
                startOver();
            }
            SetLifeText();
            SetScoreText();
            Vector2 pos = this.transform.position;
            if (Input.GetKey(KeyCode.LeftArrow)) {
                pos.x -= 0.5f;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                pos.x += 0.5f;
            }
            this.transform.position = pos;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            over = false;
            game = true;
            g.text = "";
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Hit")
        {
            source.Play(0);
            Destroy(collidedWith);
            addScore();
        }
    }
}
