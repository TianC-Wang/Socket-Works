#include <stdio.h>
#include <Windows.h>
#include <string>

#pragma comment(lib,"ws2_32.lib")

int funcSend(std::string,std::string,u_short,int);

int main(int argc,char ** args)
{
	funcSend(*(args+2),
			 *(args+1),
			 10101,
			 255);
	return 0;
}

int funcSend(std::string strData,std::string address,u_short port,int len)
{
	for(int i=0;i<strData.length();i+=255){
		WSADATA wsd;
		SOCKET s;

		if (WSAStartup(MAKEWORD(2, 2), &wsd))
		{
			//printf("WSAStartup failed!\n");
			return 1;
		}

		s = socket(AF_INET, SOCK_DGRAM, 0);

		if (s == INVALID_SOCKET)
		{
			//printf("socket failed,Error Code:%d\n", WSAGetLastError());
			WSACleanup();
			return 2;
		}

		//Start here
		SOCKADDR_IN addr;
		SOCKET sockClient = socket(AF_INET, SOCK_DGRAM, 0);

		addr.sin_family = AF_INET;
		addr.sin_addr.S_un.S_addr = inet_addr(address.c_str());
		addr.sin_port = htons(port);

		sendto(sockClient, strData.c_str()+i, len, 0, (sockaddr *)&addr, 50);
		closesocket(s);
		WSACleanup();

	}
	return 0;
}