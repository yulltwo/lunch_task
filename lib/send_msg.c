#include <stdio.h>
#include <pthread.h>
#include <stdlib.h>
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
void send_msg(char *message, int len)
{
int i;
pthread_mutex_lock(&mutx);
for(i=0;i<clnt_cnt;i++)
write(clnt_socks[i],message,len);
pthread_mutex_unlock(&mutx);
}
