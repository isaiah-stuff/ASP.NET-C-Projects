namespace Stuffle.Isaiah.Exam2.Services;
    public interface IEmailService
    {
    Task SendEmail(string strTo, string strFrom, string strSubject, string strMessage);

}
