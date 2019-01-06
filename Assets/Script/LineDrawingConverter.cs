using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
// using OpenCvSharp;

public class LineDrawingConverter : MonoBehaviour {
    /*
    public Texture2D LineDrawing(string path, int g_value, int d_value, int t_value)
    {
        Debug.Log("Hello!");
        var image_mat = new Mat(path);
        var tmp_mat = new Mat();
        // グレースケールへ変換
        Cv2.CvtColor(image_mat, image_mat, ColorConversionCodes.BGR2GRAY);
        // ガウスぼかし
        Cv2.GaussianBlur(image_mat, tmp_mat, new Size(5,5), 0);
        Cv2.Dilate(tmp_mat, tmp_mat, new Mat(Mat.Ones(d_value)));
        Cv2.Absdiff(tmp_mat, image_mat, tmp_mat);

        tmp_mat = 255 - tmp_mat;
        Cv2.Threshold(tmp_mat, tmp_mat, t_value, 255, ThresholdTypes.Binary);
        tmp_mat = 255 - tmp_mat;
        Cv2.CvtColor(tmp_mat, tmp_mat, ColorConversionCodes.GRAY2RGBA);

        int rows = image_mat.Rows, cols = image_mat.Cols;
        Debug.Log("Hello");

        // 2値画像を基に透明化された画像を返す
        for (int x = 0; x < rows; x++)
        {
            for(int y = 0; y < cols; y++)
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

        Debug.Log("Hello");
        // MatからTexture2Dに変換する
        var ConvertedImage = new Texture2D(rows, cols, TextureFormat.RGBA32, false);
        ConvertedImage.LoadRawTextureData(tmp_mat.ToBytes());

        return ConvertedImage;
    }
    */

    // PNG画像からテクスチャを生成するメソッド
    // 参考: http://urx2.nu/OP8B
    Texture2D PngToTex2D(string path)
    {
        BinaryReader bin = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read));
        byte[] rb = bin.ReadBytes((int)bin.BaseStream.Length);
        bin.Close();
        int pos = 16, width = 0, height = 0;
        for (int i = 0; i < 4; i++) width = width * 256 + rb[pos++];
        for (int i = 0; i < 4; i++) height = height * 256 + rb[pos++];
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(rb);
        return texture;
    }

}
