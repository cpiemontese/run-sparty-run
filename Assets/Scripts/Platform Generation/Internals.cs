using UnityEngine;

public static class Internals
{
    public static GameObject GenerateTile(GameObject gameObject, Transform parentTransform, Vector3 positionInParent, int speed)
    {
        var generatedObject = Object.Instantiate(gameObject, parentTransform, false);
        generatedObject.transform.position = positionInParent;
        Scroll scroll = generatedObject.GetComponent<Scroll>();
        scroll.speed = speed;
        return generatedObject;
    }
}