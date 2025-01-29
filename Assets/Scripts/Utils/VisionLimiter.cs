using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VisionLimiter : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public Transform player;
    public Light[] lightSources;
    public float maxDistance = 20f;

    private Vignette vignette;
    private ColorGrading colorGrading;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        float closestLight = Mathf.Infinity;

        foreach (var light in lightSources)
        {
            float distance = Vector3.Distance(player.position, light.transform.position);
            closestLight = Mathf.Min(closestLight, distance);
        }

        float baselineVignette = 0.55f;
        float baselineExposure = -3f;

        if (closestLight < maxDistance)
        {
            float intensityFactor = 1 - (closestLight / maxDistance);

            vignette.intensity.value = Mathf.Lerp(baselineVignette, 0.2f, intensityFactor);
            colorGrading.postExposure.value = Mathf.Lerp(baselineExposure, 0f, intensityFactor);
        }
        else
        {
            vignette.intensity.value = baselineVignette;
            colorGrading.postExposure.value = baselineExposure;
        }
    }
}
