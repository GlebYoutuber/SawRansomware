#include <Windows.h>
#include <debugapi.h>

typedef long (WINAPI* RtlSetProcessIsCritical) (
	IN BOOLEAN    bNew,
	OUT BOOLEAN* pbOld,
	IN BOOLEAN    bNeedScb);

int main() 
{
	HANDLE ntdll = LoadLibrary((LPCWSTR)"ntdll.dll");
	RtlSetProcessIsCritical SetCriticalProcess;
	LoadLibraryA("ntdll.dll");
	SetCriticalProcess = (RtlSetProcessIsCritical)
    GetProcAddress((HINSTANCE)ntdll, "RtlSetProcessIsCritical");
}
