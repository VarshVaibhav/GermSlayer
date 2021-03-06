using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bacteria : MonoBehaviour
{
    private const float Gravity = 10.0f;
    public bool IsActive { set; get; }

    private float verticalVelocity;
    private float speed;
    private float rotationSpeed;

    private bool isSliced = false;

    public SpriteRenderer bRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private float lastSpriteUpdate;
    private float spriteUpdateDelta = 0.125f;

    public GameObject Effect1;
    public GameObject splashBlood;


    public Animator anime;
    public void LaunchBacteria(float verticalVelocity, float xSpeed, float xStart)
    {
        IsActive = true;
        speed = xSpeed;
        this.verticalVelocity = verticalVelocity;
        transform.position = new Vector3(xStart, -5, 0);
        rotationSpeed = Random.Range(-180, 180);
        isSliced = false;

        spriteIndex = 0;
        bRenderer.sprite = sprites[spriteIndex];
    }
    private void Update()
    {
        if (!IsActive)
            return;
        verticalVelocity -= Gravity * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        anime.gameObject.GetComponent<Animator>().enabled = true;
        if (isSliced)
        {
            anime.gameObject.GetComponent<Animator>().enabled = false;
            if (spriteIndex != sprites.Length-1 && Time.time - lastSpriteUpdate > spriteUpdateDelta)
            {            
                lastSpriteUpdate = Time.time;
                spriteIndex++;
                bRenderer.sprite = sprites[spriteIndex];
            }
            
        }
        if (transform.position.y < -7)
        {
            IsActive = false;
            if (gameObject.tag == "Level2Bacteria")
            {

                if (!isSliced)
                {
                    GameManager.Instance.camAnim.SetTrigger("fall");
                    GameManager.Instance.LoseLP();
                }
            }
        }
    }
    public void Slice()
    {
        if (isSliced)        
            return;
        
        if (verticalVelocity < 0.5f)
            verticalVelocity = 0.5f;

        speed = speed * 0.5f;
        isSliced = true;

        Instantiate(Effect1, transform.position + transform.forward * -2, Quaternion.identity);
        SoundManager.Instance.PlaySound(1);
  
        Instantiate(splashBlood, transform.position + transform.forward * -2, Quaternion.identity);
        GameManager.Instance.CamShake();

        if(gameObject.tag == "Level1Virus")
        {
            ScoreLevel1.Instance.IncrementScore(5);
        }
        if (gameObject.tag == "Level2Bacteria")
        {
            ScoreLevel2.Instance.IncrementScore(10);
        }
    }
}
