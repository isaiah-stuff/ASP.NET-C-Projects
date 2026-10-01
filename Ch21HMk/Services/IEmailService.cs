namespace Ch21HMk.Services;
public interface IEmailService
{

    Task SendEmail(string strTo, string strFrom,string strCC, string strBCC, string strSubject, string strTextFormat, string strMessage);

}