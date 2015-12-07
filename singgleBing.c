#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <windows.h>

#define MAX 5
#define WHITE 15
#define YELLOW 14


int main(void) {

	int Player[MAX][MAX];
	int Com[MAX][MAX];
	int playerChk, comChk;
	int Num;

	InitCount(Player, Com);

	MixMAP(Player);

	while (1) {
		gotoxy(0, 0);

		// 컴퓨터들 출력
		textcolor(WHITE);
		printf(" ====== Player ====== \n");
		printMAP(Player);
		textcolor(WHITE);
		printf(" ===== Computer ===== \n");
		printMAP(Com);

		textcolor(WHITE);
		printf(" > ");
		scanf("%d", &Num);

		if (SearchMAP(Player, Num) == 0) {
			printf("잘못입력하셨습니다. \n");
			system("pause");
			system("cls");
			continue;
		}

		SearchMAP(Com, Num);

	
		while (1) {
			Num = baserand(1, MAX*MAX);
			if (SearchMAP(Com, Num) == 1) {
				SearchMAP(Player, Num);
				break;
			}
		}

		playerChk = CheckMAP(Player);
		comChk = CheckMAP(Com);

		printf("Player Check = %d \n", playerChk);
		printf("Com Check = %d \n", comChk);

		if (playerChk >= MAX && comChk >= MAX) {
			if (playerChk > comChk) {
				Winner(0, Player, Com);
			}
			else if (playerChk < comChk) {
				Winner(1, Player, Com);
			}
			else {
				Winner(2, Player, Com);
			}
		}
		else  if (playerChk >= MAX) {
			Winner(0, Player, Com);
		}
		else  if (comChk >= MAX) {
			Winner(1, Player, Com);
		}

		system("pause");
		system("cls");
	}
	return 0;
}
