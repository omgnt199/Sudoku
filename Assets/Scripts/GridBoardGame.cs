using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridBoardGame : MonoBehaviour
{
    private int width = 9;
    private int height = 9;
    public GameObject filltemp1x1;
    public GameObject filltemp3x3;
    private String difficulty;
    private int[][] grid;
    private Sudoku sk;
    private int[,] board;
    private int[,] board_result = new int[9,9];
    private Button easy_btn, medium_btn, hard_btn;
    // Start is called before the first frame update
    void Start()
    {
        easy_btn = GameObject.Find("Easy").GetComponent<Button>();
        medium_btn = GameObject.Find("Medium").GetComponent<Button>();
        hard_btn = GameObject.Find("Hard").GetComponent<Button>();
        easy_btn.onClick.AddListener(newGameEasy);
        medium_btn.onClick.AddListener(newGameMedium);
        hard_btn.onClick.AddListener(newGameHard);
        startGame();
    }
    // Update is called once per frame
    void Update()
    {
        Play();
    }

    void startGame()
    {

        for (int x = 2; x < width; x += 3)
        {
            for (int y = 2; y < height; y += 3)
            {
                Instantiate(filltemp3x3, new Vector3(x, y), Quaternion.identity);
            }
        }
        createBoard("Easy");


    }

    public void newGameEasy()
    {
        clearBoard();
        createBoard("Easy");
    }
    public void newGameMedium()
    {
        clearBoard();
        createBoard("Medium");
    }
    public void newGameHard()
    {
        clearBoard();
        createBoard("Hard");
    }

    void createBoard(String difficult)
    {
        int clues = 0;
        if (difficult.Equals("Easy")) clues = UnityEngine.Random.Range(37, 50);
        if (difficult.Equals("Medium")) clues = UnityEngine.Random.Range(27, 36);
        if (difficult.Equals("Hard")) clues = UnityEngine.Random.Range(18, 26);
        sk = new Sudoku(9, 81 - clues);
        sk.fillValues();
        copyMultipleArrays(sk.result, board_result, 9);
        for (int x = 1; x <= width; x++)
        {
            for (int y = 1; y <= height; y++)
            {
                GameObject tempfill;
                tempfill = Instantiate(filltemp1x1, new Vector3(x, y), Quaternion.identity);
                int num = sk.mat[x - 1, y - 1];
                if (num != 0)
                    tempfill.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = num.ToString();
                else tempfill.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = null;
            }
        }

    }
    bool checkObjectexist(int x, int y)
    {
        return Physics2D.Raycast(new Vector2(x, y), Vector2.right, 0.2f);
    }
    void clearBoard()
    {
        for(int x = 1; x <= width; x++)
        {
            for( int y = 1; y <= height; y++)
            {
                if(Physics2D.Raycast(new Vector2(x, y), Vector2.right, .5f)) 
                {
                    GameObject obj;
                    obj = Physics2D.Raycast(new Vector2(x, y), Vector2.right, .5f).collider.gameObject; 
                    Destroy(obj);
                }
            }
        }
    }

    void copyMultipleArrays(int[,] origin, int[,] des,int N)
    {
        for(int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                des[i, j] = origin[i, j];
            }
        }
    }

    void Play()
    {

    }

    bool isGameOver()
    {
        return true;
    }
}
