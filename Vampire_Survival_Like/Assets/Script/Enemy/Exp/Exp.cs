using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public bool isclose;
    //private GameObject gameManager;

    private Rigidbody2D target;
    float speed = 8;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isclose)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position, speed * Time.deltaTime);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.A_instance.PlaySfx(AudioManager.Sfx.exp);
            Destroy(gameObject);
            GameManager.instance.EXP_UI.GetComponent<EXP_Bar_Slider>().Exp_Up();
        }
    }
}
