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
            for (int h = 0; h < 5; h++)
            {
                for (int w = 0; w < 5; w++)
                {
                    Instantiate(commpass, new Vector3(
                        0.2f * w - 0.4f, 0.2f * h - 0.4f, 0.2f * d - 0.4f), Quaternion.identity);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
