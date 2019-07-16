using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Kakera;
using System.Runtime.InteropServices;
using System;

<<<<<<< HEAD
#if UNITY_IPHONE

//ターゲットのイメージを管理するクラス
public class TargetManager : MonoBehaviour {
    /*
    // ファイルのあるパス（デバッグ用）
    const string linerImageTargetPath = "/Textures/liner_image.png";
    const string rawImageTargetPath = "/Textures/raw_image.png";
    */

    /*! OpenCVのプラグイン
     * 参考:
     * (1) http://nn-hokuson.hatenablog.com/entry/2017/05/12/201453 
     */
    [DllImport("OpenCVPlugin")]
    private static extern void LineDrawing(IntPtr img, int width, int height, int gaussian, int dilation, int threshold);
    private Color32[] pixels_;
    private GCHandle pixels_handle_;
    private IntPtr pixels_ptr_ = IntPtr.Zero;

    // イメージを適用するテクスチャ
    private Texture2D mainTexture;
    // イメージがないテクスチャ
    public Texture2D nullImageTexture;
    // イメージの表示に関わる変数
    public bool isLineDrawing;

    // 線画化のパラメータ
    private int gaussian, dilation, threshold;


    /* カメラロールから写真を選択する
     * 参考：
     * (1) https://blog.kakeragames.com/2016/11/21/unity-image-picker.html
     * (2) http://baba-s.hatenablog.com/entry/2017/12/31/211600
     */
    [SerializeField] private Unimgpicker imagePicker;
    [SerializeField] private MeshRenderer imageRenderer;
    [SerializeField] private Image imageView;
    private void Awake()
    {
        imagePicker.Completed += (string path) =>
        {
            StartCoroutine(LoadImage(path, imageRenderer, imageView));
        };
    }
    public void OnPressShowPicker()
    {
        imagePicker.Show("Select Image", "unimgpicker", 1024);
    }
    private IEnumerator LoadImage(string path, MeshRenderer output, Image image)
    {
        var url = "file://" + path;
        var www = new WWW(url);
        yield return www;

        var texture = www.texture;
        if (texture == null)
        {
            Debug.LogError("Failed to load texture url:" + url);
        }
        output.material.mainTexture = texture;
        mainTexture = (Texture2D)output.material.mainTexture;
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void setParametor(int g, int d, int t)
    {
        gaussian = g;
        dilation = d;
        threshold = t;
    }

    // イラストのテクスチャを適用したマテリアルを返すメソッド
    public Texture2D GetTargetImage()
    {
        if(mainTexture == null)
        {
            mainTexture = nullImageTexture;
            return nullImageTexture;
        }

        // マテリアルを返す
        return (isLineDrawing) ? ToLineDrawing(gaussian, dilation, threshold) : mainTexture;
    }

    public Sprite GetSprite()
    {
        Texture2D texture = GetTargetImage();
        int width = texture.width, height = texture.height;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, width, height), Vector2.zero);
        return sprite;
    }

    public Texture2D ToLineDrawing(int g, int d, int t)
    {
        // ピクセルデータを取り出す
        // mainTexture = (Texture2D)imageRenderer.material.mainTexture;
        mainTexture.filterMode = FilterMode.Point;
        pixels_ = mainTexture.GetPixels32();
        pixels_handle_ = GCHandle.Alloc(pixels_, GCHandleType.Pinned);
        pixels_ptr_ = pixels_handle_.AddrOfPinnedObject();

        int w = mainTexture.width;
        int h = mainTexture.height;

        // Native Pluginを呼び出す
        LineDrawing(pixels_ptr_, w, h, g, d, t);

        // ピクセルデータからテクスチャを作る
        Texture2D change_texture = new Texture2D(w, h, TextureFormat.RGBA32, false);
        change_texture.filterMode = FilterMode.Point;
        change_texture.SetPixels32(pixels_);
        change_texture.Apply();

        return change_texture;
=======
public class TargetManager : MonoBehaviour
{

    const string linerImageTargetPath = "/Textures/liner_image.png";
    const string rawImageTargetPath = "/Textures/raw_image.png";
    public GameObject imagePlate;
    private Material ImageMaterial;

    // Use this for initialization
    void Start()
    {
        GetTarget(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetTarget(bool isLiner)
    {
        // imageMaterialをimagePlateから取得する
        ImageMaterial = imagePlate.GetComponent<Renderer>().material;
        // PNG画像からテクスチャを作成する
        ImageMaterial.mainTexture = PngToTex2D(Application.streamingAssetsPath + (isLiner ? linerImageTargetPath : rawImageTargetPath));
        // テクスチャを適用する
        imagePlate.GetComponent<Renderer>().material = ImageMaterial;
>>>>>>> 4f418839d8c3d2c3aece6b3630a3e38d5d45e148
    }

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

#endif
