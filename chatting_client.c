#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#define BUF_SIZE 1024
void error_handling(char *message);
//echo_clint
int main(int argc, char* argv[])
{
	int sock;
	struct sockaddr_in serv_adr;
	char message[BUF_SIZE];
	int str_len, recv_len, recv_cnt;
	if (argc != 3)
	{
		printf("Usage:%s<port>\n", argv[0]);
		exit(1);
	}
	sock = socket(PF_INET, SOCK_STREAM, 0);
	if (sock == -1)
		error_handling("socket() error");

	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = inet_addr(argv[1]);
	serv_adr.sin_port = htons(atoi(argv[2]));
	if (connect(sock, (struct sockaddr*)&serv_adr, sizeof(serv_adr)) == -1)
		error_handling("connect() error");
	else
		puts("Connected.......");

	while (1)
	{
		fgets(message, sizeof(message), stdin);
		write(sock,message,sizeof(message));
		read(sock,message,sizeof(message));
		printf("server said : %s\n",message);
		

	
	}
	close(sock);
	return 0;
}
void error_handling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}

<<<<<<< HEAD

=======
>>>>>>> 3da043ea331381e75c282c38c3814e3cf8662354
