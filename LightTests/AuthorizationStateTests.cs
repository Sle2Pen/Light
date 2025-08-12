using Light.LightAuthorizationStateUpdatesDispatcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightTests
{
    /// <summary>
    /// мб добавить валидацию в vo
    /// </summary>
    [TestClass]
    public class AuthorizationStateTests
    {
        #region Static constructors
        [TestMethod]
        public void Empty_Nothing_StateTypeIsEmpty()
        {
            var authorizationState = AuthorizationState.Empty();

            Assert.AreEqual(AuthorizationStateType.Empty, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitStartupParameters_Nothing_StateTypeIsWaitStartupParameters()
        {
            var authorizationState = AuthorizationState.WaitStartupParameters();

            Assert.AreEqual(AuthorizationStateType.WaitStartupParameters, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitPhoneNumber_Nothing_StateTypeIsWaitPhoneNumber()
        {
            var authorizationState = AuthorizationState.WaitPhoneNumber();

            Assert.AreEqual(AuthorizationStateType.WaitPhoneNumber, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitTelegramMessageCode_CodeTypeCodeLengthPhoneNumber_WaitCode()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;

            var authorizationState = AuthorizationState.WaitTelegramMessageCode(phoneNumber, codeLength);

            Assert.AreEqual(AuthorizationStateType.WaitCode, authorizationState.StateType);
            Assert.IsNotNull(authorizationState.PhoneNumber);
            Assert.AreEqual(phoneNumber, authorizationState.PhoneNumber);
            Assert.AreEqual(codeLength, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.TelegramMessage, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitSmsCode_CodeTypeCodeLengthPhoneNumber_WaitCode()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;

            var authorizationState = AuthorizationState.WaitSmsCode(phoneNumber, codeLength);

            Assert.AreEqual(AuthorizationStateType.WaitCode, authorizationState.StateType);
            Assert.IsNotNull(authorizationState.PhoneNumber);
            Assert.AreEqual(phoneNumber, authorizationState.PhoneNumber);
            Assert.AreEqual(codeLength, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Sms, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitCallCode_CodeTypeCodeLengthPhoneNumber_WaitCode()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;

            var authorizationState = AuthorizationState.WaitCallCode(phoneNumber, codeLength);

            Assert.AreEqual(AuthorizationStateType.WaitCode, authorizationState.StateType);
            Assert.IsNotNull(authorizationState.PhoneNumber);
            Assert.AreEqual(phoneNumber, authorizationState.PhoneNumber);
            Assert.AreEqual(codeLength, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Call, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitFlashCall_CodeTypeCallerPhoneNumberPatternPhoneNumber_WaitCode()
        {
            string phoneNumber = "Hello world";
            string callerPhoneNumberPattern = "another Hello world";

            var authorizationState = AuthorizationState.WaitFlashCall(phoneNumber, callerPhoneNumberPattern);

            Assert.AreEqual(AuthorizationStateType.WaitCode, authorizationState.StateType);
            Assert.IsNotNull(authorizationState.PhoneNumber);
            Assert.AreEqual(phoneNumber, authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.FlashCall, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNotNull(authorizationState.CallerPhoneNumberPattern);
            Assert.AreEqual(callerPhoneNumberPattern, authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void WaitMissedCall_CodeTypeCallerPhoneNumberPatternPhoneNumber_WaitCode()
        {
            string phoneNumber = "Hello world";
            string callerPhoneNumberPrefix = "prefix hello world!";
            int codeLength = 16;

            var authorizationState = AuthorizationState.WaitMissedCall(phoneNumber, callerPhoneNumberPrefix, codeLength);

            Assert.AreEqual(AuthorizationStateType.WaitCode, authorizationState.StateType);
            Assert.IsNotNull(authorizationState.PhoneNumber);
            Assert.AreEqual(phoneNumber, authorizationState.PhoneNumber);
            Assert.AreEqual(codeLength, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.MissedCall, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
            Assert.IsNotNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.AreEqual(callerPhoneNumberPrefix, authorizationState.CallerPhoneNumberPrefix);
        }

        [TestMethod]
        public void WaitPassword_HasPassportDataHasRecoveryEmailAddressRecoveryEmailAddressPatternPasswordHint_WaitPassword()
        {
            bool hasPassportData = true;
            bool hasRecoveryEmailAddress = true;
            string recoveryEmailAddressPattern = "Hello email";
            string passwordHint = "This is test password hint";

            var authorizationState = AuthorizationState.WaitPassword(hasPassportData, hasRecoveryEmailAddress, recoveryEmailAddressPattern, passwordHint);

            Assert.AreEqual(AuthorizationStateType.WaitPassword, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsNotNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsNotNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);

            Assert.IsTrue(authorizationState.HasRecoveryEmailAddress);
            Assert.IsTrue(authorizationState.HasPassportData);
            Assert.AreEqual(recoveryEmailAddressPattern, authorizationState.RecoveryEmailAddressPattern);
            Assert.AreEqual(passwordHint, authorizationState.PasswordHint);
        }

        [TestMethod]
        public void Ready_None_Ready()
        {
            var authorizationState = AuthorizationState.Ready();

            Assert.AreEqual(AuthorizationStateType.Ready, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void Closing_None_Closing()
        {
            var authorizationState = AuthorizationState.Closing();

            Assert.AreEqual(AuthorizationStateType.Closing, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }

        [TestMethod]
        public void Closed_None_Closed()
        {
            var authorizationState = AuthorizationState.Closed();

            Assert.AreEqual(AuthorizationStateType.Closed, authorizationState.StateType);
            Assert.IsNull(authorizationState.PhoneNumber);
            Assert.AreEqual(0, authorizationState.CodeLength);
            Assert.AreEqual(AuthorizationCodeType.Unknown, authorizationState.CodeType);
            Assert.IsFalse(authorizationState.HasRecoveryEmailAddress);
            Assert.IsNull(authorizationState.RecoveryEmailAddressPattern);
            Assert.IsFalse(authorizationState.HasPassportData);
            Assert.IsNull(authorizationState.PasswordHint);
            Assert.IsNull(authorizationState.CallerPhoneNumberPrefix);
            Assert.IsNull(authorizationState.CallerPhoneNumberPattern);
        }
        #endregion

        #region Overrided .GetHashCode()
        [TestMethod]
        public void GetHashCode_Empty_ResultrightHash()
        {
            var state = AuthorizationState.Empty();
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitStartupParameters_ResultrightHash()
        {
            var state = AuthorizationState.WaitStartupParameters();
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitPhoneNumber_ResultrightHash()
        {
            var authorizationState = AuthorizationState.WaitPhoneNumber();

            var state = AuthorizationState.WaitPhoneNumber();
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitTelegramMessageCode_ResultrightHash()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;
            var state = AuthorizationState.WaitTelegramMessageCode(phoneNumber, codeLength);
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();
            hash = hash * two + state.PhoneNumber.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitSmsCode_ResultrightHash()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;
            var state = AuthorizationState.WaitSmsCode(phoneNumber, codeLength);
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();
            hash = hash * two + state.PhoneNumber.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitCallCode_ResultrightHash()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;
            var state = AuthorizationState.WaitCallCode(phoneNumber, codeLength);
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();
            hash = hash * two + state.PhoneNumber.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitFlashCall_ResultrightHash()
        {
            string phoneNumber = "Hello world";
            string callerPhoneNumberPattern = "another Hello world";
            var state = AuthorizationState.WaitFlashCall(phoneNumber, callerPhoneNumberPattern);
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();
            hash = hash * two + state.PhoneNumber.GetHashCode();
            hash = hash * two + state.CallerPhoneNumberPattern.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitMissedCall_ResultrightHash()
        {
            string phoneNumber = "Hello world";
            string callerPhoneNumberPrefix = "prefix hello world!";
            int codeLength = 16;
            var state = AuthorizationState.WaitMissedCall(phoneNumber, callerPhoneNumberPrefix, codeLength);
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();
            hash = hash * two + state.PhoneNumber.GetHashCode();
            hash = hash * two + state.CallerPhoneNumberPrefix.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_WaitPassword_ResultrightHash()
        {
            bool hasPassportData = true;
            bool hasRecoveryEmailAddress = true;
            string recoveryEmailAddressPattern = "Hello email";
            string passwordHint = "This is test password hint";
            var state = AuthorizationState.WaitPassword(hasPassportData, hasRecoveryEmailAddress, recoveryEmailAddressPattern, passwordHint);
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();
            hash = hash * two + state.RecoveryEmailAddressPattern.GetHashCode();
            hash = hash * two + state.PasswordHint.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_Ready_ResultrightHash()
        {
            var state = AuthorizationState.Ready();
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_Closing_ResultrightHash()
        {
            var state = AuthorizationState.Closing();
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }

        [TestMethod]
        public void GetHashCode_Closed_ResultrightHash()
        {
            var state = AuthorizationState.Closed();
            int one = 13;
            int two = 17;
            var hash = one;
            hash = hash * two + state.StateType.GetHashCode();
            hash = hash * two + state.CodeType.GetHashCode();
            hash = hash * two + state.HasPassportData.GetHashCode();
            hash = hash * two + state.HasRecoveryEmailAddress.GetHashCode();
            hash = hash * two + state.CodeLength.GetHashCode();

            var result = state.GetHashCode();

            Assert.AreEqual(hash, result);
        }
        #endregion

        #region Overrided .Equals()
        [TestMethod]
        public void Equals_EqualPropertiesSameState_ResultTrue()
        {
            var state_1 = AuthorizationState.WaitStartupParameters();
            var state_2 = AuthorizationState.WaitStartupParameters();

            bool result = state_1.Equals(state_2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_EqualPropertiesDifferentTypes_ResultFalse()
        {
            var state_1 = AuthorizationState.WaitStartupParameters();
            var state_2 = AuthorizationState.Closed();

            bool result = state_1.Equals(state_2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OperatorEquals_EqualPropertiesSameState_ResultTrue()
        {
            var state_1 = AuthorizationState.WaitStartupParameters();
            var state_2 = AuthorizationState.WaitStartupParameters();

            bool result = (state_1 == state_2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OperatorNotEquals_NotEqualPropertiesSameState_ResultTrue()
        {
            var state_1 = AuthorizationState.WaitStartupParameters();
            var state_2 = AuthorizationState.Ready();

            bool result = (state_1 != state_2);

            Assert.IsTrue(result);
        }
        #endregion

        #region Behavior
        [TestMethod]
        public void IsAwaitingCode_Empty_ResultFalse()
        {
            var empty = AuthorizationState.Empty();

            Assert.IsFalse(empty.IsAwaitingCode);
        }

        [TestMethod]
        public void IsAwaitingCode_WaitCode_ResultTrue()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;

            var waitCode = AuthorizationState.WaitSmsCode(phoneNumber, codeLength);

            Assert.IsTrue(waitCode.IsAwaitingCode);
        }

        [TestMethod]
        public void IsAwaitingPassword_Empty_ResultFalse()
        {
            var empty = AuthorizationState.Empty();

            Assert.IsFalse(empty.IsAwaitingPassword);
        }

        [TestMethod]
        public void IsAwaitingPassword_WaitPassword_ResultTrue()
        {
            bool hasPassportData = true;
            bool hasRecoveryEmailAddress = true;
            string recoveryEmailAddressPattern = "Hello email";
            string passwordHint = "This is test password hint";

            var waitPassword = AuthorizationState.WaitPassword(hasPassportData, hasRecoveryEmailAddress, recoveryEmailAddressPattern, passwordHint);

            Assert.IsTrue(waitPassword.IsAwaitingPassword);
        }

        [TestMethod]
        public void IsAwaitingInitialAuthorizationInfo_Empty_ResultFalse()
        {
            var empty = AuthorizationState.Empty();

            Assert.IsFalse(empty.IsAwaitingInitialAuthorizationInfo);
        }

        [TestMethod]
        public void IsAwaitingInitialAuthorizationInfo_WaitPhone_ResultTrue()
        {
            var waitPhone = AuthorizationState.WaitPhoneNumber();

            Assert.IsTrue(waitPhone.IsAwaitingInitialAuthorizationInfo);
        }

        [TestMethod]
        public void IsReady_Empty_ResultFalse()
        {
            var empty = AuthorizationState.Empty();

            Assert.IsFalse(empty.IsReady);
        }

        [TestMethod]
        public void IsReady_Ready_ResultTrue()
        {
            var ready = AuthorizationState.Ready();

            Assert.IsTrue(ready.IsReady);
        }

        [TestMethod]
        public void IsNotReady_Empty_ResultFalse()
        {
            var empty = AuthorizationState.Empty();

            Assert.IsTrue(empty.IsNotReady);
        }

        [TestMethod]
        public void IsNotReady_WaitPhone_ResultFalse()
        {
            var ready = AuthorizationState.Ready();

            Assert.IsFalse(ready.IsNotReady);
        }
        #endregion

        #region ToString()
        [TestMethod]
        public void ToString_Empty_CorrectString()
        {
            const string controlString = "State type : Empty\n" +
                "Phone number : \n" +
                "Code length : 0\n" +
                "Code type : Unknown\n" +
                "Has recovery email address : False\n" +
                "Recovery email address pattern : \n" +
                "Caller phone number prefix : \n" +
                "Caller phone number pattern: \n" +
                "Has passport data : False\n" +
                "Password hint: \n";
            var authorizationState = AuthorizationState.Empty();

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitStartupParameters_CorrectString()
        {
            const string controlString = "State type : WaitStartupParameters\n" +
                "Phone number : \n" +
                "Code length : 0\n" +
                "Code type : Unknown\n" +
                "Has recovery email address : False\n" +
                "Recovery email address pattern : \n" +
                "Caller phone number prefix : \n" +
                "Caller phone number pattern: \n" +
                "Has passport data : False\n" +
                "Password hint: \n";
            var authorizationState = AuthorizationState.WaitStartupParameters();


            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitPhoneNumber_CorrectString()
        {
            const string controlString = "State type : WaitPhoneNumber\n" +
                    "Phone number : \n" +
                    "Code length : 0\n" +
                    "Code type : Unknown\n" +
                    "Has recovery email address : False\n" +
                    "Recovery email address pattern : \n" +
                    "Caller phone number prefix : \n" +
                    "Caller phone number pattern: \n" +
                    "Has passport data : False\n" +
                    "Password hint: \n";
            var authorizationState = AuthorizationState.WaitPhoneNumber();

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitTelegramMessageCode_CorrectString()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;
            const string controlString = "State type : WaitCode\n" +
                    "Phone number : Hello world\n" +
                    "Code length : 16\n" +
                    "Code type : TelegramMessage\n" +
                    "Has recovery email address : False\n" +
                    "Recovery email address pattern : \n" +
                    "Caller phone number prefix : \n" +
                    "Caller phone number pattern: \n" +
                    "Has passport data : False\n" +
                    "Password hint: \n";
            var authorizationState = AuthorizationState.WaitTelegramMessageCode(phoneNumber, codeLength);

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitSmsCode_CorrectString()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;
            const string controlString = "State type : WaitCode\n" +
                        "Phone number : Hello world\n" +
                        "Code length : 16\n" +
                        "Code type : Sms\n" +
                        "Has recovery email address : False\n" +
                        "Recovery email address pattern : \n" +
                        "Caller phone number prefix : \n" +
                        "Caller phone number pattern: \n" +
                        "Has passport data : False\n" +
                        "Password hint: \n";
            var authorizationState = AuthorizationState.WaitSmsCode(phoneNumber, codeLength);

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitCallCode_CorrectString()
        {
            string phoneNumber = "Hello world";
            int codeLength = 16;
            const string controlString = "State type : WaitCode\n" +
                           "Phone number : Hello world\n" +
                           "Code length : 16\n" +
                           "Code type : Call\n" +
                           "Has recovery email address : False\n" +
                           "Recovery email address pattern : \n" +
                           "Caller phone number prefix : \n" +
                           "Caller phone number pattern: \n" +
                           "Has passport data : False\n" +
                           "Password hint: \n";
            var authorizationState = AuthorizationState.WaitCallCode(phoneNumber, codeLength);

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitFlashCall_CorrectString()
        {
            string phoneNumber = "Hello world";
            string callerPhoneNumberPattern = "another Hello world";
            const string controlString = "State type : WaitCode\n" +
                               "Phone number : Hello world\n" +
                               "Code length : 0\n" +
                               "Code type : FlashCall\n" +
                               "Has recovery email address : False\n" +
                               "Recovery email address pattern : \n" +
                               "Caller phone number prefix : \n" +
                               "Caller phone number pattern: another Hello world\n" +
                               "Has passport data : False\n" +
                               "Password hint: \n";
            var authorizationState = AuthorizationState.WaitFlashCall(phoneNumber, callerPhoneNumberPattern);

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitMissedCall_CorrectString()
        {
            string phoneNumber = "Hello world";
            string callerPhoneNumberPrefix = "prefix hello world!";
            int codeLength = 16;
            const string controlString = "State type : WaitCode\n" +
                                   "Phone number : Hello world\n" +
                                   "Code length : 16\n" +
                                   "Code type : MissedCall\n" +
                                   "Has recovery email address : False\n" +
                                   "Recovery email address pattern : \n" +
                                   "Caller phone number prefix : prefix hello world!\n" +
                                   "Caller phone number pattern: \n" +
                                   "Has passport data : False\n" +
                                   "Password hint: \n";
            var authorizationState = AuthorizationState.WaitMissedCall(phoneNumber, callerPhoneNumberPrefix, codeLength);

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_WaitPassword_CorrectString()
        {
            bool hasPassportData = true;
            bool hasRecoveryEmailAddress = true;
            string recoveryEmailAddressPattern = "Hello email";
            string passwordHint = "This is test password hint";
            const string controlString = "State type : WaitPassword\n" +
                        "Phone number : \n" +
                        "Code length : 0\n" +
                        "Code type : Unknown\n" +
                        "Has recovery email address : True\n" +
                        "Recovery email address pattern : Hello email\n" +
                        "Caller phone number prefix : \n" +
                        "Caller phone number pattern: \n" +
                        "Has passport data : True\n" +
                        "Password hint: This is test password hint\n";
            var authorizationState = AuthorizationState.WaitPassword(hasPassportData, hasRecoveryEmailAddress, recoveryEmailAddressPattern, passwordHint);

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_Ready_CorrectString()
        {
            const string controlString = "State type : Ready\n" +
                    "Phone number : \n" +
                    "Code length : 0\n" +
                    "Code type : Unknown\n" +
                    "Has recovery email address : False\n" +
                    "Recovery email address pattern : \n" +
                    "Caller phone number prefix : \n" +
                    "Caller phone number pattern: \n" +
                    "Has passport data : False\n" +
                    "Password hint: \n";
            var authorizationState = AuthorizationState.Ready();

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_Closing_CorrectString()
        {
            const string controlString = "State type : Closing\n" +
                    "Phone number : \n" +
                    "Code length : 0\n" +
                    "Code type : Unknown\n" +
                    "Has recovery email address : False\n" +
                    "Recovery email address pattern : \n" +
                    "Caller phone number prefix : \n" +
                    "Caller phone number pattern: \n" +
                    "Has passport data : False\n" +
                    "Password hint: \n";
            var authorizationState = AuthorizationState.Closing();

            Assert.AreEqual(controlString, authorizationState.ToString());
        }

        [TestMethod]
        public void ToString_Closed_CorrectString()
        {
            const string controlString = "State type : Closed\n" +
                    "Phone number : \n" +
                    "Code length : 0\n" +
                    "Code type : Unknown\n" +
                    "Has recovery email address : False\n" +
                    "Recovery email address pattern : \n" +
                    "Caller phone number prefix : \n" +
                    "Caller phone number pattern: \n" +
                    "Has passport data : False\n" +
                    "Password hint: \n";
            var authorizationState = AuthorizationState.Closed();

            Assert.AreEqual(controlString, authorizationState.ToString());
        }
        #endregion
    }
}
