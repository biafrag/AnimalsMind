using UnityEngine;
public class RockChewAudio : MonoBehaviour {
    
    public int clicks = 0;

    System.Random rand = new System.Random();
        
    void OnAudioFilterRead(float[] data, int channels) {
        bool inClick = false;    // whether we're generating a click (true) or silence (false)
        int samplesLeft = 0;    // how many samples of that click or silence we still have to go
        for (int i = 0; i < data.Length; i += channels) {
            if (samplesLeft < 1) {
                // If out of clicks, then just generate silence for the rest of the time.
                if (clicks < 1) {
                    inClick = false;
                    samplesLeft = data.Length / channels;
                } else if (inClick) {
                    // Generate a small random silence.
                    inClick = false;
                    samplesLeft = rand.Next(1,10);
                } else {
                    // Generate a click.
                    inClick = true;
                    samplesLeft = rand.Next(2,5);
                    clicks--;
                }
            }
            for (int j=0; j<channels; j++) {
                data[i+j] = inClick ? (float)(rand.NextDouble() * 2.0 - 1.0) : 0;
            }            
            samplesLeft--;
        }
        clicks = 0;
    } 
}