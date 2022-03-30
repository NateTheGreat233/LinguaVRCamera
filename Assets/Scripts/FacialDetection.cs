using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.CvEnum;
using VideoCapture = Emgu.CV.VideoCapture;
using TMPro;
using Emgu.CV.Structure;
using System;
using System.IO;
// using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class FacialDetection : MonoBehaviour
{
    private CascadeClassifier cascade;
    private Rectangle[] faces;
    private Matrix4x4 camToWorldMatrix;
    private Matrix4x4 projectionMatrix;
    private bool hasFaces;

    public TextMeshPro debugText;
    public TextMeshPro debugText2;
    public TextMeshPro debugText3;

    public RawImage testImage;

    private void Awake()
    {
        hasFaces = false;
        
        
        cascade = new CascadeClassifier();
        FileStorage file = new FileStorage("Assets/lbpcascade_frontalface_improved.xml", FileStorage.Mode.FormatXml);
        cascade.Read(file.GetFirstTopLevelNode());
     
        
        var testbytes = new byte[30000];
        for (int i = 0; i < testbytes.Length; i++)
        {
            testbytes[i] = 150;
        }


        /*
        var texture = new Texture2D(100, 100, TextureFormat.RGB24, false);
        testImage.texture = texture;

        var t = testImage.texture as Texture2D;
        t.LoadRawTextureData(testbytes); //TODO: Should be able to do this: texture.LoadRawTextureData(pointerToImage, 1280 * 720 * 4);
        t.Apply();
        */
    }


    public void sendFrame(byte[] bytes, Matrix4x4 camM, Matrix4x4 pM, int resWidth, int resHeight)
    {
        /*
        camToWorldMatrix = camM;
        projectionMatrix = pM;
        debugText.text = "w: " + resWidth + ", h: " + resHeight + ", l: " + bytes.Length;
        Bitmap imageBitmap = copyDataToBitmap(bytes, resWidth, resHeight);
        debugText2.text = "got bitmap!";
        Image<Rgba, byte> image = new Image<Rgba, byte>(imageBitmap);
        debugText3.text = "image created?";
        detectFaces(image);
        */
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

    /*
    private void detectFaces(Image<Rgba, byte> image)
    {
        CvInvoke.CvtColor(image, image, ColorConversion.Bgra2Gray);
        Rectangle[] rectangles = cascade.DetectMultiScale(image);
        faces = rectangles;
        hasFaces = true;
    }
    */
}
