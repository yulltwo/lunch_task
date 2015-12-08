CC = gcc
CFLAGS = -g -W -I../include
OUTPUT = lunch_task

$(OUTPUT): main.o
	$(CC) -o $(OUTPUT) $(CFLAGS) -L../lib main.o -lfuncs -lpthread

main.o: main.c
	$(CC) -o main.o $(CFLAGS) -c main.c -lpthread

clean :
	rm *.o $(OUTPUT)
