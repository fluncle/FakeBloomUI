using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode, RequireComponent(typeof(Image))]
public class ImageGlow : MonoBehaviour
{
    private static readonly int PROPERTY_EMISSION_COLOR = Shader.PropertyToID("_EmissionColor");

    [ColorUsage(false, true)]
    public Color EmissionColor;

    private Material _mat;

    private Material Mat
    {
        get
        {
            if (_mat != null)
            {
                return _mat;
            }
            Initialize();
            return _mat;
        }
    }

    private void Initialize()
    {
        Image image = GetComponent<Image>();
        Shader uiGlowShader = Shader.Find("UI/Glow");
        if (image.material == null || image.material.shader != uiGlowShader)
        {
            _mat = new Material(uiGlowShader);
        }
        else
        {
            _mat = new Material(image.material);
        }
        _mat.name = "UI-Glow (Instance)";
        image.material = _mat;
    }

    private void Update()
    {
        Mat.SetColor(PROPERTY_EMISSION_COLOR, EmissionColor);
    }

    private void OnRenderObject()
    {
        Mat.SetColor(PROPERTY_EMISSION_COLOR, EmissionColor);
    }

    private void OnDestroy()
    {
        if(_mat != null)
        {
            if (Application.isPlaying)
            {
                Destroy(_mat);
            }
            else
            {
                DestroyImmediate(_mat);
            }
        }
    }
}