#include "udp-header.h"
#include <malloc.h>
#include <string.h>
#include <stdio.h>
#include <time.h>

int main(void) {
	time_t t;
	struct tm now;
	char* buffer = malloc(256);
	while(1) {
		memset(buffer, 0, 256);
		SOCKADDR_IN addr =
		udp_recv(buffer, 255, INADDR_ANY, 10101);
		time(&t);
		now = *localtime(&t);
		printf("Time:%02d:%02d:%02d,\nFrom:%s:%d\n%s\nSend: ", now.tm_hour, now.tm_min, now.tm_sec, inet_ntoa(addr.sin_addr), addr.sin_port, buffer);
		memset(buffer, 0, 256);
		fgets(buffer, 255, stdin);
		putchar('\n');
		udp_send_str(buffer, addr.sin_addr.s_addr, 10102);
	}
	free(buffer);
	return 0;
}