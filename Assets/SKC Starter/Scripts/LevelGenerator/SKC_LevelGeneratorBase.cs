/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public class SKC_LevelGeneratorBase : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms = null;

    public bool randomize = false;
    public bool blockRandom = false;
    public int blockCount;

    public int spawnAmount = 0;
    public float spaceBetweenPlatform = 0f;
    public Vector3 spawnAngle = new Vector3(0f, 0f, 0f);
    public bool angelStep = false;

    float boundX = 0, boundY = 0, boundZ = 0;

    public void CreateLevelForward(Transform parent = null)
    {
        if (parent != null)
        {
            if (randomize)
            {
                if(!blockRandom)
                {
                    if (angelStep)
                    {
                        for (int i = 0; i < spawnAmount; i++)
                        {
                            int randomN = Random.Range(0, platforms.Length);
                            boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                            boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                            boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                            var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < spawnAmount; i++)
                        {
                            int randomN = Random.Range(0, platforms.Length);
                            boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                            boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                            boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                            var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        }
                    }
                }
                else
                {
                    if(!angelStep)
                    {
                        int tempa = 0;
                        for (int i = 0; i < spawnAmount / blockCount; i++)
                        {
                            int randomN = Random.Range(0, platforms.Length / blockCount);
                            if (i == 0)
                            {
                                for (int j = 0; j < blockCount; j++)
                                {
                                    boundX = platforms[j].GetComponent<Renderer>().bounds.size.x;
                                    boundY = platforms[j].GetComponent<Renderer>().bounds.size.y;
                                    boundZ = platforms[j].GetComponent<Renderer>().bounds.size.z;
                                    var platformTemp = (GameObject)Instantiate(platforms[j], Vector3.forward * (boundZ + spaceBetweenPlatform) * j, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                                }
                            }
                            else
                            {
                                for (int k = blockCount * randomN; k < (blockCount * randomN) + blockCount; k++)
                                {
                                    boundX = platforms[k].GetComponent<Renderer>().bounds.size.x;
                                    boundY = platforms[k].GetComponent<Renderer>().bounds.size.y;
                                    boundZ = platforms[k].GetComponent<Renderer>().bounds.size.z;
                                    var platformTemp = (GameObject)Instantiate(platforms[k], Vector3.forward * (boundZ + spaceBetweenPlatform) * (blockCount+ tempa), Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                                    tempa++;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        spawnObj++;
                    }
                }
            }
        }
        else
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                        spawnObj++;
                    }
                }
            }
        }
    }

    public void CreateLevelNegativeForward(Transform parent = null)
    {
        if (parent == null)
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        spawnObj++;
                    }
                }
            }
        }
        else
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.forward * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                        spawnObj++;
                    }
                }
            }
        }
    }

    public void CreateLevelUp(Transform parent = null)
    {
        if (parent == null)
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.up * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.up * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        spawnObj++;
                    }
                }
            }
        }
        else
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.up * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.up * (boundZ + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                        spawnObj++;
                    }
                }
            }
        }
    }

    public void CreateLevelNegativeUp(Transform parent = null)
    {
        if (parent == null)
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        spawnObj++;
                    }
                }
            }
        }
        else
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.up * (boundY + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                        spawnObj++;
                    }
                }
            }
        }
    }

    public void CreateLevelRight(Transform parent = null)
    {
        if (parent == null)
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length  - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length  - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        spawnObj++;
                    }
                }
            }
        }
        else
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                        spawnObj++;
                    }
                }
            }
        }
    }

    public void CreateLevelNegativeRight(Transform parent = null)
    {
        if (parent == null)
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), this.gameObject.transform);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length ) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), this.gameObject.transform);
                        spawnObj++;
                    }
                }
            }
        }
        else
        {
            if (randomize)
            {
                if (angelStep)
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                    }
                }
                else
                {
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        int randomN = Random.Range(0, platforms.Length);
                        boundX = platforms[randomN].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[randomN].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[randomN].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[randomN], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                    }
                }
            }
            else
            {
                if (angelStep)
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x * i, spawnAngle.y * i, spawnAngle.z * i), parent);
                        spawnObj++;

                    }
                }
                else
                {
                    int spawnObj = 0;
                    for (int i = 0; i < spawnAmount; i++)
                    {
                        if (spawnObj > platforms.Length - 1) spawnObj = 0;
                        boundX = platforms[spawnObj].GetComponent<Renderer>().bounds.size.x;
                        boundY = platforms[spawnObj].GetComponent<Renderer>().bounds.size.y;
                        boundZ = platforms[spawnObj].GetComponent<Renderer>().bounds.size.z;
                        var platformTemp = (GameObject)Instantiate(platforms[spawnObj], -Vector3.right * (boundX + spaceBetweenPlatform) * i, Quaternion.Euler(spawnAngle.x, spawnAngle.y, spawnAngle.z), parent);
                        spawnObj++;
                    }
                }
            }
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */