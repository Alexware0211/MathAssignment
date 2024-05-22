using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseManager : MonoBehaviour
{
    [SerializeField] private RawImage noiseTextureImage;
    [SerializeField] private Terrain noiseTerrain;

    private int _width = 256;
    private int _height = 256;

    private Noise _noise;
    private float _scale, _lastScale;

    private void Awake()
    {
        _scale = 0.1f;
        _noise = new PerlinNoise();
        RecomputeNoise();
    }

    private void RecomputeNoise()
    {
        float[,] noise = new float[_width, _height];

        // Y = Height, X = Width
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                noise[x,y] = _noise.GetNoiseMap(x, y, _scale);
            }
        }
        SetNoiseTexture(noise);
    }

    private void SetNoiseTexture (float [,] noise)
    {
        Color[] pixels = new Color[_width * _height];

        // Y = Height, X = Width
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                pixels[x + _width * y] = Color.Lerp(Color.black, Color.white, noise[x, y]);
            }
        }

        Texture2D texture = new Texture2D(_width,_height);
        texture.SetPixels(pixels);
        texture.Apply();
        noiseTextureImage.texture = texture;
        noiseTerrain.terrainData.SetHeights(0,0,noise);
    }

    private void UpdateUI()
    {
        if (_scale == _lastScale)
            return;

        RecomputeNoise();
        _lastScale = _scale;
    }

    private void OnGUI() 
    {
        _scale = GUI.HorizontalSlider(new Rect(50f, 50f, 100f, 100f), _scale, 0.1f, 0.3f);

        if(GUI.changed)
        {
            UpdateUI();
        }

    }
}
