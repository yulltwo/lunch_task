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
int clnt_cnt = 0;
char message[BUF_SIZE];
int clnt_socks[MAX_CLNT];

pthread_mutex_t mutx;
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
