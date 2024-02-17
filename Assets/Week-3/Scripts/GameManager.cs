using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Battleship
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
            // Top left is 0,0
            { 1,1,0,0,1 },
            { 0,0,0,0,0 },
            { 0,0,1,0,1 },
            { 1,0,1,0,0 },
            { 1,0,1,0,1 }


            // Bottom right is 4,4
        };

        private bool[,] hits;

        // Total number of rows/columns 
        private int nRows;
        private int nCols;
        // Current row/column
        private int row;
        private int col;
        // Correctly hit ships
        private int score;
        // Total time game has been running
        private int time;

        // Parent of all cells
        [SerializeField] Transform gridRoot;
        // Template used to populate the grid
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scoreLabel;

        private void Awake()
        {
            // Initialize rows/columns to help with operations
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);
            // Create identical 2D array that is a bool instead of int
            hits = new bool[nRows, nCols];

            // Populate grid using a loop
            for (int i = 0; i < nRows * nCols; i++)
            {
                Instantiate(cellPrefab, gridRoot);
            }

            SelectCurrentCell();
            InvokeRepeating("IncrementTime", 1f, 1f);
        }
        Transform GetCurrentCell()
        {
            int index = (row * nCols) + col;
            return gridRoot.GetChild(index);
        }
        Transform GetTotalCells(int row, int col)
        {
            // Using local variables to get all of the cells rather than the current one 
            int index = (row * nCols) + col;
            return gridRoot.GetChild(index);
        }
        void SelectCurrentCell()
        {
            // Get current cell
            Transform cell = GetCurrentCell();
            // Set cursor "on"
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }
        void UnselectCurrentCell()
        {
            // Get current cell
            Transform cell = GetCurrentCell();
            // Set cursor "off"
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);
        }
        public void MoveHorizontal(int amt)
        {
            UnselectCurrentCell();
            col += amt;
            // Make sure the column stays within bounds of the grid
            col = Mathf.Clamp(col, 0, nCols - 1);
            SelectCurrentCell();
        }
        public void MoveVertical(int amt)
        {
            UnselectCurrentCell();
            row += amt;
            // Make sure the row stays within bounds of the grid
            row = Mathf.Clamp(row, 0, nRows - 1);
            SelectCurrentCell();
        }
        void ShowHit()
        {
            // Get current cell
            Transform cell = GetCurrentCell();
            //Set hit image "on"
            Transform hit = cell.Find("Hit");
            hit.gameObject.SetActive(true);
        }
        void ShowMiss()
        {
            // Get current cell
            Transform cell = GetCurrentCell();
            //Set miss image "on"
            Transform miss = cell.Find("Miss");
            miss.gameObject.SetActive(true);
        }
        void IncrementScore()
        {
            score++;
            scoreLabel.text = string.Format("Score: {0}", score);
        }
        void IncrementTime()
        {
            time++;
            // Update time label, displaying in the mm:ss format
            // ss should always have 2 digits
            // mm should only display as many digits as necessary
            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));
        }
        public void Fire()
        {
            // Checks if the hit data in the cell is true or false.
            // If it's true, don't do anything (because we already fired a shot here.)
            if (hits[row, col]) return;

            // Mark cell as being fired upon
            hits[row, col] = true;
            
            // If this cell is a ship
            if (grid[row,col] == 1)
            {
                ShowHit();
                IncrementScore();
            }
            // If the cell is open water
            else
            {
                ShowMiss();
            }

            TryEndGame();
        }

        public void Restart()
        {
            // Resets the game, randomizes ships, and turns off hit and miss images
            winLabel.SetActive(false);
            UnselectCurrentCell();
            col = 0;
            row = 0;
            SelectCurrentCell();
            time = 0;
            score = 0;
            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));
            scoreLabel.text = string.Format("Score: {0}", score);

            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    ResetCells(row, col);
                    hits[row, col] = false;
                }
            }

            RandomizeShips();
        }
        void ResetCells(int row, int col)
        {
            Transform cell = GetTotalCells(row, col);
            Transform hit = cell.Find("Hit");
            Transform miss = cell.Find("Miss");
            hit.gameObject.SetActive(false);
            miss.gameObject.SetActive(false);
        }
        void RandomizeShips()
        {
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    grid[row, col] = Random.Range(0, 11) > 5 ? 1 : 0;
                }
            }
        }

        void TryEndGame()
        {
            // Check every row
            for (int row = 0; row < nRows;  row++)
            {
                // Check every column
                for (int col = 0; col < nCols; col++)
                {
                    // If cell is not a ship, ignore
                    if (grid[row, col] == 0) continue;
                    // if a cell is a ship and hasn't been hit, return (we haven't finished the game)
                    if (hits[row, col] == false) return;
                }
            }

            // If the loop has been successfully completed, then show the win label!
            winLabel.SetActive(true);
            // Stop timer
            CancelInvoke("IncrementTime");
        }
    }
}
