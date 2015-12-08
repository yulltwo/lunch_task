#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <signal.h>
#include <sys/wait.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#define BUF_SIZE 1024
void error_handling(char *message);


int main(int argc, char* argv[])
{
	int serv_sock, clnt_sock;
	struct sockaddr_in serv_adr, clnt_adr;
	int select_;
	int maxfd;
	int n;
	fd_set reads;
	pid_t pid;
	struct sigaction act;
	socklen_t adr_sz;
	int str_len, state;
	char message[BUF_SIZE];
	char message_s[BUF_SIZE];
	if (argc != 2){
		printf("Usage : %s <port> \n", argv[0]);
		exit(1);
	}
	
	serv_sock = socket(PF_INET, SOCK_STREAM, 0);

	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(atoi(argv[1]));

	if (bind(serv_sock, (struct sockaddr*) &serv_adr, sizeof(serv_adr)) == -1)
		error_handling("bind() error");

	if (listen(serv_sock, 5) == -1)
		error_handling("listen() error");
	while (1)
	{
		adr_sz = sizeof(clnt_adr);
		clnt_sock = accept(serv_sock, (struct sockaddr*)&clnt_adr, &adr_sz);		
		pid = fork();
		if (pid <0)
		{
		printf("can not fork");
			
			return -1;
		}
		else if (pid == 0)
		{
			while (1)
			{
				memset(message,0,sizeof(message));
				memset(message_s,0,sizeof(message_s));
				maxfd = clnt_sock + 1;
				FD_ZERO(&reads);
				FD_SET(0, &reads);
				FD_SET(clnt_sock, &reads);
				select_ = select(maxfd, &reads, NULL, NULL, NULL);

				if (select_ < 0)
				{
					error_handling("select() error");
					exit(-1);
				}
				if (FD_ISSET(clnt_sock, &reads))
				{
					n = read(clnt_sock,message_s, sizeof(message_s));
					if (n != 0)
					{
						message_s[n] = '\0';
						printf("receive : %s",message_s);
						
					}
				}
				if (FD_ISSET(0, &reads))
				{
					n = read(0, message, BUF_SIZE);
					if (n>0)
					{
						if (write(clnt_sock, message, n) != n)
							error_handling("fail in sending");
						
					}
				}
				

			}
		}
		else
{
printf("1");
			close(clnt_sock);
}
	}
printf("2");
	close(serv_sock);
	return 0;
}

void error_handling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}



