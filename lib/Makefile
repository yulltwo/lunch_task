AR = ar
CC = gcc
CFLAGS = -g -Wall -I../include
OUTPUT = libfuncs.a
SRCS = handle_clnt.c error.c send_msg.c
OBJFILES = handle_clnt.o error.o send_msg.o
.PHONY : clean

$(OUTPUT) : $(OBJFILES)
	$(AR) rv $(OUTPUT) $(OBJFILES)

%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@ -lpthread

clean:
	rm -f $(OBJFILES) $(OUTPUT)
