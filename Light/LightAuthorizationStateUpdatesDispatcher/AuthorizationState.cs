namespace Light.LightAuthorizationStateUpdatesDispatcher
{
    public struct AuthorizationState
    {
        private const int hashStart = 13;
        private const int hashMult = 17;

        private AuthorizationState(
            AuthorizationStateType stateType = AuthorizationStateType.Empty,
            string phoneNumber = null,
            int codeLength = 0,
            AuthorizationCodeType codeType = AuthorizationCodeType.Unknown,
            string callerPhoneNumberPattern = null,
            string callerPhoneNumberPrefix = null,
            bool hasRecoveryEmailAddress = false,
            string recoveryEmailAddressPattern = null,
            bool hasPassportData = false,
            string passwordHint = null)
        {
            StateType = stateType;
            PhoneNumber = phoneNumber;
            CodeLength = codeLength;
            CodeType = codeType;
            HasRecoveryEmailAddress = hasRecoveryEmailAddress;
            RecoveryEmailAddressPattern = recoveryEmailAddressPattern;
            CallerPhoneNumberPrefix = callerPhoneNumberPrefix;
            CallerPhoneNumberPattern = callerPhoneNumberPattern;
            HasPassportData = hasPassportData;
            PasswordHint = passwordHint;
        }

        public AuthorizationStateType StateType { get; }
        public string PhoneNumber { get; }
        public int CodeLength { get; }
        public AuthorizationCodeType CodeType { get; }
        public string CallerPhoneNumberPattern { get; }
        public string CallerPhoneNumberPrefix { get; }
        public bool HasRecoveryEmailAddress { get; }
        public string RecoveryEmailAddressPattern { get; }
        public bool HasPassportData { get; }
        public string PasswordHint { get; }

        public bool IsNotReady => StateType != AuthorizationStateType.Ready;
        public bool IsAwaitingInitialAuthorizationInfo => StateType == AuthorizationStateType.WaitPhoneNumber;//|| StateType == AuthorizationStateType.WaitEmailAddress;
        public bool IsAwaitingCode => StateType == AuthorizationStateType.WaitCode;
        public bool IsAwaitingPassword => StateType == AuthorizationStateType.WaitPassword;
        public bool IsReady => StateType == AuthorizationStateType.Ready;

        public static AuthorizationState Empty()
        {
            return new AuthorizationState();
        }

        public static AuthorizationState WaitStartupParameters()
        {
            return new AuthorizationState(stateType: AuthorizationStateType.WaitStartupParameters);
        }

        public static AuthorizationState WaitPhoneNumber()
        {
            return new AuthorizationState(stateType: AuthorizationStateType.WaitPhoneNumber);
        }

        public static AuthorizationState WaitTelegramMessageCode(string phoneNumber, int codeLength)
        {
            return new AuthorizationState(
                stateType: AuthorizationStateType.WaitCode,
                phoneNumber: phoneNumber,
                codeLength: codeLength,
                codeType: AuthorizationCodeType.TelegramMessage);
        }

        public static AuthorizationState WaitSmsCode(string phoneNumber, int codeLength)
        {
            return new AuthorizationState(
                stateType: AuthorizationStateType.WaitCode,
                phoneNumber: phoneNumber,
                codeLength: codeLength,
                codeType: AuthorizationCodeType.Sms);
        }

        public static AuthorizationState WaitCallCode(string phoneNumber, int codeLength)
        {
            return new AuthorizationState(
                stateType: AuthorizationStateType.WaitCode,
                phoneNumber: phoneNumber,
                codeLength: codeLength,
                codeType: AuthorizationCodeType.Call);
        }

        public static AuthorizationState WaitFlashCall(string phoneNumber, string callerPhoneNumberPattern)
        {
            return new AuthorizationState(
                stateType: AuthorizationStateType.WaitCode,
                phoneNumber: phoneNumber,
                codeType: AuthorizationCodeType.FlashCall,
                callerPhoneNumberPattern: callerPhoneNumberPattern);
        }

        public static AuthorizationState WaitMissedCall(
            string phoneNumber,
            string callerPhoneNumberPrefix,
            int codeLength)
        {
            return new AuthorizationState(
                stateType: AuthorizationStateType.WaitCode,
                phoneNumber: phoneNumber,
                codeLength: codeLength,
                codeType: AuthorizationCodeType.MissedCall,
                callerPhoneNumberPrefix: callerPhoneNumberPrefix);
        }

        public static AuthorizationState WaitPassword(
            bool hasPassportData,
            bool hasRecoveryEmailAddress,
            string recoveryEmailAddressPattern,
            string passwordHint)
        {
            return new AuthorizationState(
                stateType: AuthorizationStateType.WaitPassword,
                hasRecoveryEmailAddress: hasRecoveryEmailAddress,
                recoveryEmailAddressPattern: recoveryEmailAddressPattern,
                hasPassportData: hasPassportData,
                passwordHint: passwordHint);
        }

        public static AuthorizationState Ready()
        {
            return new AuthorizationState(stateType: AuthorizationStateType.Ready);
        }

        public static AuthorizationState Closing()
        {
            return new AuthorizationState(stateType: AuthorizationStateType.Closing);
        }

        public static AuthorizationState Closed()
        {
            return new AuthorizationState(stateType: AuthorizationStateType.Closed);
        }

        public override bool Equals(object obj) =>
        obj is AuthorizationState anotherState && EqualsDetails(anotherState);

        private bool EqualsDetails(AuthorizationState anotherState) =>
            StateType == anotherState.StateType &&
            CodeType == anotherState.CodeType &&
            HasPassportData == anotherState.HasPassportData &&
            HasRecoveryEmailAddress == anotherState.HasRecoveryEmailAddress &&
            CodeLength == anotherState.CodeLength &&
            PhoneNumber == anotherState.PhoneNumber &&
            RecoveryEmailAddressPattern == anotherState.RecoveryEmailAddressPattern &&
            CallerPhoneNumberPrefix == anotherState.CallerPhoneNumberPrefix &&
            CallerPhoneNumberPattern == anotherState.CallerPhoneNumberPattern &&
            PasswordHint == anotherState.PasswordHint;

        public static bool operator ==(AuthorizationState firstState, AuthorizationState secondState) => firstState.Equals(secondState);
        public static bool operator !=(AuthorizationState firstState, AuthorizationState secondState) => !firstState.Equals(secondState);

        public override int GetHashCode()
        {
            int hashCode = hashStart;

            hashCode = hashCode * hashMult + StateType.GetHashCode();
            hashCode = hashCode * hashMult + CodeType.GetHashCode();
            hashCode = hashCode * hashMult + HasPassportData.GetHashCode();
            hashCode = hashCode * hashMult + HasRecoveryEmailAddress.GetHashCode();
            hashCode = hashCode * hashMult + CodeLength.GetHashCode();

            if (PhoneNumber != null)
            {
                hashCode = hashCode * hashMult + PhoneNumber.GetHashCode();
            }

            if (RecoveryEmailAddressPattern != null)
            {
                hashCode = hashCode * hashMult + RecoveryEmailAddressPattern.GetHashCode();
            }

            if (CallerPhoneNumberPrefix != null)
            {
                hashCode = hashCode * hashMult + CallerPhoneNumberPrefix.GetHashCode();
            }

            if (CallerPhoneNumberPattern != null)
            {
                hashCode = hashCode * hashMult + CallerPhoneNumberPattern.GetHashCode();
            }

            if (PasswordHint != null)
            {
                hashCode = hashCode * hashMult + PasswordHint.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString() => string.Format(
                "State type : {0}\n" +
                "Phone number : {1}\n" +
                "Code length : {2}\n" +
                "Code type : {3}\n" +
                "Has recovery email address : {4}\n" +
                "Recovery email address pattern : {5}\n" +
                "Caller phone number prefix : {6}\n" +
                "Caller phone number pattern: {7}\n" +
                "Has passport data : {8}\n" +
                "Password hint: {9}\n",
                StateType,
                PhoneNumber is null ? string.Empty : PhoneNumber,
                CodeLength,
                CodeType,
                HasRecoveryEmailAddress,
                RecoveryEmailAddressPattern is null ? string.Empty : RecoveryEmailAddressPattern,
                CallerPhoneNumberPrefix is null ? string.Empty : CallerPhoneNumberPrefix,
                CallerPhoneNumberPattern is null ? string.Empty : CallerPhoneNumberPattern,
                HasPassportData,
                PasswordHint is null ? string.Empty : PasswordHint);

    }

    public enum AuthorizationStateType//после того как заработает как нужно-добавить закомментированное
    {
        Empty,
        WaitStartupParameters,
        WaitPhoneNumber,
        //WaitEmailAddress,
        //WaitEmailCode,//мб перенести в тип кода
        WaitCode,
        //WaitOtherDeviceConfirmation,
        //WaitRegistration,
        WaitPassword,
        Ready,
        Closing,
        Closed//после этого нада пересоздать клиент телеги
    };

    public enum AuthorizationCodeType
    {
        Unknown,
        TelegramMessage,
        Sms,
        Call,
        FlashCall,
        MissedCall,
        Email
    }
}
