using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuPanel; // Tham chiếu đến panel của menu
    /*    public GameObject gameController; // Tham chiếu đến GameController hoặc đối tượng quản lý trò chơi*/
    public Button startButton; // Tham chiếu đến nút bắt đầu trong menu
    public static MainMenuController instance;
    public bool star {  get;  set; } 

    private void Awake()
    {
        instance = this;    
        
    }


    // Start is called before the first frame update
    void Start()
    {
        // Gắn sự kiện cho nút bắt đầu
       /* startButton.onClick.AddListener(StartGameOnClick);*/
    }

    // Hàm xử lý khi người dùng nhấp vào nút bắt đầu
    public void StartGameOnClick()
    {
        startButton.gameObject.SetActive(false);

        // Ẩn menu
        menuPanel.SetActive(false);
        star = true;

        // Kích hoạt trò chơi
   /*     gameController.SetActive(true);*/
    }
}
