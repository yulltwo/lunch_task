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
	// 1번 빙고판을 위한 동적 할당...
	ptr = (int **)malloc(sizeof(int *) * 7);
	ptr[0] = (int *)malloc(sizeof(int) * 49);
	// 2번 빙고판을 위한 동적할당..
	ptr2 = (int **)malloc(sizeof(int *) * 7);
	ptr2[0] = (int *)malloc(sizeof(int) * 49);

	// 같은 수를 입력 하지 않기 위한 동적할당..
	p_ptr = (int *)malloc(sizeof(int) * 25);

	// 빙고판용 동적할당을 2차원 배열로 바꾸기...
	for (i = 0; i < 7; i++)
	{
		ptr[i] = ptr[0] + 7 * i;
		ptr2[i] = ptr2[0] + 7 * i;
	}

	// 랜덤하게 숫자 넣기...
	insert(ptr, p_ptr);
	insert(ptr2, p_ptr);

	do
	{

		for (i = 0; i <2; i++)
		{
			system("cls");
			printf("1번 빙고판 \n");
			flag = print(ptr);

			printf("\n\n");
			printf("2번 빙고판 \n");
			flag1 = print(ptr2);

			printf("\n");

			if (flag == 0 && flag1 == 0)
			{
				printf("야 %d번 너 몇번 할래? :", i + 1);
				scanf("%d", &ans);
				fflush(stdin);
				if (ans < 1 || ans >25)
				{
					printf(" 입력 범위는 1부터 25까지입니다. \n");
					printf(" 아무키나 누르면 다시 입력할수 있습니다. ");
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
				printf("1번이 이겼네... 추카해...\n");
				exit(0);
			}
			else
			{
				printf("2번이 이겼네... 추카해...\n");
				exit(0);
			}


		}

	} while (1);
}

//숫자 입력 해서 배열값 바꾸는 함수. 
void game_start(int ans, int **p, int **p1, int *t)
{
	int i, j, cnt = 0;
	for (i = 1; i < 6; i++)
	{

		for (j = 1; j < 6; j++)
		{
			// 입력한 값을 별표로 수정... 
			if (ans == p[i][j])
			{
				p[i][j] = 42;
				// 각 라인에 별개수 증가. 
				p[6][j]++;
				p[i][6]++;
				if (i == j)
					p[6][0]++;
				if (i + j == 6)
					p[0][6]++;

				cnt++;
			}
			// 입력한 값을 별표로 수정. 
			if (ans == p1[i][j])
			{
				p1[i][j] = 42;
				//각 라인에 별개수 증가. 
				p1[6][j]++;
				p1[i][6]++;
				// 오른쪽 대각선.. 
				if (i == j)
					p1[6][0]++;

				// 왼쪽 대각선. 
				if (i + j == 6)
					p1[0][6]++;
				cnt++;
			}
		}
	}
	if (cnt == 0)
	{
		printf("이미 지운 수야...--;;\n");
		printf("다시 선택해...--;;\n");
		--*t;
		getchar();
		return;
	}
}


//1부터 25까지의 수를 집어넣는 함수. 
void insert(int **p, int *p1)
{
	int i, j, r;

	// 플래그 함수 초기화....
	for (i = 0; i < 25; i++)
	{
		p1[i] = 0;
	}
	// 배열 초기화.. 별 개수 세기 위해서..
	for (i = 0; i < 49; i++)
		p[0][i] = 0;

	// 숫자 넣기...
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

//화면에 출력 하는 함수. 
int print(int **p)
{
	int i, j, k = 0;

	// 만약 프로그램 돌아가는 것을 보고 싶으면 아래꺼의 주석 처리를 제거하시오...
	/*
	for ( i = 0 ; i < 49; i++)
	{
	printf("[ %2d ] ", p[0][i]);
	if ( (i+1)%7 == 0 )
	printf("\n");
	}
	*/
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
	// 빙고 개수를 세기 위한 거...
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
		printf("\n당신이 이겼어...");
		return 1;
	}
	return 0;
}
