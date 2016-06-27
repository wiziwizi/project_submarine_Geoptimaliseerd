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
	private GameObject weapon1;
	[SerializeField]
	private GameObject weapon2;
	[SerializeField]
	private GameObject weapon3;

	[SerializeField]
	private GameObject weaponE0;
	[SerializeField]
	private GameObject weaponE1;
	[SerializeField]
	private GameObject weaponE2;
	[SerializeField]
	private GameObject weaponE3;

	[SerializeField]
	private GameObject engine1;
	[SerializeField]
	private GameObject engine2;
	[SerializeField]
	private GameObject engine3;

	[SerializeField]
	private GameObject engineE0;
	[SerializeField]
	private GameObject engineE1;
	[SerializeField]
	private GameObject engineE2;
	[SerializeField]
	private GameObject engineE3;

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
			if (weapon1.activeInHierarchy)
			{
				currentWepDesc = "-Aim, + 2 Lazers";
				weaponE0.SetActive (false);
				weaponE1.SetActive (true);
				weapon1.SetActive (false);
				weapon2.SetActive (true);
				UIController._pickups -= upgradeCostWeapon;
				upgradeCostWeapon += 5;
				cost.text = "Pickup Cost:" + upgradeCostWeapon;
			}
		}
		if(UIController._pickups >= upgradeCostWeapon && current == 0)
		{
			if(weapon2.activeInHierarchy)
			{
				currentWepDesc = "- 2 Lazers, + 50 % FireRate";
				weaponE1.SetActive (false);
				weaponE2.SetActive (true);
				weapon2.SetActive(false);
				weapon3.SetActive(true);
				UIController._pickups -= upgradeCostWeapon;
				upgradeCostWeapon += 5;
				cost.text = "Pickup Cost:" + upgradeCostWeapon;
			}
		}
		if(UIController._pickups >= upgradeCostWeapon && current == 0)
		{
			if(weapon3.activeInHierarchy)
			{
				currentWepDesc = "Max";
				weaponE2.SetActive (false);
				weaponE3.SetActive (true);
				weapon3.SetActive(false);
				speedPlus = true;
				UIController._pickups -= upgradeCostWeapon;
				cost.text = "Max";
			}
		}

		if (UIController._pickups >= upgradeCostEngine && current == 1)
		{
			if (engine1.activeInHierarchy)
			{
				currentEngDesc = "+ Speed";
				engineE0.SetActive (false);
				engineE1.SetActive (true);
				engine1.SetActive (false);
				engine2.SetActive (true);
				UIController._pickups -= upgradeCostEngine;
				upgradeCostEngine += 5;
				cost.text = "Pickup Cost:" + upgradeCostEngine;
			}
		}
		if(UIController._pickups >= upgradeCostEngine && current == 1)
		{
			if(engine2.activeInHierarchy)
			{
				currentEngDesc = "+ Speed, + Rotation speed";
				engineE1.SetActive (false);
				engineE2.SetActive (true);
				engine2.SetActive(false);
				engine3.SetActive(true);
				UIController._pickups -= upgradeCostEngine;
				upgradeCostEngine += 5;
				cost.text = "Pickup Cost:" + upgradeCostEngine;
			}
		}
		if(UIController._pickups >= upgradeCostEngine && current == 1)
		{
			if(engine3.activeInHierarchy)
			{
				currentEngDesc = "Max";
				engineE2.SetActive (false);
				engineE3.SetActive (true);
				engine3.SetActive(false);
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
				weaponE0.SetActive (true);
				weaponE1.SetActive (true);
				weaponE2.SetActive (true);
				weaponE3.SetActive (true);
			}
		}
	}
}