﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TableCloth.Resources
{
    // 공통 문자열들
    public static partial class StringResources
    {
        public static string AppName => CommonStrings.AppName;

        public static string AppCopyright => CommonStrings.AppCopyright;

        public static string AppPublisher => CommonStrings.AppPublisher;

        public static string AppCommentText => CommonStrings.AppCommentText;

        public static string AppNameForWixAndStore => CommonStrings.AppNameForWixAndStore;

        public static string AppPublisherForWixAndStore => CommonStrings.AppPublisherForWixAndStore;

        public static string AppCommentTextForWixAndStore => CommonStrings.AppCommentTextForWixAndStore;

        public static string AppContactForWixAndStore => CommonStrings.AppContactForWixAndStore;

        public static string AppInfoUrl => CommonStrings.AppInfoUrl;

        public static string PrivacyPolicyUrl => CommonStrings.PrivacyPolicyUrl;

        public static string IEModePolicyXmlUrl => CommonStrings.IEModePolicyXmlUrl;

        public static string AppUpdateInfoUrl => CommonStrings.AppUpdateInfoUrl;

        public static string CatalogUrl => CommonStrings.CatalogUrl;

        public static string ImageUrlPrefix => CommonStrings.ImageUrlPrefix;

        public static string SentryDsn => CommonStrings.SentryDsn;

        public static string UserAgentText => CommonStrings.UserAgentText;

        public static string EveryonesPrinterUrl => CommonStrings.UserAgentText;

        public static string AdobeReaderUrl => CommonStrings.AdobeReaderUrl;

        public static string HancomOfficeViewerUrl => CommonStrings.ImageUrlPrefix;

        public static string RaiDriveUrl => CommonStrings.ImageUrlPrefix;
    }
#pragma warning disable IDE0040, IDE0066

    // 공통 대화 상자 제목들
    partial class StringResources
    {
        public static readonly string TitleText_Info
            = $"{AppName} 정보";

        public static readonly string TitleText_Error
            = $"{AppName} 오류";

        public static readonly string TitleText_Warning
            = $"{AppName} 경고";

        public static readonly string TitleText_Question
            = $"{AppName} 확인";
    }

    // 공동 인증서 관련 문자열들
    partial class StringResources
    {
        public static readonly TimeSpan Cert_ExpireWindow = TimeSpan.FromDays(-3d);

        public static string Cert_Availability_MayTooEarly(DateTime now, DateTime notBefore)
            => $"{(int)Math.Truncate((notBefore - now).TotalDays)}일 후 사용 가능";

        public static string Cert_Availability_ExpireSoon(DateTime now, DateTime notAfter, TimeSpan expireWindow)
            => $"{(int)Math.Truncate((now - (notAfter - expireWindow)).TotalDays)}일 후 만료";

        public static readonly string Cert_Availability_Expired = "만료됨";

        public static readonly string Cert_Availability_Available = "사용 가능";

        public static string Error_Cert_MayTooEarly(DateTime now, DateTime notBefore)
            => $"선택하신 공동 인증서는 {(int)Math.Truncate((notBefore - now).TotalDays)}일 후부터 사용 가능합니다.";

        public static string Error_Cert_ExpireSoon(DateTime now, DateTime notAfter, TimeSpan expireWindow)
            => $"{(int)Math.Truncate((now - (notAfter - expireWindow)).TotalDays)}일 후에 만료됩니다. 새로운 공동 인증서로 교체가 필요합니다.";

        public static readonly string Error_Cert_Expired
            = $"선택하신 공동 인증서는 만료되었습니다. 다른 공동 인증서를 선택하거나, 새로운 공동 인증서로 교체 발급해야 합니다.";
    }

    // 상태 알림 문자열들
    partial class StringResources
    {
        public static readonly string Status_ParsingCommandLine = "명령줄 분석 중...";

        public static readonly string Status_InitSentrySDK = "Sentry SDK 초기화 중...";

        public static readonly string Status_LoadingPreferences = "환경 설정 불러오는 중...";

        public static readonly string Status_CheckInternetConnection = "인터넷 연결 상태 확인 중...";

        public static readonly string Status_EvaluatingRequirementsMet = "시스템 환경 확인 중...";

        public static readonly string Status_InitializingApplication = "애플리케이션 초기화 중...";

        public static readonly string Status_LoadingCatalog = "카탈로그 불러오는 중...";

        public static readonly string Status_LoadingImages = "이미지 불러오는 중...";

        public static readonly string Status_InitializingFailed = "오류가 발생했습니다.";

        public static readonly string Status_Done = "실행 준비가 완료되었습니다.";
    }

    // 비 사용자 인터페이스 문자열들
    partial class StringResources
    {
        public static readonly string UnknownText = "알 수 없음";
    }

    // 오류 메시지에 표시될 문자열들
    partial class StringResources
    {
        public static readonly string Info_Loading
            = "잠시만 기다려 주세요.";

        public static readonly string Info_UpdateRequired
            = "새 버전의 식탁보가 출시되었습니다.";

        public static readonly string Info_UpdateNotRequired
            = "최신 버전의 식탁보를 사용 중입니다.";

        public static readonly string Ask_RestartRequired =
            "설정이 반영되려면 식탁보 프로그램을 다시 시작해야 합니다." + Environment.NewLine +
            "지금 다시 시작하시겠습니까?";

        public static string Error_Unknown([CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
            => $"예기치 않은 오류가 발생했습니다. (파일: {file} (행: {line}), 멤버: {member})";

        public static string Info_Offline
            = "시스템이 인터넷과 연결되지 않은 것 같습니다. 모든 기능을 사용하려면 인터넷에 연결한 후 식탁보 프로그램을 다시 실행해 주세요.";

        public static readonly string Error_Already_TableCloth_Running
            = "이미 식탁보 프로그램이 실행되고 있어요.";

        public static readonly string Error_Hostess_Missing
            = "샌드박스 자동 설치 프로그램 파일을 찾을 수 없습니다. 프로그램을 다시 설치해주세요.";

        public static readonly string Error_Images_Missing
            = "기본 이미지와 아이콘 리소스 파일을 찾을 수 없습니다. 프로그램을 다시 설치해주세요.";

        public static readonly string Error_Windows_OS_Too_Old
            = "실행하고 있는 운영 체제는 윈도우 샌드박스 기능을 지원하지 않는 오래된 버전의 운영 체제 같습니다. 윈도우 10 이상으로 업그레이드 해주세요.";

        public static readonly string Error_Windows_Sandbox_Missing
            = "윈도우 샌드박스가 설치되어있지 않은 것 같습니다! 윈도우 기능 켜기/끄기에서 윈도우 샌드박스를 활성화해주세요.";

        public static readonly string Error_Windows_Dism_Missing
            = "DISM.exe 유틸리티를 찾을 수 없어 식탁보가 Windows 샌드박스 설치 대리 실행을 진행할 수 없습니다. 윈도우 기능 켜기/끄기에서 윈도우 샌드박스를 활성화하는 것을 시도해볼 수 있습니다.";

        public static readonly string Error_Restart_And_RunAgain
            = "윈도우 샌드박스를 설치한 후에는 시스템을 다시 시작해야 할 수 있습니다. 필요한 경우 시스템을 다시 시작하고, 식탁보를 다시 실행해주시기 바랍니다.";

        public static readonly string Error_HyperVisor_Missing
            = "시스템 가상화 기능 지원 여부를 확인할 수 없습니다. 윈도우 샌드박스가 정상적으로 실행되지 않을 가능성이 있습니다.";

        public static readonly string Error_OpenDerAndKey_Simultaneously =
            "공동 인증서 정보 파일 (der)과 공동 인증서 개인 키 파일 (key)을 각각 하나씩 선택해주세요." + Environment.NewLine +
            Environment.NewLine +
            "Ctrl 키나 Shift 키를 누른 채로 선택하거나, 파일 선택 창에서 빈 공간을 드래그하면 여러 파일을 선택할 수 있어요.";

        public static readonly string Error_Windows_Sandbox_Already_Running
            = "식탁보를 통해서 윈도우 샌드박스를 실행하고 있는 것 같습니다. 사용을 마친 후 윈도우 샌드박스를 먼저 종료해주세요.";

        public static readonly string Error_IEMode_NotAvailable
            = "Microsoft Edge 브라우저 안에서 인터넷 익스플로러 모드를 활성화해야 호환성 문제를 피할 수 있습니다. 인터넷 익스플로러를 시스템 구성 요소 추가/제거를 통해 활성화해주세요.";

        public static string Error_Cannot_Invoke_GetVersionEx(int errorCode)
            => $"윈도우 OS 버전 정보 조회 API를 호출했지만, 다음의 오류 코드와 함께 실패했습니다 - {errorCode:X8}";

        public static readonly string Error_Cannot_Invoke_GetProductInfo
            = "윈도우 OS 제품 정보 조회 API를 호출했지만, 정보를 가져올 수 없습니다.";

        public static readonly string Error_SandboxMightNotAvailable
            = "검색된 제품 정보에 따르면, 윈도우 샌드박스 기능이 지원되지 않는 버전의 운영 체제를 사용 중인 것 같습니다.";

        public static string Error_HostFolder_Unavailable(IEnumerable<string> unavailableDirectories)
        {
            var buffer = new StringBuilder();
            foreach (var eachUnavailableDirectory in unavailableDirectories)
                buffer.AppendLine(string.Format("- {0}", eachUnavailableDirectory));

            return "다음의 디렉터리를 이 컴퓨터에서 찾을 수 없어 샌드박스에서 연결할 때 제외합니다." + Environment.NewLine +
                Environment.NewLine + buffer.ToString();
        }

        public static readonly string Error_Windows_Explorer_Missing
            = "윈도우 탐색기 프로그램을 찾을 수 없습니다.";

        public static readonly string Error_Windows_Explorer_CanNotStart
            = "윈도우 탐색기 프로그램을 시작할 수 없습니다.";

        public static readonly string Error_Windows_Sandbox_CanNotStart
            = "샌드박스 프로그램을 실행하지 못했습니다.";

        public static readonly string Error_Cannot_Find_CertFile
            = "공동 인증서 정보 파일 (.der) 파일을 찾을 수 없습니다.";

        public static readonly string Error_Cannot_Find_KeyFile
            = "공동 인증서 개인 키 파일 (.key) 파일을 찾을 수 없습니다.";

        public static readonly string Error_Cannot_Find_PfxFile
            = "공동 인증서 파일 (.pfx 또는 .p12) 파일을 찾을 수 없습니다.";

        public static string Error_Cannot_Download_Catalog(Exception
#if !NETFX
            ?
#endif
            ex)
        {
            if (ex is AggregateException ae)
                return Error_Cannot_Download_Catalog(ae?.InnerException);

            var message = $"카탈로그 파일을 내려받지 못했습니다.";

            if (ex != null)
            {
                message = string.Concat(message, Environment.NewLine +
                    Environment.NewLine +
                    $"참고로, 발생했던 오류는 다음과 같습니다 - {ex.Message}");
            }

            return message;
        }

        public static string Error_Cannot_Create_AppDataDirectory(Exception
#if !NETFX
            ?
#endif
            ex)
        {
            if (ex is AggregateException ae)
                return Error_Cannot_Create_AppDataDirectory(ae?.InnerException);

            var message = $"애플리케이션 데이터 저장을 위한 디렉터리를 만들지 못했습니다.";

            if (ex != null)
            {
                message = string.Concat(message, Environment.NewLine
                    + Environment.NewLine
                    + $"참고로, 발생했던 오류는 다음과 같습니다 - {ex.Message}");
            }

            return message;
        }

        public static string Error_Cannot_Prepare_AppContents(Exception
#if !NETFX
            ?
#endif
            ex)
        {
            if (ex is AggregateException ae)
                return Error_Cannot_Create_AppDataDirectory(ae?.InnerException);

            var message = $"애플리케이션 콘텐츠 생성 작업을 진행하지 못했습니다.";

            if (ex != null)
            {
                message = string.Concat(message, Environment.NewLine
                    + Environment.NewLine
                    + $"참고로, 발생했던 오류는 다음과 같습니다 - {ex.Message}");
            }

            return message;
        }

        public static readonly string Error_Cannot_Run_SysInfo =
            "시스템 정보 유틸리티를 실행할 수 없습니다.";

        public static readonly string Error_ShortcutFailed =
            "바로 가기 생성에 실패했습니다.";

        public static readonly string Info_ShortcutSuccess =
            "바탕 화면에 바로 가기를 생성했습니다.";

        public static readonly string Info_CopyCommandLineSuccess =
            "자동화 작업 실행 시 사용할 수 있는 명령어를 클립보드에 복사했습니다.";

        public static readonly string Error_ShortcutNoSiteSelected =
            "선택된 웹 사이트가 없어 바로 가기를 생성할 수 없습니다.";

        public static readonly string Info_WillCreateSingleSiteShortcut =
            "바로 가기에 지정할 수 있는 최대 명령어 길이 제한으로 처음 선택한 사이트만 바로 가기로 만듭니다.";
    }

    // 스크립트 내에서 사용되는 문자열들
    partial class StringResources
    {
        public static readonly string Script_InstructionTitleText
            = "안내";

        public static string Script_InstructionMessage(int packageTotalCount, string siteNameList)
            => $"지금부터 {packageTotalCount}개 프로그램의 설치 과정이 시작됩니다. 모든 프로그램의 설치가 끝나면 자동으로 {siteNameList} 홈페이지가 열립니다.";
    }

    // 호스트 프로그램의 일반 메시지 문자열들
    partial class StringResources
    {
        public static readonly string Hostess_No_Targets
            = "이용하려는 웹 사이트 아이디가 지정되지 않았습니다. 샌드박스는 지금부터 사용하실 수 있어요.";

        public static readonly string Hostess_No_PowerShell_Error
            = "Windows PowerShell 실행 파일을 찾을 수 없어 설치 스크립트를 실행할 수 없습니다.";

        public static readonly string Hostess_CustomScript_Title
            = "별도 설치 스크립트";

        public static readonly string Hostess_Download_InProgress
            = "다운로드 중...";

        public static readonly string Hostess_Install_InProgress
            = "설치하는 중...";

        public static readonly string Hostess_Install_Succeed
            = "설치 완료";

        public static readonly string Hostess_Install_Failed
            = "설치 실패";

        public static readonly string Hostess_Warning_Title
            = "사이트 이용 시 주의 사항";
    }

    // 호스트 프로그램의 오류 메시지 문자열들
    partial class StringResources
    {
        public static readonly string HostessError_CatalogDeserilizationFailure
            = "Catalog.xml 파일의 형식이 프로그램이 이해하는 것과 다른 것 같습니다.";

        public static string HostessError_CatalogLoadFailure(Exception
#if !NETFX
            ?
#endif
            ex)
        {
            if (ex is AggregateException ae)
                return HostessError_CatalogLoadFailure(ae?.InnerException);

            var message = $"원격 웹 사이트로부터 Catalog.xml 파일을 불러올 수 없어 설치를 계속 진행할 수 없습니다.";

            if (ex != null)
            {
                message = string.Concat(message, Environment.NewLine +
                    Environment.NewLine +
                    $"참고로, 발생했던 오류는 다음과 같습니다 - {ex.Message}");
            }

            return message;
        }

        public static string HostessError_X509CertError(string certSubject, string errorCode)
        {
            return String.Format(
                "원격 웹 사이트와의 통신 도중 X509 인증서 오류가 발생했습니다. 인증서 주체는 {0}이며, 발생한 오류 코드는 {1} 입니다.",
                certSubject, errorCode);
        }

        public static string HostessError_PackageInstallFailure(string errorMessage)
            => $"패키지를 설치하는 도중 오류가 발생했습니다. {(string.IsNullOrWhiteSpace(errorMessage) ? "그러나 원인을 파악하지 못했습니다." : errorMessage)}";

        public static string HostessError_Package_CanNotStart
            = "패키지 설치 프로그램을 시작하지 못했습니다.";
    }

    // 호스트 프로그램에서 사용할 스위치
    partial class StringResources
    {
        public static readonly string TableCloth_Switch_Prefix = "--";

        public static readonly string TableCloth_Switch_IgnoreSwitch = "--ignore--";

        public static readonly string TableCloth_Switch_EnableMicrophone = TableCloth_Switch_Prefix + "enable-microphone";

        public static readonly string TableCloth_Switch_EnableCamera = TableCloth_Switch_Prefix + "enable-camera";

        public static readonly string TableCloth_Switch_EnablePrinter = TableCloth_Switch_Prefix + "enable-printer";

        public static readonly string Tablecloth_Switch_EnableCert = TableCloth_Switch_Prefix + "enable-cert";

        public static readonly string TableCloth_Switch_CertPublicKey = TableCloth_Switch_Prefix + "cert-public-key";

        public static readonly string TableCloth_Switch_CertPrivateKey = TableCloth_Switch_Prefix + "cert-private-key";

        public static readonly string TableCloth_Switch_InstallEveryonesPrinter = TableCloth_Switch_Prefix + "install-everyones-printer";

        public static readonly string TableCloth_Switch_InstallAdobeReader = TableCloth_Switch_Prefix + "install-adobe-reader";

        public static readonly string TableCloth_Switch_InstallHancomOfficeViewer = TableCloth_Switch_Prefix + "install-hancom-office-viewer";

        public static readonly string TableCloth_Switch_InstallRaiDrive = TableCloth_Switch_Prefix + "install-rai-drive";

        public static readonly string TableCloth_Switch_EnableIEMode = TableCloth_Switch_Prefix + "enable-ie-mode";

        public static readonly string TableCloth_Switch_DryRun = TableCloth_Switch_Prefix + "dry-run";

        public static readonly string TableCloth_Switch_Help = TableCloth_Switch_Prefix + "help";

        public static readonly string TableCloth_TableCloth_Switches_Help = $@"ServiceID ServiceID ... <옵션>

ServiceID는 {CatalogUrl}을 확인해주세요.

옵션:

{TableCloth_Switch_EnableMicrophone}
  오디오 입력 사용하기 기능을 켭니다.

{TableCloth_Switch_EnableCamera}
  비디오 입력 사용하기 기능을 켭니다.

{TableCloth_Switch_EnablePrinter}
  프린터 공유하기 기능을 켭니다.

{Tablecloth_Switch_EnableCert}
  인증서를 기능을 켭니다.

{TableCloth_Switch_CertPublicKey} <파일 경로>
  인증서 공개 키 파일 경로를 지정합니다.

{TableCloth_Switch_CertPrivateKey} <파일 경로>
  인증서 비밀 키 파일 경로를 지정합니다.

{TableCloth_Switch_InstallEveryonesPrinter}
  모두의 프린터 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_InstallAdobeReader}
  Adobe Reader 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_InstallHancomOfficeViewer}
  한컴오피스 뷰어 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_InstallRaiDrive}
  RaiDrive 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_EnableIEMode}
  Internet Explorer 모드를 활성화합니다.

