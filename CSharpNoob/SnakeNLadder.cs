using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	class SnakeNLadder
	{
		public int v
		{
			get; set;
		}
		public int dist
		{
			get; set;
		}

		public SnakeNLadder(int vertex, int distance)
		{
			v = vertex;
			dist = distance;
		}

		public static int GetMinDiceThrows(int[] board, int board_size)
		{

			bool[] visited = new bool[board_size];

			for (int i = 0; i < board_size; i++)
			{
				visited[i] = false;
			}

			visited[0] = true;
			Queue que = new Queue();
			SnakeNLadder queEntry = new SnakeNLadder(0, 0);
			que.Enqueue(queEntry);

			SnakeNLadder item = (SnakeNLadder)que.Peek();
			while (que.Count > 0)
			{
				item = (SnakeNLadder) que.Peek();
				int vertex = item.v;

				//Ending condition:  We're at the last piece;
				if (vertex == board_size - 1)
				{
					break;
				}

				que.Dequeue();
				/* 1 ~ 6 dice here, also cannot exceed board size for obvious reason
				*/
				for (int j = vertex +1; j <= (vertex + 6) && j < board_size; j++)
				{
					if (!visited[j])
					{
						SnakeNLadder entry = new SnakeNLadder(j, item.dist + 1);
						visited[j] = true;
						
						//if we ru n into a ladder or snake here...
						if (board[j] != -1)
						{
							entry.v = board[j];
						}
						que.Enqueue(entry);
                    }
				}
			}
			return item.dist;
		}

		public static void TestGame()
		{
			int board_size = 30;
			int[] board = new int[board_size];

			//initialize the game board
			for (int i = 0; i < board_size; i++)
			{
				board[i] = -1;
			}

			// Ladders
			board[2] = 21;
			board[4] = 7;
			board[10] = 25;
			board[19] = 28;

			// Snakes
			board[26] = 0;
			board[20] = 8;
			board[16] = 2;
			board[18] = 6;

			int minRolls = GetMinDiceThrows(board, board_size);

			System.Console.WriteLine("The minimum # of rolls to win this snake and ladder game is "
				+ minRolls + " rolls using a dice of 1-6");
		}

	}
}
