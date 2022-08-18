using UnityEngine;

/// <summary>
/// Oyunda park edilebilen karelerin sol'dan ve sað'dan gelen araç kaçýncý sýrada
/// oraya yerleþebiliceðini, içinde araba olup olmadýðýný , ve rengini tutuðum bir model
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


