using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private Transform shootingPoint;
	[SerializeField] private TextMeshProUGUI ammoText;
	[SerializeField] private GunInfo currentGun;
	private Vector3 direction;
	private bool isWithinRange;

	private void Start()
	{
		currentGun.CurrentAmmo = currentGun.MagazineSize;
		UpdateAmmoText();
	}

	public void Attack()
	{
		if (isWithinRange)
		{
			if (currentGun.CurrentAmmo > 0)
			{
				currentGun.CurrentAmmo--;
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				var newBullet = Instantiate(currentGun.Bullet, shootingPoint.position, rotation);
				UpdateAmmoText();
			}
			else
			{
				Reload();
			}
		}
	}

	public void ChooseGun(GunInfo gun)
	{
		currentGun = gun;
	}

	public GunInfo GetCurrentGun()
	{
		return currentGun;
	}

	private void UpdateAmmoText()
	{
		ammoText.text = currentGun.CurrentAmmo + "/" + currentGun.MagazineSize;
	}

	private async void Reload()
	{
		await Task.Delay((int)currentGun.ReloadTime*1000); // Заглушка, имитация перезарядки
		currentGun.CurrentAmmo = currentGun.MagazineSize;
		UpdateAmmoText();
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<EnemyBase>() != null)
		{
			var enemyPosition = collision.gameObject.transform.position;
			direction = enemyPosition - transform.position;
			isWithinRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<EnemyBase>() != null)
		{
			isWithinRange = false;
		}
	}
}
