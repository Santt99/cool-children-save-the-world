using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    public GameObject _RainDrop;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    private float counter = 0;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (counter % 180 == 0)
        {
            float thisXPostion = transform.position.x;
            float thisYPostion = transform.position.y;
            float thisZPostion = transform.position.z;
            float xPosition = Random.Range(thisXPostion - 0.3f, thisXPostion + 0.3f);
            float yPosition = Random.Range(thisYPostion, thisYPostion + 0.3f);
            float zPosition = Random.Range(thisZPostion - 0.3f, thisZPostion + 0.3f);
            Instantiate(_RainDrop, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
        }
        counter = (int)Mathf.Ceil(counter + (1 * Time.deltaTime));
    }

}
