using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Ball : MonoBehaviour
{
	
    [SerializeField] Text life;
	public GameObject vaus;

	GameObject racket;

	private static int cnt = 0;

    Vector3 originalPosition = new Vector3(7, 1, 0);
    Vector3 racketOriginalPosition = new Vector3(7, 0, 0);

    private float speed = 25f;
    private int lifeCount = 3;
    
	// Use this for initialization
	void Start () {
//		racket = Instantiate (vaus, racketOriginalPosition, Quaternion.identity) as GameObject;

		racket = transform.parent.GetChild (transform.GetSiblingIndex() + 1).gameObject;

		Debug.Log ("Racket" + racket.name.ToString ());


        racket.transform.position = racketOriginalPosition;
        transform.position = originalPosition;

        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        //life.text = string.Format("Life {0}", lifeCount);
	}

    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.y < -14)
        {
            Restart();
        } 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		Debug.Log (col.gameObject.name);
		if(col.gameObject.name == racket.name)
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

		if (col.gameObject.tag == "block") {
			cnt++;
			Debug.Log (cnt.ToString ());
			if (cnt == 5) {
				FindObjectOfType<attack> ().NewAttack1 ();
				cnt = 0;
			}
		}
    }

    void Restart()
    {
        transform.position = originalPosition;
        racket.transform.position = racketOriginalPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void Reset()
    {
        transform.position = originalPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        racket.transform.position = racketOriginalPosition;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void SetLifeText()
    {
        life.text = string.Format("Life {0}", lifeCount);
    }
}
