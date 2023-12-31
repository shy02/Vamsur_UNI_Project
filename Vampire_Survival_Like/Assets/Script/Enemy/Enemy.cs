using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float em_health = 10f;
    // Start is called before the first frame update
    public float Original_speed = 2;
    public float _speed;
    private GameObject gm;
    private Rigidbody2D target;
    bool isLive;
    public GameObject Drop_exp;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    
    void Start()
    {
        _speed = Original_speed;
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager");
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionStay2D(Collision2D other) {
        if(other.collider.gameObject.CompareTag("Player")){
            gm.GetComponent<GameManager>().Player_damage(0.5f);
        }
    }
    void FixedUpdate()
    {
        Vector2 director = target.position - rigid.position;

        Vector2 next = director.normalized * Original_speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + next);
        target.velocity = Vector2.zero;
        
        if(em_health <= 0)
        {
            Dead();
            AudioManager.A_instance.PlaySfx(AudioManager.Sfx.e_dead);

        }

    }
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return;
    }
    */
    public void Dead()
    {
        gm.GetComponent<GameManager>().DeadNum++;
        Drop_Exp();
        Destroy(gameObject);
    }
    public void GetDamage(float DMG){
        em_health = em_health - DMG;
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.e_hit);
    }

    private void Drop_Exp()
    {
        Vector3 spawnPosition = transform.position;
        Instantiate(Drop_exp, spawnPosition, Quaternion.identity);
    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }

    public void Slow(float slowFactor)      //바나나밟으면 속도 감소 (추가)
    {
        Original_speed *= (slowFactor/100);
        Invoke("ReturnSpeed", 2f+((2f/100)*GameManager.instance.player.GetComponent<Player_State>().WeaphoneTime));
    }
    public void KnockBack(){
        if(target.position.x > transform.position.x){
        rigid.AddForce(new Vector2(-1000f, 0f));
        }
        else{
        rigid.AddForce(new Vector2(1000f, 0f));
        }
        if(target.position.y > transform.position.y){
        rigid.AddForce(new Vector2(0f, -1000f));
        }
        else{
        rigid.AddForce(new Vector2(0f, 1000f));
        }
        
    }
    public void ReturnSpeed()
    {
        Original_speed = _speed;
    }

}
