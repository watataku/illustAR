using System.IO;
using UnityEngine;

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
