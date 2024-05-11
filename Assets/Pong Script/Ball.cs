using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Vector2 Speed;
    [SerializeField]
    Vector2 resetpos;
    Rigidbody2D rb;
    bool GameStart;
    
    public void ResetBall()
    {
        transform.position = new Vector2(resetpos.x, resetpos.y);
    }

    public void ActivatePU(float magnitude)
    {
        rb.velocity *= magnitude;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Is starting " + GameStart);
        //Get rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tambahan
        //Start the match by clicking space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(GameStart == false)
            {
                //Memulai permainan
                GameStart = true;
                Debug.Log("Game started");
                //Menggerakan bola ketika permainan mulai
                rb.velocity = Speed;
            }
            else
            {
                //Apabila menekan key space lagi, tidak akan berubah dan menyatakan
                //permainan sudah dimulai
                Debug.Log("Game already started");
            }
        }
    }
}
