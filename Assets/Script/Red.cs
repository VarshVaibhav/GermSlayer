using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    private const float Gravity = 10.0f;
    public bool IsActive { set; get; }

    private float verticalVelocity;
    private float speed;
    private float rotationSpeed;

    private bool isSliced = false;

    public SpriteRenderer rRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private float lastSpriteUpdate;
    private float spriteUpdateDelta = 0.125f;

    public GameObject blood;
    public GameObject cross;

    public Animator anime;
    public void LaunchRed(float verticalVelocity, float xSpeed, float xStart)
    {
        IsActive = true;
        speed = xSpeed;
        this.verticalVelocity = verticalVelocity;
        transform.position = new Vector3(xStart, -5, 0);
        rotationSpeed = Random.Range(-180, 180);
        isSliced = false;

        spriteIndex = 0;
        rRenderer.sprite = sprites[spriteIndex];
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
            if (spriteIndex != sprites.Length - 1 && Time.time - lastSpriteUpdate > spriteUpdateDelta)
            {
                lastSpriteUpdate = Time.time;
                spriteIndex++;
                rRenderer.sprite = sprites[spriteIndex];
            }
        }
        if (transform.position.y < -7)
            IsActive = false;
    }
    public void rSlice()
    {
        if (isSliced)
            return;
        if (verticalVelocity < 0.5f)
            verticalVelocity = 0.5f;
        
        speed = speed * 0.5f;
        isSliced = true;

        Instantiate(blood, transform.position + transform.forward*-2, Quaternion.Euler(210, 0, 0));
        SoundManager.Instance.PlaySound(4);
        Instantiate(cross, transform.position + transform.up*-0.5f, Quaternion.identity);
        GameManager.Instance.camAnim.SetTrigger("fall");

        GameManager.Instance.LoseLP();
    }
}