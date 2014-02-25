// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamGameServerUtils {
		// return the number of seconds since the user
		public static uint GetSecondsSinceAppActive() {
			return NativeMethods.ISteamGameServerUtils_GetSecondsSinceAppActive();
		}

		public static uint GetSecondsSinceComputerActive() {
			return NativeMethods.ISteamGameServerUtils_GetSecondsSinceComputerActive();
		}

		// the universe this client is connecting to
		public static EUniverse GetConnectedUniverse() {
			return NativeMethods.ISteamGameServerUtils_GetConnectedUniverse();
		}

		// Steam server time - in PST, number of seconds since January 1, 1970 (i.e unix time)
		public static uint GetServerRealTime() {
			return NativeMethods.ISteamGameServerUtils_GetServerRealTime();
		}

		// returns the 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)
		// e.g "US" or "UK".
		public static string GetIPCountry() {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamGameServerUtils_GetIPCountry());
		}

		// returns true if the image exists, and valid sizes were filled out
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight) {
			return NativeMethods.ISteamGameServerUtils_GetImageSize(iImage, out pnWidth, out pnHeight);
		}

		// returns true if the image exists, and the buffer was successfully filled out
		// results are returned in RGBA format
		// the destination buffer size should be 4 * height * width * sizeof(char)
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize) {
			return NativeMethods.ISteamGameServerUtils_GetImageRGBA(iImage, pubDest, nDestBufferSize);
		}

		// returns the IP of the reporting server for valve - currently only used in Source engine games
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort) {
			return NativeMethods.ISteamGameServerUtils_GetCSERIPPort(out unIP, out usPort);
		}

		// return the amount of battery power left in the current system in % [0..100], 255 for being on AC power
		public static byte GetCurrentBatteryPower() {
			return NativeMethods.ISteamGameServerUtils_GetCurrentBatteryPower();
		}

		// returns the appID of the current process
		public static uint GetAppID() {
			return NativeMethods.ISteamGameServerUtils_GetAppID();
		}

		// Sets the position where the overlay instance for the currently calling game should show notifications.
		// This position is per-game and if this function is called from outside of a game context it will do nothing.
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition) {
			NativeMethods.ISteamGameServerUtils_SetOverlayNotificationPosition(eNotificationPosition);
		}

		// API asynchronous call results
		// can be used directly, but more commonly used via the callback dispatch API (see steam_api.h)
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed) {
			return NativeMethods.ISteamGameServerUtils_IsAPICallCompleted(hSteamAPICall, out pbFailed);
		}

		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall) {
			return NativeMethods.ISteamGameServerUtils_GetAPICallFailureReason(hSteamAPICall);
		}

		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed) {
			return NativeMethods.ISteamGameServerUtils_GetAPICallResult(hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		// this needs to be called every frame to process matchmaking results
		// redundant if you're already calling SteamAPI_RunCallbacks()
		public static void RunFrame() {
			NativeMethods.ISteamGameServerUtils_RunFrame();
		}

		// returns the number of IPC calls made since the last time this function was called
		// Used for perf debugging so you can understand how many IPC calls your game makes per frame
		// Every IPC call is at minimum a thread context switch if not a process one so you want to rate
		// control how often you do them.
		public static uint GetIPCCallCount() {
			return NativeMethods.ISteamGameServerUtils_GetIPCCallCount();
		}

		// API warning handling
		// 'int' is the severity; 0 for msg, 1 for warning
		// 'const char *' is the text of the message
		// callbacks will occur directly after the API function is called that generated the warning or message
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) {
			NativeMethods.ISteamGameServerUtils_SetWarningMessageHook(pFunction);
		}

		// Returns true if the overlay is running & the user can access it. The overlay process could take a few seconds to
		// start & hook the game process, so this function will initially return false while the overlay is loading.
		public static bool IsOverlayEnabled() {
			return NativeMethods.ISteamGameServerUtils_IsOverlayEnabled();
		}

		// Normally this call is unneeded if your game has a constantly running frame loop that calls the
		// D3D Present API, or OGL SwapBuffers API every frame.
		//
		// However, if you have a game that only refreshes the screen on an event driven basis then that can break
		// the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also
		// need to Present() to the screen any time an even needing a notification happens or when the overlay is
		// brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present
		// in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you
		// refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.
		public static bool BOverlayNeedsPresent() {
			return NativeMethods.ISteamGameServerUtils_BOverlayNeedsPresent();
		}
#if ! _PS3
		// Asynchronous call to check if an executable file has been signed using the public key set on the signing tab
		// of the partner site, for example to refuse to load modified executable files.
		// The result is returned in CheckFileSignature_t.
		//   k_ECheckFileSignatureNoSignaturesFoundForThisApp - This app has not been configured on the signing tab of the partner site to enable this function.
		//   k_ECheckFileSignatureNoSignaturesFoundForThisFile - This file is not listed on the signing tab for the partner site.
		//   k_ECheckFileSignatureFileNotFound - The file does not exist on disk.
		//   k_ECheckFileSignatureInvalidSignature - The file exists, and the signing tab has been set for this file, but the file is either not signed or the signature does not match.
		//   k_ECheckFileSignatureValidSignature - The file is signed and the signature is valid.
		public static SteamAPICall_t CheckFileSignature(string szFileName) {
			return (SteamAPICall_t)NativeMethods.ISteamGameServerUtils_CheckFileSignature(new InteropHelp.UTF8String(szFileName));
		}
#endif
#if _PS3
		public static void PostPS3SysutilCallback(ulong status, ulong param, IntPtr userdata) {
			NativeMethods.ISteamGameServerUtils_PostPS3SysutilCallback(status, param, userdata);
		}

		public static bool BIsReadyToShutdown() {
			return NativeMethods.ISteamGameServerUtils_BIsReadyToShutdown();
		}

		public static bool BIsPSNOnline() {
			return NativeMethods.ISteamGameServerUtils_BIsPSNOnline();
		}

		// Call this with localized strings for the language the game is running in, otherwise default english
		// strings will be used by Steam.
		public static void SetPSNGameBootInviteStrings(string pchSubject, string pchBody) {
			NativeMethods.ISteamGameServerUtils_SetPSNGameBootInviteStrings(new InteropHelp.UTF8String(pchSubject), new InteropHelp.UTF8String(pchBody));
		}
#endif
		// Activates the Big Picture text input dialog which only supports gamepad input
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax) {
			return NativeMethods.ISteamGameServerUtils_ShowGamepadTextInput(eInputMode, eLineInputMode, new InteropHelp.UTF8String(pchDescription), unCharMax);
		}

		// Returns previously entered text & length
		public static uint GetEnteredGamepadTextLength() {
			return NativeMethods.ISteamGameServerUtils_GetEnteredGamepadTextLength();
		}

		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText) {
			IntPtr pchText2 = Marshal.AllocHGlobal((int)cchText);
			bool ret = NativeMethods.ISteamUtils_GetEnteredGamepadTextInput(pchText2, cchText);
			pchText = ret ? InteropHelp.PtrToStringUTF8(pchText2) : null;
			Marshal.FreeHGlobal(pchText2);
			return ret;
		}

		// returns the language the steam client is running in, you probably want ISteamApps::GetCurrentGameLanguage instead, this is for very special usage cases
		public static string GetSteamUILanguage() {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamGameServerUtils_GetSteamUILanguage());
		}

		// returns true if Steam itself is running in VR mode
		public static bool IsSteamRunningInVR() {
			return NativeMethods.ISteamGameServerUtils_IsSteamRunningInVR();
		}
	}
}