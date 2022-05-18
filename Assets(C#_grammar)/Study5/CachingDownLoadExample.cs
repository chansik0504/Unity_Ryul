using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachingDownLoadExample : MonoBehaviour
{
    public string bundleURL;
    public int version;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.DownloadAndCache());
    }

    IEnumerator DownloadAndCache()
    {
        while(!Caching.ready)
        {
            yield return null;
        }

        WWW www = WWW.LoadFromCacheOrDownload(this.bundleURL, this.version);

        yield return www;

        if (www.error != null)
        {
            Debug.Log("fail : (");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
