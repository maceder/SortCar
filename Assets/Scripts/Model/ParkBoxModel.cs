using UnityEngine;

/// <summary>
/// Oyunda park edilen karelere sol'dan ve sa�'dan gelen ara�lar�n ka��nc� s�rada
/// yerle�ece�ini, i�inde araba olup olmad���n� , ve rengini tutu�um bir model
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


