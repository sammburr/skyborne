using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Struggle : MonoBehaviour
{
	
	public PlayerMovement PM;
	public KeyCode StruggleKey;
	public GameObject StruggleSlider;
	public RectTransform Text;

	public uint DecreaseRate;
	public int ProgressGoal;

	public bool IsStruggling;

	Slider slider;

	private void Start() {

		slider = StruggleSlider.GetComponent<Slider>();	

	}

	private void Update() {

		if(IsStruggling) {
			StruggleSlider.SetActive(true);
			PM.CanMove = false;
			PlayerStruggle();
		}

	}

       	int progress = 0;	
	int timer = 0;
	bool back = false;

	private void PlayerStruggle() {

		timer++;

		if(Input.GetKeyDown(StruggleKey)) {
			progress ++;
			
			if(back)
				Text.Rotate(new Vector3(0f, 0f, 2f));
			else
				Text.Rotate(new Vector3(0f, 0f, -2f));

			back = !back;

		}

		if(timer%DecreaseRate == 0) {
			if(progress>0)
				progress --;
			timer = 0;			
		}

		if(progress == ProgressGoal) {
			PM.CanMove = true;
			IsStruggling = false;
			StruggleSlider.SetActive(false);
			progress = 0;
		}

		slider.value = (float)progress/(float)ProgressGoal;

	}

}