{TableCloth_Switch_Help}
  이 도움말을 표시합니다.
";

        public static readonly string TableCloth_Hostess_Switches_Help = $@"ServiceID ServiceID ... <옵션>

ServiceID는 {CatalogUrl}을 확인해주세요.

옵션:

{TableCloth_Switch_InstallEveryonesPrinter}
  모두의 프린터 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_InstallAdobeReader}
  Adobe Reader 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_InstallHancomOfficeViewer}
  한컴오피스 뷰어 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_InstallRaiDrive}
  RaiDrive 설치를 샌드박스 시작 후 실행합니다.

{TableCloth_Switch_EnableIEMode}
  Internet Explorer 모드를 활성화합니다.

{TableCloth_Switch_DryRun}
  (개발자용 기능) 애플리케이션 패키지 설치, 시스템 설정 변경을 건너뛰고 프로그램의 실행 과정만 살펴봅니다.

{TableCloth_Switch_Help}
  이 도움말을 표시합니다.
";
    }

    // 로그 기록용 메시지 (로그를 데이터로 분석하는 경우를 고려하여 이 부분은 번역하지 않습니다.)
    partial class StringResources
    {
        public static string TableCloth_Log_WsbFileCreateFail_ProhibitTranslation(string wsbFilePath)
            => $"WSB file `{wsbFilePath}` was not created.";

        public static string TableCloth_Log_CannotParseWsbFile_ProhibitTranslation(string wsbFilePath)
            => $"Cannot parse WSB file `{wsbFilePath}`. The file content may corrupted or invalid.";

        public static string TableCloth_Log_HostFolderNotExists_ProhibitTranslation(string
#if !NETFX
            ?
#endif
            hostFolderPath)
            => $"The path `{hostFolderPath}` of the host folder listed in the WSB file does not exist on the host.";

        public static string TableCloth_Log_DirectoryEnumFail_ProhibitTranslation(string targetPath, Exception reason)
            => $"Directory enumeration failed - {targetPath} (Reason: {TableCloth_UnwrapException(reason)})";

        public static string TableCloth_UnwrapException(Exception
#if !NETFX
            ?
#endif
            failureReason)
        {
            var unwrappedException = failureReason;

            if (failureReason is AggregateException ae)
                unwrappedException = ae.InnerException;

            return unwrappedException?.Message ?? UnknownText;
        }
    }

    // 상수
    partial class StringResources
    {
        public const string DisplayName_Other = "기타";
        public const string DisplayName_Banking = "뱅킹";
        public const string DisplayName_Financing = "대출/금융";
        public const string DisplayName_Security = "증권/투자";
        public const string DisplayName_Insurance = "보험";
        public const string DisplayName_CreditCard = "신용 카드";
        public const string DisplayName_Government = "공공";
        public const string DisplayName_Education = "교육";
    }

#pragma warning restore IDE0040, IDE0066
}