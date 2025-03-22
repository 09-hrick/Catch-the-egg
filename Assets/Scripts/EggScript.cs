using UnityEngine;

public class EggScript : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm == null) return;
        if (collision.gameObject.CompareTag("Bottom"))
        {
            if (gameObject.CompareTag("Egg"))
            {
                gm.deductLife();
            }
            Debug.Log("EGG BROKE Bottom");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Basket"))
        {
            if (gameObject.CompareTag("RottenEgg"))
            {
                Destroy(gameObject);
                gm.deductLife();
                Debug.Log("Rotten EGG BROKE Basket");
            }
            else if (gameObject.CompareTag("Egg"))
            {
                if (transform.position.y > collision.transform.position.y)
                {
                    Destroy(gameObject);
                    gm.AddScore();
                    Debug.Log("EGG BROKE BASKET");
                }
            }
        }
    }
}
