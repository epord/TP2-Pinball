using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public float blinkFrequence = 10f;
    private List<GameObject> lights;
    private IEnumerator coroutine;

    //All lights
    public GameObject light_1;
    public GameObject light_2;
    public GameObject light_3;
    public GameObject light_4;

	void Start ()
    {
        lights = new List<GameObject>();
        lights.Add(light_1);
        lights.Add(light_2);
        lights.Add(light_3);
        lights.Add(light_4);
        //RandomBlink(blinkFrequence, 10f, this.lights);
        //Blink(blinkFrequence, 10f, this.lights);
        //BottomToTopBlink(blinkFrequence, 10f, this.lights);
        //SwitchOn(10f, this.lights);
    }

    public void Blink(float frequence, float endTime, List<GameObject> lights)
    {
        coroutine = Blink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void RandomBlink(float frequence, float endTime, List<GameObject> lights)
    {
        coroutine = RandomBlink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void BottomToTopBlink(float frequence, float endTime, List<GameObject> lights)
    {
        coroutine = BottomToTopBlink(1f / frequence, endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public void SwitchOn(float endTime, List<GameObject> lights)
    {
        coroutine = SwitchOn(endTime, lights, true);
        StartCoroutine(coroutine);
    }

    public IEnumerator SwitchOn(float endTime, List<GameObject> lights, bool arg)
    {
        foreach (GameObject obj in lights)
        {
            SwitchOn(obj);
        }
        while (Time.time < endTime)
        {
            yield return new WaitForSeconds(1f);
        }
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
