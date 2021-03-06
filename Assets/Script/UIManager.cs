﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD

/*!
 * UIのコントロールを管理するクラス
 */
public class UIManager : MonoBehaviour {

    // イメージに関する処理
    public Image imageView; // 描画するイメージ
    public GameObject ImagePlane; // ARモードで表示するイメージ
    private Material imageMaterial;
    private bool isAR = true;  // ARモードとUIモードの切り替え
=======
// using OpenCvSharp;

public class UIManager : MonoBehaviour {

    // UIに関する処理
    public Button onLoadPicture;                    // カメラロールから写真の読み込み
    public Button switchOfLinerImage;               // 線画の切り替え
    public Button startDrawing;                     // 描画開始→ARモードへ

    // イメージに関する処理
    public Image imageView; // 描画するイメージ
    public Texture2D TargetImageTexture;
    const string imageTargetPath = "/Textures/satori.jpg";
    private bool isLiner; // 線画化するか否かのフラグ
    private bool isAR;  // ARモードとUIモードの切り替え
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148

    // デバッグ
    private int gaussianCounter, dilationCounter, thresholdCounter;
    public Text Gcnt, Dcnt, Tcnt;

<<<<<<< HEAD
    // 参照したイメージを管理するクラス
    public TargetManager target;

=======
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    // 2つのモードの切替用
    public GameObject UIMode;
    public GameObject ARMode;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        Debug.Log(target);
        imageMaterial = ImagePlane.GetComponent<Renderer>().material;
        target.nullImageTexture = (Texture2D)imageMaterial.mainTexture;
        ImageInit(7, 5, 220);
        SwitchingDrawingMode();
	}
=======
        isLiner = false;
        isAR = true;
        ImageInit(7, 5, 220);
        SwitchingDrawingMode();
	}
	
	// Update is called once per frame
	void Update () {

    }
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148

    void ImageInit(int gauss, int dil, int thresh)
    {
        gaussianCounter = gauss;
        dilationCounter = dil;
        thresholdCounter = thresh;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
    }

    void ReloadImage(int gauss, int dil, int thresh)
    {
        // イメージの更新
        target.setParametor(gauss, dil, thresh);
        imageView.sprite = target.GetSprite();
        imageMaterial.mainTexture = target.GetTargetImage();

        // パラメータの表示を更新
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
    }

    void ReloadImage(bool isLiner, int gauss, int dil, int thresh)
    {
        // OpenCVによる変換の有無
        if (isLiner)
        {
            //TargetImageTexture = LineDrawing(imageTargetPath, gaussianCounter, dilationCounter, thresholdCounter);
        }
        else
        {
            TargetImageTexture = PngToTex2D(imageTargetPath);
        }


        // キャンバスにテクスチャを適用する
        imageView.material.mainTexture = TargetImageTexture;

>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
        Gcnt.text = gaussianCounter.ToString();
        Dcnt.text = dilationCounter.ToString();
        Tcnt.text = thresholdCounter.ToString();
    }

    // AR<->UIの切り替え
    public void SwitchingDrawingMode()
    {
        isAR = !isAR;
<<<<<<< HEAD
        // ARmanager.ActivateARMode(isLineDrawing);
=======
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
        UIMode.SetActive(!isAR);
        ARMode.SetActive(isAR);
    }

    // 線画<->イラストの切り替え
<<<<<<< HEAD
    public void SwitchingLineDrawing()
    {
        target.isLineDrawing = !target.isLineDrawing;
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
=======
    public void TrigerOfLiner()
    {
        isLiner = !isLiner;
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }

    // パラメータの調整
    public void GaussianPlusOnClick()
    {
        gaussianCounter += 2;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }
    public void GaussianMinusOnClick()
    {
        if (gaussianCounter <= 1) return;
        gaussianCounter -= 2;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }
    public void DilationPlusOnClick()
    {
        dilationCounter += 2;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }
    public void DilationMinusOnClick()
    {
        if (dilationCounter <= 1) return;
        dilationCounter -= 2;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }
    public void ThresholdPlusOnClick()
    {
        if (thresholdCounter >= 250) return;
        thresholdCounter += 10;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }
    public void ThresholdMinusOnClick()
    {
        if (thresholdCounter <= 0) return;
        thresholdCounter -= 10;
<<<<<<< HEAD
        ReloadImage(gaussianCounter, dilationCounter, thresholdCounter);
    }
=======
        ReloadImage(isLiner, gaussianCounter, dilationCounter, thresholdCounter);
    }

    // PNG画像からテクスチャを生成するメソッド
    // 参考: http://urx2.nu/OP8B
    Texture2D PngToTex2D(string path)
    {
        BinaryReader bin = new BinaryReader(new FileStream(Application.streamingAssetsPath + path, FileMode.Open, FileAccess.Read));
        byte[] rb = bin.ReadBytes((int)bin.BaseStream.Length);
        bin.Close();
        int pos = 16, width = 0, height = 0;
        for (int i = 0; i < 4; i++) width = width * 256 + rb[pos++];
        for (int i = 0; i < 4; i++) height = height * 256 + rb[pos++];
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(rb);
        return texture;
    }
    /*
    public Texture2D LineDrawing(string path, int g_value, int d_value, int t_value)
    {
        Mat image_mat = new Mat(Application.streamingAssetsPath + path);
        Debug.Log("Hello");
        Mat tmp_mat = new Mat();
        // グレースケールへ変換
        Cv2.CvtColor(image_mat, image_mat, ColorConversionCodes.BGR2GRAY);
        // ガウスぼかし
        Cv2.GaussianBlur(image_mat, tmp_mat, new Size(g_value, g_value), 0);
        Cv2.Dilate(tmp_mat, tmp_mat, new Mat(Mat.Ones(d_value)));
        Cv2.Absdiff(tmp_mat, image_mat, tmp_mat);

        tmp_mat = 255 - tmp_mat;
        Cv2.Threshold(tmp_mat, tmp_mat, t_value, 255, ThresholdTypes.Binary);
        tmp_mat = 255 - tmp_mat;
        Cv2.CvtColor(tmp_mat, tmp_mat, ColorConversionCodes.GRAY2RGBA);

        int rows = image_mat.Rows, cols = image_mat.Cols;

        // 2値画像を基に透明化された画像を返す
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                Vec4b px = tmp_mat.At<Vec4b>(x, y);
                if ((px[0] + px[1] + px[2]) != 0)
                {
                    px[0] = (px[1] = 0);
                }
                else
                {
                    px[3] = 0;
                }
                tmp_mat.Set<Vec4b>(x, y, px);
            }
        }

        // MatからTexture2Dに変換する
        Texture2D ConvertedImage = new Texture2D(rows, cols, TextureFormat.RGBA32, false);
        ConvertedImage.LoadRawTextureData(tmp_mat.ToBytes());

        return ConvertedImage;
    }
    */
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
}
