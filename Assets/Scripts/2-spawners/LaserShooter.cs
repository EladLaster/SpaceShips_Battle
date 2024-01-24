using UnityEngine;

public class LaserShooter : ClickSpawner {
    [SerializeField] NumberField scoreField;
    [SerializeField] float timeBetweenShots = 0.5f;
    private float lastShotTime;

    protected override GameObject spawnObject() {
        if (Time.time - lastShotTime >= timeBetweenShots) {

            GameObject newObject = base.spawnObject();  // base = super
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder)
                newObjectScoreAdder.SetScoreField(scoreField);

            lastShotTime = Time.time;
            return newObject;
        }

        return null;
    }
}
