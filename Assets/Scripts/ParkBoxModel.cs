using UnityEngine;

/// <summary>
/// Oyunda park edilebilen karelerin sol'dan ve sa�'dan gelen ara� ka��nc� s�rada
/// oraya yerle�ebilice�ini, i�inde araba olup olmad���n� , ve rengini tutu�um bir model
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


