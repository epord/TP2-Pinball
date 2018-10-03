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
    public List<GameObject> rampLights1;
    public List<GameObject> rampLights2;
    public List<GameObject> wheelArrows;
    public GameObject rampArrow;
    public GameObject lockArrow;
    public GameObject targetsArrow;

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
        foreach (Transform child in GameObject.Find("RampLights").transform)
        {
            rampLights1.Add(child.gameObject);
        }
        foreach (Transform child in GameObject.Find("RampLights2").transform)
        {
            rampLights2.Add(child.gameObject);
        }
                   
        RandomBlink(5f, 100000f, skyLights);
        BottomToTopBlink(5f, 100000f, skyLights);
        TopToBottomBlink(10f, 100000f, centerLights);
        BottomToTopBlink(10f, 100000f, centerLights);
        RandomBlink(5f, 100000f, centerLights);
        BlinkRamp(0.5f, launcherLights);
    }

    public void BlinkRamp(float speed, List<GameObject> lights)
    {       
        IEnumerator coroutine = BlinkRamp(speed, lights, true);
        StartCoroutine(coroutine);
    }

    private IEnumerator BlinkRamp(float speed, List<GameObject> lights, bool arg)
    {
        float duration = speed;
        foreach (GameObject obj in lights)
        {
            SwitchOn(obj);
            while (duration > 0)
            {

                duration -= Time.deltaTime;
                yield return null;
            }
            duration = speed;
        }
        SwitchOff(lights);
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

    public void SwitchLauncherLights(int lightsOn)
    {
        for (int i = 0; i < lightsOn; i++ )
        {
            launcherLights[i].GetComponent<MLight>().SwitchOn();
        }

        for (int i = lightsOn; i < launcherLights.Count; i++)
        {
            launcherLights[i].GetComponent<MLight>().SwitchOff();
        }
    }

    public void SetWheelMission()
    {
        foreach (GameObject arrow in wheelArrows)
        {
            arrow.GetComponent<ArrowLight>().TurnOn();
        }
        lockArrow.GetComponent<ArrowLight>().TurnOff();
        lockArrow.GetComponent<ArrowLight>().TurnOff();
        rampArrow.GetComponent<ArrowLight>().TurnOff();
    }

    public void SetRampMission()
    {
        foreach (GameObject arrow in wheelArrows)
        {
            arrow.GetComponent<ArrowLight>().TurnOff();
        }
        targetsArrow.GetComponent<ArrowLight>().TurnOff();
        lockArrow.GetComponent<ArrowLight>().TurnOff();
        rampArrow.GetComponent<ArrowLight>().TurnOn();
    }

    public void SetLockMission()
    {
        foreach (GameObject arrow in wheelArrows)
        {
            arrow.GetComponent<ArrowLight>().TurnOff();
        }
        targetsArrow.GetComponent<ArrowLight>().TurnOff();
        lockArrow.GetComponent<ArrowLight>().TurnOn();
        rampArrow.GetComponent<ArrowLight>().TurnOff();
    }

    public void SetTargetsMission()
    {
        foreach (GameObject arrow in wheelArrows)
        {
            arrow.GetComponent<ArrowLight>().TurnOff();
        }
        targetsArrow.GetComponent<ArrowLight>().TurnOn();
        lockArrow.GetComponent<ArrowLight>().TurnOff();
        rampArrow.GetComponent<ArrowLight>().TurnOff();
    }
}
