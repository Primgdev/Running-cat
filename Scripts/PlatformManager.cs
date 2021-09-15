using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platform;

    [SerializeField]
    private int offset;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platform.Length; i++)
        {
            Instantiate(platform[i], new Vector3(0, 0, i * 12), Quaternion.Euler(0, 90, 0));
            offset += 12;
        }
    }

    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, offset);
        offset += 12;
    }
}
