#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>
#define BUF_SIZE 1024
char message[BUF_SIZE];

pthread_mutex_t mutx;
void error_handling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
