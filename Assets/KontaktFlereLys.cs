using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class KontaktFlereLys : MonoBehaviour
{
    [SerializeField] string lightTag;
    GameObject[] lysArray;
    GameObject linkedLight;

    // Start is called before the first frame update
    void Start()
    {
        lysArray = GameObject.FindGameObjectsWithTag(lightTag);
        GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>().lightsInKontakter += lysArray.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SlukAlleLys()
    {
        for (int i = 0; i < lysArray.Length; i++)
        {
            linkedLight = lysArray[i];
            if (linkedLight.GetComponent<Light2D>().intensity != 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>().lysSlukket++;
            }
            linkedLight.GetComponent<Light2D>().intensity = 0;
        }
    }
}
