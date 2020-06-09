using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [System.Serializable] 
public struct Animal {
	public float highCutoffFreq;
	public float lowCutoffFreq;
}

        // for (int i = 0; i < data.Length; i++) {
        //     data[i] = (float)(rand.NextDouble() * 2.0 - 1.0 + offset);
        // }

public class AudioController : MonoBehaviour {
    
    [Range(-1f, 1f)]
    float offset;
    System.Random rand = new System.Random();

    public bool owlMode;

    Animal owl;
    
    AudioLowPassFilter lowPassFilter;
    AudioHighPassFilter highPassFilter;

 	void Awake() {
 		owl.lowCutoffFreq = 800;
 		owl.highCutoffFreq = 12000;

        lowPassFilter = GetComponent<AudioLowPassFilter>();
        highPassFilter = GetComponent<AudioHighPassFilter>();
        Update();
    }

    void Update() {
        lowPassFilter.cutoffFrequency = owlMode ? owl.lowCutoffFreq : 31;
        highPassFilter.cutoffFrequency = owlMode ? owl.highCutoffFreq : 20000;
    }

    void OnAudioFilterRead(float[] data, int channels) {

    }



    
}