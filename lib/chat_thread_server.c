#include <stdio.h>
#include <pthread.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <signal.h>
#include <sys/wait.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#define BUF_SIZE 1024
#define MAX_CLNT 256
void* handle_clnt(void *arg);
void send_msg(char *msg, int len);
void error_handling(char *msg);
int clnt_cnt = 0;
char message[BUF_SIZE];
int clnt_socks[MAX_CLNT];

pthread_mutex_t mutx;
int main(int argc, char *argv[])
{
	 int serv_sock,clnt_sock;
	struct sockaddr_in serv_adr, clnt_adr;
	int clnt_adr_sz;
	pthread_t t_id;
	if (argc != 2) {
		printf("Usag : %s<port> \n", argv[0]);
		exit(1);
	}
	pthread_mutex_init(&mutx, NULL);
	serv_sock = socket(PF_INET, SOCK_STREAM, 0);

	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(atoi(argv[1]));

	if (bind(serv_sock, (struct sockaddr*) &serv_adr, sizeof(serv_adr)) == -1)
		error_handling("bind() error");

	if (listen(serv_sock, 10) == -1)
		error_handling("listen() error");
	while (1)
	{
		clnt_adr_sz = sizeof(clnt_adr);
		clnt_sock = accept(serv_sock, (struct sockaddr*)&clnt_adr, &clnt_adr_sz);

		pthread_mutex_lock(&mutx);
		clnt_socks[clnt_cnt++] = clnt_sock;
		pthread_mutex_unlock(&mutx);

		pthread_create(&t_id, NULL, handle_clnt, (void*)&clnt_sock);
		pthread_detach(t_id);
		printf("Conneted client IP:%s \n", inet_ntoa(clnt_adr.sin_addr));
	}
	close(serv_sock);
	return 0;
}

void * handle_clnt(void *arg)
{
	int clnt_sock = *((int*)arg);
	int str_len = 0, i;
	
	
	while((str_len=read(clnt_sock,message,sizeof(message)))!=0)
{
	send_msg(message,str_len);
printf("clnt said %s",message);
	}
	pthread_mutex_lock(&mutx);
	for (i = 0; i<clnt_cnt; i++)
	{

		if (clnt_sock == clnt_socks[i])
		{
			while (i++<clnt_cnt - 1)

				clnt_socks[i] = clnt_socks[i + 1];
			break;
		}
	}
	clnt_cnt--;
	pthread_mutex_unlock(&mutx);
	close(clnt_sock);
	return NULL;
}

void error_handling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}

void send_msg(char *message, int len)
{
int i;
pthread_mutex_lock(&mutx);
for(i=0;i<clnt_cnt;i++)
write(clnt_socks[i],message,len);
pthread_mutex_unlock(&mutx);
}
