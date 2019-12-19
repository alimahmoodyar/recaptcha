using Newtonsoft.Json;
using System;
using System.Net;

/// <summary>
/// Check reCaptcha v3 Status and Score
/// </summary>
public class GoogleReCaptchaResponse
{
    public bool success { set;  get; }
    public string challenge_ts { set; get; }
    public string hostname { set; get; }
    public string error_codes { set; get; }
    public string score { set; get; }


}
public class reCaptcha
{
	public static string Check(string g_recaptcha_response, ref bool status, ref double score)
	{
        try
        {
            string secret = "your_secret_key";
            string URI = "https://www.google.com/recaptcha/api/siteverify?secret=" + secret + "&response=" + g_recaptcha_response;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, "");
                GoogleReCaptchaResponse G = JsonConvert.DeserializeObject<GoogleReCaptchaResponse>(HtmlResult);
                if (G.success.ToString().ToLower() == "true")
                {
                    status = true;
                    score = Convert.ToDouble(G.score.ToString());
                }
                else
                {
                    status = false;
                    score = 0;
                }
                return "";
            }
        }
        catch (Exception e)
        {
            return e.Message.ToString();
        }
	}
}
