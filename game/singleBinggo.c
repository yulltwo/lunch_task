#include <stdio.h>
#include <stdlib.h>
#include <time.h>


int print(int **p);
void game_start(int ans, int **p, int **p1, int *t);
void insert(int **p, int *p1);


main()
{

	int **ptr, **ptr2, *p_ptr;
	int ans;
	int i, flag, flag1;

	srand((unsigned)time(NULL));
	//Binggo No.1
	ptr = (int **)malloc(sizeof(int *) * 7);
	ptr[0] = (int *)malloc(sizeof(int) * 49);
	//Binggo No.2
	ptr2 = (int **)malloc(sizeof(int *) * 7);
	ptr2[0] = (int *)malloc(sizeof(int) * 49);

	// Not Same Number
	p_ptr = (int *)malloc(sizeof(int) * 25);

	// 2D array
	for (i = 0; i < 7; i++)
	{
		ptr[i] = ptr[0] + 7 * i;
		ptr2[i] = ptr2[0] + 7 * i;
	}

	// random number
	insert(ptr, p_ptr);
	insert(ptr2, p_ptr);

	do
	{

		for (i = 0; i <2; i++)
		{
			system("cls");
			printf("No.1 Binggo \n");
			flag = print(ptr);

			printf("\n\n");
			printf("No.2 Binggo\n");
			flag1 = print(ptr2);

			printf("\n");

			if (flag == 0 && flag1 == 0)
			{
				printf("No.%d, Choice Number :", i + 1);
				scanf("%d", &ans);
				fflush(stdin);
				if (ans < 1 || ans >25)
				{
					printf(" Inpput Number 1~25 \n");
					getchar();
					i--;
				}
				else
				{
					game_start(ans, ptr, ptr2, &i);
				}

			}
			else if (flag == 1)
			{
				printf("No.1 Win\n");
				exit(0);
			}
			else
			{
				printf("No.2 Win\n");
				exit(0);
			}


		}

	} while (1);
}


void game_start(int ans, int **p, int **p1, int *t)
{
	int i, j, cnt = 0;
	for (i = 1; i < 6; i++)
	{

		for (j = 1; j < 6; j++)
		{
			// ***
			if (ans == p[i][j])
			{
				p[i][j] = 42;
				// binggo count 
				p[6][j]++;
				p[i][6]++;
				if (i == j)
					p[6][0]++;
				if (i + j == 6)
					p[0][6]++;

				cnt++;
			}
			// *** 
			if (ans == p1[i][j])
			{
				p1[i][j] = 42;
				// binggo count 
				p1[6][j]++;
				p1[i][6]++;
				if (i == j)
					p1[6][0]++;
				if (i + j == 6)
					p1[0][6]++;
				cnt++;
			}
		}
	}
	if (cnt == 0)
	{
		printf("Do Reselect\n");
		--*t;
		getchar();
		return;
	}
}


//input Number 1~25 
void insert(int **p, int *p1)
{
	int i, j, r;


	for (i = 0; i < 25; i++)
	{
		p1[i] = 0;
	}

	for (i = 0; i < 49; i++)
		p[0][i] = 0;


	for (i = 1; i<6; i++)
	{
		for (j = 1; j < 6;)
		{
			r = rand() % 25;
			p[i][j] = r + 1;
			if (p1[r] < 1)
			{
				p1[r]++;
				j++;
			}
		}
	}
}

// print screen
int print(int **p)
{
	int i, j, k = 0;

	for (i = 1; i<6; i++)
	{
		for (j = 1; j < 6; j++)
		{
			if (p[i][j] == 42)
			{
				printf("[%2c] ", p[i][j]);
			}
			else
				printf("[%2d] ", p[i][j]);
		}
		printf("\n");
	}
	// Binggo Counter
	for (i = 0; i < 7; i++)
	{
		if (p[6][i] == 5)
			k++;
		if (p[i][6] == 5)
			k++;
	}

	printf("bingo count = %d ", k);

	if (k == 5)
	{
		printf("\nYou Win!!");
		return 1;
	}
	return 0;
}

