using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    static int counter;
    Text mText;


    [SerializeField]
    private float resistance = 1F;

    private float spinTime = 1F;

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.y < -2.8)
        {
            Time.timeScale = 0F;
            print("Game Over");
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute                DONE
            resistance -= collision.gameObject.GetComponent<Bullet>().Damage;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }

            Destroy(collision.gameObject);
            counter++;

            mText = GameObject.Find("HazardCounter").GetComponent<Text>();
            mText.text = "Destroyed Hazards = " + counter;
        }

        if (collision.gameObject.GetComponent<APBullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute                DONE
            resistance -= collision.gameObject.GetComponent<APBullet>().Damage;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
            counter++;

            mText.text = "Destroyed Hazards = " + counter;
        }

        if (collision.gameObject.GetComponent<Shelter>() != null)
        {
            Shelter shelter = collision.gameObject.GetComponent<Shelter>();

            shelter.Damage(1);
            OnHazardDestroyed();

            if(shelter.IsInvoking("Regenerate") == true)
            {
                shelter.CancelInvoke("Regenerate");
                shelter.Invoke("Regenerate", shelter.regenTime);
            }
            else
                shelter.Invoke("Regenerate", shelter.regenTime);
        }
    }

    protected virtual void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}