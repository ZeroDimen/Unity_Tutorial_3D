using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Portal_Pad : MonoBehaviour
{
    private string inputNum;
    public TextMeshProUGUI tpString;

    [SerializeField] private RawImage cctvImage;

    [SerializeField] private Button[] numPad;
    [SerializeField] private GameObject[] Zone_Number;

    private bool isWarp;
    private Camera camera;
    public Transform Player; // 개선 해야할지도
    public static string Zone_name;
    private int currentZone;

    public void Start()
    {
        
        Get_Zone_Number();
        Get_CCTV(currentZone);
        Init();

    }

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        inputNum = "";
        isWarp = false;
        tpString.text = $"Teleport \n Zone {currentZone} -> Zone ";
    }


    private void Get_Zone_Number()
    {
        string str_Zone = Zone_name.Replace("Zone_", "");
        currentZone = int.Parse(str_Zone);
        bool result = int.TryParse(str_Zone, out currentZone);
        if (result == false)
        {
            Debug.Log($"Portal_Pad Err : input {Zone_name}");
        }
    }

    private void Get_CCTV(int Zone_Num, bool isWarp = false)
    {
        if (Zone_Num <= Zone_Number.Length)
        {
            camera = Zone_Number[Zone_Num -1].GetComponentInChildren<Camera>();
            if (isWarp)
            {
                Player.position = camera.transform.position;
            }
            else
            {
                cctvImage.texture = camera.targetTexture;
            }
        }
        else
        {
            Debug.Log("Zone Number out of range"); // 해결 해야할지도
        }
    }


    private void TouchnumPad(string numString) // numPad에서 버튼 입력시 호출 되는 함수
    {
        if (numString == "Enter") // Enter 버튼 입력시
        {
            if (inputNum != "")
            {
                Get_CCTV(int.Parse(inputNum), isWarp);
                Lock_numPad(true);
            }
            

        }
        else if (numString == "Delete") // Delete 버튼 입력시
        {
            inputNum = "";
            Get_CCTV(currentZone);
            Lock_numPad(false);
        }
        else
        {
            inputNum += numString;
            if (inputNum == "0")
            {
                inputNum = "";
            }
        }
        tpString.text = $"Teleport \n Zone {currentZone} -> Zone {inputNum}";
    }

    private void Lock_numPad(bool isLock)
    {
        isWarp = isLock;
        
        foreach (var button in numPad)
        {
            button.interactable = !isLock;
        }
    }
}

