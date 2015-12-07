#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<WinSock2.h>
#include<conio.h>
#include<string.h>
#pragma comment(lib,"wsock32.lib")

void main()
{
	SOCKET s;
	struct sockaddr_in sin;
	WSADATA wsaData;
	char ID[32];
	char buf[128];
	int tmp;
	int nTimeout = 200;
	char data[160];
	if (WSAStartup(WINSOCK_VERSION, &wsaData) != 0)
	{
		printf("WSAStartup error %d\n", WSAGetLastError());
		return;
	}

	s = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (s == INVALID_SOCKET)
	{
		printf("socket error %d\n", WSAGetLastError());
		WSACleanup();
		return;
	}

	sin.sin_family = AF_INET;
	sin.sin_addr.s_addr = inet_addr("192.168.0.12");
	sin.sin_port = htons(8887);

	puts("connecting server.....");

	if (connect(s, (struct sockaddr*)&sin, sizeof(sin)) != 0)
	{
		printf("connect error %d\n", WSAGetLastError());
		closesocket(s);
		WSACleanup();
		return;
	}
	puts("connected");
	tmp = sizeof(int);
	setsockopt(s, SOL_SOCKET, SO_RCVTIMEO, (char*)&nTimeout, tmp);
	printf("ID:");
	gets(ID);


	while (1)
	{
		memset(data, 0, sizeof(data));
		tmp = 0;
		if (_kbhit())
		{
			printf("%s : ", ID);
			gets(buf);
			if (strcmp(buf, "END") == 0)
			{
				send(s, "END", 3, 0);
				break;
			}
			sprintf(data, "%s : %s", ID, buf);
			tmp = send(s, data, strlen(data), 0);
			if (tmp < strlen(data))
			{
				printf("send error %d\n", WSAGetLastError());
				closesocket(s);
				WSACleanup();
				return;
			}
		}
		else
		{
			tmp = recv(s, data, sizeof(data), 0);
			if (tmp == 0 || WSAGetLastError() == WSAETIMEDOUT) continue;
			if (tmp == SOCKET_ERROR)
			{
				printf("recv error %d\n", WSAGetLastError());
				closesocket(s);
				WSACleanup();
				return;
			}
			printf("%s\n", data);
			if (strcmp(data, "END") == 0)break;
		}
	}
	closesocket(s);
	WSACleanup();
	return;
}
