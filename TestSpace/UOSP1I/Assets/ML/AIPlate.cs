using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class AIPlate : Agent {

    public Transform plateT;
    public Transform ballT;
    public Transform triggerT;
    public Rigidbody plateRB;
    public Rigidbody ballRB;
    private Vector3 startPos;

    public override void Initialize() {
        startPos = Vector3.zero;
    }

    public override void OnEpisodeBegin() {
        plateT.localPosition = startPos;
        ballT.localPosition = startPos + new Vector3(0, 1, 0);
        triggerT.localPosition = startPos + new Vector3(0, -0.5f, 0);
        plateRB.velocity = Vector3.zero;
        ballRB.velocity = Vector3.zero;
        ballRB.AddForce(Random.Range(0f, 500f), Random.Range(500f, 1000f), Random.Range(0f, 500f));
    }

    public override void OnActionReceived(float[] vectorAction) {
        plateRB.AddForce((new Vector3(Mathf.FloorToInt(vectorAction[0]) - 1, 0, Mathf.FloorToInt(vectorAction[1]) - 1)) * 500);
    }

    public override void CollectObservations(VectorSensor sensor) {
        sensor.AddObservation(plateT.position);
        sensor.AddObservation(ballT.position - plateT.position);
        sensor.AddObservation(plateRB.velocity);
        sensor.AddObservation(ballRB.velocity);
    }

    public override void Heuristic(float[] actionsOut) {
    }

    public void lose() {
        AddReward(-10);
        EndEpisode();
    }

    public void UReward() {
        AddReward(1);
    }
}
