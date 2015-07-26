using UnityEngine;
using System.Collections;

public interface IEffect {

	void onKeyPress(KeyCode code);

	void addStats(Champion champion);

}
