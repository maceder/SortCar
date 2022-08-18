using UnityEngine;

/// <summary>
/// Oyunda park edilen karelere sol'dan ve sað'dan gelen araçlarýn kaçýncý sýrada
/// yerleþeceðini, içinde araba olup olmadýðýný , ve rengini tutuðum bir model
/// </summary>
[System.Serializable]
public class BoxModel
{
    public GameObject gridBox;
    public int leftQueue;
    public int rightQueue;
    public bool isHaveCar;
    public EnumObjectColor gridBoxColor;
}


