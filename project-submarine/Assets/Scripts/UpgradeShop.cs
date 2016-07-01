using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour {

	[SerializeField]
	private Canvas shopWindow;
	[SerializeField]
	private GameObject selection;
	[SerializeField]
	private GameObject healthBar;
	[SerializeField]
	private Canvas eToShop;

	[SerializeField]
	private GameObject[] shopItems;

	[SerializeField]
	private GameObject[] equippedItems;

	[SerializeField]
	private GameObject engIcon;
	[SerializeField]
	private GameObject wepIcon;

	[SerializeField]
	private int upgradeCostWeapon;
	[SerializeField]
	private int upgradeCostEngine;

	[SerializeField]
	private Text desc;
	[SerializeField]
	private Text cost;

	[SerializeField]
	private Camera camera1;
	[SerializeField]
	private Camera camera2;

	private int current = 0;
	private bool speedPlus;
	private bool speedMin;
	private float speed;
	private string currentWepDesc;
	private string currentEngDesc;

	public static bool _canShop;
	public static bool _secret;

	[SerializeField]
	private GameObject player;

	void Awake()
	{
		currentWepDesc = "+ 1 Lazer";
		currentEngDesc = "+ Rotation speed";
		desc.text = currentWepDesc;
		cost.text = "Pickup Cost:" + upgradeCostWeapon;
		shopWindow.enabled = false;
		camera2.enabled = false;
		wepIcon.SetActive (true);
		engIcon.SetActive (false);
	}

	public void Exit()
	{
		//text.SetActive (true);
		Pauze._pause = false;
		shopWindow.enabled = false;
		camera1.enabled = true;
		camera2.enabled = false;
	}

	public void Upgrade()
	{
		if (UIController._pickups >= upgradeCostWeapon && current == 0)
		{
			if (shopItems[0].activeInHierarchy)
			{
				currentWepDesc = "-Aim, + 2 Lazers";
				equippedItems[0].SetActive (false);
				equippedItems[1].SetActive (true);
				shopItems[0].SetActive (false);
				shopItems[1].SetActive (true);
				UIController._pickups -= upgradeCostWeapon;
				upgradeCostWeapon += 5;
				cost.text = "Pickup Cost:" + upgradeCostWeapon;
			}
		}
		if(UIController._pickups >= upgradeCostWeapon && current == 0)
		{
			if(shopItems[1].activeInHierarchy)
			{
				currentWepDesc = "- 2 Lazers, + 50 % FireRate";
				equippedItems[1].SetActive (false);
				equippedItems[2].SetActive (true);
				shopItems[1].SetActive(false);
				shopItems[2].SetActive(true);
				UIController._pickups -= upgradeCostWeapon;
				upgradeCostWeapon += 5;
				cost.text = "Pickup Cost:" + upgradeCostWeapon;
			}
		}
		if(UIController._pickups >= upgradeCostWeapon && current == 0)
		{
			if(shopItems[2].activeInHierarchy)
			{
				currentWepDesc = "Max";
				equippedItems[2].SetActive (false);
				equippedItems[3].SetActive (true);
				shopItems[2].SetActive(false);
				speedPlus = true;
				UIController._pickups -= upgradeCostWeapon;
				cost.text = "Max";
			}
		}

		if (UIController._pickups >= upgradeCostEngine && current == 1)
		{
			if (shopItems[3].activeInHierarchy)
			{
				currentEngDesc = "+ Speed";
				equippedItems[4].SetActive (false);
				equippedItems[5].SetActive (true);
				shopItems[3].SetActive (false);
				shopItems[4].SetActive (true);
				UIController._pickups -= upgradeCostEngine;
				upgradeCostEngine += 5;
				cost.text = "Pickup Cost:" + upgradeCostEngine;
			}
		}
		if(UIController._pickups >= upgradeCostEngine && current == 1)
		{
			if(shopItems[4].activeInHierarchy)
			{
				currentEngDesc = "+ Speed, + Rotation speed";
				equippedItems[5].SetActive (false);
				equippedItems[6].SetActive (true);
				shopItems[4].SetActive(false);
				shopItems[5].SetActive(true);
				UIController._pickups -= upgradeCostEngine;
				upgradeCostEngine += 5;
				cost.text = "Pickup Cost:" + upgradeCostEngine;
			}
		}
		if(UIController._pickups >= upgradeCostEngine && current == 1)
		{
			if(shopItems[5].activeInHierarchy)
			{
				currentEngDesc = "Max";
				equippedItems[6].SetActive (false);
				equippedItems[7].SetActive (true);
				shopItems[0].SetActive(false);
				speedMin = true;
				UIController._pickups -= upgradeCostEngine;
				cost.text = "Max";
			}
		}
	}

	public void Next()
	{
		speedPlus = true;
	}

	public void Previous()
	{
		speedMin = true;
	}

	void FixedUpdate ()
	{
		selection.transform.Translate(Vector3.right * speed * Time.deltaTime);
		if (speedPlus == true)
		{
			speed += 0.3f;

			if(selection.transform.position.x > -1695f)
			{
				desc.text = currentEngDesc;
				speed = 0f;
				current++;
				wepIcon.SetActive (false);
				engIcon.SetActive (true);
				speedPlus = false;
			}
		}


		if (speedMin == true)
		{
			speed -= 0.3f;

			if(selection.transform.position.x < -1720.6f)
			{
				desc.text = currentWepDesc;
				cost.text = "Pickup Cost:" + upgradeCostWeapon;
				speed = 0f;
				current--;
				wepIcon.SetActive (true);
				engIcon.SetActive (false);
				speedMin = false;
			}
		}


		if (_canShop == true)
		{
			if (Input.GetKey(KeyCode.E))
			{
				desc.text = currentEngDesc;
				cost.text = "Pickup Cost: " + upgradeCostEngine;
				eToShop.enabled = false;
				Pauze._pause = true;
				//text.SetActive (false);
				shopWindow.enabled = true;
				camera1.enabled = false;
				camera2.enabled = true;
			}
		}

		if (_secret == true)
		{
			if (Input.GetKey(KeyCode.V))
			{
				shopItems[0].SetActive (true);
				shopItems[1].SetActive (true);
				shopItems[2].SetActive (true);
				shopItems[3].SetActive (true);
			}
		}
	}
}