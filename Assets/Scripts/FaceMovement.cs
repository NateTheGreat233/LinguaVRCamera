using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FaceMovement : MonoBehaviour
{
    public FacialDetection facialDetection;

    private void Update()
    {
        if (!facialDetection.getHasFaces())
        {
            return;
        }
        Rectangle[] faces = facialDetection.getFaces();
        Matrix4x4 camToWorldMatrix = facialDetection.getCamToWorldMatrix();
        Matrix4x4 projectionMatrix = facialDetection.getProjectionMatrix();
        if (faces.Length == 0)
        {
            return;
        }

        float x = faces[0].X;
        float y = faces[0].Y;

        Vector2 imagePosProjected = LocatableCameraUtils.ConvertPixelCoordsToScaledCoords(new Vector2(x, y), CameraStreamHelper.Instance.GetLowestResolution());

        Vector3 cameraSpacePos = UnProjectVector(projectionMatrix, new Vector3(imagePosProjected.x, imagePosProjected.y, 1));
        Vector3 facePosition = camToWorldMatrix.MultiplyPoint(cameraSpacePos);   // ray point in world space

        transform.position = facePosition;

    }
    private static Vector3 UnProjectVector(Matrix4x4 proj, Vector3 to)
    {
        Vector3 from = new Vector3(0, 0, 0);
        var axsX = proj.GetRow(0);
        var axsY = proj.GetRow(1);
        var axsZ = proj.GetRow(2);
        from.z = to.z / axsZ.z;
        from.y = (to.y - (from.z * axsY.z)) / axsY.y;
        from.x = (to.x - (from.z * axsX.z)) / axsX.x;
        return from;
    }
}
