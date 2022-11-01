using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] Slider fuelBar;
    [SerializeField] Image fuelFill;

	public void SetMaxFuel(float fuel)
	{
		fuelBar.maxValue = fuel;
		fuelBar.value = fuel;

		fuelFill.color = Color.green;
	}

	public void SetFuel(float fuel)
	{
		fuelBar.value = fuel;
	}
}
