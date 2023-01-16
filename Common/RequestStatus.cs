namespace Common
{
    /// <summary>
    /// Cтатус реквеста, обработан он или нет.
    /// </summary>
    public enum RequestStatus
    {
        Success,
        Failed,
        Forbidden,
        Error
    }
}