#include "udp-header.h"
#include <malloc.h>
#include <string.h>
#include <stdio.h>
#include <time.h>

int main(int _Argc, char** _Argv) {
	time_t t;
	struct tm now;
	char* buffer = malloc(256);
	while(1) {
		memset(buffer, 0, 256);
		printf("Send: ");
		fgets(buffer, 255, stdin);
		putchar('\n');
		udp_send_str(buffer, inet_addr(_Argv[1]), 10101);
		memset(buffer, 0, 256);
		SOCKADDR_IN addr =
		udp_recv(buffer, 255, INADDR_ANY, 10102);
		time(&t);
		now = *localtime(&t);
		printf("Time:%02d:%02d:%02d,\nFrom:%s:%d\n%s\n", now.tm_hour, now.tm_min, now.tm_sec, inet_ntoa(addr.sin_addr), addr.sin_port, buffer);
	}
	free(buffer);
	return 0;
}