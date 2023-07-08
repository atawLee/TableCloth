﻿using System;
using System.Windows;
using System.Windows.Threading;
using TableCloth.Resources;

namespace TableCloth.Components
{
    /// <summary>
    /// Windows Presentation Foundation의 메시지 상자 표시 기능을 구현합니다.
    /// </summary>
    public sealed class AppMessageBox
    {
        /// <summary>
        /// 정보를 안내하는 메시지 상자를 띄웁니다.
        /// </summary>
        /// <param name="parentWindowHandle">메시지 상자가 속한 부모 창의 핸들</param>
        /// <param name="message">표시할 메시지</param>
        /// <param name="messageBoxButton">메시지 박스 버튼 구성</param>
        /// <returns>누른 버튼이 무엇인지 반환합니다.</returns>
        public MessageBoxResult DisplayInfo(object parentWindowHandle, string message, MessageBoxButton messageBoxButton = MessageBoxButton.OK)
        {
            var dispatcher = parentWindowHandle is Window window ? window?.Dispatcher : null;

            if (dispatcher == null)
                dispatcher = Dispatcher.CurrentDispatcher;

            return (MessageBoxResult)dispatcher.Invoke(
                new Func<object, string, MessageBoxResult>((parent, message) =>
                {
                    return parent is Window window
                        ? MessageBox.Show(
                            window, message, StringResources.TitleText_Info,
                            messageBoxButton, MessageBoxImage.Information, MessageBoxResult.OK)
                        : MessageBox.Show(
                            message, StringResources.TitleText_Info,
                            messageBoxButton, MessageBoxImage.Information, MessageBoxResult.OK);
                }),
                new object[] { parentWindowHandle, message, });
        }

        /// <summary>
        /// 오류를 안내하는 메시지 상자를 띄웁니다.
        /// </summary>
        /// <param name="parentWindowHandle">메시지 상자가 속한 부모 창의 핸들</param>
        /// <param name="failureReason">발생한 예외 개체의 참조</param>
        /// <param name="isCritical">심각성 여부</param>
        /// <returns>누른 버튼이 무엇인지 반환합니다.</returns>
        public MessageBoxResult DisplayError(object parentWindowHandle, Exception failureReason, bool isCritical)
        {
            var unwrappedException = failureReason;

            if (failureReason is AggregateException ae)
                unwrappedException = ae.InnerException;

            return DisplayError(parentWindowHandle, unwrappedException?.Message ?? StringResources.UnknownText, isCritical);
        }

        /// <summary>
        /// 오류를 안내하는 메시지 상자를 띄웁니다.
        /// </summary>
        /// <param name="parentWindowHandle">메시지 상자가 속한 부모 창의 핸들</param>
        /// <param name="message">표시할 메시지</param>
        /// <param name="isCritical">심각성 여부</param>
        /// <returns>누른 버튼이 무엇인지 반환합니다.</returns>
        public MessageBoxResult DisplayError(object parentWindowHandle, string message, bool isCritical)
        {
            var dispatcher = parentWindowHandle is Window window ? window?.Dispatcher : null;

            if (dispatcher == null)
                dispatcher = Dispatcher.CurrentDispatcher;

            return (MessageBoxResult)dispatcher.Invoke(
                new Func<object, string, bool, MessageBoxResult>((parent, message, isCritical) =>
                {
                    return parent is Window window
                        ? MessageBox.Show(
                            window, message,
                            isCritical ? StringResources.TitleText_Error : StringResources.TitleText_Warning,
                            MessageBoxButton.OK,
                            isCritical ? MessageBoxImage.Stop : MessageBoxImage.Warning, MessageBoxResult.OK)
                        : MessageBox.Show(
                            message,
                            isCritical ? StringResources.TitleText_Error : StringResources.TitleText_Warning,
                            MessageBoxButton.OK,
                            isCritical ? MessageBoxImage.Stop : MessageBoxImage.Warning, MessageBoxResult.OK);
                }),
                new object[] { parentWindowHandle, message, isCritical });
        }
    }
}