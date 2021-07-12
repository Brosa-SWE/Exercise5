namespace Exercise5
{
    interface IUI
    {
        int GetUserInputInt(int minimumValue, int maximumValue);
        int GetUserInputInt(string customPrompt, bool clearScreenBetweenTries, int minimumValue, int maximumValue);
        string GetUserInputString();
        string GetUserInputString(string customPrompt, bool clearScreenBetweenTries);
        void Write(string messageToWrite);
    }
}