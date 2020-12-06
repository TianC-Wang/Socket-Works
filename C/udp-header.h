#include <WinSock2.h>
#include <string.h>

#pragma comment(lib,"ws2_32.lib")

inline SOCKADDR_IN udp_recv(char* _Buffer, int _Length, unsigned long _Address, unsigned short _Port) {
	int len = sizeof(SOCKADDR);
	WSADATA wData;
	WSAStartup(MAKEWORD(2, 2), &wData);
	SOCKET sock = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	SOCKADDR_IN addr, addrRecv;
	addr.sin_family = AF_INET;
	addr.sin_addr.s_addr = _Address;
	addr.sin_port = htons(_Port);
	bind(sock, (SOCKADDR*)&addr, sizeof(addr));
	recvfrom(sock, _Buffer, _Length, 0, (SOCKADDR*)&addrRecv, &len);
	closesocket(sock);
	WSACleanup();
	return addrRecv;
}

inline void udp_send(const char* const _Buffer, int _Length, unsigned long _Address, unsigned short _Port) {
	WSADATA wData;
	WSAStartup(MAKEWORD(2, 2), &wData);
	SOCKET sock = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	SOCKADDR_IN addr;
	addr.sin_family = AF_INET;
	addr.sin_addr.s_addr = _Address;
	addr.sin_port = htons(_Port);
	sendto(sock, _Buffer, _Length, 0, (SOCKADDR*)&addr, sizeof(addr));
	closesocket(sock);
	WSACleanup();
}

inline void udp_send_str(const char* const _Buffer, unsigned long _Address, unsigned short _Port) {
	udp_send(_Buffer, strlen(_Buffer), _Address, _Port);
}