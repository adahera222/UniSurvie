using UnityEngine;
using System.Collections;

[AddComponentMenu("Twur/Cycles Temps")]

public class CyclesTemps : MonoBehaviour {
	public float _maxFlareLuminosite;
	public float _minFlareLuminosite;
	public float _maxLumiereLuminosite;
	public float _minLumiereLuminosite;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}

