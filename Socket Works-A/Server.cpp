#include <iostream>
#include <iomanip>
#include <thread>
#include <WinSock2.h>
#pragma comment(lib, "WS2_32.lib")

int main(void) {

    // run wsa.

    WSADATA wData = { 0 };
    WSAStartup(MAKEWORD(2, 2), &wData);

    // message buffer.

    int nSize = sizeof(sockaddr);
    char* buffer = new char[256];

    // intro.

    std::cout << "Server End Executive Program:" << std::endl << std::endl;

    // apply socket.
    
    SOCKET sockSer = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);

    // fill address info.

    SOCKADDR_IN addrCli, addrSer = { 0 };
        addrSer.sin_family = AF_INET;
        addrSer.sin_port = htons(10101);
        // addrSer.sin_addr.s_addr = INADDR_ANY; // INADDR_ANY == 0

    // bind address info to socket.

    bind(sockSer, (sockaddr*)&addrSer, sizeof(addrSer));

    // recv client's message.

    // formation:
    // hh:mm
    // from: (xx)x.(xx)x.(xx)x.(xx)x :
    // [message]
    //
    // [wait for another message]

    while (true) {
        time_t t = 0;
        memset(buffer, 0, 256);
        recvfrom(sockSer, buffer, 255, 0, (sockaddr*)&addrCli, &nSize);
        time(&t);
        std::cout << std::setfill('0') << std::setw(2);
        std::cout << localtime(&t)->tm_hour << ":" << localtime(&t)->tm_min << std::endl;
        std::cout << "from: " << inet_ntoa(addrCli.sin_addr) << " :" << std::endl;
        std::cout << buffer << std::endl << std::endl;
    }

    // release memory.

    delete[] buffer;

    // release socket.

    closesocket(sockSer);

    // clear up wsa.

    WSACleanup();

    // exit with code 0.

    return 0;
}