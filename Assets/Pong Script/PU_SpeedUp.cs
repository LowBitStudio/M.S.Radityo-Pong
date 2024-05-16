using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PU_SpeedUp : MonoBehaviour
{
    public PU_Manager PUM;
    public Collider2D ball;

    [SerializeField]
    private float magnitude;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other == ball)
        {
            ball.GetComponent<Ball>().ActivateSpeedPU(magnitude);
            //Destroy the object
            PUM.RemovePowerUp(gameObject);
        } 
    }

    private void Start()
    {
        if(gameObject.activeSelf)
        {
            //Debug.Log(gameObject.name + " is active.");
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        PUM.RemovePowerUp(gameObject);
    }
}
