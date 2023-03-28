using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchEffect : MonoBehaviour
{
    public List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public List<List<Vector3>> allLinePoints = new List<List<Vector3>>();
    public Material lineMaterial;

    private LineRenderer currentLineRenderer;
    [SerializeField]
    private List<Vector3> currentLinePoints = new List<Vector3>();
    private int lineCount = 0;

    public void NewLine()
    {
        GameObject newGameObject = new GameObject();
        LineRenderer newLineRenderer;

        newLineRenderer = newGameObject.AddComponent<LineRenderer>();
        newLineRenderer.positionCount = 0;
        newLineRenderer.startColor = Color.white;
        newLineRenderer.endColor = Color.white;
        newLineRenderer.startWidth = 0.6f;
        newLineRenderer.endWidth = 0.6f;
        newLineRenderer.useWorldSpace = true;
        newLineRenderer.material = lineMaterial;

        lineRenderers.Add(newLineRenderer);

        List<Vector3> linePoints = new List<Vector3>();

        allLinePoints.Add(linePoints);
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lineCount += 1;
            NewLine();
            currentLinePoints = allLinePoints[lineCount - 1];
            currentLineRenderer = lineRenderers[lineCount - 1];

            float objectToCamera = Vector3.Distance(this.transform.position, Camera.main.transform.position);
            Debug.Log($"{this.gameObject.name}와 메인 카메라의 거리 : {objectToCamera}");
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float objectToCamera = Vector3.Distance(this.transform.position, Camera.main.transform.position);

            worldPos.z = -objectToCamera;

            if (currentLinePoints.Contains(worldPos) == false)
            {
                currentLinePoints.Add(worldPos);

                currentLineRenderer.positionCount = currentLinePoints.Count;
                currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, worldPos);
            }
        }
    }
}
