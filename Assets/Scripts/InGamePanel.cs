using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour {
    [SerializeField]
    Text _text;
    [SerializeField]
    Slider _slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _slider.value = Singleton.Energy;
        _text.text = ((int)Singleton.Energy).ToString();

        if (Player.reloadingEnergy)
            _text.color = Color.red;
        else
            _text.color = Color.blue;
	}
}
