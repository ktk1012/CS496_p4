using UnityEngine;
using System.Collections;

public class hold : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		transform.position = new Vector3(18, 18, 0);
    }

    void Update()
    {
        if (active1.del)
        {
            Destroy(transform.gameObject);
            active1.del = false;
        }
    }
}
