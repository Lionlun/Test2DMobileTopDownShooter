using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunInfo : ScriptableObject
{
	public string Name;

	public PlayerBullet Bullet;
	public float MaxDistance;

	public int CurrentAmmo;
	public int MagazineSize;
	public float ReloadTime;
}
