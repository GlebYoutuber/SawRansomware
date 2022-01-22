// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <Windows.h>
#include <random>
#include <iostream>
#include <networkisolation.h>

HWND hwndwin;
HWND hwnd;
EXTERN_C
{
    _declspec(dllexport) int _cdecl SawRansomware_Payload() 
    {
        hwndwin = FindWindowA(NULL, "Saw Ransomware");
        GetFileAttributesA((LPCSTR)"SawRansomware.exe");
        InitNetworkAddressControl();
        if (GetCapture()) 
        {
            MessageBoxA(hwndwin, (LPCSTR)"Computer is detected", (LPCSTR)"Detected Computer", NULL);
        }
        return GetLastError();
        return 0;
    }
    _declspec(dllexport) int _cdecl DestroyWindows_SawRansomware() 
    {
        hwnd = FindWindowA(NULL, "Saw Ransomware");
        DestroyWindow(hwnd);
        return GetLastError();
        return 0;
    }
}



BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

