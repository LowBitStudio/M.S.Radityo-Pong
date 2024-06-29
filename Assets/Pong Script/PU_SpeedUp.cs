using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PU_SpeedUp : MonoBehaviour
{
    [Header("Item Setting")]
    public PU_Manager PUM;
    public Collider2D ball;

    [Header("Item SFX")]
    public string PU_Name = "Fast Ball";
    public GameObject FloatingTextPrefab;
    public Collider2D PowerUpCollider;
    public SpriteRenderer sr;

    [SerializeField]
    private float magnitude;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other == ball)
        {
            ball.GetComponent<Ball>().ActivateSpeedPU(magnitude);
            StartCoroutine(BallHit());
        } 
    }

    private void Start()
    {
        if(gameObject.activeSelf)
        {
            sr = GetComponent<SpriteRenderer>();
            PowerUpCollider = GetComponent<Collider2D>();
            //Debug.Log(gameObject.name + " is active.");
            StartCoroutine(Timer());
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = PU_Name;
    }

    public IEnumerator BallHit()
    {
        sr.enabled = false;
        PowerUpCollider.enabled = false;
        ShowFloatingText();
        yield return new WaitForSeconds(1.31f);
        //Destroy the object
        PUM.RemovePowerUp(gameObject);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        PUM.RemovePowerUp(gameObject);
    }
}
