using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCompass : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var commpass = GameObject.Find("Compass 1");
        // 5 x 5 x 5のコンパスを配置する
        for (int d = 0; d < 5; d++)
        {
            for (int h = 0; h < 10; h++)
            {
                for (int w = 0; w < 10; w++)
                {
                    Instantiate(commpass, new Vector3(
                        0.02f * w - 0.10f, 0.02f * h - 0.10f, 0.02f * d + 2.0f), Quaternion.identity);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
