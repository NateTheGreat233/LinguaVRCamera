using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.CvEnum;
using VideoCapture = Emgu.CV.VideoCapture;

public class FacialDetection : MonoBehaviour
{
    private CascadeClassifier cascade;
    private Rectangle[] faces;
    private Matrix4x4 camToWorldMatrix;
    private Matrix4x4 projectionMatrix;
    private bool hasFaces;

    private void Awake()
    {
        hasFaces = false;
        cascade = new CascadeClassifier();
        FileStorage file = new FileStorage("Assets/lbpcascade_frontalface_improved.xml", FileStorage.Mode.FormatXml);
        cascade.Read(file.GetFirstTopLevelNode());
    }

    public void sendFrame(byte[] bytes, Matrix4x4 camM, Matrix4x4 pM)
    {
        camToWorldMatrix = camM;
        projectionMatrix = pM;
        Mat img = byteToGrayMat(bytes);
        detectFaces(img);
    }

    public Matrix4x4 getCamToWorldMatrix()
    {
        return camToWorldMatrix;
    }

    public Matrix4x4 getProjectionMatrix()
    {
        return projectionMatrix;
    }

    public Rectangle[] getFaces()
    {
        return faces;
    }

    public bool getHasFaces()
    {
        return hasFaces;
    }

    private void detectFaces(Mat grayImg)
    {
        Rectangle[] rectangles = cascade.DetectMultiScale(grayImg);
        faces = rectangles;
        hasFaces = true;
    }

    private Mat byteToGrayMat(byte[] bytes)
    {
        //Mat img = new Mat(4000, 6000, DepthType.Cv8U, 3);
        Mat img = new Mat();
        CvInvoke.Imdecode(bytes, ImreadModes.AnyColor, img);
        CvInvoke.CvtColor(img, img, ColorConversion.Rgba2Gray);

        return img;
    }

}
