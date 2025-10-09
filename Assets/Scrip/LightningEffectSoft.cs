using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffectSoft : MonoBehaviour
{
    //Luz
    [SerializeField] private Light Lightninglight;
    [SerializeField] private float min = 20f;
    [SerializeField] private float max = 40f;

    //Ambiente
    [SerializeField] private Color LightningAmbColor = new Color(0.6f, 0.7f, 1f);
    private Color NormalAmb;

    //Audio
    [SerializeField] private AudioSource rainloop;
    [SerializeField] public List<AudioSource> thunders = new List<AudioSource>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Lightninglight.enabled = false;
        NormalAmb = RenderSettings.ambientLight;
        if(rainloop !=null && !rainloop.isPlaying) rainloop.Play();
        StartCoroutine(LightningRoutine());
    }

    IEnumerator LightningRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            StartCoroutine(LightningFlash());
        }
    }

    IEnumerator LightningFlash()
    {
        for (int i = 0; i < 2; i++)
        {
            Lightninglight.enabled = true;
            RenderSettings.ambientLight = LightningAmbColor;
            yield return new WaitForSeconds(0.15f);
            Lightninglight.enabled = false;
            RenderSettings.ambientLight = NormalAmb;
            yield return new WaitForSeconds(Random.Range(0.5f, 0.1f));
        }

        yield return new WaitForSeconds(Random.Range(0.5f, 0.2f));
        PlayRandomThunder();


    }

    void PlayRandomThunder()
    {
        if (thunders.Count == 0) return;
        int index = Random.Range(0, thunders.Count);
        thunders[index].Play();
    }

}
