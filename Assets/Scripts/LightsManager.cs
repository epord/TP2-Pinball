using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public float blinkFrequence = 5f;
    private List<GameObject> lights;

    //All lights
    public List<GameObject> skyLights;
    public List<GameObject> centerLights;
    public List<GameObject> launcherLights;

	void Start ()
    {
        foreach(Transform child in GameObject.Find("SkyLights").transform)
        {
            skyLights.Add(child.gameObject);
        }
        foreach(Transform child in GameObject.Find("CenterLights").transform)
        {
            centerLights.Add(child.gameObject);
        }
        foreach (Transform child in GameObject.Find("LauncherLights").transform)
        {
            launcherLights.Add(child.gameObject);
        }
        RandomBlink(5f, 100000f, skyLights);
        BottomToTopBlink(5f, 100000f, skyLights);
        TopToBottomBlink(10f, 100000f, centerLights);
        BottomToTopBlink(10f, 100000f, centerLights);
        RandomBlink(5f, 100000f, centerLights);
    }

    public void Blink(float frequence, float endTime, List<GameObject> lights)
    {
        IEnumerator coroutine = Blink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void RandomBlink(float frequence, float endTime, List<GameObject> lights)
    {
        IEnumerator coroutine = RandomBlink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void BottomToTopBlink(float frequence, float endTime, List<GameObject> lights)
    {
        IEnumerator coroutine = BottomToTopBlink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void TopToBottomBlink(float frequence, float endTime, List<GameObject> lights)
    {
        IEnumerator coroutine = TopToBottomBlink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void SwitchOn(List<GameObject> lights)
    {
        foreach (GameObject obj in lights)
        {
            SwitchOn(obj);
        }
    }

    public void SwitchOff(List<GameObject> lights)
    {
        foreach (GameObject obj in lights)
        {
            SwitchOff(obj);
        }
    }

    private IEnumerator BottomToTopBlink(float waitTime, float endTime, List<GameObject> lights, bool arg)
    {
        while (Time.time < endTime)
        {
            foreach(GameObject obj in lights)
            {
                SwitchOn(obj);
                yield return new WaitForSeconds(waitTime);
                SwitchOff(obj);
            }
        }
    }

    private IEnumerator TopToBottomBlink(float waitTime, float endTime, List<GameObject> lights, bool arg)
    {
        while (Time.time < endTime)
        {
            for (int i = lights.Count - 1; i >= 0; i--)
            {
                SwitchOn(lights[i]);
                yield return new WaitForSeconds(waitTime);
                SwitchOff(lights[i]);
            }
        }
    }

    private IEnumerator RandomBlink(float waitTime, float endTime, List<GameObject> lights, bool arg)
    {
        while (Time.time < endTime)
        {
            foreach (GameObject obj in lights)
            {
                if (Random.value >= 0.5)
                {
                    SwitchOn(obj);
                }
            }
            yield return new WaitForSeconds(waitTime);
            foreach (GameObject obj in lights)
            {
                if (Random.value >= 0.5)
                {
                    SwitchOff(obj);
                }
            }
            yield return new WaitForSeconds(waitTime);
        }
        foreach (GameObject obj in lights)
        {
            SwitchOff(obj);
        }
    }

    private IEnumerator Blink(float waitTime, float endTime, List<GameObject> lights, bool arg)
    {
        while (Time.time < endTime)
        {
            foreach (GameObject obj in lights)
            {
                SwitchOn(obj);
            }                
            yield return new WaitForSeconds(waitTime);
            foreach (GameObject obj in lights)
            {
                SwitchOff(obj);
            }
            yield return new WaitForSeconds(waitTime);
        }
        yield break;
    }

    public void SwitchOn(GameObject obj)
    {
        obj.GetComponent<MLight>().SwitchOn();
    }

    public void SwitchOff(GameObject obj)
    {
        obj.GetComponent<MLight>().SwitchOff();
    }
}
